using DatabaseSeed.Data;
using DatabaseSeed.Dto;
using DatabaseSeed.Models.Test;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DatabaseSeed.Services;

public class TestsService
{
    private readonly DataContext _dataContext;

    public TestsService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CreateTest(ICollection<TextChoiceQuestionApiResponseDto> questionsWrappers, string tag)
    {
        var test = MapTest(questionsWrappers, tag);

        _dataContext.Add(test);

        await _dataContext.SaveChangesAsync();
        
        Console.WriteLine("DB_CONTEXT::Test created successfully");
    }

    private Test MapTest(ICollection<TextChoiceQuestionApiResponseDto> questionsWrappers, string tag)
    {
        var difficultyCounts = questionsWrappers
            .GroupBy(q => q.Difficulty)
            .ToDictionary(g => g.Key, g => g.Count());
        
        // Get the difficulty with the highest count
        var majorityDifficulty = difficultyCounts
            .OrderByDescending(kv => kv.Value)
            .FirstOrDefault().Key;
        
        return new Test
        {
            Name = tag,
            Subject = tag,
            Duration = questionsWrappers.Count * 1,
            IsPublished = true,
            TemplateId = null,
            QuestionsPools = MapQuestionsPools(questionsWrappers),
            Difficulty = Enum.Parse<TestDifficulty>(majorityDifficulty, true),
            CreatedTimestamp = DateTime.Now
        };
    }

    private ICollection<QuestionsPool> MapQuestionsPools(ICollection<TextChoiceQuestionApiResponseDto> questionsWrappers)
    {
        var easyQuestions = new List<Question>();
        var mediumQuestions = new List<Question>();
        var hardQuestions = new List<Question>();
        
        foreach (var textChoiceQuestionResponseDto in questionsWrappers)
        {
            switch (textChoiceQuestionResponseDto.Difficulty)
            {
                case "easy":
                    easyQuestions.Add(MapQuestion(textChoiceQuestionResponseDto));
                    break;
                case "medium": 
                    mediumQuestions.Add(MapQuestion(textChoiceQuestionResponseDto));
                    break;
                case "hard": 
                    hardQuestions.Add(MapQuestion(textChoiceQuestionResponseDto));
                    break;
            }
        }

        var questionsPools = new List<QuestionsPool>();
        if (easyQuestions.Count > 0)
        {
            questionsPools.Add(new QuestionsPool
            {
                Name = "easy questions",
                NumOfQuestionsToBeGenerated = easyQuestions.Count,
                GenerationStrategy = GenerationStrategy.Randomly,
                Questions = easyQuestions
            });
        }
        
        if (mediumQuestions.Count > 0)
        {
            questionsPools.Add(new QuestionsPool
            {
                Name = "medium questions",
                NumOfQuestionsToBeGenerated = mediumQuestions.Count,
                GenerationStrategy = GenerationStrategy.Randomly,
                Questions = mediumQuestions
            });
        }
        
        if (hardQuestions.Count > 0)
        {
            questionsPools.Add(new QuestionsPool
            {
                Name = "hard questions",
                NumOfQuestionsToBeGenerated = hardQuestions.Count,
                GenerationStrategy = GenerationStrategy.Randomly,
                Questions = hardQuestions
            });
        }

        return questionsPools;
    }

    private Question MapQuestion(TextChoiceQuestionApiResponseDto questionApiResponseDto)
    {
        return new Question
        {
            Text = questionApiResponseDto.Question.Text,
            MaxScore = 1,
            TemplateId = null,
            Answers = MapAnswers(questionApiResponseDto)
        };
    }

    private ICollection<Answer> MapAnswers(TextChoiceQuestionApiResponseDto questionApiResponseDto)
    {
        var answers = new List<Answer>();
        answers.AddRange(
            questionApiResponseDto.IncorrectAnswers.Select(
                a => new Answer
                {
                    Text = a,
                    IsCorrect = false,
                    TemplateId = null
                }
            )
        );
        answers.Add(
            new Answer
            {
                Text = questionApiResponseDto.CorrectAnswer,
                IsCorrect = true,
                TemplateId = null
            }
        );
        
        return ShuffleArray(answers);
    }
    
    private static ICollection<T> ShuffleArray<T>(IList<T> array)
    {
        var rng = new Random();
        var n = array.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (array[k], array[n]) = (array[n], array[k]);
        }

        return array;
    }
}
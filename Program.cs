using DatabaseSeed.Data;
using DatabaseSeed.Services;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

var dbConnectionString =
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestingPlatformDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
    "Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=True";

optionsBuilder.UseSqlServer(dbConnectionString);
await using var dataContext = new DataContext(optionsBuilder.Options);

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://the-trivia-api.com/v2/");

var questionsService = new QuestionsApiService(httpClient);
var testsService = new TestsService(dataContext);

var tags = (await questionsService.GetAllTags()).Select(tag => tag.Trim()).Distinct();

foreach (var tag in tags)
{
    var questions = await questionsService.GetAllQuestionByTag(tag);
    
    if (questions.Count >= 2)
    {
        await testsService.CreateTest(questions, tag);
    }
    
    await Task.Delay(100);
}
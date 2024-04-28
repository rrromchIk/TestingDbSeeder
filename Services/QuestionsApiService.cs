using System.Text.Json;
using DatabaseSeed.Dto;

namespace DatabaseSeed.Services;

public class QuestionsApiService
{
    private readonly HttpClient _httpClient;
    private const string TAGS_ENDPOINT = "tags";
    private const string QUESTIONS_ENDPOINT = "questions";
    private const string LIMIT_PARAM = "limit=50";
    private const string TAGS_PARAM = "tags=";

    public QuestionsApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ICollection<string>> GetAllTags()
    {
        var url = _httpClient.BaseAddress + TAGS_ENDPOINT;
        Console.WriteLine($"GET::{url}");
        var response = await _httpClient.GetAsync(url);
        Console.WriteLine($"GET::{url}. Status code: {response.StatusCode}");
        var tags = await HandleHttpResponse<ICollection<string>>(response);
        return tags;
    }

    public async Task<ICollection<TextChoiceQuestionApiResponseDto>> GetAllQuestionByTag(string tag)
    {
        var url = _httpClient.BaseAddress + QUESTIONS_ENDPOINT + $"?{TAGS_PARAM}" + tag.Trim() + $"&{LIMIT_PARAM}";
        Console.WriteLine($"GET::{url}");
        var response = await _httpClient.GetAsync(url);
        Console.WriteLine($"GET::{url}. Status code: {response.StatusCode}");
        var textChoiceQuestions = await HandleHttpResponse<ICollection<TextChoiceQuestionApiResponseDto>>(response);
        Console.WriteLine($"GET::{url}. Questions fetched: {textChoiceQuestions.Count}");
        return textChoiceQuestions;
    }
    
    
    private static async Task<T> HandleHttpResponse<T>(HttpResponseMessage httpResponse)
    {
        await using var stream = await httpResponse.Content.ReadAsStreamAsync();
        var apiResponseDto = await JsonSerializer.DeserializeAsync<T>(
            stream,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        return apiResponseDto;
    }
}
using ExamModul3.Api.Entities;
using System.Text.Json;

namespace ExamModul3.Api.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly string FilePath;
    public QuestionRepository()
    {
        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Questions.json");
        var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (!File.Exists(FilePath))
        {
            var stream = File.Create(FilePath);
            stream.Close();
        }
    }

    public List<Question>? GetAllQuestion()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            return new List<Question>();
        }

        var questions = JsonSerializer.Deserialize<List<Question>>(json);
        return questions;
    }

    public void SaveAllQuestions(List<Question> questions)
    {
        var json = JsonSerializer.Serialize(questions);
        File.WriteAllText(FilePath, json);
    }
}

using ExamModul3.Api.Entities;

namespace ExamModul3.Api.Repositories;

public interface IQuestionRepository
{
    public List<Question>? GetAllQuestion();
    public void SaveAllQuestions(List<Question> questions);
}
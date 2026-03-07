using ExamModul3.Api.Dtos;

namespace ExamModul3.Api.Services;

public interface IQuestionService
{
    public int GetCountOfQuestions();
    public QuestionGetDto GetRandomQuestion();
    public Guid AddQuestion(QuestionCreateDto questionCreateDto);
    public bool DeleteQuestion(Guid questionId);
    public bool UpgradeQuestion(Guid questionId, QuestionCreateDto questionCreateDto);
}
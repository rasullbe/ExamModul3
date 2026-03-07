using ExamModul3.Api.Dtos;
using ExamModul3.Api.Entities;
using ExamModul3.Api.Repositories;

namespace ExamModul3.Api.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository PostRepository;
    public PostService()
    {
        QuestionRepository = new UserRepository();
    }
    public Guid AddQuestion(QuestionCreateDto questionCreateDto)
    {
        var question = new Question()
        {
            QuestionId = Guid.NewGuid(),
            Text = questionCreateDto.Text,
            VariantA = questionCreateDto.VariantA,
            VariantB = questionCreateDto.VariantB,
            VariantC = questionCreateDto.VariantC,
            Answer = questionCreateDto.Answer
        };
    }

    public bool DeleteQuestion(Guid questionId)
    {
        var questions = QuestionRepository.GetAllQuestion();
        foreach (var question in questions)
        {
            if (question.QuestionId == questionId)
            {
                questions.Remove(question);
                QuestionRepository.SaveAllQuestions(questions);
                return true;
            }
        }
        return false;
    }

    public int GetCountOfQuestions()
    {
        throw new NotImplementedException();
    }

    public QuestionGetDto GetRandomQuestion()
    {
        throw new NotImplementedException();
    }

    public bool UpgradeQuestion(Guid questionId, QuestionCreateDto questionCreateDto)
    {
        throw new NotImplementedException();
    }
}

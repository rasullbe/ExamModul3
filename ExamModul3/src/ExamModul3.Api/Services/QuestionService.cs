using ExamModul3.Api.Dtos;
using ExamModul3.Api.Entities;
using ExamModul3.Api.Repositories;

namespace ExamModul3.Api.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
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

        var questions = _questionRepository.GetAllQuestion() ?? new List<Question>();
        questions.Add(question);
        _questionRepository.SaveAllQuestions(questions);

        return question.QuestionId;
    }

    public bool DeleteQuestion(Guid questionId)
    {
        var questions = _questionRepository.GetAllQuestion();
        var questionToRemove = questions?.FirstOrDefault(q => q.QuestionId == questionId);

        if (questionToRemove != null)
        {
            questions.Remove(questionToRemove);
            _questionRepository.SaveAllQuestions(questions);
            return true;
        }
        return false;
    }

    public int GetCountOfQuestions()
    {
        var questions = _questionRepository.GetAllQuestion();
        return questions?.Count ?? 0;
    }

    public QuestionGetDto GetRandomQuestion()
    {
        var questions = _questionRepository.GetAllQuestion();
        if (questions == null || questions.Count == 0)
            return null;

        var random = new Random();
        var randomQuestion = questions[random.Next(questions.Count)];

        return new QuestionGetDto
        {
            QuestionId = randomQuestion.QuestionId,
            Text = randomQuestion.Text,
            VariantA = randomQuestion.VariantA,
            VariantB = randomQuestion.VariantB,
            VariantC = randomQuestion.VariantC
        };
    }

    public bool UpgradeQuestion(Guid questionId, QuestionCreateDto questionCreateDto)
    {
        var questions = _questionRepository.GetAllQuestion();
        var question = questions?.FirstOrDefault(q => q.QuestionId == questionId);

        if (question != null)
        {
            question.Text = questionCreateDto.Text;
            question.VariantA = questionCreateDto.VariantA;
            question.VariantB = questionCreateDto.VariantB;
            question.VariantC = questionCreateDto.VariantC;
            question.Answer = questionCreateDto.Answer;

            _questionRepository.SaveAllQuestions(questions);
            return true;
        }
        return false;
    }
}

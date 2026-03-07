using ExamModul3.Api.Dtos;
using ExamModul3.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamModul3.Api.Controllers;

[Route("api/qiestions")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService PostService;
    public QuestionController()
    {
        QuestionService = new QuestionService();
    }

    [HttpPost("add")]
    public Guid Create(QuestionCreateDto postCreateDto, string token)
    {
        return QuestionService.AddQuestion(postCreateDto);
    }

    
}

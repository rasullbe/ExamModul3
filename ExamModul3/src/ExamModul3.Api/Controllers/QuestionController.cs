using ExamModul3.Api.Dtos;
using ExamModul3.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamModul3.Api.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;
    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost("add")]
    public Guid Create(QuestionCreateDto postCreateDto, string token)
    {
        return _questionService.AddQuestion(postCreateDto);
    }

    
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagementApi.Application.UseCases.Tasks.GetAll;
using TasksManagementApi.Application.UseCases.Tasks.Register;
using TasksManagementApi.Communication.Requests;
using TasksManagementApi.Communication.Responses;

namespace TasksManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly GetAllTasksUseCase _getAllTasksUseCase;
    private readonly RegisterTaskUseCase _registerTaksUseCase;

    public TasksController(
        GetAllTasksUseCase getAllTasksUseCase,
        RegisterTaskUseCase registerTaksUseCase
    )
    {
        _getAllTasksUseCase = getAllTasksUseCase;
        _registerTaksUseCase = registerTaksUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get()
    {
        var response = _getAllTasksUseCase.Execute();

        if (response.Tasks.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTaskJson), StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterTaskJson request) 
    {
        var response = _registerTaksUseCase.Execute(request);

        return Created(string.Empty, response);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagementApi.Application.UseCases.Tasks.GetAll;
using TasksManagementApi.Communication.Responses;

namespace TasksManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly GetAllTasksUseCase _getAllTasksUseCase;

    public TasksController(GetAllTasksUseCase getAllTasksUseCase)
    {
        _getAllTasksUseCase = getAllTasksUseCase;
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
}

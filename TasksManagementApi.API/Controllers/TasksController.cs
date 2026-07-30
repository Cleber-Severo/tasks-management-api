using Microsoft.AspNetCore.Mvc;
using TasksManagementApi.Application.UseCases.Tasks.Delete;
using TasksManagementApi.Application.UseCases.Tasks.GetAll;
using TasksManagementApi.Application.UseCases.Tasks.GetById;
using TasksManagementApi.Application.UseCases.Tasks.Register;
using TasksManagementApi.Application.UseCases.Tasks.Update;
using TasksManagementApi.Communication.Requests;
using TasksManagementApi.Communication.Responses;

namespace TasksManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly GetAllTasksUseCase _getAllTasksUseCase;
    private readonly RegisterTaskUseCase _registerTaksUseCase;
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase;
    private readonly UpdateTaskUsecase _updateTaskUsecase;
    private readonly DeleteTaskUseCase _deleteTaskUseCase;

    public TasksController(
        GetAllTasksUseCase getAllTasksUseCase,
        RegisterTaskUseCase registerTaksUseCase,
        GetTaskByIdUseCase getTaskByIdUseCase,
        UpdateTaskUsecase updateTaskUsecase,
        DeleteTaskUseCase deleteTaskUseCase
    )
    {
        _getAllTasksUseCase = getAllTasksUseCase;
        _getTaskByIdUseCase = getTaskByIdUseCase;
        _registerTaksUseCase = registerTaksUseCase;
        _updateTaskUsecase = updateTaskUsecase;
        _deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTaskJson request) 
    {
        var response = _registerTaksUseCase.Execute(request);

        return Created(string.Empty, response);
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

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid id)
    {
        var response = _getTaskByIdUseCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateTaskJson request)
    {
        _updateTaskUsecase.Execute(request ,id);

        return Ok("Tarefa atualizada com sucesso.");
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _deleteTaskUseCase.Execute(id);

        return Ok("Tarefa removida com sucesso.");
    }

}

using TasksManagementApi.Communication.Entities;
using TasksManagementApi.Communication.Requests;
using TasksManagementApi.Communication.Responses;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public RegisterTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public ResponseShortTaskJson Execute(RequestRegisterTaskJson request)
    {
        var entity = new TaskEntity
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority,
        };
            
        _taskRepository.Add(entity);

        return new ResponseShortTaskJson { Id = entity.Id, Name = entity.Name };
    }
}

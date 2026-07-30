using TasksManagementApi.Communication.Responses;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.GetById;

public class GetTaskByIdUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public ResponseTaskJson Execute(Guid id)
    { 
        var task = _taskRepository.GetById(id);

        return new ResponseTaskJson
        { 
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            Priority = task.Priority
        };
    }

}

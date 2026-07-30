using TasksManagementApi.Communication.Responses;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public ResponseAllTasksJson Execute() { 
        var tasksList = _taskRepository.GetAll().ToList();
        
        return new ResponseAllTasksJson
        {
            Tasks = tasksList.Select(task => new ResponseTaskJson
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status
            }).ToList()
        };
    }
}

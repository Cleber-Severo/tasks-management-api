using TasksManagementApi.Communication.Entities;
using TasksManagementApi.Communication.Requests;
using TasksManagementApi.Communication.Responses;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.Register;

public class UpdateTaskUsecase
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskUsecase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(RequestUpdateTaskJson request, Guid id)
    {
            
        _taskRepository.Update(request, id);

    }
}

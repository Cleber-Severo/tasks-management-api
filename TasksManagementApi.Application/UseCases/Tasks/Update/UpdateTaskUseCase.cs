using TasksManagementApi.Communication.Requests;
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

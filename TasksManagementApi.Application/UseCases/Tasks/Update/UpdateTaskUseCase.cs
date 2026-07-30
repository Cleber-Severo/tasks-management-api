using TasksManagementApi.Communication.Exceptions;
using TasksManagementApi.Communication.Requests;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.Update;

public class UpdateTaskUsecase
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskUsecase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(RequestUpdateTaskJson request, Guid id)
    {
        var task = _taskRepository.GetById(id);

        if (task is null)
            throw new NotFoundException("Tarefa não encontrada");

        _taskRepository.Update(request, id);

    }
}

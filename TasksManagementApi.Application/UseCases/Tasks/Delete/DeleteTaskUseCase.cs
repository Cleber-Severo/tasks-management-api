using TasksManagementApi.Communication.Exceptions;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.Delete;

public class DeleteTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(Guid id)
    {
        var task = _taskRepository.GetById(id);

        if (task is null)
            throw new NotFoundException("Tarefa não encontrada");

        _taskRepository.Delete(id);
    }
}

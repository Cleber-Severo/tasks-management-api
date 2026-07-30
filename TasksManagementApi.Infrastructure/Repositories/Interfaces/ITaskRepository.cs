using TasksManagementApi.Communication.Entities;
namespace TasksManagementApi.Infrastructure.Repositories.Interfaces;

public interface ITaskRepository
{
    IReadOnlyCollection<TaskEntity> GetAll();
    TaskEntity GetById(Guid id);
    void Add(TaskEntity task);
}

using TasksManagementApi.Communication.Entities;
using TasksManagementApi.Communication.Requests;
namespace TasksManagementApi.Infrastructure.Repositories.Interfaces;

public interface ITaskRepository
{
    IReadOnlyCollection<TaskEntity> GetAll();
    TaskEntity? GetById(Guid id);
    void Add(TaskEntity task);
    void Update(RequestUpdateTaskJson task, Guid id);
}

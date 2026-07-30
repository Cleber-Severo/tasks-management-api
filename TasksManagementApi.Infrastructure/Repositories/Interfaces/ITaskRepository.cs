using TasksManagementApi.Communication.Entities;
namespace TasksManagementApi.Infrastructure.Repositories.Interfaces;

public interface ITaskRepository
{
    IReadOnlyCollection<TaskEntity> GetAll();
}

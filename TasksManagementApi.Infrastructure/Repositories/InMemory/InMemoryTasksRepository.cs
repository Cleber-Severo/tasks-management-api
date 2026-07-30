using TasksManagementApi.Communication.Entities;
using TasksManagementApi.Communication.Enums;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Infrastructure.Repositories.InMemory;

public class InMemoryTasksRepository : ITaskRepository
{
    private readonly List<TaskEntity> _tasks = [
         new()
        {
            Name = "Implement Login",
            Description = "Create the user authentication flow using JWT.",
            Priority = PriorityType.High,
            DueDate = DateTime.Now.AddDays(2),
            Status = StatusType.InProgress
        },
        new()
        {
            Name = "Write Unit Tests",
            Description = "Cover the TaskService with unit tests.",
            Priority = PriorityType.Medium,
            DueDate = DateTime.Now.AddDays(5),
            Status = StatusType.Pending
        },
        new()
        {
            Name = "Update Documentation",
            Description = "Add API endpoints to the README file.",
            Priority = PriorityType.Low,
            DueDate = DateTime.Now.AddDays(7),
            Status = StatusType.Pending
        },
        new()
        {
            Name = "Fix Validation Bug",
            Description = "Prevent tasks from being created with an empty name.",
            Priority = PriorityType.High,
            DueDate = DateTime.Now.AddDays(1),
            Status = StatusType.Completed
        }
    ];

    public void Add(TaskEntity task)
    {
       _tasks.Add(task);
    }

    public List<TaskEntity> GetAll() => _tasks;

    IReadOnlyCollection<TaskEntity> ITaskRepository.GetAll()
    {
        return GetAll();
    }
}

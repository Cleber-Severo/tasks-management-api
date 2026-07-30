using TasksManagementApi.Communication.Entities;
using TasksManagementApi.Communication.Enums;
using TasksManagementApi.Communication.Requests;
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

    public void Update(RequestUpdateTaskJson request, Guid id)
    {
        var task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task is null) return;

        task.Name = request.Name;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.Status = request.Status;
        task.Priority = request.Priority;
    }

    public List<TaskEntity> GetAll() => _tasks;

    public TaskEntity? GetById(Guid id)
        => _tasks.FirstOrDefault(task => task.Id == id);

    IReadOnlyCollection<TaskEntity> ITaskRepository.GetAll()
    {
        return GetAll();
    }
}

using TasksManagementApi.Communication.Enums;

namespace TasksManagementApi.Communication.Entities;

public class TaskEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityType Priority { get; set; }
    public DateTime DueDate { get; set; }
    public StatusType Status { get; set; }
}

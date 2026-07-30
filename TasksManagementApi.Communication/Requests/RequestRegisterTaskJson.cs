using TasksManagementApi.Communication.Enums;

namespace TasksManagementApi.Communication.Requests;

public class RequestRegisterTaskJson
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityType Priority { get; set; }
    public DateTime DueDate { get; set; }
}

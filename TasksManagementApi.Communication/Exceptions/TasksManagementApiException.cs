using System.Net;

namespace TasksManagementApi.Communication.Exceptions;

public abstract class TasksManagementApiException : SystemException
{
    public TasksManagementApiException(string ErrorMessage) : base(ErrorMessage)
    {
    }

    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatuscode();
}

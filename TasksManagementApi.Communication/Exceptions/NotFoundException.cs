using System.Net;

namespace TasksManagementApi.Communication.Exceptions;

public class NotFoundException : TasksManagementApiException
{
    public NotFoundException(string ErrorMessage) : base(ErrorMessage)
    {
    }

    public override List<string> GetErrors() => [Message];
    public override HttpStatusCode GetHttpStatuscode() => HttpStatusCode.NotFound;
}

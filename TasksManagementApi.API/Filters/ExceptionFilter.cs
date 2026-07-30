using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TasksManagementApi.Communication.Exceptions;
using TasksManagementApi.Communication.Responses;

namespace TasksManagementApi.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TasksManagementApiException tasksManagementApiException)
        {
            context.HttpContext.Response.StatusCode = (int)tasksManagementApiException.GetHttpStatuscode();


            context.Result = new ObjectResult(new ResponseErrorMessagesJson(tasksManagementApiException.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro desconhecido."));
    }
}

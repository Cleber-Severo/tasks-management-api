using System.ComponentModel.DataAnnotations;
using TasksManagementApi.Communication.Entities;
using TasksManagementApi.Communication.Exceptions;
using TasksManagementApi.Communication.Requests;
using TasksManagementApi.Communication.Responses;
using TasksManagementApi.Infrastructure.Repositories.Interfaces;

namespace TasksManagementApi.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public RegisterTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public ResponseShortTaskJson Execute(RequestRegisterTaskJson request)
    {
        Validate(request);

        var entity = new TaskEntity
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority,
        };
            
        _taskRepository.Add(entity);

        return new ResponseShortTaskJson { Id = entity.Id, Name = entity.Name };
    }

    private void Validate(RequestRegisterTaskJson request)
    {
        var validator = new RegisterTaskValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }

    }
}

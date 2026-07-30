using FluentValidation;
using TasksManagementApi.Communication.Requests;

namespace TasksManagementApi.Application.UseCases.Tasks.Register;

public class RegisterTaskValidator : AbstractValidator<RequestRegisterTaskJson>
{
    public RegisterTaskValidator() {
        RuleFor(task => task.Name)
            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("Tarefa não pode ter mais de 100 caracteres.");

        RuleFor(task => task.DueDate)
            .GreaterThan(DateTime.Today)
            .WithMessage("Data não pode estar no passado");
    }
}

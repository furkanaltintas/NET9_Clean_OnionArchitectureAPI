using FluentValidation;

namespace OnionDemo.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.FullName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(2)
            .WithMessage("İsim Soyisim");

        RuleFor(r => r.Email)
            .NotEmpty()
            .MaximumLength(60)
            .EmailAddress()
            .MinimumLength(8)
            .WithMessage("E-posta Adresi");

        RuleFor(r => r.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithName("Şifre");

        RuleFor(r => r.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(6)
            .Equal(r => r.Password)
            .WithMessage("Parola Tekrarı");
    }
}
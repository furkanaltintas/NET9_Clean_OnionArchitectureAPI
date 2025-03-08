using FluentValidation;

namespace OnionDemo.Application.Features.Auth.Command.Revoke;

class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
{
    public RevokeCommandValidator()
    {
        RuleFor(r => r.Email)
            .EmailAddress()
            .NotEmpty();
    }
}
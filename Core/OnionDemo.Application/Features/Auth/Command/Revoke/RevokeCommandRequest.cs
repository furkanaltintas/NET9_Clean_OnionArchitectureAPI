using MediatR;

namespace OnionDemo.Application.Features.Auth.Command.Revoke;

public class RevokeCommandRequest : IRequest<Unit>
{
    public string Email { get; set; }
}
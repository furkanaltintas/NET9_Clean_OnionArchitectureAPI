﻿using MediatR;

namespace OnionDemo.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
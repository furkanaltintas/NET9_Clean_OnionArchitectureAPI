using OnionDemo.Application.Bases;
using OnionDemo.Application.Features.Auth.Exception;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if(user is not null) throw new UserAlreadyExistException();
        return Task.CompletedTask;
    }
}
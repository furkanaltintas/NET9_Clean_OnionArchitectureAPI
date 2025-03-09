using OnionDemo.Application.Bases;
using OnionDemo.Application.Features.Auth.Exception;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null) throw new UserAlreadyExistException();
        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword) throw new EmailOrPasswordInvalidException();
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldNotBeExpired(User user)
    {
        if (user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenShouldNotBeExpiredException();
        return Task.CompletedTask;
    }

    public Task EmailAddressShouldBeValid(User? user)
    {
        if (user is null) throw new EmailAddressShouldBeValidException();
        return Task.CompletedTask;
    }

    internal async Task EmailAddressShouldBeValid(User? user)
    {
        if (user is null) throw new EmailAddressShouldBeValidException();
        return Task.CompletedTask;
    }
}
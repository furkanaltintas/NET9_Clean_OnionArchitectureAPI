using OnionDemo.Application.Bases;

namespace OnionDemo.Application.Features.Auth.Exception;

public class UserAlreadyExistException : BaseExceptions
{
    public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!")
    {
    }
}

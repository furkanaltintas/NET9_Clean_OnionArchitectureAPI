using OnionDemo.Application.Bases;

namespace OnionDemo.Application.Features.Auth.Exception;

public class EmailOrPasswordInvalidException : BaseExceptions
{
    public EmailOrPasswordInvalidException() : base("Kullanıcı adı veya şifre yanlıştır!")
    {
    }
}
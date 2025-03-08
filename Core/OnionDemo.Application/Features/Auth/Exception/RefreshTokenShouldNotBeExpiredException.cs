using OnionDemo.Application.Bases;


namespace OnionDemo.Application.Features.Auth.Exception;

public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
{
    public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapınız.")
    {

    }
}

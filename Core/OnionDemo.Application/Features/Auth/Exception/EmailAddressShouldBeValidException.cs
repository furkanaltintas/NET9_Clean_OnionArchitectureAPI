using OnionDemo.Application.Bases;

namespace OnionDemo.Application.Features.Auth.Exception;

public class EmailAddressShouldBeValidException : BaseExceptions
{
    public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır!")
    {
    }
}
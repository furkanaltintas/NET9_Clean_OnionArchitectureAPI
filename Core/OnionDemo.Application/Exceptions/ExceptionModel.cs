using Newtonsoft.Json;

namespace OnionDemo.Application.Exceptions;

public class ExceptionModel : ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}

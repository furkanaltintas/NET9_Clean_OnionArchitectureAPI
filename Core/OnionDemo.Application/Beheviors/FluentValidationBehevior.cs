using FluentValidation;
using MediatR;

namespace OnionDemo.Application.Beheviors;

public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .GroupBy(v => v.ErrorMessage)
            .Select(v => v.First())
            .Where(v => v != null)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return next();
    }
}
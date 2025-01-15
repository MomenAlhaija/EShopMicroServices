using FluentValidation;
using MediatR;
namespace BuildingBlocks.Behaviour;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : BuildingBlocks.CQRS.ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResult = await Task.WhenAll(validators.Select(V => V.ValidateAsync(context, cancellationToken)));
        var failures=
                     validationResult
                     .Where(v=>v.Errors.Any())
                     .SelectMany(p=>p.Errors).ToList();
        if (failures.Any())
            throw new ValidationException(failures);

        return await next();
    }
}

using ErrorOr;
using FluentValidation;
using MediatR;

namespace RestaurantDDD.Application.Common.Behaviors
{
    public class ValidationCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest,
        TResponse> where TRequest : IRequest<TResponse> where TResponse: IErrorOr
    {

        private readonly IValidator<TRequest>? _validator;

        public ValidationCommandBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

     
        async Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if(_validator == null)
            {
                return await next();
            }
            // Before calling handler
            var validationResult = await _validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors.ConvertAll(
                validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage
                    )
                );
            return (dynamic)errors;

        }

      
    }
}

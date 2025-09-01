using KendoNET.DynamicLinq;
using MediatR;
using Saltro.Application.Common;

namespace Saltro.Application.Behaviours;

public class DataSourceRequestBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var props = typeof(TRequest)
            .GetProperties()
            .Where(p => p.PropertyType == typeof(DataSourceRequest));

        foreach (var prop in props)
        {
            if (prop.GetValue(request) is DataSourceRequest dsRequest)
            {
                dsRequest.LowerCaseFilterValue();
                DataRequestHelper.FixSerialization(dsRequest);
            }
        }

        return await next(cancellationToken);
    }
}
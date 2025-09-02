using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Exceptions;
using Saltro.Application.Payloads;
using Saltro.Domain.Repository;
using ProductEntity = Saltro.Domain.Entities.Product;

namespace Saltro.Application.Commands.Products;

public sealed record CreateProduct(CreateProductRequest Payload) : IRequest<bool>;

internal sealed class CreateProductHandler(IProductRepository repository, ILogger<CreateProductHandler> logger)
    : IRequestHandler<CreateProduct, bool>
{
    private readonly IProductRepository _repository = repository;
    private readonly ILogger<CreateProductHandler> _logger = logger;

    public async Task<bool> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        try
        {
            var newProduct = ProductEntity.Create(
                uniqueId: "",
                name: request.Payload.Name,
                price: request.Payload.Price,
                maxQuantity: request.Payload.MaxQuantity,
                type: request.Payload.Type.GetValueOrDefault(0),
                productNo: request.Payload.ProductNo!,
                productCode: request.Payload.ProductCode!,
                isFLag: request.Payload.IsFlag,
                isPackageOnly: request.Payload.IsPackageOnly,
                subscription: request.Payload.Subscription!,
                isNotOrderable: false,
                sellPrice: request.Payload.SellPrice,
                sellVAT: request.Payload.SellVAT,
                costCenter: request.Payload.CostCenter!,
                costDim1: request.Payload.CostDim1!);

            await _repository.AddAsync(newProduct);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Create Product with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}

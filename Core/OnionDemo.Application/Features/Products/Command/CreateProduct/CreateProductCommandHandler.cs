using MediatR;
using OnionDemo.Application.Features.Products.Rules;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductRules _productRules;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
    {
        _unitOfWork = unitOfWork;
        _productRules = productRules;
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
        await _productRules.ProductTitleMustNotBeSame(products, request.Title);


        Product product = new(request.Title, request.Description, request.Price, request.Discount, request.BrandId);
        await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

        if (await _unitOfWork.SaveAsync() > 0)
        {
            foreach (var categoryId in request.CategoryIds)
                await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new(product.Id, categoryId));
            await _unitOfWork.SaveAsync();
        }

        return Unit.Value;
    }
}
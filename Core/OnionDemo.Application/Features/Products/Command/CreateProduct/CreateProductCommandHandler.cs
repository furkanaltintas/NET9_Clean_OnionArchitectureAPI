using MediatR;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
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
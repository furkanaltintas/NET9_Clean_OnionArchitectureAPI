using MediatR;
using OnionDemo.Application.Interfaces.AutoMapper;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id && !p.IsDeleted);

        var productMap = _mapper.Map<Product, UpdateProductCommandRequest>(request);

        var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(pc => pc.ProductId == request.Id);
        await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

        foreach (var categoryId in request.CategoryIds)
            await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new(product.Id, categoryId));

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(productMap);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
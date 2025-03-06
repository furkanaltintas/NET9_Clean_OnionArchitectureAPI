using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.DTOs;
using OnionDemo.Application.Interfaces.AutoMapper;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: i => i.Include(p => p.Brand));

        _mapper.Map<BrandDto, Brand>(new Brand());

        var getAllProductsQueryResponses = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
        foreach (var getAllProductsQueryResponse in getAllProductsQueryResponses)
            getAllProductsQueryResponse.Price -= (getAllProductsQueryResponse.Price * getAllProductsQueryResponse.Discount / 100);

        return getAllProductsQueryResponses;
    }
}
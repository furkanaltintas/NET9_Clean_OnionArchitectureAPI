using MediatR;
using OnionDemo.Application.Interfaces.RedisCache;

namespace OnionDemo.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuery
{
    public string CacheKey => "GetAllProducts";

    public double CacheTime => 60;
}
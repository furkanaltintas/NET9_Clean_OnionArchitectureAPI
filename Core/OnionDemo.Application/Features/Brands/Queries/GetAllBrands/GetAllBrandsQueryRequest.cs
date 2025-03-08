using MediatR;
using OnionDemo.Application.Interfaces.RedisCache;

namespace OnionDemo.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryRequest : IRequest<IList<GetAllBrandsQueryResponse>>, ICacheableQuery
{
    public string CacheKey => "GetAllBrands";

    public double CacheTime => 5;
}
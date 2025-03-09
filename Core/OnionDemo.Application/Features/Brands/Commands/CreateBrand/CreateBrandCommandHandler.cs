using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionDemo.Application.Bases;
using OnionDemo.Application.Interfaces.AutoMapper;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
{
    public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        Faker faker = new("tr");

        List<Brand> brands = new();

        for (int i = 0; i < 1000000; i++)
            brands.Add(new(faker.Commerce.Department(1)));

        await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
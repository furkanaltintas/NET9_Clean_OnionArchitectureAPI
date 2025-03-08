using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Features.Brands.Commands.CreateBrand;
using OnionDemo.Application.Features.Brands.Queries.GetAllBrands;

namespace OnionDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult GetAllBrands()
    {
        var response = _mediator.Send(new GetAllBrandsQueryRequest());
        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}
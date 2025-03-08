using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Features.Products.Command.CreateProduct;
using OnionDemo.Application.Features.Products.Command.DeleteProduct;
using OnionDemo.Application.Features.Products.Command.UpdateProduct;
using OnionDemo.Application.Features.Products.Queries.GetAllProducts;

namespace OnionDemo.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _mediator.Send(new GetAllProductsQueryRequest());
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}
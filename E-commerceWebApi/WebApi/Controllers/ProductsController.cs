using E_commerceWebApi.Application.DTOs;
using E_commerceWebApi.Application.Products.Commands.AddProduct;
using E_commerceWebApi.Application.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts( )
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand addProductcommand)
        {
            var result = await _mediator.Send(addProductcommand);
            return Ok(result);
        }
    }
}

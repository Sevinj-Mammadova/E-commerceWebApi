using E_commerceWebApi.Application.DTOs;
using E_commerceWebApi.Application.Orders.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_commerceWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            var command = new CreateOrderCommand(orderDto);
            var order = await _mediator.Send(command);
            return Ok(order);
        }

        // GET /api/orders/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var query = new GetOrderDetailsQuery(id);
            var orderDetails = await _mediator.Send(query);
            return Ok(orderDetails);
        }
    }
}

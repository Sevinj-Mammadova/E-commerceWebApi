using AutoMapper;
using E_commerceWebApi.Application.DTOs;
using E_commerceWebApi.Application.Orders.Dtos;
using E_commerceWebApi.Domain.Entities;
using E_commerceWebApi.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

// --- CreateOrderCommand
public class CreateOrderCommand : IRequest<Order>
{
    public CreateOrderDto OrderDto { get; set; }

    public CreateOrderCommand() { }

    public CreateOrderCommand(CreateOrderDto dto)
    {
        OrderDto = dto;
    }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.OrderDto == null)
            throw new ArgumentNullException(nameof(request.OrderDto));

        // Optional: validate product exists
        var product = await _context.Products.FindAsync(new object[] { request.OrderDto.ProductId }, cancellationToken);
        if (product == null)
            throw new KeyNotFoundException("Product not found");
        var order = _mapper.Map<Order>(product);

        //var order = new Order
        //{
        //    ProductId = request.OrderDto.ProductId,
        //    Quantity = request.OrderDto.Quantity,
        //    TotalPrice = product.Price * request.OrderDto.Quantity,
        //    OrderDate = DateTime.UtcNow
        //};

        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return order;
    }
}

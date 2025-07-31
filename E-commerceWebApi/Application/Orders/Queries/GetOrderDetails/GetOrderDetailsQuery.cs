using AutoMapper;
using E_commerceWebApi.Application.DTOs;
using E_commerceWebApi.Application.Orders.Dtos;
using E_commerceWebApi.Domain.Entities;
using E_commerceWebApi.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


public class GetOrderDetailsQuery : IRequest<OrderDetailsDto>
{
    public int Id { get; set; }

    public GetOrderDetailsQuery() { }

    public GetOrderDetailsQuery(int id)
    {
        Id = id;
    }
}

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GetOrderDetailsQueryHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(o => o.Product)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
            throw new KeyNotFoundException("Order not found");

        var dto = new OrderDetailsDto
        {
            OrderId = order.Id,
            ProductId = order.ProductId,
            ProductName = order.Product.Name,
            Quantity = order.Quantity,
            TotalPrice = order.TotalPrice
        };

        return dto;
    }
}
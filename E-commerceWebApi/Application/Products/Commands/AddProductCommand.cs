using AutoMapper;
using E_commerceWebApi.Application.DTOs;
using E_commerceWebApi.Domain.Entities;
using E_commerceWebApi.Infrastructure.Data;
using MediatR;

namespace E_commerceWebApi.Application.Products.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public  CreateProductDto ProductDto { get; set; }

    }
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.ProductDto;
            if (dto == null) 
                throw new ArgumentNullException(nameof(dto));
            var product = _mapper.Map<Product>(dto);
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
            
        }
    }
}

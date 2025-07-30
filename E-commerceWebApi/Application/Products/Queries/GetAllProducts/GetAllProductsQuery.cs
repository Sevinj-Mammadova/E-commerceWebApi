using E_commerceWebApi.Domain.Entities;
using E_commerceWebApi.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_commerceWebApi.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

    }
    
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly DataContext _context;
        public GetAllProductsQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.ToListAsync(cancellationToken);
            return result;
        }
    }
}

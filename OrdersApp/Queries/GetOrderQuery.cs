using MediatR;

namespace OrdersApp.Queries
{
    public record GetOrderQuery : IRequest<IEnumerable<Order>>;
  
}

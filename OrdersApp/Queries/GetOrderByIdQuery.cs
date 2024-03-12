using MediatR;

namespace OrdersApp.Queries
{
    public record GetOrderByIdQuery(int id) : IRequest<Order>;
}

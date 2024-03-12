using MediatR;

namespace OrdersApp.Commandes
{
    public record UpdateOrderCommande(int id,Order Order) : IRequest;

}

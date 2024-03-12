using MediatR;

namespace OrdersApp.Commandes
{
    public record DeleteOrderCommande(int id) : IRequest;

}

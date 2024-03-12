using MediatR;
namespace OrdersApp.Commandes
{
    public record AddOrderCommande(Order Order) : IRequest;
}

using MediatR;
using OrdersApp.Commandes;

namespace OrdersApp.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommande, Unit>
    {

        private readonly DataStorage _dataStorage;

        public DeleteOrderHandler(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public async Task<Unit> Handle(DeleteOrderCommande request, CancellationToken cancellationToken)
        {
            Order exsitOrder = await _dataStorage.GetOrderById(request.id);

            if (exsitOrder!= null)
            {
                _dataStorage.DeleteOrder(request.id);
            }

            return Unit.Value;
        }
    }
}

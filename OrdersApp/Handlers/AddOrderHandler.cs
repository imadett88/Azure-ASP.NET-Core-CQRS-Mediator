using MediatR;
using OrdersApp.Commandes;

namespace OrdersApp.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommande, Unit>
    {

        private readonly DataStorage _dataStorage;

        public AddOrderHandler(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public async Task<Unit> Handle(AddOrderCommande request, CancellationToken cancellationToken)
        {
             await _dataStorage.AddOrder(request.Order);
             return Unit.Value;

        }
    }
}

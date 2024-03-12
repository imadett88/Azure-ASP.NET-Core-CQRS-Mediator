using MediatR;
using OrdersApp.Commandes;

namespace OrdersApp.Handlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommande, Unit>
    {

        private readonly DataStorage _dataStorage;

        public UpdateOrderHandler(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public async Task<Unit> Handle(UpdateOrderCommande request, CancellationToken cancellationToken)
        {
            Order exsitOrder = await _dataStorage.GetOrderById(request.id);
            
            // verify
            if (exsitOrder != null)
            {
                // Update the order properties
                exsitOrder.Name = request.Order.Name;
                exsitOrder.Description = request.Order.Description;
                exsitOrder.Price = request.Order.Price;
            }

            return Unit.Value;

        }
    }
}

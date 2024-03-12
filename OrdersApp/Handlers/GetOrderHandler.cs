using MediatR;
using OrdersApp.Queries;

namespace OrdersApp.Handlers
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, IEnumerable<Order>>
    {

        private DataStorage _dataStorage;

        public GetOrderHandler(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return await _dataStorage.GetAllOrders();
        }
    }
}

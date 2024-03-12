using MediatR;
using OrdersApp.Queries;

namespace OrdersApp.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly DataStorage _dataStorage;

        public GetOrderByIdHandler(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dataStorage.GetOrderById(request.id);
        }
    }
}

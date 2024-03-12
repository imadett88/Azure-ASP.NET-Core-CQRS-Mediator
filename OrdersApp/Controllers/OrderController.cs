using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Commandes;
using OrdersApp.Queries;

namespace OrdersApp.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public OrderController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }


        // GET
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var orders = await _sender.Send(new GetOrderQuery());
            return Ok(orders);
        }

        // GET BY ID
        [HttpGet("{id:int}", Name = "GetOrderById")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var order = await _sender.Send(new GetOrderByIdQuery(id));

            return Ok(order);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] Order order)
        {
            await _sender.Send(new AddOrderCommande(order));

            return StatusCode(201);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            await _sender.Send(new UpdateOrderCommande(id,order));

            return Ok();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _sender.Send(new DeleteOrderCommande(id));

            return NoContent();
        }
    }
}

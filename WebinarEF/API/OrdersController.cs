using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebinarEF.DTO;
using WebinarEF.Interfaces;
using WebinarEF.Models;

namespace WebinarEF.API;

[Route("api/[controller]")]
[ApiController]
[SwaggerTag("OrdersController With UnitOfWork")]
public class OrdersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/orders
    [HttpGet]
    public IActionResult GetOrders()
    {

        var orders = _unitOfWork.Orders.GetAllAsync().Result;
        return Ok(orders);
    }

    // GET: api/orders
      /// <summary>
    ///     Get Orders by Customer Name
    /// </summary>
    /// <param name="customerName"></param>
    /// <returns></returns>
    // GET: api/orders/5
    [HttpGet("GetOrdersSplitedQuery")]
    [SwaggerOperation("GetOrdersUsingSplittedQuery with splitted Query")]
    public IActionResult GetOrdersSpplitedQuery()
    {

        var orders = _unitOfWork.Orders.GetOrdersUsingSplittedQuery();

        return Ok(orders);
    }



    // GET: api/orders/5
    [HttpGet("order/{id:int}")]
    public IActionResult GetOrder(int id)
    {
        var order = _unitOfWork.Orders.GetByIdAsync(id).Result;
        if (order == null) return NotFound();

        return Ok(order);
    }

    /// <summary>
    ///     Get Orders by Customer Name
    /// </summary>
    /// <param name="customerName"></param>
    /// <returns></returns>
    // GET: api/orders/5
    [HttpGet("order/{customerName}")]
    [SwaggerOperation("GetOrderByCustomer with Compiled Query")]
    public IActionResult GetOrderByCustomer(string customerName)
    {
        var orders = _unitOfWork.Orders.GetOrdersByCustomer(customerName);
        if (orders == null) return NotFound();

        return Ok(orders);
    }

    // POST: api/orders
    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderDto order)
    {
        if (order == null) return BadRequest();

        var customer = _unitOfWork.Customers.GetByIdAsync(order.CustomerId).Result;
        if (customer == null)
            return BadRequest();

        var orderItemsDb = order.OrderItems
            .Select(x => new OrderItem { ProductName = x.ProductName, Quantity = x.Quantity }).ToList();

        var orderDb = new Order { Customer = customer, CustomerId = customer.Id, OrderItems = orderItemsDb };

        _unitOfWork.Orders.AddAsync(orderDb);
        _unitOfWork.Commit();

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
}
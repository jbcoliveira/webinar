using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebinarEF.Interfaces;
using WebinarEF.Models;

namespace WebinarEF.API;

[Route("api/[controller]")]
[ApiController]
[SwaggerTag("Customer without UnitOfWork, only repository")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    // GET: api/<CustomerController>
    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        var customers = _customerRepository.GetAllAsync();
        return customers.Result;
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public Task<Customer> Get(int id)
    {
        return _customerRepository.GetByIdAsync(id);
    }

    // POST api/<CustomerController>
    [HttpPost]
    public void Post([FromBody] Customer value)
    {
        _customerRepository.AddAsync(value);
    }


    [HttpGet("GetCustomerLazyLoading")]
    [SwaggerOperation("Lazy Loading")]
    public IActionResult GetCustomerLazyLoading(int id)
    {

       var customer = _customerRepository.GetCustomerLazyLoading(id);

        return Ok(customer);
    }

    [HttpGet("GetCustomerEagerLoading")]
    [SwaggerOperation("Eager Loading")]
    public IActionResult GetCustomerEagerLoading(int id)
    {

        var customer = _customerRepository.GetCustomerEagerLoading(id);

        return Ok(customer);
    }

}
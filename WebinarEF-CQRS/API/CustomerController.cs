using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebinarEFCQRS.Domain;
using WebinarEFCQRS.Features.Customer.Commands.Create;
using WebinarEFCQRS.Features.Customer.Commands.Delete;
using WebinarEFCQRS.Features.Customer.Commands.Update;
using WebinarEFCQRS.Features.Customer.Dtos;
using WebinarEFCQRS.Features.Customer.Queries.Get;
using WebinarEFCQRS.Features.Customer.Queries.List;

namespace WebinarEFCQRS.API;

[Route("api/[controller]")]
[ApiController]
[SwaggerTag("Customer CQRS")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }


    // GET: api/<CustomerController>
    [HttpGet]
    public List<CustomerDto> Get()
    {
        var customers = _mediator.Send(new ListCustomerQuery());
        return customers.Result;
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public Task<CustomerDto> Get(int id)
    {
        var customer = _mediator.Send(new GetCustomerQuery(id));
        return customer;
    }

    // POST api/<CustomerController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] Customer value)
    {
        var customerId = await _mediator.Send(new CreateCustomerCommand(value));
        if (customerId == 0) return Results.BadRequest();
        return Results.Created($"/Customer/{customerId}", new { id = customerId });
    }

    // PUT api/<CustomerController>
    [HttpPut("{id}")]
    public Task<IResult> Update(int id, [FromBody] UpdateCustomerCommand command)
    {
        if (id != command.Id)
        {
            return Task.FromResult(Results.BadRequest());
        }

        if (id == 0)
        {
            return Task.FromResult(Results.BadRequest());
        }

        return Task.FromResult(Results.Ok( _mediator.Send(command)));
    }
}
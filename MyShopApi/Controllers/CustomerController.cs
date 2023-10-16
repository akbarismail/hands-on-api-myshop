using Microsoft.AspNetCore.Mvc;
using MyShopApi.Entities;
using MyShopApi.Repositories;

namespace MyShopApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IPersistence _persistence;

    public CustomerController(IRepository<Customer> customerRepository, IPersistence persistence)
    {
        _customerRepository = customerRepository;
        _persistence = persistence;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerNameAndEmail([FromQuery] string name, [FromQuery] string email)
    {
        try
        {
            var customer = await _customerRepository.FindAsync(customer => 
                customer.Email != null && customer.CustomerName != null && 
                customer.CustomerName.Equals(name) && customer.Email.Equals(email));
            if (customer is null) return NotFound("customer not found");
            return Ok(customer);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewCustomer([FromBody] Customer payload)
    {
        var customer = await _customerRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created("/api/customers", customer);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer payload)
    {
        var customer = _customerRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        try
        {
            var customerId = await _customerRepository.FindByIdAsync(Guid.Parse(id));
            if (customerId is null) return NotFound("customer not found");
            _customerRepository.Delete(customerId);
            await _persistence.SaveChangesAsync();
            return Ok();
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }
}
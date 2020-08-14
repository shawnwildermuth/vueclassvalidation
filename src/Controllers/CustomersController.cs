using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueClassValidation.Data;
using VueClassValidation.Data.Entities;
using VueClassValidation.Models;

namespace VueClassValidation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ILogger<CustomersController> _logger;
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _repository;

    public CustomersController(ILogger<CustomersController> logger, IMapper mapper, ICustomerRepository repository)
    {
      _logger = logger;
      _mapper = mapper;
      _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<CustomerModel[]>> GetCustomersAsync()
    {
      return _mapper.Map<CustomerModel[]>(await _repository.GetCustomersAsync());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<CustomerModel>> GetCustomerAsync(int id)
    {
      return _mapper.Map<CustomerModel>(await _repository.GetCustomerAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CustomerModel>> PostAsync([FromBody] CustomerModel model)
    {
      try
      {
        var entity = _mapper.Map<Customer>(model);

        _repository.Add(entity);

        if (await _repository.SaveAllAsync())
        {
          return CreatedAtRoute(new { }, _mapper.Map<CustomerModel>(entity));
        }
      }
      catch (Exception ex)
      {
        _logger.LogWarning("Failed to save customer", ex);
      }

      return BadRequest("Could not create new Customer");
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CustomerModel>> Put(int id, [FromBody] CustomerModel model)
    {
      try
      {
        var existing = await _repository.GetCustomerAsync(id);

        if (existing == null) return NotFound();

        _mapper.Map(model, existing);

        if (await _repository.SaveAllAsync())
        {
          return Ok(_mapper.Map<CustomerModel>(existing));
        }
      }
      catch (Exception ex)
      {
        _logger.LogWarning("Failed to update customer", ex);
      }

      return BadRequest("Could not update Customer");
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var customer = await _repository.GetCustomerAsync(id);
        if (customer == null) return NotFound();

        _repository.Delete(customer);
        if (await _repository.SaveAllAsync())
        {
          return Ok();
        }

      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete customer", ex);
      }

      return BadRequest("Failed to delete customer, unknown reason");
    }
  }
}

using CargoBusiness.Services;
using CargoEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CargoManagerSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("AddCustomer")]
        public bool AddNewCustomer(Customer newCustomerData)
        {
            return _customerService.AddNewCustomer(newCustomerData);
        }
        [HttpPut("UpdateCustomerDeatails")]
        public bool UpdateCustomerDetails(Customer updatedCustomerData)
        {
            return _customerService.UpdateCustomerDetails(updatedCustomerData);
        }
        [HttpGet("ViewAllOrders")]
        public IList<CargoOrder> ViewAllOrders(int customerId)
        {
            return _customerService.ViewAllOrders(customerId);
        }
        [HttpGet("GetCustomerDetails")]
        public IActionResult GetCustomerDetails()
        {
            var status = _customerService.GetCustomerDetails();
            return Ok(status);
        }
        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound(); // Return 404 if the customer is not found
            }
            return Ok(customer);
        }
    }
}

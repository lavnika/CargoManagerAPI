using CargoBusiness.Services;
using CargoData.Repository;
using CargoEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagerSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService) 
        { 
            _employeeService = employeeService;
        }
        [HttpGet("SearchForCargoFare")]
        public CargoFare SearchForCargoFare(int cargofareid)
        {
            return _employeeService.SearchForCargoFare(cargofareid);
        }
        [HttpGet("SearchForCustomer")]
        public IList<Customer> SearchForCustomer(int customerid)
        {
            return _employeeService.SearchForCustomer(customerid);
        }
        [HttpGet("SearchForOrder")]
        public IList<CargoOrder> SearchForOrder(int customerid)
        {
            return _employeeService.SearchForOrder(customerid);
        }
        [HttpPut("UpdateCargoOrderById")]
        public bool UpdateCargoOrderById(CargoOrder updatedCargoTypeData)
        {
            return _employeeService.UpdateCargoOrderById(updatedCargoTypeData);
        }
        [HttpPut("UpdateCustomer")]
        public bool UpdateCustomer(Customer updatedCustomerData)
        {
            return _employeeService.UpdateCustomer(updatedCustomerData);
        }
        [HttpPut("UpdatePlaces")]
        public bool UpdatePlaces(CargoOrder updatedPlaceData)
        {
            return _employeeService.UpdatePlaces(updatedPlaceData);
        }
        [HttpPut("UpdateSelfRecord")]
        public bool UpdateSelfRecord(Employee updatedEmployeeData)
        {
            return _employeeService.UpdateSelfRecord(updatedEmployeeData);
        }
        [HttpPost("BookingCargoOrder")]
        public IActionResult AddCargoOrders(CargoOrder insertcargoorders)
        {
            var result = _employeeService.AddCargoOrders(insertcargoorders);
            return Ok(result);
        }
        [HttpGet("GetCargoOrderById")]
        public IActionResult GetEmployeeById(int id)
        {
            var result = _employeeService.GetCargoOrderById(id);
            return Ok(result);
        }
        [HttpDelete("DeleteCargoOrder")]
        public IActionResult DeleteCargoOrderById(int cargoorderId)
        {
            var result =_employeeService.DeleteCargoOrderById(cargoorderId);
            return Ok(result);
        }
    }
}

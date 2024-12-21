using CargoBusiness.Services;
using CargoEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CargoManagerSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly AdminService _adminService;
        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        //[HttpPost("AddNewCargoType")]
        //public IActionResult AddNewCargoType(CargoType insertcargotypedata)
        //{
        //    var result = _adminService.AddNewCargoType(insertcargotypedata);
        //    return Ok(result);
        //}
        [HttpPost("BookingCargo")]
        public bool BookingCargo(CargoBooking cargobookingdata)
        {
            return _adminService.BookingCargo(cargobookingdata);
        }
        [HttpPost("CalculationcargoPrice")]
        public bool CalculatingCargoPrice(CargoFare cargofaredata)
        {
            return _adminService.CalculatingCargoPrice(cargofaredata);
        }
        [HttpDelete("CancelCargo")]
        public bool CancelationOfCargo(int cargoorderid)
        {
            return _adminService.CancelationOfCargo(cargoorderid);
        }
        [HttpDelete("DeleteExistingEmployee")]
        public bool DeleteExistingEmployee(int employeeid)
        {
            return _adminService.DeleteExistingEmployee(employeeid);
        }
        [HttpPost("RegisterNewEmployee")]
        public bool RegisterNewEmployee(Employee newemployeedata)
        {

            return _adminService.RegisterNewEmployee(newemployeedata);
        }
        [HttpPost("RegistrationOnSystem")]
        public bool RegistrationOnSystem(Admin newadmindata)
        {
            return _adminService.RegistrationOnSystem(newadmindata);
        }
        [HttpGet("SearchForAddress")]
        public IList<CargoFare> SearchForAddress()
        {
            return _adminService.SearchForAddress();
        }
        [HttpGet("SearchForCustomer")]
        public IList<Customer> SearchForCustomer(int customerid)
        {
            return _adminService.SearchForCustomer(customerid);
        }
        [HttpPut("UpdateCargoBooking")]
        public bool UpdateCargoBooking(CargoBooking updatecargobookingdata)
        {
            return _adminService.UpdateCargoBooking(updatecargobookingdata);
        }
        [HttpPut("UpdateEmployee")]
        public bool UpdateEmployee(Employee updateemployeedata)
        {
            return _adminService.UpdateEmployee(updateemployeedata);
        }
        [HttpPut("UpdatePlaceAndPrice")]
        public bool UpdatePlaceAndPrice(CargoFare updateplaceandpricedata)
        {
            return _adminService.UpdatePlaceAndPrice(updateplaceandpricedata);
        }
        [HttpGet("ViewStatusOfCargo")]
        public IList<CargoBooking> ViewStatusOfCargo()
        {
            return _adminService.ViewStatusOfCargo();
        }
        [HttpPost("GeneratePassKey")]
        public IActionResult GenerateGatePassForCargoEntry(GatePass gatePass)
        {
            var result = _adminService.GenerateGatePassForCargoEntry(gatePass);
            return Ok(result);
        }

        //[HttpPost("MarkTruckExit")]
        //public IActionResult MarkTruckExit(int cargoBookingId, DateTime exitDate, string exitReason)
        //{
        //    var result = _adminService.MarkTruckExit(cargoBookingId, exitDate, exitReason);
        //    return Ok(result);
        //}
        //[HttpPost("StoreCargo")]
        //public IActionResult StoreCargoAndGenerateGatePass(int cargoBookingId, int capacity, DateTime EntryDate)
        //{
        //    var result = _adminService.StoreCargoAndGenerateGatePass(cargoBookingId, capacity, EntryDate);
        //    return Ok(result);
        //}
        [HttpGet("HouseKeepingDetails")]
        public IActionResult HousekeepingMaintainance()
        {
            var result = _adminService.HousekeepingMaintainance();
            return Ok(result);
        }
        [HttpGet("GetAdminDetails")]
        public IActionResult GetAdminDetails()
        {
            var result = _adminService.GetAdminDetails();
            return Ok(result);
        }
        [HttpGet("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            var result = _adminService.GetEmployeeDetails();
            return Ok(result);
        }
        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var result = _adminService.GetEmployeeById(id);
            return Ok(result);
        }
        [HttpGet("GetCargoBookingById")]
        public IActionResult GetCargoBookingById(int id)
        {
            var result = _adminService.GetCargoBookingById(id);
            return Ok(result);
        }
        [HttpGet("GetCargoFareById")]
        public IList<CargoFare> GetCargoFareById(int cargofareid)
        {
            return _adminService.GetCargoFareById(cargofareid);
        }
        [HttpGet("WareHouseDetails")]
        public IActionResult GetWareHouseDetails()
        {
            var result = _adminService.GetWareHouseDetails();
            return Ok(result);
        }
    }
}

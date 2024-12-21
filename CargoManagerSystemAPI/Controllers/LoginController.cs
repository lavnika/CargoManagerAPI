using System.Runtime.Intrinsics.Arm;
using CargoBusiness.Services;
using CargoEntity;
using CargoManagerSystemAPI.ProjectDataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CargoManagerSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly AdminService _employeeService;
        private readonly CustomerService _customerService;

        public LoginController(AdminService adminService, CustomerService customerService)
        {
            _adminService = adminService;
            _customerService = customerService;
            _employeeService = adminService;
        }
       
        

        // GET: api/<ValuesController>
        [HttpPost]
        public IActionResult Login(UserLoginDetails userLoginDetails)
        {
            var admins = _adminService.GetAdminDetails().ToList();
            var employee = _employeeService.GetEmployeeDetails().ToList();
            var Customer = _customerService.GetCustomerDetails().ToList();

            //var FoundEmp = employees.Where(emp => emp.Equals(emp.EmployeeId == userLoginDetails.UserId) && emp.Equals(emp.EmployeePassword == userLoginDetails.Password));
            //var FoundEmp1 = employees.Select(emp => emp.Equals(emp.EmployeeId == userLoginDetails.UserId) && emp.Equals(emp.EmployeePassword == userLoginDetails.Password));
            var FoundAdm = admins.FirstOrDefault<Admin>(adm => (adm.Username == userLoginDetails.UserId) && adm.Password == userLoginDetails.Password && adm.Role == userLoginDetails.Role);
            var FoundEMp = employee.FirstOrDefault<Employee>(emp =>(emp.Username == userLoginDetails.UserId) && emp.Password==userLoginDetails.Password && emp.Role == userLoginDetails.Role);
            var FoundCust = Customer.FirstOrDefault<Customer>(cust=>(cust.Username == userLoginDetails.UserId)&&cust.Password==userLoginDetails.Password && cust.Role == userLoginDetails.Role);    

            if (FoundAdm != null)
            {
                userLoginDetails.UserId = FoundAdm.Username;
                return Ok(userLoginDetails);
            }
            if(FoundEMp!=null)
            {
                userLoginDetails.UserId = FoundEMp.Username;
                return Ok(userLoginDetails);
            }
            if(FoundCust!= null)
            {
                userLoginDetails.UserId = FoundCust.Username ;
                return Ok(userLoginDetails);
            }
            else
            {
                return BadRequest("Invalid user name or password");
            }

        }
    }
}

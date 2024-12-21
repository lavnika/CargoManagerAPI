using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoData.Repository;
using CargoEntity;

namespace CargoBusiness.Services
{
    /// <summary>
    /// Service class responsible for handling administrative operations related to cargo, bookings, employees, and system registration.
    /// </summary>
    public class AdminService
    {
        private readonly IAdminRepo _adminRepo;

        /// <summary>
        /// Initializes a new instance of the AdminService class with the specified repository.
        /// </summary>
        /// <param name="adminRepo">The repository used for data access.</param>
        public AdminService(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        // <summary>
        /// Adds a new cargo type to the system.
        /// </summary>
        /// <param name="insertcargotypedata">The cargo type data to be added.</param>
        /// <returns>
        ///   <c>true</c> if the cargo type was added successfully;
        ///   <c>false</c> if the cargo type already exists or an error occurred during the operation.
        /// </returns>

        public bool AddNewCargoType(CargoType insertcargotypedata)
        {
            bool status = _adminRepo.AddNewCargoType(insertcargotypedata);
            return status;
        }
        public bool BookingCargo(CargoBooking cargobookingdata)
        {
            bool status = _adminRepo.BookingCargo(cargobookingdata);
            return status;
        }
        public bool CalculatingCargoPrice(CargoFare cargofaredata)
        {
            bool status = _adminRepo.CalculatingCargoPrice(cargofaredata);
            return status;
        }
        public bool CancelationOfCargo(int cargoorderid)
        {
            bool status = _adminRepo.CancelationOfCargo(cargoorderid);
            return status;
        }
        public bool DeleteExistingEmployee(int employeeid)
        {
            bool status = _adminRepo.DeleteExistingEmployee(employeeid);
            return status;
        }
        public bool RegisterNewEmployee(Employee newemployeedata)
        {
            bool status = _adminRepo.RegisterNewEmployee(newemployeedata);
            return status;
        }
        public bool RegistrationOnSystem(Admin newadmindata)
        {
            bool status = _adminRepo.RegistrationOnSystem(newadmindata);
            return status;
        }
        public IList<CargoFare> SearchForAddress()
        {
            return _adminRepo.SearchForAddress();
        }
        public IList<Customer> SearchForCustomer(int customerid)
        {
            return _adminRepo.SearchForCustomer(customerid);
        }
        public IList<Employee> SearchForEmployee(int employeeid)
        {
            return _adminRepo.SearchForEmployee(employeeid);
        }
        public bool UpdateCargoBooking(CargoBooking updatecargobooking)
        {
            bool status=_adminRepo.UpdateCargoBooking(updatecargobooking);
            return status;
        }
        public bool UpdateEmployee(Employee updateemployeedata)
        {
            bool status = _adminRepo.UpdateEmployee(updateemployeedata);
            return status;
        }
        public bool UpdatePlaceAndPrice(CargoFare updateplaceandpricedata)
        {
            bool status = _adminRepo.UpdatePlaceAndPrice(updateplaceandpricedata);
            return status;
        }
        public IList<CargoBooking> ViewStatusOfCargo()
        {
            return _adminRepo.ViewStatusOfCargo();
        }
        public bool GenerateGatePassForCargoEntry(GatePass gatePass)
        {
            return _adminRepo.GenerateGatePassForCargoEntry(gatePass);
        }

        public bool MarkTruckExit(int cargoBookingId, DateTime exitDate, string exitReason)
        {
            return _adminRepo.MarkTruckExit(cargoBookingId, exitDate, exitReason);
        }
        public bool StoreCargoAndGenerateGatePass(int cargoBookingId, int capacity, DateTime EntryDate)
        {
            return _adminRepo.StoreCargoAndGenerateGatePass(cargoBookingId, capacity, EntryDate);
        }
        public IList<HousekeepingMovement>? HousekeepingMaintainance()
        {
            return _adminRepo.HousekeepingMaintainance();
        }
        public IList<Admin> GetAdminDetails()
        {
            return _adminRepo.GetAdminDetails();
        }
        public IList<Employee> GetEmployeeDetails()
        {
            return _adminRepo.GetEmployeeDetails();
        }
        public Employee GetEmployeeById(int id)
        {
            return (_adminRepo.GetEmployeeById(id));
        }
        public CargoBooking GetCargoBookingById(int id)
        {
            return (_adminRepo.GetCargoBookingById(id));
        }
        public IList<CargoFare> GetCargoFareById(int cargofareid)
        {
            return _adminRepo.GetCargoFareById(cargofareid);
        }
        public IList<WareHouse>? GetWareHouseDetails()
        {
            return _adminRepo.GetWareHouseDetails();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoEntity;

namespace CargoData.Repository
{
    /// <summary>
    /// Interface defining operations related to administrative tasks in the Cargo Manager System.
    /// </summary>
    public interface IAdminRepo
    {
        /// <summary>
        /// Registers a new administrator in the system.
        /// </summary>
        /// <param name="newadmindata">The data of the new administrator to be registered.</param>
        /// <returns>True if the registration is successful; otherwise, false.</returns>
        bool RegistrationOnSystem(Admin newadmindata);

        /// <summary>
        /// Searches and retrieves a list of cargo addresses.
        /// </summary>
        /// <returns>A list of cargo addresses.</returns>
        IList<CargoFare> SearchForAddress();

        /// <summary>
        /// Calculates the price of cargo based on the provided CargoFare data.
        /// </summary>
        /// <param name="cargofaredata">The data for calculating cargo price.</param>
        /// <returns>True if the calculation is successful; otherwise, false.</returns>
        bool CalculatingCargoPrice(CargoFare cargofaredata);

        /// <summary>
        /// Books cargo with the provided CargoBooking data.
        /// </summary>
        /// <param name="bookingdata">The data for booking cargo.</param>
        /// <returns>True if the booking is successful; otherwise, false.</returns>
        bool BookingCargo(CargoBooking bookingdata);

        /// <summary>
        /// Retrieves the status of cargo bookings.
        /// </summary>
        /// <returns>A list of cargo bookings representing their status.</returns>
        IList<CargoBooking> ViewStatusOfCargo();

        /// <summary>
        /// Cancels a cargo booking based on the provided ID.
        /// </summary>
        /// <param name="cargoorderid">The ID of the cargo order to be canceled.</param>
        /// <returns>True if the cancellation is successful; otherwise, false.</returns>
        bool CancelationOfCargo(int cargoorderid);

        /// <summary>
        /// Registers a new employee in the system.
        /// </summary>
        /// <param name="newemployeedata">The data of the new employee to be registered.</param>
        /// <returns>True if the registration is successful; otherwise, false.</returns>
        bool RegisterNewEmployee(Employee newemployeedata);

        /// <summary>
        /// Deletes an existing employee based on the provided ID.
        /// </summary>
        /// <param name="employeeid">The ID of the employee to be deleted.</param>
        /// <returns>True if the deletion is successful; otherwise, false.</returns>
        bool DeleteExistingEmployee(int employeeid);

        /// <summary>
        /// Updates employee information.
        /// </summary>
        /// <param name="updateemployeedata">The data for updating employee information.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdateEmployee(Employee updateemployeedata);

        /// <summary>
        /// Searches and retrieves employee information based on the provided ID.
        /// </summary>
        /// <param name="employeeid">The ID of the employee to be searched.</param>
        /// <returns>A list of employee data matching the search criteria.</returns>
        IList<Employee> SearchForEmployee(int employeeid);

        /// <summary>
        /// Searches and retrieves customer information based on the provided ID.
        /// </summary>
        /// <param name="customerid">The ID of the customer to be searched.</param>
        /// <returns>A list of customer data matching the search criteria.</returns>
        IList<Customer> SearchForCustomer(int customerid);

        /// <summary>
        /// Adds a new cargo type to the system.
        /// </summary>
        /// <param name="insertcargotypedata">The data for adding a new cargo type.</param>
        /// <returns>True if the addition is successful; otherwise, false.</returns>
        bool AddNewCargoType(CargoType insertcargotypedata);

        /// <summary>
        /// Updates existing cargo type information.
        /// </summary>
        /// <param name="updatecargotypedata">The data for updating cargo type information.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdateCargoBooking(CargoBooking updatecargobookingdata);

        /// <summary>
        /// Updates place and price information for a cargo type.
        /// </summary>
        /// <param name="updateplaceandpricedata">The data for updating place and price information.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        /// <summary>
        /// Updates the place and price information for a cargo based on the provided data.
        /// </summary>
        /// <param name="updateplaceandpricedata">Data containing information to update the cargo fare.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdatePlaceAndPrice(CargoFare updateplaceandpricedata);

        /// <summary>
        /// Generates a gate pass for cargo entry based on the provided information.
        /// </summary>
        /// <param name="cargoBookingId">Unique identifier for the cargo booking.</param>
        /// <param name="entryDate">Date of cargo entry.</param>
        /// <param name="typeOfDelivery">Type of delivery for the cargo.</param>
        /// <param name="orderStaus">Status of the cargo order.</param>
        /// <returns>True if the gate pass generation is successful; otherwise, false.</returns>
        bool GenerateGatePassForCargoEntry(GatePass generategatepass);

        /// <summary>
        /// Marks the exit of a truck from the cargo facility based on the provided information.
        /// </summary>
        /// <param name="cargoBookingId">Unique identifier for the cargo booking associated with the truck exit.</param>
        /// <param name="exitDate">Date of the truck exit.</param>
        /// <param name="exitReason">Reason for the truck exit.</param>
        /// <returns>True if the truck exit is successfully marked; otherwise, false.</returns>
        bool MarkTruckExit(int cargoBookingId, DateTime exitDate, string exitReason);

        /// <summary>
        /// Stores cargo information, checks warehouse capacity, and generates a gate pass for entry.
        /// </summary>
        /// <param name="cargoBookingId">Unique identifier for the cargo booking.</param>
        /// <param name="capacity">Warehouse capacity to check before storing the cargo.</param>
        /// <param name="EntryDate">Date of cargo entry.</param>
        /// <returns>True if the cargo is successfully stored, and a gate pass is generated; otherwise, false.</returns>
        bool StoreCargoAndGenerateGatePass(int cargoBookingId, int capacity, DateTime EntryDate);

        /// <summary>
        /// Retrieves a list of housekeeping movements for maintenance purposes.
        /// </summary>
        /// <returns>List of housekeeping movements.</returns>
        IList<HousekeepingMovement> HousekeepingMaintainance();

        IList<Admin> GetAdminDetails();

        IList<Employee> GetEmployeeDetails(); 

        Employee GetEmployeeById(int id);
        CargoBooking GetCargoBookingById(int id);

        IList<CargoFare> GetCargoFareById(int cargofareid);
        IList<WareHouse>? GetWareHouseDetails();
    }

}

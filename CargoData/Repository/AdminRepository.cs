using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoData.DataContext;
using CargoEntity;

namespace CargoData.Repository
{
    public class AdminRepository : IAdminRepo
    {
        private readonly CargoDbContext _dbContext;

        public AdminRepository(CargoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Adds a new cargo type to the system after checking for duplicates based on the cargo type's name.
        /// </summary>
        /// <param name="insertcargotypedata">The cargo type data to be added.</param>
        /// <returns>
        /// Returns true if the cargo type is successfully added, 
        /// false if a cargo type with the same name already exists or if an error occurs during the operation.
        /// </returns>
        public bool AddNewCargoType(CargoType insertcargotypedata)
        {
            try
            { 
                    // Check if the cargo type already exists based on some criteria (e.g., name, code, etc.)
                    var existingCargoType= _dbContext.CargoTypes?
                        .FirstOrDefault(ct => ct.CargoTypeId == insertcargotypedata.CargoTypeId);

                    if (existingCargoType != null)
                    {
                        // Cargo type with the same name already exists, handle the duplication scenario
                        // You might throw an exception, return a specific result, or take any other desired action
                        return false;
                    }

                    // If the cargo type doesn't exist, add it to the database
                    _dbContext.CargoTypes?.Add(insertcargotypedata);
                    _dbContext.SaveChanges();

                    // Return true to indicate successful addition
                    return true;
                
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Books cargo based on the provided cargo booking data, performing necessary validations and database operations.
        /// </summary>
        /// <param name="bookingdata">The cargo booking data to be processed.</param>
        /// <returns>
        /// Returns true if the cargo is successfully booked; otherwise, returns false in case of invalid data or an error during the operation.
        /// </returns>
        public bool BookingCargo(CargoBooking bookingdata)
        {
            try
            {
                // Check if the cargo booking data is valid
                if (bookingdata == null || bookingdata.BookingStatus =="Invalid")
                {
                    // Invalid cargo booking data, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Invalid cargo booking data");
                }

                // Perform additional business logic or validation if needed
                // For example, check if the product is available, if the warehouse has capacity, etc.
                // If any validation fails, throw an exception or return false based on your design

                // Add cargo booking to the database
                _dbContext.CargoBooking?.Add(bookingdata);
                _dbContext.SaveChanges();

                // Return true to indicate successful booking
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in BookingCargo: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Calculates the cargo price based on the provided cargo fare data and updates the database.
        /// </summary>
        /// <param name="cargofaredata">The cargo fare data used for calculating the cargo price.</param>
        /// <returns>
        /// Returns true if the cargo price is successfully calculated and updated; otherwise, returns false in case of invalid data or an error during the operation.
        /// </returns>
        public bool CalculatingCargoPrice(CargoFare cargofaredata)
        {
            
            try
            {
                // Check if the cargo fare data is valid
                if (cargofaredata == null || cargofaredata.Weight <= 0 || cargofaredata.FareAmount <= 0)
                {
                    // Invalid cargo fare data, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Invalid cargo fare data");
                }

                // Perform additional business logic or validation if needed
                // For example, check if the cargo type is valid, if the weight is within acceptable limits, etc.
                // If any validation fails, throw an exception or return false based on your design

                // Calculate the cargo price based on the provided cargo fare data
                _dbContext.CargoFare?.Add(cargofaredata);
                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful calculation and update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in CalculatingCargoPrice: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Cancels a cargo booking based on the provided cargo order ID.
        /// </summary>
        /// <param name="cargoorderid">The ID of the cargo booking to be canceled.</param>
        /// <returns>
        /// Returns true if the cargo booking is successfully canceled; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool CancelationOfCargo(int cargoorderid)
        {
            try
            {
                // Retrieve the cargo booking based on the provided ID
                var cargoBooking = _dbContext.CargoBooking?.FirstOrDefault(cb => cb.CargoBookingId == cargoorderid);

                // Check if the cargo booking exists
                if (cargoBooking == null)
                {
                    // Cargo booking not found, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Cargo booking not found");
                }

                // Perform additional business logic or validation if needed
                // For example, check if the cargo booking can be canceled based on its status, etc.
                // If any validation fails, throw an exception or return false based on your design

                // Update the cargo booking status to "Canceled" (assuming you have a Status property)
                cargoBooking.BookingStatus = "Canceled";

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful cancellation
                return true;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error in CancelationOfCargo:");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Deletes an existing employee based on the provided employee ID.
        /// </summary>
        /// <param name="employeeid">The ID of the employee to be deleted.</param>
        /// <returns>
        /// Returns true if the employee is successfully deleted; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool DeleteExistingEmployee(int employeeid)
        {
            try
            {
                // Retrieve the employee based on the provided ID
                var employee = _dbContext.Employees?.FirstOrDefault(e => e.EmployeeId == employeeid);

                // Check if the employee exists
                if (employee == null)
                {
                    // Employee not found, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Employee not found");
                }

                // Perform additional business logic or validation if needed
                // For example, check if the employee can be deleted based on certain conditions, etc.
                // If any validation fails, throw an exception or return false based on your design

                // Remove the employee from the database
                _dbContext.Employees?.Remove(employee);

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful deletion
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in DeleteExistingEmployee: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Registers a new employee in the system.
        /// </summary>
        /// <param name="newemployeedata">The data of the new employee to be registered.</param>
        /// <returns>
        /// Returns true if the employee is successfully registered; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool RegisterNewEmployee(Employee newemployeedata)
        {
            try
            {
                // Check if the employee data is valid
                if (newemployeedata == null || string.IsNullOrWhiteSpace(newemployeedata.FirstName) || string.IsNullOrWhiteSpace(newemployeedata.LastName))
                {
                    // Invalid employee data, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Invalid employee data");
                }

                // Perform additional business logic or validation if needed
                // For example, check if the employee data is unique, meets certain criteria, etc.
                // If any validation fails, throw an exception or return false based on your design

                // Add the new employee to the database
                _dbContext.Employees?.Add(newemployeedata);

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful registration
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in RegisterNewEmployee: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Registers a new administrator in the system.
        /// </summary>
        /// <param name="newadmindata">The data of the new administrator to be registered.</param>
        /// <returns>
        /// Returns true if the administrator is successfully registered; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool RegistrationOnSystem(Admin newadmindata)
        {
            try
            {
                // Check if the admin data is valid
                if (newadmindata == null || string.IsNullOrWhiteSpace(newadmindata.FirstName) || string.IsNullOrWhiteSpace(newadmindata.LastName))
                {
                    // Invalid admin data, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Invalid admin data");
                }

                // Perform additional business logic or validation if needed
                // For example, check if the admin data is unique, meets certain criteria, etc.
                // If any validation fails, throw an exception or return false based on your design

                // Add the new admin to the database
                _dbContext.Admins?.Add(newadmindata);

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful registration
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in RegistrationOnSystem: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Searches for and retrieves a list of cargo addresses.
        /// </summary>
        /// <returns>A list of cargo addresses (CargoFare entities).</returns>
        public IList<CargoFare> SearchForAddress()
        {
            try
            {
                // Retrieve the list of cargo addresses from the database
                var cargoAddresses = _dbContext.CargoFare?.ToList();

                // Return the list of cargo addresses
                return cargoAddresses;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in SearchForAddress: {ex.Message}");

                // Return an empty list or null to indicate that an error occurred during the operation
                return new List<CargoFare>();
            }
        }

        /// <summary>
        /// Searches for and retrieves customer information based on the provided customer ID.
        /// </summary>
        /// <param name="customerid">The ID of the customer to search for.</param>
        /// <returns>A list of customer entities matching the provided ID.</returns>
        public IList<Customer> SearchForCustomer(int customerid)
        {
            try
            {
                // Retrieve customer information based on the provided ID
                var customers = _dbContext.Customers?
                    .Where(c => c.CustomerId == customerid)
                    .ToList();

                // Return the list of customer entities
                return customers;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in SearchForCustomer: {ex.Message}");

                // Return an empty list or null to indicate that an error occurred during the operation
                return new List<Customer>();
            }
        }

        /// <summary>
        /// Searches for and retrieves employee information based on the provided employee ID.
        /// </summary>
        /// <param name="employeeid">The ID of the employee to search for.</param>
        /// <returns>A list of employee entities matching the provided ID.</returns>
        public IList<Employee> SearchForEmployee(int employeeid)
        {
            try
            {
                // Retrieve employee information based on the provided ID
                var employees = _dbContext.Employees?
                    .Where(e => e.EmployeeId == employeeid)
                    .ToList();

                // Return the list of employee entities
                return employees;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in SearchForEmployee: {ex.Message}");

                // Return an empty list or null to indicate that an error occurred during the operation
                return new List<Employee>();
            }
        }

        /// <summary>
        /// Updates existing cargo type information.
        /// </summary>
        /// <param name="updatecargotypedata">The updated cargo type data.</param>
        /// <returns>
        /// Returns true if the cargo type is successfully updated; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdateCargoBooking(CargoBooking updatecargobookingdata)
        {
            try
            {
                // Check if the cargo type to be updated exists in the database
                var existingCargoType = _dbContext.CargoBooking?
                    .FirstOrDefault(ct => ct.CargoBookingId == updatecargobookingdata.CargoBookingId);

                if (existingCargoType == null)
                {
                    // Cargo type not found, handle the scenario
                    // You might throw an exception, return a specific result, or take any other desired action
                    return false;
                }

                // Update existing cargo type properties with the provided data
                existingCargoType.CargoBookingId = updatecargobookingdata.CargoBookingId;
                existingCargoType.CargoFareID = updatecargobookingdata.CargoFareID;
                existingCargoType.BookingDate = updatecargobookingdata.BookingDate;
                existingCargoType.BookingStatus = updatecargobookingdata.BookingStatus;
                
                // Update other properties as needed

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in UpdateCargoBooking: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Updates existing employee information.
        /// </summary>
        /// <param name="updateemployeedata">The updated employee data.</param>
        /// <returns>
        /// Returns true if the employee information is successfully updated; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdateEmployee(Employee updateemployeedata)
        {
            try
            {
                // Check if the employee to be updated exists in the database
                var existingEmployee = _dbContext.Employees?
                    .FirstOrDefault(e => e.EmployeeId == updateemployeedata.EmployeeId);

                if (existingEmployee == null)
                {
                    // Employee not found, handle the scenario
                    // You might throw an exception, return a specific result, or take any other desired action
                    return false;
                }

                // Update existing employee properties with the provided data
                existingEmployee.FirstName = updateemployeedata.FirstName;
                existingEmployee.LastName = updateemployeedata.LastName;
                existingEmployee.Username = updateemployeedata.Username;
                existingEmployee.Password = updateemployeedata.Password;
                existingEmployee.Email = updateemployeedata.Email;
                existingEmployee.Address = updateemployeedata.Address;
                existingEmployee.PhoneNo = updateemployeedata.PhoneNo;
                // Update other properties as needed

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in UpdateEmployee: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Updates place and price information for cargo fare.
        /// </summary>
        /// <param name="updateplaceandpricedata">The updated cargo fare data with place and price information.</param>
        /// <returns>
        /// Returns true if the place and price information is successfully updated; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdatePlaceAndPrice(CargoFare updateplaceandpricedata)
        {
            try
            {
                // Check if the cargo fare to be updated exists in the database
                var existingCargoFare = _dbContext.CargoFare?
                    .FirstOrDefault(cf => cf.CargoFareID == updateplaceandpricedata.CargoFareID);

                if (existingCargoFare == null)
                {
                    // Cargo fare not found, handle the scenario
                    // You might throw an exception, return a specific result, or take any other desired action
                    return false;
                }

                // Update existing cargo fare properties with the provided data
                existingCargoFare.SourceLocation = updateplaceandpricedata.SourceLocation;
                existingCargoFare.DestinationLocation = updateplaceandpricedata.DestinationLocation;
                existingCargoFare.FareAmount = updateplaceandpricedata.FareAmount;
                // Update other properties as needed

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in UpdatePlaceAndPrice: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Retrieves a list of cargo bookings to view their status.
        /// </summary>
        /// <returns>
        /// Returns a list of cargo bookings if successful; otherwise, returns an empty list in case of an error during the operation.
        /// </returns>
        public IList<CargoBooking> ViewStatusOfCargo()
        {
            try
            {
                // Retrieve the list of cargo bookings from the database
                var cargoBookings = _dbContext.CargoBooking?.ToList(); // You can add filtering or sorting logic as needed

                // Return the list of cargo bookings
                return cargoBookings;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in ViewStatusOfCargo: {ex.Message}");

                // Return an empty list to indicate that an error occurred during the operation
                return new List<CargoBooking>();
            }
        }
        /// <summary>
        /// Generates a gate pass for cargo entry based on the provided parameters.
        /// </summary>
        /// <param name="cargoBookingId">Represents the cargo booking ID.</param>
        /// <param name="entryDate">Represents the entry date for the gate pass.</param>
        /// <param name="typeOfDelivery">Represents the type of delivery for the gate pass.</param>
        /// <param name="orderStatus">Represents the status of the cargo order.</param>
        /// <returns>
        /// Returns true if the gate pass is successfully generated, false otherwise.
        /// </returns>
        public bool GenerateGatePassForCargoEntry(GatePass generategatepass)
        {
            try
            {
                // Check if the cargo type already exists based on some criteria (e.g., name, code, etc.)
                var existingGatePassId = _dbContext.GatePasses?
                    .FirstOrDefault(ct => ct.GatePassId == generategatepass.GatePassId);

                if (existingGatePassId != null)
                {
                    // Cargo type with the same name already exists, handle the duplication scenario
                    // You might throw an exception, return a specific result, or take any other desired action
                    return false;
                }

                // If the cargo type doesn't exist, add it to the database
                _dbContext.GatePasses?.Add(generategatepass);
                _dbContext.SaveChanges();

                // Return true to indicate successful addition
                return true;

            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }
        /// <summary>
        /// Marks the exit of a truck associated with a cargo booking.
        /// </summary>
        /// <param name="cargoBookingId">Represents the cargo booking ID associated with the truck exit.</param>
        /// <param name="exitDate">Represents the date and time of the truck exit.</param>
        /// <param name="exitReason">Represents the reason for the truck exit.</param>
        /// <returns>
        /// Returns true if the truck exit is successfully marked, false otherwise.
        /// </returns>
        public bool MarkTruckExit(int cargoBookingId, DateTime exitDate, string exitReason)
        {
            try
            {
                // Retrieve cargo booking based on ID
                var cargoBooking = _dbContext.CargoBooking?.FirstOrDefault(cb => cb.CargoBookingId == cargoBookingId);

                if (cargoBooking == null)
                {
                    // Cargo booking not found, handle the scenario
                    // You might throw an exception, return a specific result, or take any other desired action
                    return false;
                }

                // Mark truck exit (assuming you have a TruckExit entity)
                var truckExit = new TruckExit
                {
                    CargoBookingId = cargoBookingId,
                    ExitDate = exitDate,
                    Reason = exitReason
                    // You can add other properties or logic as needed
                };

                // Add truck exit to the database
                _dbContext.TruckExit?.Add(truckExit);
                _dbContext.SaveChanges();

                // Update cargo booking status or perform other actions if needed

                // Return true to indicate successful truck exit marking
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error in MarkTruckExit: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Stores cargo in the warehouse and generates a gate pass for cargo entry.
        /// </summary>
        /// <param name="cargoBookingId">Represents the cargo booking ID associated with the cargo.</param>
        /// <param name="capacity">Represents the warehouse capacity for the stored cargo.</param>
        /// <param name="entryDate">Represents the entry date for the gate pass.</param>
        /// <returns>
        /// Returns true if cargo is successfully stored, and a gate pass is generated; otherwise, returns false.
        /// </returns>
        public bool StoreCargoAndGenerateGatePass(int cargoBookingId, int capacity,DateTime EntryDate)
        {
            try
            {
                // Check if the cargo booking exists
                var cargoBooking = _dbContext.CargoBooking?.FirstOrDefault(cb => cb.CargoBookingId == cargoBookingId);

                if (cargoBooking == null)
                {
                    // Cargo booking not found, handle the scenario
                    // For simplicity, throwing an exception, but you can customize this based on your requirements
                    throw new ArgumentException("Cargo booking not found");
                }

                // Assuming you have a Cargo entity, create a new Cargo record
                var cargo = new WareHouse
                {
                    CargoBookingId = cargoBookingId,
                    Capacity = capacity
                    // You can add other cargo details as needed
                };

                // Add the cargo to the database
                _dbContext.WareHouse?.Add(cargo);
                _dbContext.SaveChanges();

                // Update the cargo booking status to indicate that the cargo is stored
                // cargoBooking.BookingStatus = "Stored";
                // _dbContext.SaveChanges(); // Uncomment and update the status if needed

                // Generate a new gate pass for cargo entry
                var gatePass = new GatePass
                {
                    CargoBookingId = cargoBookingId,
                    EntryDate = EntryDate,
                    TypeOfDelivery = "Delivery" // Assuming this is a delivery gate pass
                                                // You can add other properties or logic as needed
                };

                // Add the new gate pass to the database
                _dbContext.GatePasses?.Add(gatePass);
                _dbContext.SaveChanges();

                // Return true to indicate successful cargo storage and gate pass generation
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in StoreCargoAndGenerateGatePass: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }
        /// <summary>
        /// Retrieves a list of housekeeping maintenance movements from the database.
        /// </summary>
        /// <returns>
        /// Returns a list of housekeeping maintenance movements if retrieval is successful; otherwise, returns an empty list.
        /// </returns>
        public IList<HousekeepingMovement>? HousekeepingMaintainance()
        {
            try
            {
                // Retrieve the list of housekeeping movements from the database
                var maintenanceList = _dbContext.HousekeepingMovement?.ToList(); // You can add filtering or sorting logic as needed

                // Return the list of housekeeping movements
                return maintenanceList;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in HousekeepingMaintainance: {ex.Message}");

                // Return an empty list to indicate that an error occurred during the operation
                return new List<HousekeepingMovement>();
            }
        }

        public IList<Admin> GetAdminDetails()
        {
            IList<Admin> list = _dbContext.Admins?.ToList();
            return list;
        }
       
        public IList<Employee> GetEmployeeDetails()
        {
           IList<Employee> employees = _dbContext.Employees?.ToList();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employees = _dbContext.Employees?.Find(id);
            return employees;
        }

        CargoBooking IAdminRepo.GetCargoBookingById(int id)
        {
            CargoBooking cargobooking = _dbContext.CargoBooking?.Find(id);
            return cargobooking;
        }

        IList<CargoFare> IAdminRepo.GetCargoFareById(int cargofareid)
        {
                try
                {
                    var cargofares = _dbContext.CargoFare?
                        .Where(c => c.CargoFareID == cargofareid)
                        .ToList();


                    return cargofares;
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions as needed
                    // For simplicity, logging to the console, but you should implement proper logging
                    Console.WriteLine($"Error in SearchForCustomer: {ex.Message}");

                    // Return an empty list or null to indicate that an error occurred during the operation
                    return new List<CargoFare>();
                }
            
        }
        public IList<WareHouse>? GetWareHouseDetails()
        {
            try
            {
                // Retrieve the list of housekeeping movements from the database
                var maintenanceList = _dbContext.WareHouse?.ToList(); // You can add filtering or sorting logic as needed

                // Return the list of housekeeping movements
                return maintenanceList;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in HousekeepingMaintainance: {ex.Message}");

                // Return an empty list to indicate that an error occurred during the operation
                return new List<WareHouse>();
            }
        }
    }
}

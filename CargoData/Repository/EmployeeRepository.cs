using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoData.DataContext;
using CargoEntity;
using Microsoft.EntityFrameworkCore;

namespace CargoData.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        private readonly CargoDbContext _dbContext;
        public EmployeeRepository(CargoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Searches and retrieves cargo fare information based on the provided cargo fare ID.
        /// </summary>
        /// <param name="cargofareid">The ID of the cargo fare to search for.</param>
        /// <returns>
        /// Returns a list of cargo fares that match the provided cargo fare ID if successful; otherwise, returns an empty list in case of an error during the operation.
        /// </returns>
        public CargoFare SearchForCargoFare(int cargofareid)
        {
            return _dbContext.CargoFare?.FirstOrDefault(c => c.CargoFareID == cargofareid);
        }

        /// <summary>
        /// Searches and retrieves customer information based on the provided customer ID.
        /// </summary>
        /// <param name="customerid">The ID of the customer to search for.</param>
        /// <returns>
        /// Returns a list of customers that match the provided customer ID if successful; otherwise, returns an empty list in case of an error during the operation.
        /// </returns>
        public IList<Customer> SearchForCustomer(int customerid)
        {
            try
            {
                // Search for customer based on the provided customer ID
                var matchingCustomers = _dbContext.Customers?
                    .Where(c => c.CustomerId == customerid)
                    .ToList();

                // Return the list of matching customers
                return matchingCustomers;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in SearchForCustomer: {ex.Message}");

                // Return an empty list to indicate that an error occurred during the operation
                return new List<Customer>();
            }
        }

        /// <summary>
        /// Searches and retrieves cargo orders based on the provided customer ID.
        /// </summary>
        /// <param name="customerid">The ID of the customer for whom to search for orders.</param>
        /// <returns>
        /// Returns a list of cargo orders that match the provided customer ID if successful; otherwise, returns an empty list in case of an error during the operation.
        /// </returns>
        public IList<CargoOrder> SearchForOrder(int customerid)
        {
            try
            {
                // Search for cargo orders based on the provided customer ID
                var matchingOrders = _dbContext.CargoOrders?
                    .Where(co => co.CustomerId == customerid)
                    .ToList();

                // Return the list of matching cargo orders
                return matchingOrders;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                // For simplicity, logging to the console, but you should implement proper logging
                Console.WriteLine($"Error in SearchForOrder: {ex.Message}");

                // Return an empty list to indicate that an error occurred during the operation
                return new List<CargoOrder>();
            }
        }

        /// <summary>
        /// Updates existing cargo type information.
        /// </summary>
        /// <param name="updatedCargoTypeData">The updated cargo type data.</param>
        /// <returns>
        /// Returns true if the update is successful; otherwise, returns false in case of an error during the operation.
        /// </returns>
        //public bool UpdateCargoOrderById(CargoOrder updatedCargoOrderData)
        //{
        //    try
        //    {
        //        // Check if the cargo type with the specified ID exists in the database
        //        var existingCargoType = _dbContext.CargoOrders?
        //            .FirstOrDefault(ct => ct.CargoOrderId == updatedCargoOrderData.CargoOrderId);

        //        if (existingCargoType == null)
        //        {
        //            // Cargo type with the specified ID does not exist, return false
        //            return false;
        //        }

        //        // Update the existing cargo type properties with the new data
        //        existingCargoType.CargoOrderId= updatedCargoorderData.CargoOrderId;
        //        existingCargoType.CustomerId = updatedCargoorderData.CustomerId;
        //        existingCargoType.CargoTypeId = updatedCargoorderData.CargoTypeId;
        //        existingCargoType.OrderDate = updatedCargoorderData.OrderDate;
        //        existingCargoType.Status = updatedCargoorderData.Status;
        //        existingCargoType.Location= updatedCargoorderData.Location;
        //        // Update other properties as needed

        //        // Save changes to the database
        //        _dbContext.SaveChanges();

        //        // Return true to indicate successful update
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exceptions as needed
        //        // For simplicity, logging to the console, but you should implement proper logging
        //        Console.WriteLine($"Error in UpdateCargoType: {ex.Message}");

        //        // Return false to indicate that an error occurred during the operation
        //        return false;
        //    }
        //}

        /// <summary>
        /// Updates existing customer information.
        /// </summary>
        /// <param name="updatedCustomerData">The updated customer data.</param>
        /// <returns>
        /// Returns true if the update is successful; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdateCustomer(Customer updatedCustomerData)
        {
            try
            {
                // Check if the customer with the specified ID exists in the database
                var existingCustomer = _dbContext.Customers?
                    .FirstOrDefault(c => c.CustomerId == updatedCustomerData.CustomerId);

                if (existingCustomer == null)
                {
                    // Customer with the specified ID does not exist, return false
                    return false;
                }

                // Update the existing customer properties with the new data
                existingCustomer.FirstName = updatedCustomerData.FirstName;
                existingCustomer.LastName = updatedCustomerData.LastName;
                existingCustomer.Email = updatedCustomerData.Email;
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
                Console.WriteLine($"Error in UpdateCustomer: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Update places information for a cargo order.
        /// </summary>
        /// <param name="updatedPlaceData">The updated place data for the cargo order.</param>
        /// <returns>
        /// Returns true if the update is successful; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdatePlaces(CargoOrder updatedPlaceData)
        {
            try
            {
                // Check if the cargo order with the specified ID exists in the database
                var existingCargoOrder = _dbContext.CargoOrders?
                    .FirstOrDefault(co => co.CargoOrderId == updatedPlaceData.CargoOrderId);

                if (existingCargoOrder == null)
                {
                    // Cargo order with the specified ID does not exist, return false
                    return false;
                }

                // Update the existing cargo order properties with the new place data
                existingCargoOrder.Location = updatedPlaceData.Location;
                // Update other place-related properties as needed

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error in UpdatePlaces: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Update self-record information for an employee.
        /// </summary>
        /// <param name="updatedEmployeeData">The updated employee data.</param>
        /// <returns>
        /// Returns true if the update is successful; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdateSelfRecord(Employee updatedEmployeeData)
        {
            try
            {
                // Check if the employee with the specified ID exists in the database
                var existingEmployee = _dbContext.Employees?
                    .FirstOrDefault(e => e.EmployeeId == updatedEmployeeData.EmployeeId);

                if (existingEmployee == null)
                {
                    // Employee with the specified ID does not exist, return false
                    return false;
                }

                // Update the existing employee properties with the new data
                existingEmployee.FirstName = updatedEmployeeData.FirstName;
                existingEmployee.LastName = updatedEmployeeData.LastName;
                // Update other properties as needed

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error in UpdateSelfRecord: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        bool IEmployeeRepo.AddCargoOrder(CargoOrder insertcargoorders)
        {
            _dbContext.CargoOrders?.Add(insertcargoorders);
            _dbContext.SaveChanges();
            return true;
        }

        CargoOrder IEmployeeRepo.GetCargoOrderById(int id)
        {
            CargoOrder orders = _dbContext.CargoOrders?.Find(id);
            return orders;
        }

        public bool UpdateCargoOrder(CargoOrder updatedCargoOrderData)
        {
            try
            {
                // Check if the cargo type with the specified ID exists in the database
                var existingCargoType = _dbContext.CargoOrders?
                    .FirstOrDefault(ct => ct.CargoOrderId == updatedCargoOrderData.CargoOrderId);

                if (existingCargoType == null)
                {
                    // Cargo type with the specified ID does not exist, return false
                    return false;
                }

                // Update the existing cargo type properties with the new data
                existingCargoType.CargoOrderId = updatedCargoOrderData.CargoOrderId;
                existingCargoType.CustomerId = updatedCargoOrderData.CustomerId;
                existingCargoType.CargoTypeId = updatedCargoOrderData.CargoTypeId;
                existingCargoType.OrderDate = updatedCargoOrderData.OrderDate;
                existingCargoType.Status = updatedCargoOrderData.Status;
                existingCargoType.Location = updatedCargoOrderData.Location;
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
                Console.WriteLine($"Error in UpdateCargoType: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        bool IEmployeeRepo.DeleteCargoOrder(int cargoorderid)
        {
             CargoOrder status=_dbContext.CargoOrders?.Find(cargoorderid);
            _dbContext.Remove(status);
            _dbContext.SaveChanges();
            return true;
        }





        //public IList<Employee> GetEmployeeDetails()
        //{
        //    IList<Employee> list = _dbContext.Employees?.ToList();
        //    return list;
        //}
    }

}

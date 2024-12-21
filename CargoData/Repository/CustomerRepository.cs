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
    public class CustomerRepository : ICustomerRepo
    {
        private readonly CargoDbContext _dbContext;
        public CustomerRepository(CargoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        /// <summary>
        /// Add a new customer to the system.
        /// </summary>
        /// <param name="newCustomerData">The data of the new customer to be added.</param>
        /// <returns>
        /// Returns true if the addition is successful; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool AddNewCustomer(Customer newCustomerData)
        {
            try
            {
                // Check if the customer with the specified ID or unique identifier already exists in the database
                var existingCustomer = _dbContext.Customers?
                    .FirstOrDefault(c => c.CustomerId == newCustomerData.CustomerId || c.Username == newCustomerData.Username);

                if (existingCustomer != null)
                {
                    // Customer with the specified ID or username already exists, handle the duplication scenario
                    // You might throw an exception, return a specific result, or take any other desired action
                    return false;
                }

                // If the customer doesn't exist, add it to the database
                _dbContext.Customers?.Add(newCustomerData);
                _dbContext.SaveChanges();

                // Return true to indicate successful addition
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error in AddNewCustomer: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// Update details of an existing customer in the system.
        /// </summary>
        /// <param name="updatedCustomerData">The updated customer data.</param>
        /// <returns>
        /// Returns true if the update is successful; otherwise, returns false in case of an error during the operation.
        /// </returns>
        public bool UpdateCustomerDetails(Customer updatedCustomerData)
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
                // Update other properties as needed

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate successful update
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error in UpdateCustomerDetails: {ex.Message}");

                // Return false to indicate that an error occurred during the operation
                return false;
            }
        }

        /// <summary>
        /// View details of all orders placed by the customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer whose orders are to be retrieved.</param>
        /// <returns>
        /// Returns a list of all orders placed by the customer.
        /// </returns>
        public IList<CargoOrder> ViewAllOrders(int customerId)
        {
            try
            {
                // Retrieve all orders placed by the specified customer
                var customerOrders = _dbContext.CargoOrders?
                    .Where(co => co.CustomerId == customerId)
                    .ToList();

                return customerOrders;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error in ViewAllOrders: {ex.Message}");

                // Return an empty list or handle the error as per your requirements
                return new List<CargoOrder>();
            }
        }

        public IList<Customer> GetCustomersDetails()
        {
            IList<Customer> list = _dbContext.Customers?.ToList();
            return list;
        }
        public Customer? GetCustomerById(int customerId)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}

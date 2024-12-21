using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoEntity;

namespace CargoData.Repository
{
    /// <summary>
    /// Interface defining operations related to customer tasks in the Cargo Manager System.
    /// </summary>
    public interface ICustomerRepo
    {
        /// <summary>
        /// Adds a new customer to the system.
        /// </summary>
        /// <param name="newCustomerData">The data of the new customer to be added.</param>
        /// <returns>True if the addition is successful; otherwise, false.</returns>
        bool AddNewCustomer(Customer newCustomerData);

        /// <summary>
        /// Updates customer details.
        /// </summary>
        /// <param name="updatedCustomerData">The data for updating customer details.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdateCustomerDetails(Customer updatedCustomerData);

        /// <summary>
        /// Views details of all orders placed by the customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer whose orders are to be viewed.</param>
        /// <returns>A list of cargo orders representing the details of all orders placed by the customer.</returns>
        IList<CargoOrder> ViewAllOrders(int customerId);

        IList<Customer> GetCustomersDetails();

        Customer? GetCustomerById(int customerId);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoEntity;

namespace CargoData.Repository
{
    /// <summary>
    /// Interface defining operations related to employee tasks in the Cargo Manager System.
    /// </summary>
    public interface IEmployeeRepo
    {
        /// <summary>
        /// Updates self-record on the Cargo Manager System.
        /// </summary>
        /// <param name="updatedEmployeeData">The data for updating employee's own record.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdateSelfRecord(Employee updatedEmployeeData);

        /// <summary>
        /// Searches for customers based on provided criteria.
        /// </summary>
        /// <param name="customerid">The ID of the customer to be searched.</param>
        /// <returns>A list of customer data matching the search criteria.</returns>
        IList<Customer> SearchForCustomer(int customerid);

        /// <summary>
        /// Searches for cargo fare based on provided criteria.
        /// </summary>
        /// <param name="cargofareid">The ID of the cargo fare to be searched.</param>
        /// <returns>A list of cargo fare data matching the search criteria.</returns>
        CargoFare SearchForCargoFare(int cargofareid);

        /// <summary>
        /// Searches for orders based on provided criteria.
        /// </summary>
        /// <param name="cargobookingid">The ID of the cargo booking order to be searched.</param>
        /// <returns>A list of cargo booking data matching the search criteria.</returns>
        IList<CargoOrder> SearchForOrder(int customerid);

        /// <summary>
        /// Updates cargo type information.
        /// </summary>
        /// <param name="updatedCargoTypeData">The data for updating cargo type information.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdateCargoOrder(CargoOrder updatedCargoOrderData);

        /// <summary>
        /// Updates places information.
        /// </summary>
        /// <param name="updatedPlaceData">The data for updating place information.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdatePlaces(CargoOrder updatedPlaceData);

        /// <summary>
        /// Updates customer information.
        /// </summary>
        /// <param name="updatedCustomerData">The data for updating customer information.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        bool UpdateCustomer(Customer updatedCustomerData);

        //IList<Employee> GetEmployeeDetails();

        bool AddCargoOrder(CargoOrder insertcargoorders);

        CargoOrder GetCargoOrderById(int id);

        bool DeleteCargoOrder(int cargoorderid);

    }

}

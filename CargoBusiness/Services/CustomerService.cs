using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoData.Repository;
using CargoEntity;

namespace CargoBusiness.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public bool AddNewCustomer(Customer newCustomerData)
        {
            bool status = _customerRepo.AddNewCustomer(newCustomerData);
            return status;
        }
        public bool UpdateCustomerDetails(Customer updatedCustomerData)
        {
            bool status = _customerRepo.UpdateCustomerDetails(updatedCustomerData);
            return status;
        }
        public IList<CargoOrder> ViewAllOrders(int customerId)
        {
            return _customerRepo.ViewAllOrders(customerId);
        }

        public IList<Customer> GetCustomerDetails()
        {
            return _customerRepo.GetCustomersDetails();
        }
        public Customer? GetCustomerById(int customerId)
        {
            return _customerRepo.GetCustomerById(customerId);
        }
    }
}

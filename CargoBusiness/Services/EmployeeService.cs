using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoData.Repository;
using CargoEntity;

namespace CargoBusiness.Services
{
    public class EmployeeService
    {
        public readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public CargoFare SearchForCargoFare(int cargofareid)
        {
            return _employeeRepo.SearchForCargoFare(cargofareid);
        }
        public IList<Customer> SearchForCustomer(int customerid)
        {
            return _employeeRepo.SearchForCustomer(customerid);
        }
        public IList<CargoOrder> SearchForOrder(int customerid)
        {
            return _employeeRepo.SearchForOrder(customerid);
        }
        public bool UpdateCargoOrderById(CargoOrder updatedCargoOrderData)
        {
            bool status = _employeeRepo.UpdateCargoOrder(updatedCargoOrderData);
            return status;
        }
        public bool UpdateCustomer(Customer updatedCustomerData)
        {
            bool status = _employeeRepo.UpdateCustomer(updatedCustomerData);
            return status;
        }
        public bool UpdatePlaces(CargoOrder updatedPlaceData)
        {
            bool status = _employeeRepo.UpdatePlaces(updatedPlaceData);
            return status;
        }
        public bool UpdateSelfRecord(Employee updatedEmployeeData)
        {
            bool status = _employeeRepo.UpdateSelfRecord(updatedEmployeeData);
            return status;
        }
        //public IList<Employee> GetEmployeesDeatails()
        //{
        //     return _employeeRepo.GetEmployeeDetails();
           
            
        //}
        public bool AddCargoOrders(CargoOrder insertcargoorders)
        {
            bool status = _employeeRepo.AddCargoOrder(insertcargoorders);
            return status;
        }
        public CargoOrder GetCargoOrderById(int id)
        {
            return (_employeeRepo.GetCargoOrderById(id));
        }

        public bool DeleteCargoOrderById(int cargoorderId) {
        _employeeRepo.DeleteCargoOrder(cargoorderId);
            return true;
        }
    }
}

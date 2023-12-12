using ModalLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBusiness
    {
        void AddEmployee(EmployeeModel employee);
        IEnumerable<EmployeeModel> GetAllEmployees();
        void UpdateEmployee(EmployeeModel employee);
        void DeleteEmployee(int id);
       EmployeeModel GetEmployee(int id);
        EmployeeModel LoginEmployee(LoginModel login);

        IEnumerable<EmployeeModel> GetEmployeeByName(string name);
    }
}
using ModalLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRepo
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
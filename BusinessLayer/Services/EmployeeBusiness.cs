using BusinessLayer.Interfaces;
using ModalLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepo repo;
        public EmployeeBusiness(IEmployeeRepo repo)
        {
            this.repo = repo;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            repo.AddEmployee(employee);
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return repo.GetAllEmployees();
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            repo.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            repo.DeleteEmployee(id);
        }
        public EmployeeModel GetEmployee(int id)
        {
            return repo.GetEmployee(id);
        }
        public EmployeeModel LoginEmployee(LoginModel login)
        {
            return repo.LoginEmployee(login);
        }


    }
}

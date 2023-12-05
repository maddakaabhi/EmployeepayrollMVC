using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModalLayer.Models;
using System;
using System.Security.Cryptography;

namespace EmployeePayrollApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBusiness business;
        public EmployeeController(IEmployeeBusiness business)
        {
            this.business = business;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var result = business.GetAllEmployees();
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]

        public IActionResult AddEmployee([Bind] EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    business.AddEmployee(employee);
                    return RedirectToAction("GetAllEmployees");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            try
            {
                var result = business.GetEmployee(id);
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult EditEmployee([Bind] EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    business.UpdateEmployee(employee);
                    return RedirectToAction("GetAllEmployees");
                }
                return View(employee);
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = business.GetEmployee(id);
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult Delete([Bind] int id)
        {
            try
            {
                business.DeleteEmployee(id);
                return RedirectToAction("GetAllEmployees");
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var result = business.GetEmployee(id);
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

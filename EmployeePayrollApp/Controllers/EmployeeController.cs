using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModalLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                IEnumerable<int> employees = result.Select(x=>x.employeeID);
                // ViewData["empid"]=new List<string>() { "Hi","Hello","what"};
                //IList<string> studentList = new List<String>();
                //studentList.Add( "Bill" );
                //studentList.Add("Steve" );
                //studentList.Add( "Ram" );

                //TempData["students"] = studentList;
                //TempData["Employee"]=employees;
               //return RedirectToAction("Index", "Home");
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
                ViewBag.Department = new List<string>() { "IT", "Assistant", "HR", "politician" };
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
                ViewBag.Department = new List<string>() { "IT", "Assistant", "HR", "politician" };
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
                ViewBag.Department = new List<string>() { "IT", "Assistant", "HR", "politician" };
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
                ViewBag.Department = new List<string>() { "IT", "Assistant", "HR", "politician" };
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
                id = (int)HttpContext.Session.GetInt32("EmpId");
                var result = business.GetEmployee(id);
                return View(result);
               
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        
        public IActionResult LoginMethod()
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

        public IActionResult LoginMethod(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid) {
                    EmployeeModel employee = business.LoginEmployee(login);
                    HttpContext.Session.SetInt32("EmpId", employee.employeeID);
                    return RedirectToAction("GetEmployee");
                    //string url = "GetEmployee/" + employee.employeeID;
                    //return Redirect(url.ToString());
                    
                }
                return View(login);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

    }
}

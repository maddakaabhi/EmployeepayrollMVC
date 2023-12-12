using ModalLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private string connectionString = "Server=LAPTOP-JDE1S40N\\SQLEXPRESS;Database=EmployeePayRollDB;Integrated Security=true";


        public void AddEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@profileimage", employee.profileimage);
                cmd.Parameters.AddWithValue("@Gender", employee.gender);
                cmd.Parameters.AddWithValue("@department", employee.department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startdate", employee.StartDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.employeeID = Convert.ToInt32(reader["EmployeeId"]);
                    employee.name = reader.GetValue(1).ToString();
                    employee.profileimage = reader.GetValue(2).ToString();
                    employee.gender = reader.GetValue(3).ToString();
                    employee.department = reader.GetValue(4).ToString();
                    employee.salary = Convert.ToInt32(reader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employee.notes = reader["Notes"].ToString();

                    list.Add(employee);


                }
                con.Close();

            }
            return list;

        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_updateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", employee.employeeID);
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@profileimage", employee.profileimage);
                cmd.Parameters.AddWithValue("@Gender", employee.gender);
                cmd.Parameters.AddWithValue("@department", employee.department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startdate", employee.StartDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_deleteemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public EmployeeModel GetEmployee(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from employeepayroll where EmployeeId=" + id, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                EmployeeModel employee = new EmployeeModel();
                while (reader.Read())
                {

                    employee.employeeID = Convert.ToInt32(reader["EmployeeId"]);
                    employee.name = reader.GetValue(1).ToString();
                    employee.profileimage = reader.GetValue(2).ToString();
                    employee.gender = reader.GetValue(3).ToString();
                    employee.department = reader.GetValue(4).ToString();
                    employee.salary = Convert.ToInt32(reader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employee.notes = reader["Notes"].ToString();

                }
                return employee;
                con.Close ();
            }

        }

        public EmployeeModel LoginEmployee(LoginModel login)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", login.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", login.LoginName);

                con.Open();
                EmployeeModel employee = new EmployeeModel();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //employee.employeeID = reader.IsDBNull("EmployeeId") ? 0 : Convert.ToInt32(reader["EmployeeId"]);
                    //employee.name = reader.IsDBNull("Name") ? null : reader["Name"].ToString();
                    //employee.profileimage = reader.IsDBNull("ProfileImage") ? null : reader["ProfileImage"].ToString();
                    //employee.gender = reader.IsDBNull("Gender") ? null : reader["Gender"].ToString();
                    //employee.department = reader.IsDBNull("Department") ? null : reader["Department"].ToString();
                    //employee.salary = reader.IsDBNull("Salary") ? 0 : Convert.ToInt32(reader["Salary"]);
                    //employee.StartDate = reader.IsDBNull("StartDate") ? DateTime.Now : Convert.ToDateTime(reader["StartDate"]);
                    //employee.notes = reader.IsDBNull("Notes") ? null : reader["Notes"].ToString();

                    employee.employeeID = Convert.ToInt32(reader["EmployeeId"]);
                    employee.name =  reader["Name"].ToString();
                    employee.profileimage = reader["ProfileImage"].ToString();
                    employee.gender =  reader["Gender"].ToString();
                    employee.department =  reader["Department"].ToString();
                    employee.salary = Convert.ToInt32(reader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employee.notes =  reader["Notes"].ToString();
                }
                return employee;
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeeByName(string name) 
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("Sp_GetName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Name", name);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.employeeID = Convert.ToInt32(reader["EmployeeId"]);
                    employee.name = reader.GetValue(1).ToString();
                    employee.profileimage = reader.GetValue(2).ToString();
                    employee.gender = reader.GetValue(3).ToString();
                    employee.department = reader.GetValue(4).ToString();
                    employee.salary = Convert.ToInt32(reader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employee.notes = reader["Notes"].ToString();

                    employees.Add(employee);
                }
                con.Close();
            }
            return employees;
        }
    }
}


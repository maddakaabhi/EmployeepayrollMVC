﻿using ModalLayer.Models;
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
            }

        }
    }
}

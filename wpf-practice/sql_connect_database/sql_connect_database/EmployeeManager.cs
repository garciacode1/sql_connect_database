using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace sql_connect_database
{
    public class EmployeeManager
    {
        const string connectionString = "server=localhost;user=root;password=;port=3306;database=jdgj_ictprg431";


        public List<Employee> ShowAllEmployees()
        {   
            List <Employee> employees = new List <Employee> ();

            
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string loademployees = "SELECT * FROM employees;";
            using MySqlCommand command = new MySqlCommand (loademployees, connection);
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                int id = Convert.ToInt32(reader["id"]);
                string firstName = (string)(reader["given_name"]);
                string familyName = (string)(reader["family_name"]);
                DateTime dob = Convert.ToDateTime(reader["date_of_birth"]);
                string genderIdentity = (string)(reader["gender_identity"]);
                int grossSalary = Convert.ToInt32(reader["gross_salary"]);
                int supervisorId = Convert.ToInt32(reader["supervisor_id"]);
                int branchId = Convert.ToInt32(reader["branch_id"]);

                Employee employee = new Employee(id, firstName, familyName, dob, genderIdentity, grossSalary, supervisorId, branchId);

                employees.Add(employee);

            }

            return employees;

        
        }  
        public void AddEmployee(Employee employee)  //Method to Add an employee 
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string addemployeesql = @"INSERT INTO employees (given_name, family_name, date_of_birth, gender_identity, gross_salary, supervisor_id, branch_id)"+
                                      "VALUES (@GivenName, @FamilyName, @DateOfBirth, @Gender, @GrossSalary, @SupervisorID, @BranchID)";
        
        
               using MySqlCommand cmd = new MySqlCommand(addemployeesql,connection );
               cmd.Parameters.AddWithValue("@GivenName", employee.GivenName);
               cmd.Parameters.AddWithValue("@FamilyName", employee.FamilyName);
               cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateofBirth);
               cmd.Parameters.AddWithValue("@Gender", employee.GenderIdentity);
               cmd.Parameters.AddWithValue("@GrossSalary", employee.GrossSalary);
               cmd.Parameters.AddWithValue("@SupervisorID", employee.SupervisorID);
               cmd.Parameters.AddWithValue("@BranchID", employee.BranchID);

               cmd.ExecuteNonQuery();

            connection.Close();



        }
        public void DeleteEmployee(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string deletesql = "DELETE FROM employees WHERE id = @Id;";

            using MySqlCommand cmd = new MySqlCommand(deletesql, connection);

            cmd.Parameters.AddWithValue("@Id", id);


            cmd.ExecuteNonQuery();


            connection.Close();

        }
        public List<Employee> ShowHigherSalary()
        {
           List<Employee> employees = new List<Employee>();
            using MySqlConnection connection = new MySqlConnection( connectionString);
            connection.Open();

            string highersalary = "SELECT * FROM employees Where gross_salary >70000";
            
            using MySqlCommand cmd = new MySqlCommand(highersalary, connection);
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int id = Convert.ToInt32(reader["id"]);
                string firstName = (string)(reader["given_name"]);
                string familyName = (string)(reader["family_name"]);
                DateTime dob = Convert.ToDateTime(reader["date_of_birth"]);
                string genderIdentity = (string)(reader["gender_identity"]);
                int grossSalary = Convert.ToInt32(reader["gross_salary"]);
                int supervisorId = Convert.ToInt32(reader["supervisor_id"]);
                int branchId = Convert.ToInt32(reader["branch_id"]);

                Employee employee = new Employee(id, firstName, familyName, dob, genderIdentity, grossSalary, supervisorId, branchId);

                employees.Add(employee);

            }

            return employees;














        }


    }   
    
}

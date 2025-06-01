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


        public List<Employee> LoadEmployees()
        {   
            List <Employee> employees = new List <Employee> ();

            
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string loademployees = "SELECT * FROM employees;";





          /*string insertSql = @"INSERT INTO employees 
                (given_name, family_name, branch_id, date_of_birth, gross_salary, gender_identity, supervisor_id) 
                VALUES 
                (@GivenName, @FamilyName, @BranchId, @DateOfBirth, @GrossSalary, @Gender, @SupervisorId)";


              command.ExecuteNonQuery();

            using MySqlCommand command = new MySqlCommand(insertSql, connection);

            //command.Parameters.AddWithValue("@GivenName", )
          

              string sql3 = "SELECT * FROM employees;";
            command2.CommandText = sql3;
            MySqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                
                int id = Convert.ToInt32(reader["id"]);
                string firstName = (string)reader["given_name"];
                string familyName = (string)reader["family_name"];
                int branch_id = Convert.ToInt32(reader["branch_id"]);
                DateTime dob = Convert.ToDateTime(reader["date_of_birth"]);
                
               
                MessageBox.Show(firstName + " " + familyName + " (" + dob.ToString("d") +")" );
            }*/



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


    }   
    
}

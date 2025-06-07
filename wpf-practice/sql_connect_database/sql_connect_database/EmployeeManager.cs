using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
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

            string addemployeesql = @"INSERT INTO employees (given_name, family_name, date_of_birth, gender_identity, gross_salary, supervisor_id, branch_id)" +
                                      "VALUES (@GivenName, @FamilyName, @DateOfBirth, @Gender, @GrossSalary, @SupervisorID, @BranchID); SELECT LAST_INSERT_ID();";


            using MySqlCommand cmd = new MySqlCommand(addemployeesql, connection);
            cmd.Parameters.AddWithValue("@GivenName", employee.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", employee.FamilyName);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateofBirth);
            cmd.Parameters.AddWithValue("@Gender", employee.GenderIdentity);
            cmd.Parameters.AddWithValue("@GrossSalary", employee.GrossSalary);
            cmd.Parameters.AddWithValue("@SupervisorID", employee.SupervisorID);
            cmd.Parameters.AddWithValue("@BranchID", employee.BranchID);

            int newId = Convert.ToInt32(cmd.ExecuteScalar());
            employee.ID=newId;
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
        public List<Employee> EmployeesByBranchId(int branchId)
        {
            List<Employee> employees = new List<Employee>();
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string employeesbybranch = "SELECT * FROM employees WHERE branch_id = @branchId";
            using MySqlCommand cmd = new MySqlCommand(employeesbybranch, connection);
            cmd.Parameters.AddWithValue("@branchId", branchId);

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
                int fetchedBranchId = Convert.ToInt32(reader["branch_id"]);


                Employee employee = new Employee(id, firstName, familyName, dob, genderIdentity, grossSalary, supervisorId, branchId);

                employees.Add(employee);

            }

            return employees;


        }
        public List<string> SearchSalesById(int Id)
        {
            List<string> employeeSalesList = new List<string>();                       //this list doesnt use the previoous employee list because the attributes are not the same, there are new attributes
                                                                                       //therefore, it wouldnot be an instance of the class Employee as the the previous functions created.  
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string salesbyid = @"SELECT employees.id, employees.given_name, employees.family_name, working_with.total_sales, working_with.client_id 
                                    FROM employees
                                    INNER JOIN working_with ON employees.id = working_with.employee_id WHERE employees.id = @Id;";

            using MySqlCommand cmd = new MySqlCommand(salesbyid, connection);
            cmd.Parameters.AddWithValue("@Id", Id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                int employeId = Convert.ToInt32(reader["id"]);
                string givenName = reader["given_name"].ToString();
                string familyName = reader["family_name"].ToString();
                int totalSales = Convert.ToInt32(reader["total_Sales"]);
                int client_id = Convert.ToInt32(reader["client_id"]);

                string result = $"ID:{employeId}, Employee:{givenName}{familyName}, Sales:{totalSales}, Client Id:{client_id}";
                employeeSalesList.Add(result);        
            
            }
            return employeeSalesList;










        }

     


    }   
    
}

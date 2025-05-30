using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace sql_connect_database
{
    public class EmployeeManager()
    {
        const string connectionString = "server=localhost;user=root;password=;port=3306;database=jdgj_ictprg431";
        public void LoadEmployees()
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertSql = @"INSERT INTO employees 
                (given_name, family_name, branch_id, date_of_birth, gross_salary, gender_identity, supervisor_id) 
                VALUES 
                (@GivenName, @FamilyName, @BranchId, @DateOfBirth, @GrossSalary, @Gender, @SupervisorId)";


            //command.ExecuteNonQuery();

            using MySqlCommand command = new MySqlCommand(insertSql, connection);

            command.Parameters.AddWithValue("@GivenName", )
          

            /*string sql3 = "SELECT * FROM employees;";
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
        public void AddEmployee()
    }    
    
}

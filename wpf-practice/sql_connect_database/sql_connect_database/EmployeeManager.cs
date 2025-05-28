using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace sql_connect_database
{
    public class EmployeeManager()
    {
        public void LoadEmployees()
        {
            string connectionString = "server=localhost;user=root;password=;port=3306;database=jdgj_ictprg431";
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = @"INSERT INTO employees(given_name, family_name, branch_id,date_of_birth)
                         VALUES('juan','garcia','2',now())";
                
            using MySqlCommand command = new MySqlCommand(sql, connection);
            //command.ExecuteNonQuery();
            string sql2 = "SELECT COUNT(*) FROM employees;";
            using MySqlCommand command2 = new MySqlCommand(sql2, connection);
            object result = command2.ExecuteScalar();
            MessageBox.Show(result.ToString());

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
            }
            
        }
    }
    
}

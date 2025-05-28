using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_connect_database
{
    public class Employee
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int BranchID { get; set; }
        
        
        
        
        
        public Employee(int id, string givenName, string familyName, DateTime dob, int branchID) 
        {
            this.ID = id;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.DateofBirth = dob;
            this.BranchID = branchID;



        }
    }

   


}


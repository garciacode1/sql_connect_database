using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_connect_database
{
    public class Employee      //class Employeee BLUEPRINT
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GenderIdentity { get; set; }
        public int GrossSalary { get; set; }
        public int SupervisorID {get; set;}
        public int BranchID { get; set; }
        
        
        
        
        
        
        public Employee(int id, string givenName, string familyName, DateTime dob, string genderIdentity, int grossSalary, int supervisorId, int branchId) //attributes of a instance of a class
        {
            this.ID = id;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.DateofBirth = dob;
            this.GenderIdentity = genderIdentity;
            this.GrossSalary = grossSalary;
            this.SupervisorID = supervisorId;
            this.BranchID = branchId;
            

        }
        public override string ToString() //ToString method  
        {
            return $"[{ID}], {GivenName}, {FamilyName}, (${GrossSalary}), [Branch:{BranchID}]";
             

        }
         



    }

   


}


using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sql_connect_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
     

        private void Bttn_Add_New_Employee_Click(object sender, RoutedEventArgs e) //click event to add employee
        {
            //read and also convert values

            //int id = Convert.ToInt32(Txt_Box_Id_Add_Employee.Text);
            string givenName = Txt_Box_Givenname_Add_Employee.Text;
            string familyName = Txt_Box_Familyname_Add_Employee.Text;
            DateTime dob = Datepicker_Add_Employee.SelectedDate ?? DateTime.Now;
            string genderIdentity = Txt_Box_Gender_Identity.Text;
            int grossSalary = Convert.ToInt32(Txt_Box_GrossSalary_Add_Employee.Text);
            int supervisorId = Convert.ToInt32(Txt_Box_Suprvisor_Id_Add_Employee.Text);
            int branchId = Convert.ToInt32(Txt_Box_BranchID_Add_Employee.Text);
            
            //create new employee objct with values

            Employee newEmployee = new Employee(
                //id,
                0,givenName,
                familyName,
                dob,
                genderIdentity,
                grossSalary,
                supervisorId,
                branchId
            );
            //Call the manager class to save employee object
            EmployeeManager manager = new EmployeeManager();
            manager.AddEmployee(newEmployee);
            Txt_Box_Id_Add_Employee.Text = newEmployee.ID.ToString();
            //Message Box to confirm that employee has been added to th database. 
            MessageBox.Show("New employee added");



        }

        private void Bttn_Delete_Employee_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(Txt_Box_Id_Delete_Employee.Text);
            EmployeeManager manager = new();
            manager.DeleteEmployee(id);
            MessageBox.Show("Employee deleted.");
        }

       


        private void Bttn_Show_Employees_Information_Click(object sender, RoutedEventArgs e)
        {
            EmployeeManager manager = new EmployeeManager();
            List<Employee> employees = manager.ShowAllEmployees();
         // MessageBox.Show("Employees recorded: " + employees.Count);//troubleshoot as the trigger wsnt working well

            List_Box_Display_Employees.Items.Clear(); //clear the listBox before displaying

            foreach (Employee employee in employees)
            {
                List_Box_Display_Employees.Items.Add(employee);

            }
        }

        private void Bttn_Show_Employees_Earn_More_Amount_Click(object sender, RoutedEventArgs e)
        {
            EmployeeManager manager = new EmployeeManager();
            List<Employee> employees = manager.ShowHigherSalary();

            List_Box_Display_Employees.Items.Clear(); //clear the listBox before displaying
            foreach (Employee employee in employees)
            {
                List_Box_Display_Employees.Items.Add(employee);

            }
        }

        private void Bttn_Show_Employee_Same_Branch_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem selectedBranchIdItem = (ComboBoxItem)Combo_Box_Branch_Id.SelectedItem;//item selected from combobox
            string selectedBranchText = selectedBranchIdItem.Content.ToString();//getcontent from selected item

            //convert text to a number
            int branchId;
            bool isValidNumber = int.TryParse(selectedBranchText, out branchId);

            //create manager object to get employees
            EmployeeManager manager = new EmployeeManager();
            List<Employee> employees= manager.EmployeesByBranchId(branchId);
            //clear list box
            List_Box_Display_Employees.Items.Clear();

            //add employees selected to the list box

            foreach (Employee employee in employees)
            {
                List_Box_Display_Employees.Items.Add(employee);
            }
        }

        private void Bttn_Show_All_Sales_Employee_Click(object sender, RoutedEventArgs e)
        {
            //get ID from text box
            int employeeId = int.Parse(Txt_Box_ID_Specific_Employee.Text);

            EmployeeManager manager = new EmployeeManager();

            List<string> salesList = manager.SearchSalesById(employeeId);

            List_Box_Display_Employees.Items.Clear();

            if (salesList.Count > 0)
            {
                foreach (string sale in salesList)
                {
                    List_Box_Display_Employees.Items.Add(sale);
                }
            }
            else
            {
                List_Box_Display_Employees.Items.Add("No sales found for this employee.");
            }

        }

        private void Bttn_Update_Salary_Click(object sender, RoutedEventArgs e)
        {
            int employeeId = int.Parse(Txt_Box_ID_Update_Salary.Text);
            int NewGrossSalary = int.Parse(Txt_Box_NewSalary_Update_Salary.Text);

            EmployeeManager manager = new();

            manager.UpdateGrossSalary(employeeId, NewGrossSalary);

            MessageBox.Show("Salary updated");

        }
        private void List_Box_Display_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List_Box_Display_Employees.SelectedItem is Employee selectedEmployee)
            {
                Txt_Box_Id_Add_Employee.Text = selectedEmployee.ID.ToString();
                Txt_Box_Givenname_Add_Employee.Text = selectedEmployee.GivenName;
                Txt_Box_Familyname_Add_Employee.Text = selectedEmployee.FamilyName;
                Datepicker_Add_Employee.SelectedDate = selectedEmployee.DateofBirth;
                Txt_Box_Gender_Identity.Text = selectedEmployee.GenderIdentity;
                Txt_Box_GrossSalary_Add_Employee.Text = selectedEmployee.GrossSalary.ToString();
                Txt_Box_Suprvisor_Id_Add_Employee.Text = selectedEmployee.SupervisorID.ToString();
                Txt_Box_BranchID_Add_Employee.Text = selectedEmployee.BranchID.ToString();
            }
        }

        private void Bttn_Search_By_Name_Click(object sender, RoutedEventArgs e)
        {
            string nametobesearched = Txt_Box_Search_By_Name.Text.Trim();

            EmployeeManager manager = new EmployeeManager();

            List<Employee> matchingnames = manager.EmployeesByGivenName(nametobesearched);  

            List_Box_Display_Employees.Items.Clear();

            if (matchingnames.Count == 0)
            {
                MessageBox.Show("No employees found.");
                return;

            }
            foreach (Employee emp in matchingnames)
            {

                List_Box_Display_Employees.Items.Add(emp);
            
            }
        }
    }


}
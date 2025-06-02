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

            int id = Convert.ToInt32(Txt_Box_Id_Add_Employee.Text);
            string givenName = Txt_Box_Givenname_Add_Employee.Text;
            string familyName = Txt_Box_Familyname_Add_Employee.Text;
            DateTime dob = Datepicker_Add_Employee.SelectedDate ?? DateTime.Now;
            string genderIdentity = Txt_Box_Gender_Identity.Text;
            int grossSalary = Convert.ToInt32(Txt_Box_GrossSalary_Add_Employee.Text);
            int supervisorId = Convert.ToInt32(Txt_Box_Suprvisor_Id_Add_Employee.Text);
            int branchId = Convert.ToInt32(Txt_Box_BranchID_Add_Employee.Text);
            
            //create new employee objct with values

            Employee newEmployee = new Employee(
                id,
                givenName,
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
    }


}
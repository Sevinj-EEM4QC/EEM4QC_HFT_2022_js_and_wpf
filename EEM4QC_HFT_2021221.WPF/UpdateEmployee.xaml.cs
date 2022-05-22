using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Logic;
using EEM4QC_HFT_2021221.WPF.Mappers;
using EEM4QC_HFT_2021221.Repository;
using EEM4QC_HFT_2021221.Data;

namespace EEM4QC_HFT_2021221.WPF
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly ISalaryRecordLogic _salaryLogic;
        private readonly IEmployeeExitDetailLogic _exitDetailLogic;
        private readonly IEmployeeStatusLogic _statusLogic;
        private DataContext _data = new DataContext();
        private readonly IBaseRepository repo;
        public UpdateEmployee()
        {
            InitializeComponent();
            repo = new BaseRepository(_data);
            _employeeLogic = new EmployeeLogic(repo);
            _salaryLogic = new SalaryRecordLogic(repo);
            _exitDetailLogic = new EmployeeExitDetailLogic(repo);
            _statusLogic = new EmployeeStatusLogic(repo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.HrEmployee employeeData = new Models.HrEmployee()
            {
                Emp_Name = txtEmployeeNme.Text,
            };

            int employeeId = Convert.ToInt32(txtEmployeeID.Text);

            var result = _employeeLogic.Edit(employeeId, employeeData);

            if (result.Result)
            {
                MessageBox.Show("Employee updated successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Employee doesnot exist. Provide correct information!");
            }
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

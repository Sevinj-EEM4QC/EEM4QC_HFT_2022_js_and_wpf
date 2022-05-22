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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Logic;
using EEM4QC_HFT_2021221.WPF.Mappers;
using EEM4QC_HFT_2021221.Repository;
using EEM4QC_HFT_2021221.Data;

namespace EEM4QC_HFT_2021221.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly ISalaryRecordLogic _salaryLogic;
        private readonly IEmployeeExitDetailLogic _exitDetailLogic;
        private readonly IEmployeeStatusLogic _statusLogic;
        private DataContext _data = new DataContext();
        private readonly IBaseRepository repo;

        public MainWindow()
        {
            InitializeComponent();
            repo = new BaseRepository(_data);
            _employeeLogic = new EmployeeLogic(repo);
            _salaryLogic = new SalaryRecordLogic(repo);
            _exitDetailLogic = new EmployeeExitDetailLogic(repo);
            _statusLogic = new EmployeeStatusLogic(repo);
        }

        public MainWindow(EmployeeLogic employeeLogic)
        {
            InitializeComponent();
            _employeeLogic = employeeLogic;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Average Salary : " + _salaryLogic.GetAvrSalary());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Minimum Salary : " + _salaryLogic.GetMinSalary());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Maximum Salary : " + _salaryLogic.GetMaxSalary());
        }


        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ExitDetails ep = new ExitDetails();
            ep.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Status emp = new Status();
            emp.Show();
        }
    }
}

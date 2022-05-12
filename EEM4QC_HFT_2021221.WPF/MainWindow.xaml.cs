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
        private DataContext _data = new DataContext();
        private readonly IBaseRepository repo;

        public MainWindow()
        {
            InitializeComponent();
            repo = new BaseRepository(_data);
            _employeeLogic = new EmployeeLogic(repo);
        }

        public MainWindow(EmployeeLogic employeeLogic)
        {
            InitializeComponent();
            _employeeLogic = employeeLogic;
        }


        void BtnAdd(object sender, RoutedEventArgs e)
        {
            Models.HrEmployee employeeData = new Models.HrEmployee()
            {
                Emp_Name = "NewEmployee",
            };

            var result = _employeeLogic.Create(employeeData);

            txt1.Text = $"Employee created, ID : {result.Result}";
        }

        void BtnModify(object sender, RoutedEventArgs e)
        {
            Models.HrEmployee employeeData = new Models.HrEmployee()
            {
                Emp_Name = "ModifiedEmployee",
            };

            int employeeId = 1;

            var result = _employeeLogic.Edit(employeeId, employeeData);

            if (result.Result)
            {
                txt1.Text = "Employee modified successfully!";
            }
            else
            {
                txt1.Text = "Could not modify employee!";
            }
        }

        void BtnDelete(object sender, RoutedEventArgs e)
        {
            int employeeId = 4;

            var result = _employeeLogic.Delete(employeeId);

            if (result.Result)
            {
                txt1.Text = "Employee deleted successfully!";
            }
            else
            {
                txt1.Text = "Could not delete employee!";
            }
        }


        void BtnGetEmployee(object sender, RoutedEventArgs e)
        {
            int employeeId = 0;

            Models.HrEmployee result = _employeeLogic.GetSingle(employeeId);

            if (result == null)
            {
                txt1.Text = "Employee not found!";
            }
            else
            {
                ViewModels.EmployeeMainViewModel empVm = result.ToViewModel();
                txt1.Text = $"Emp. Name: {empVm.Name}\nEmp. Surename {empVm.Surname}";
            }
        }

        void BtnGetUnExitedEmployees(object sender, RoutedEventArgs e)
        {
            List<Models.UnExitedEmployeeModel> result = _employeeLogic.GetUnExitedEmployees();

            if (result == null || result.Count == 0)
            {
                txt1.Text = "UnExitedEmployees not found!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in result)
                {
                    ViewModels.EmployeeMainViewModel empVm = item.ToViewModel();
                    sb.Append($"Emp. Name: {empVm.Name}\nEmp. IsExited {empVm.Surname}");
                }

                txt1.Text = sb.ToString();
            }
        }

        void BtnGetList(object sender, RoutedEventArgs e)
        {
            List<Models.HrEmployee> result = _employeeLogic.GetList();

            if (result == null || result.Count == 0)
            {
                txt1.Text = "Employees not found!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in result)
                {
                    ViewModels.EmployeeMainViewModel empVm = item.ToViewModel();
                    sb.Append($"Emp. Name: {empVm.Name}\nEmp. Surename {empVm.Surname}");
                }

                txt1.Text = sb.ToString();
            }
        }
    }
}

﻿using System;
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
    public partial class GetEmployee : Window
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly ISalaryRecordLogic _salaryLogic;
        private readonly IEmployeeExitDetailLogic _exitDetailLogic;
        private readonly IEmployeeStatusLogic _statusLogic;
        private DataContext _data = new DataContext();
        private readonly IBaseRepository repo;
        public GetEmployee()
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
            int employeeId = Convert.ToInt32(txtEmployeeNme.Text);

            var result = _employeeLogic.GetSingle(employeeId);

            if (result != null)
            {
                ViewModels.EmployeeMainViewModel empVm = result.ToViewModel();
                MessageBox.Show("Employee Name is " + empVm.Name);
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

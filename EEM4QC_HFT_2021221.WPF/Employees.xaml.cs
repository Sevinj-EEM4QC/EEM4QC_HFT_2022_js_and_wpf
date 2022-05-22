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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {

        public Employees()
        {
            InitializeComponent();

        }


        void BtnAdd(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        void BtnModify(object sender, RoutedEventArgs e)
        {
            UpdateEmployee emp = new UpdateEmployee();
            emp.Show();
        }

        void BtnDelete(object sender, RoutedEventArgs e)
        {
            DeleteEmployee emp = new DeleteEmployee();
            emp.Show();
        }


        void BtnGetEmployee(object sender, RoutedEventArgs e)
        {
            GetEmployee emp = new GetEmployee();
            emp.Show();
        }

        void BtnGetUnExitedEmployees(object sender, RoutedEventArgs e)
        {
            AllUnexitedEmployees emp = new AllUnexitedEmployees();
            emp.Show();
        }

        void BtnGetList(object sender, RoutedEventArgs e)
        {
            AllEmployees em = new AllEmployees();
            em.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for AllEmployees.xaml
    /// </summary>
    public partial class AllUnexitedEmployees : Window
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly ISalaryRecordLogic _salaryLogic;
        private readonly IEmployeeExitDetailLogic _exitDetailLogic;
        private readonly IEmployeeStatusLogic _statusLogic;
        private DataContext _data = new DataContext();
        private readonly IBaseRepository repo;
        public AllUnexitedEmployees()
        {
            InitializeComponent();
            repo = new BaseRepository(_data);
            _employeeLogic = new EmployeeLogic(repo);
            _salaryLogic = new SalaryRecordLogic(repo);
            _exitDetailLogic = new EmployeeExitDetailLogic(repo);
            _statusLogic = new EmployeeStatusLogic(repo);

            List<Models.UnExitedEmployeeModel> result = _employeeLogic.GetUnExitedEmployees();

            if (result == null || result.Count == 0)
            {
                txt1.Text = "Un Exited Employees not found!";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

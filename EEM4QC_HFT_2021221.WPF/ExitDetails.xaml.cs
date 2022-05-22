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
    public partial class ExitDetails : Window
    {

        public ExitDetails()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddExitDetail emp = new AddExitDetail();
            emp.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateExitDetails emp = new UpdateExitDetails();
            emp.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DeleteExitDetails emp = new DeleteExitDetails();
            emp.Show();
        }
    }
}

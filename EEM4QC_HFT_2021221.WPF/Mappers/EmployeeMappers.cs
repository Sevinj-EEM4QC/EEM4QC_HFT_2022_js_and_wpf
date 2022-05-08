using EEM4QC_HFT_2021221.WPF.ViewModels;

namespace EEM4QC_HFT_2021221.WPF.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeMainViewModel ToViewModel(this Models.HrEmployee employee)
        {
            return new EmployeeMainViewModel()
            {
                Name = employee.Emp_Name,
                Surname = employee.Emp_Surname
            };
        }

        public static EmployeeMainViewModel ToViewModel(this Models.UnExitedEmployeeModel employee)
        {
            return new EmployeeMainViewModel()
            {
                Name = employee.Name,
                Surname = employee.Name
            };
        }
    }
}

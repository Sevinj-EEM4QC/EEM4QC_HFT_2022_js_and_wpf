using EEM4QC_HFT_2021221.Data;
using EEM4QC_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string Message = "Model is not exist!";
        private readonly DataContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// Constructor of repository.
        /// </summary>
        /// <param name="context">context.</param>
        public EmployeeRepository(DataContext context)
        {
            this.ctx = context;
        }

        /// <summary>
        /// Get simple employee.
        /// </summary>
        /// <returns><![CDATA[List<UnExitedEmployeeModel>]]></returns>
        public List<UnExitedEmployeeModel> GetUnExitedEmployees()
        => (from employee in this.ctx.Hr_Employees
            where !employee.Emp_Is_Existed
            join credentials in this.ctx.Hr_Employee_Credentials
            on employee.Emp_Id equals credentials.Empc_Employee_Id
            join workDetails in this.ctx.Hr_Employee_Work_Details
            on employee.Emp_Id equals workDetails.Wd_Employee_Id
            join salaryRecord in this.ctx.Hr_Employee_Salary_Record
            on employee.Emp_Id equals salaryRecord.Esr_Employee_Id
            select new UnExitedEmployeeModel
            {
                Name = employee.Emp_Name,
                Surname = employee.Emp_Surname,
                JoinedDate = workDetails.Wd_Join_Date,
                Location = workDetails.Wd_Location,
                Summary = workDetails.Wd_Summary_Job,
                Title = workDetails.Wd_Title,
                Mail = workDetails.Wd_Work_Mail,
                Phone = workDetails.Wd_Work_Phone,
                Salary = salaryRecord.Esr_Amount,
            })
            .AsNoTracking()
            .ToList();

        /// <summary>
        /// Get employees list.
        /// </summary>
        /// <returns>HrEmployee list.</returns>
        public List<HrEmployee> GetList()
            => this.ctx.Hr_Employees.AsNoTracking().ToList();

        /// <summary>
        /// Get Exited employee list.
        /// </summary>
        /// <returns>ExitedEmployeeModel list.</returns>
        public List<ExitedEmployeeModel> GetExitedEmployees()
        => (from employee in this.ctx.Hr_Employees
            where employee.Emp_Is_Existed
            join credentials in this.ctx.Hr_Employee_Credentials
            on employee.Emp_Id equals credentials.Empc_Employee_Id
            join workDetails in this.ctx.Hr_Employee_Work_Details
            on employee.Emp_Id equals workDetails.Wd_Employee_Id
            join exitDetail in this.ctx.Hr_Employee_Exit_Detail
            on workDetails.Wd_Id equals exitDetail.Eed_Employee_Work_Details_Id
            select new ExitedEmployeeModel
            {
                Name = employee.Emp_Name,
                Surname = employee.Emp_Surname,
                ExitDetail = exitDetail.Eed_Details,
                ExitDate = exitDetail.Eed_Date,
            })
            .AsNoTracking()
            .ToList();

        /// <summary>
        /// Get single.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployee.</returns>
        public HrEmployee GetSingle(int id)
            => this.ctx.Hr_Employees.FirstOrDefault(x => x.Emp_Id == id);

        /// <summary>
        /// Create simple employee.
        /// </summary>
        /// <param name="employee">employee.</param>
        /// <returns>int.</returns>
        public async Task<int> Create(HrEmployee employee) =>
            await Task.Run(() =>
            {
                try
                {
                    this.ctx.Hr_Employees.Add(employee);
                    this.ctx.SaveChanges();

                    return employee.Emp_Id;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Delete existed employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Delete(int id) =>
            await Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(id))
                    {
                        throw new Exception(message: Message);
                    }

                    this.ctx.Hr_Employees.Remove(this.GetSingle(id));
                    this.ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Edit existed employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employee">employee.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Edit(int id, HrEmployee employee) =>
            await Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(id))
                    {
                        throw new Exception(message: Message);
                    }

                    var model = this.GetSingle(id);
                    this.ctx.Attach(model);

                    model.Emp_Name = employee.Emp_Name;
                    model.Emp_Surname = employee.Emp_Surname;
                    this.ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Check if employee exist or not.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        private bool Exists(int id)
            => this.ctx.Hr_Employees.Any(x => x.Emp_Id == id);
    }
}

using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public EmployeeLogic(IBaseRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get simple employee.
        /// </summary>
        /// <returns><![CDATA[List<UnExitedEmployeeModel>]]></returns>
        public List<UnExitedEmployeeModel> GetUnExitedEmployees()
        => this.repo.EmployeeRepo.GetUnExitedEmployees().Select(x => new UnExitedEmployeeModel { Mail = x.Mail, JoinedDate = x.JoinedDate, Location = x.Location, Name = x.Name, Phone = x.Phone, Salary = x.Salary, Summary = x.Summary, Surname = x.Surname, Title = x.Title }).ToList();

        /// <summary>
        /// Get employees list.
        /// </summary>
        /// <returns><![CDATA[List<HrEmployee>]]></returns>
        public List<HrEmployee> GetList()
            => this.repo.EmployeeRepo.GetList();

        /// <summary>
        /// Get unexited model.
        /// </summary>
        /// <returns><![CDATA[List<ExitedEmployeeModel>]]></returns>
        public List<ExitedEmployeeModel> GetExitedEmployees()
        => this.repo.EmployeeRepo.GetExitedEmployees().Select(x => new ExitedEmployeeModel
        {
            Surname = x.Surname,
            ExitDate = x.ExitDate,
            ExitDetail = x.ExitDetail,
            Name = x.Name,
        }).ToList();

        /// <summary>
        /// Get existed value.
        /// </summary>
        /// <param name="id">int parametr.</param>
        /// <returns><![CDATA[HrEmployee]]></returns>
        public HrEmployee GetSingle(int id)
        => this.repo.EmployeeRepo.GetSingle(id);

        /// <summary>
        /// Create new object.
        /// </summary>
        /// <param name="employee">HrEployee object.</param>
        /// <returns><![CDATA[int]]></returns>
        public async Task<int> Create(HrEmployee employee) =>
        await Task.Run(async () =>
        {
            try
            {
                await this.repo.EmployeeRepo.Create(employee).ConfigureAwait(false);

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
        public async Task<bool> Delete(int id)
         => await Task.Run(async () =>
         {
             try
             {
                 await this.repo.EmployeeRepo.Delete(id).ConfigureAwait(false);
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
        public async Task<bool> Edit(int id, HrEmployee employee)
        => await Task.Run(async () =>
        {
            try
            {
                await this.repo.EmployeeRepo.Edit(id, employee).ConfigureAwait(false);
                return true;
            }
            catch
            {
                throw;
            }
        }).ConfigureAwait(false);
    }
}


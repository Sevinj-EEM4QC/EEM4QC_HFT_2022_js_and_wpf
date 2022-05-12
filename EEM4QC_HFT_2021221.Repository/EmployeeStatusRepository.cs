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
    public class EmployeeStatusRepository : IEmployeeStatusRepository
    {
        private readonly DataContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatusRepository"/> class.
        /// Constructor of repository.
        /// </summary>
        /// <param name="context">context.</param>
        public EmployeeStatusRepository(DataContext context)
        {
            this.ctx = context;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployeeStatus.</returns>
        public HrEmployeeStatus GetSingle(int id)
        => this.ctx.Hr_Employee_Status.AsNoTracking().FirstOrDefault(x => x.Emps_Id == id);

        /// <summary>
        /// Create simple employee status.
        /// </summary>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns>int.</returns>
        public async Task<int> Create(HrEmployeeStatus employeeStatus) =>
            await Task.Run(() =>
            {
                try
                {
                    this.ctx.Hr_Employee_Status.Add(employeeStatus);
                    this.ctx.SaveChanges();

                    return employeeStatus.Emps_Id;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Delete existed employee status.
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
                        throw new Exception(message: "Model is not exist!");
                    }

                    this.ctx.Hr_Employee_Status.Remove(this.GetSingle(id));
                    this.ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Edit existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Edit(int id, HrEmployeeStatus employeeStatus) =>
            await Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(id))
                    {
                        throw new Exception(message: "Model is not exist!");
                    }

                    var model = this.GetSingle(id);
                    this.ctx.Attach(model);

                    model.Emps_Title = employeeStatus.Emps_Title;

                    model.Emps_Description = employeeStatus.Emps_Description;

                    this.ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Check if employee status exist or not.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        private bool Exists(int id)
            => this.ctx.Hr_Employee_Status.Any(x => x.Emps_Id == id);

        public List<HrEmployeeStatus> GetList()
        => this.ctx.Hr_Employee_Status.AsNoTracking().ToList();
    }
}


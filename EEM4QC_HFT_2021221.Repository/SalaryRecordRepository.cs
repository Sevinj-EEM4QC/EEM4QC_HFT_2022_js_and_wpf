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
    public class SalaryRecordRepository : ISalaryRecordRepository
    {
        private readonly DataContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryRecordRepository"/> class.
        /// Constructor of repository.
        /// </summary>
        /// <param name="context">context.</param>
        public SalaryRecordRepository(DataContext context)
        {
            this.ctx = context;
        }

        /// <summary>
        /// Get single.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <returns>HrEmployeeSalaryRecord.</returns>
        public HrEmployeeSalaryRecord GetSingle(int ei)
        => this.ctx.Hr_Employee_Salary_Record.FirstOrDefault(x => x.Esr_Employee_Id == ei);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="salaryRecord">salaryRecord.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Create(HrEmployeeSalaryRecord salaryRecord) =>
            await Task.Run(() =>
            {
                try
                {
                    if (salaryRecord != null && this.Exists(salaryRecord.Esr_Employee_Id))
                    {
                        throw new Exception(message: "Model allready exists");
                    }

                    this.ctx.Hr_Employee_Salary_Record.Add(salaryRecord);
                    this.ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Delete existed employee credentials.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Delete(int employeeId) =>
            await Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(employeeId))
                    {
                        throw new Exception(message: "Model is not exist!");
                    }

                    this.ctx.Hr_Employee_Salary_Record.Remove(this.GetSingle(employeeId));
                    this.ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Edit existed employee credentials.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <param name="salaryRecord">salaryRecord.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Edit(int ei, HrEmployeeSalaryRecord salaryRecord) =>
            await Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(ei))
                    {
                        throw new Exception(message: "Model is not exist!");
                    }

                    var model = this.GetSingle(ei);
                    this.ctx.Attach(model);
                    model.Esr_Currency = salaryRecord.Esr_Currency;
                    model.Esr_Date = salaryRecord.Esr_Date;
                    model.Esr_Hours = salaryRecord.Esr_Hours;
                    model.Esr_Over_Time = salaryRecord.Esr_Over_Time;
                    model.Esr_Amount = salaryRecord.Esr_Amount;
                    model.Esr_Type = salaryRecord.Esr_Type;
                    model.Esr_Frequency = salaryRecord.Esr_Frequency;
                    model.Esr_Employee_Id = salaryRecord.Esr_Employee_Id;
                    this.ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Check if employee credentials exists or not.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <returns>bool.</returns>
        private bool Exists(int employeeId)
            => this.ctx.Hr_Employee_Salary_Record.Any(x => x.Esr_Employee_Id == employeeId);

        public List<HrEmployeeSalaryRecord> GetList()
         => this.ctx.Hr_Employee_Salary_Record.AsNoTracking().ToList();
    }
}

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
    public class EmployeeWorkDetailRepository : IEmployeeWorkDetailRepository
    {
        private const string Message = "Model is not exist!";
        private readonly DataContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWorkDetailRepository"/> class.
        /// Constructor of repository.
        /// </summary>
        /// <param name="context">context.</param>
        public EmployeeWorkDetailRepository(DataContext context)
        {
            this.ctx = context;
        }

        /// <summary>
        /// Get exist model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployeeWorkDetails.</returns>
        public HrEmployeeWorkDetails GetSingle(int id)
            => this.ctx.Hr_Employee_Work_Details.AsNoTracking().FirstOrDefault(x => x.Wd_Employee_Id == id);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="employeeWorkDetails">employeeWorkDetails.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Create(HrEmployeeWorkDetails employeeWorkDetails) =>
            await Task.Run(() =>
            {
                try
                {
                    if (employeeWorkDetails != null && this.Exists(employeeWorkDetails.Wd_Employee_Id))
                    {
                        throw new Exception(message: "Model allready exists");
                    }

                    this.ctx.Hr_Employee_Work_Details.Add(employeeWorkDetails);
                    this.ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Edit existed employee credentials.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <param name="employeeWorkDetails">employeeWorkDetails.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Edit(int employeeId, HrEmployeeWorkDetails employeeWorkDetails) =>
            await Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(employeeId))
                    {
                        throw new Exception(message: Message);
                    }

                    var model = this.GetSingle(employeeId);
                    this.ctx.Attach(model);

                    model.Wd_Manager = employeeWorkDetails.Wd_Manager;

                    model.Wd_Location = employeeWorkDetails.Wd_Location;
                    model.Wd_Join_Date = employeeWorkDetails.Wd_Join_Date;
                    model.Wd_Experience = employeeWorkDetails.Wd_Experience;
                    model.Wd_Work_Mail = employeeWorkDetails.Wd_Work_Mail;
                    model.Wd_Work_Phone = employeeWorkDetails.Wd_Work_Phone;
                    model.Wd_Summary_Job = employeeWorkDetails.Wd_Summary_Job;
                    model.Wd_About = employeeWorkDetails.Wd_About;
                    model.Wd_Employee_Id = employeeWorkDetails.Wd_Employee_Id;

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

                    this.ctx.Hr_Employee_Work_Details.Remove(this.GetSingle(employeeId));
                    this.ctx.SaveChanges();
                    return true;
                }
                catch
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
            => this.ctx.Hr_Employee_Work_Details.Any(x => x.Wd_Employee_Id == employeeId);

        public List<HrEmployeeWorkDetails> GetList()
        => this.ctx.Hr_Employee_Work_Details.AsNoTracking().ToList();
    }
}

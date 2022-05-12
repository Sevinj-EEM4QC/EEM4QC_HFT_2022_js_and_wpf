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
    public class EmployeeExitDetailRepository : IEmployeeExitDetailRepository
    {
        private readonly DataContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeExitDetailRepository"/> class.
        /// Constructor of repository.
        /// </summary>
        /// <param name="context">context.</param>
        public EmployeeExitDetailRepository(DataContext context)
        {
            this.ctx = context;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>HrEmployeeExitDetail.</returns>
        public HrEmployeeExitDetail GetSingle(int eedWorkDetailId)
        => this.ctx.Hr_Employee_Exit_Detail.AsNoTracking()
                            .FirstOrDefault(x => x.Eed_Employee_Work_Details_Id == eedWorkDetailId);

        /// <summary>
        /// Create simple employee exit detail.
        /// </summary>
        /// <param name="emloyeeExitDetail">emloyeeExitDetail.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Create(HrEmployeeExitDetail emloyeeExitDetail) =>
            await Task.Run(() =>
            {
                try
                {
                    var model = emloyeeExitDetail;
                    this.ctx.Hr_Employee_Exit_Detail.Add(model);

                    var workDetail = this.ctx.Hr_Employee_Work_Details
                                            .FirstOrDefault(x => x.Wd_Id == model.Eed_Employee_Work_Details_Id);
                    this.ctx.Entry(workDetail).State = EntityState.Modified;

                    workDetail.Wd_Employee_Exit_Detail_Id = model.Eed_Id;

                    this.ctx.SaveChanges();

                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Edit existed employee exit detail by employee  id.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <param name="employeeExitDetail">employeeExitDetail.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Edit(int eedWorkDetailId, HrEmployeeExitDetail employeeExitDetail) =>
            await Task.Run(() =>
            {
                try
                {
                    var model = this.ctx.Hr_Employee_Exit_Detail.FirstOrDefault(x => x.Eed_Employee_Work_Details_Id == eedWorkDetailId);

                    this.ctx.Attach(model);

                    model.Eed_Date = employeeExitDetail.Eed_Date;

                    model.Eed_Details = employeeExitDetail.Eed_Details;
                    model.Eed_Employee_Work_Details_Id = employeeExitDetail.Eed_Employee_Work_Details_Id;
                    model.Eed_Interviewer = employeeExitDetail.Eed_Interviewer;
                    model.Eed_Questions = employeeExitDetail.Eed_Questions;
                    this.ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Delete existed employee exit detail by employee  id.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Delete(int eedWorkDetailId) =>
            await Task.Run(() =>
            {
                try
                {
                    var exit_detail = this.ctx.Hr_Employee_Exit_Detail.FirstOrDefault(x => x.Eed_Employee_Work_Details_Id == eedWorkDetailId);
                    this.ctx.Hr_Employee_Exit_Detail.Remove(exit_detail);
                    this.ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }).ConfigureAwait(false);
    }
}


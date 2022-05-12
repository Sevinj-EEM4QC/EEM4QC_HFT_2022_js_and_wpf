using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class EmployeeExitDetailLogic : IEmployeeExitDetailLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeExitDetailLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public EmployeeExitDetailLogic(IBaseRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>HrEmployeeExitDetail.</returns>
        public HrEmployeeExitDetail GetSingle(int eedWorkDetailId)
        => this.repo.EmployeeExitDetailRepo.GetSingle(eedWorkDetailId);

        /// <summary>
        /// Create simple employee exit detail.
        /// </summary>
        /// <param name="emloyeeExitDetail">emloyeeExitDetail.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Create(HrEmployeeExitDetail emloyeeExitDetail)
            => await Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeeExitDetailRepo.Create(emloyeeExitDetail).ConfigureAwait(false);

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
        public async Task<bool> Edit(int eedWorkDetailId, HrEmployeeExitDetail employeeExitDetail)
            => await Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeeExitDetailRepo.Edit(eedWorkDetailId, employeeExitDetail).ConfigureAwait(false);

                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        /// <summary>
        /// Delete existed employee exit detail by employee  id.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Delete(int eedWorkDetailId)
            => await Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeeExitDetailRepo.Delete(eedWorkDetailId).ConfigureAwait(false);

                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);
    }
}


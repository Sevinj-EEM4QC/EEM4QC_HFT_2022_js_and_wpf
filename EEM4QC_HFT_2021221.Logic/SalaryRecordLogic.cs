using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class SalaryRecordLogic : ISalaryRecordLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryRecordLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public SalaryRecordLogic(IBaseRepository repo) => this.repo = repo;

        /// <summary>
        /// Get single model.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <returns>HrEmployeeSalaryRecord.</returns>
        public HrEmployeeSalaryRecord GetSingle(int ei)
        => this.repo.SalaryRecordRepo.GetSingle(ei);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="salaryRecord">salaryRecord.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Create(HrEmployeeSalaryRecord salaryRecord)
        => await Task.Run(async () =>
        {
            try
            {
                await this.repo.SalaryRecordRepo.Create(salaryRecord).ConfigureAwait(false);
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
        public async Task<bool> Delete(int employeeId)
            => await Task.Run(async () =>
            {
                try
                {
                    await this.repo.SalaryRecordRepo.Delete(employeeId).ConfigureAwait(false);
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
        /// <param name="ei">ei.</param>
        /// <param name="salaryRecord">salaryRecord.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Edit(int ei, HrEmployeeSalaryRecord salaryRecord)
            => await Task.Run(async () =>
            {
                try
                {
                    await this.repo.SalaryRecordRepo.Edit(ei, salaryRecord).ConfigureAwait(false);
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        public List<HrEmployeeSalaryRecord> GetList()
            => this.repo.SalaryRecordRepo.GetList();
    }
}
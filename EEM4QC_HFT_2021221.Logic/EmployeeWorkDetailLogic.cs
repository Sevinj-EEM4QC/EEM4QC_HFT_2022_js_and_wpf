using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class EmployeeWorkDetailLogic : IEmployeeWorkDetailLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWorkDetailLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public EmployeeWorkDetailLogic(IBaseRepository repo) => this.repo = repo;

        /// <summary>
        /// Get exist model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployeeWorkDetails.</returns>
        public HrEmployeeWorkDetails GetSingle(int id)
            => this.repo.EmployeeWorkDetailRepo.GetSingle(id);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="employeeWorkDetails">employeeWorkDetails.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Create(HrEmployeeWorkDetails employeeWorkDetails)
            => await Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeeWorkDetailRepo.Create(employeeWorkDetails).ConfigureAwait(false);
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
            await Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeeWorkDetailRepo.Edit(employeeId, employeeWorkDetails).ConfigureAwait(false);
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
            await Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeeWorkDetailRepo.Delete(employeeId).ConfigureAwait(false);
                    return true;
                }
                catch
                {
                    throw;
                }
            }).ConfigureAwait(false);

        public List<HrEmployeeWorkDetails> GetList()
            => this.repo.EmployeeWorkDetailRepo.GetList();
    }
}


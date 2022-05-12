using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class EmployeCredentialsLogic : IEmployeCredentialsLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeCredentialsLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public EmployeCredentialsLogic(IBaseRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="employeeid">eemployee id.</param>
        /// <returns><![CDATA[HrEmployeeCredentials]]></returns>
        public HrEmployeeCredentials GetSingle(int employeeid)
            => this.repo.EmployeCredentialsRepo.GetSingle(employeeid);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="employeeCredentials">employeeCredentials.</param>
        /// <returns>Task.</returns>
        public Task Create(HrEmployeeCredentials employeeCredentials)
            => Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeCredentialsRepo.Create(employeeCredentials).ConfigureAwait(false);
                }
                catch
                {
                    throw;
                }
            });

        /// <summary>
        /// Delete existed employee credentials.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <returns>Task.</returns>
        public Task Delete(int employeeId)
            => Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeCredentialsRepo.Delete(employeeId).ConfigureAwait(false);
                }
                catch
                {
                    throw;
                }
            });

        /// <summary>
        /// Edit existed employee credentials.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <param name="employeeCredentials">employeeCredentials.</param>
        /// <returns>Task.</returns>
        public Task Edit(int ei, HrEmployeeCredentials employeeCredentials)
            => Task.Run(async () =>
            {
                try
                {
                    await this.repo.EmployeCredentialsRepo.Edit(ei, employeeCredentials).ConfigureAwait(false);
                }
                catch
                {
                    throw;
                }
            });
    }
}

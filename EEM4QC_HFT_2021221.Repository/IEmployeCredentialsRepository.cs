using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public interface IEmployeCredentialsRepository
    {
        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <returns>HrEmployeeCredentials.</returns>
        HrEmployeeCredentials GetSingle(int ei);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="employeeCredentials">employeeCredentials.</param>
        /// <returns>Task.</returns>
        Task Create(HrEmployeeCredentials employeeCredentials);

        /// <summary>
        /// Edit existed employee credentials.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <param name="employeeCredentials">employeeCredentials.</param>
        /// <returns>Task.</returns>
        Task Edit(int ei, HrEmployeeCredentials employeeCredentials);

        /// <summary>
        /// Delete existed employee credentials.
        /// </summary>
        /// <param name="employeeid">employee id.</param>
        /// <returns>Task.</returns>
        Task Delete(int employeeid);
    }
}


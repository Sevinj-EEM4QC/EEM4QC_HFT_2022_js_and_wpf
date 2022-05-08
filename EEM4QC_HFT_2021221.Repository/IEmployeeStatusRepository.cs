using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public interface IEmployeeStatusRepository
    {
        List<HrEmployeeStatus> GetList();
        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployeeStatus.</returns>
        HrEmployeeStatus GetSingle(int id);

        /// <summary>
        /// Create simple employee status.
        /// </summary>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns>int.</returns>
        public Task<int> Create(HrEmployeeStatus employeeStatus);

        /// <summary>
        /// Edit existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns>bool.</returns>
        public Task<bool> Edit(int id, HrEmployeeStatus employeeStatus);

        /// <summary>
        /// Delete existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public Task<bool> Delete(int id);
    }
}


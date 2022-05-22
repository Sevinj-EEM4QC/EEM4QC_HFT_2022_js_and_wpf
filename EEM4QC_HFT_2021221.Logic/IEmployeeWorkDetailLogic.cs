using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public interface IEmployeeWorkDetailLogic
    {
        List<HrEmployeeWorkDetails> GetList();
        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployeeWorkDetails.</returns>
        HrEmployeeWorkDetails GetSingle(int id);

        /// <summary>
        /// Create simple department.
        /// </summary>
        /// <param name="workDetail">workDetail.</param>
        /// <returns>bool.</returns>
        public Task<bool> Create(HrEmployeeWorkDetails workDetail);

        /// <summary>
        /// Edit existed department.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <param name="workDetail">workDetail.</param>
        /// <returns>bool.</returns>
        public Task<bool> Edit(int employeeId, HrEmployeeWorkDetails workDetail);

        /// <summary>
        /// Delete existed department.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public Task<bool> Delete(int id);
    }
}


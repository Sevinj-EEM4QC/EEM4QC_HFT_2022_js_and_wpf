using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public interface ISalaryRecordRepository
    {
        List<HrEmployeeSalaryRecord> GetList();
        /// <summary>
        /// Get single.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <returns>HrEmployeeSalaryRecord.</returns>
        HrEmployeeSalaryRecord GetSingle(int ei);

        /// <summary>
        /// Create simple salary record.
        /// </summary>
        /// <param name="salaryRecord">salaryRecord.</param>
        /// <returns>bool.</returns>
        public Task<bool> Create(HrEmployeeSalaryRecord salaryRecord);

        /// <summary>
        /// Edit existed salary record by employee id.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <param name="salaryRecord">salaryRecord.</param>
        /// <returns>bool.</returns>
        public Task<bool> Edit(int ei, HrEmployeeSalaryRecord salaryRecord);

        /// <summary>
        /// Delete existed salary record.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public Task<bool> Delete(int id);
    }
}


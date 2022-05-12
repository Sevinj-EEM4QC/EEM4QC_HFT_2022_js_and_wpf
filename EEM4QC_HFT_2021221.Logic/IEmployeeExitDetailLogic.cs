using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public interface IEmployeeExitDetailLogic
    {
        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>HrEmployeeExitDetail.</returns>
        HrEmployeeExitDetail GetSingle(int eedWorkDetailId);

        /// <summary>
        /// Create simple employee exit detail by employee  id.
        /// </summary>
        /// <param name="emloyeeExitDetail">emloyeeExitDetail.</param>
        /// <returns>bool.</returns>
        public Task<bool> Create(HrEmployeeExitDetail emloyeeExitDetail);

        /// <summary>
        /// Edit existed employee exit detail by employee  id.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <param name="emloyeeExitDetail">emloyeeExitDetail.</param>
        /// <returns>bool.</returns>
        public Task<bool> Edit(int eedWorkDetailId, HrEmployeeExitDetail emloyeeExitDetail);

        /// <summary>
        /// Delete existed employee exit detail.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>bool.</returns>
        public Task<bool> Delete(int eedWorkDetailId);
    }
}

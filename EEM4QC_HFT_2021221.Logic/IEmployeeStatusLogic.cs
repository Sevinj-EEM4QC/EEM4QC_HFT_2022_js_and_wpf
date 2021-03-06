using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public interface IEmployeeStatusLogic
    {
        List<HrEmployeeStatus> GetList();
        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns><![CDATA[HrEmployeeStatus]]></returns>
        HrEmployeeStatus GetSingle(int id);

        /// <summary>
        /// Create simple employee status.
        /// </summary>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns><![CDATA[int]]></returns>
        public int Create(HrEmployeeStatus employeeStatus);

        /// <summary>
        /// Edit existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns>bool.</returns>
        public bool Edit(int id, HrEmployeeStatus employeeStatus);

        /// <summary>
        /// Delete existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public bool Delete(int id);
    }
}

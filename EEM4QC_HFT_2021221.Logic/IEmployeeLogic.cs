using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public interface IEmployeeLogic
    {
        /// <summary>
        /// Get employees list.
        /// </summary>
        /// <returns><![CDATA[List<HrEmployee>]]></returns>
        public List<HrEmployee> GetList();

        /// <summary>
        /// Get unexited employee.
        /// </summary>
        /// <returns><![CDATA[List<UnExitedEmployeeModel>]]></returns>
        public List<UnExitedEmployeeModel> GetUnExitedEmployees();

        /// <summary>
        /// Get exited employee.
        /// </summary>
        /// <returns><![CDATA[List<ExitedEmployeeModel>]]></returns>
        public List<ExitedEmployeeModel> GetExitedEmployees();

        /// <summary>
        /// Get single employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns><![CDATA[HrEmployee]]></returns>
        public HrEmployee GetSingle(int id);

        /// <summary>
        /// Create simple employee.
        /// </summary>
        /// <param name="employee">employee.</param>
        /// <returns><![CDATA[int]]></returns>
        public Task<int> Create(HrEmployee employee);

        /// <summary>
        /// Edit existed employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employee">employee.</param>
        /// <returns><![CDATA[bool]]></returns>
        public Task<bool> Edit(int id, HrEmployee employee);

        /// <summary>
        /// Delete existed employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns><![CDATA[bool]]></returns>
        public Task<bool> Delete(int id);
    }
}

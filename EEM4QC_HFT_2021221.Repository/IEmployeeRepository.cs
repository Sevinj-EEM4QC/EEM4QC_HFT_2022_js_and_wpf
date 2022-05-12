using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get employees list.
        /// </summary>
        /// <returns>HrEmployee list.</returns>
        public List<HrEmployee> GetList();

        /// <summary>
        /// Get unexited employee.
        /// </summary>
        /// <returns>UnExitedEmployeeModel list.</returns>
        public List<UnExitedEmployeeModel> GetUnExitedEmployees();

        /// <summary>
        /// Get exited employee.
        /// </summary>
        /// <returns>ExitedEmployeeModel list.</returns>
        public List<ExitedEmployeeModel> GetExitedEmployees();

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>HrEmployee.</returns>
        public HrEmployee GetSingle(int id);

        /// <summary>
        /// Create simple employee.
        /// </summary>
        /// <param name="employee">employee.</param>
        /// <returns>int.</returns>
        public Task<int> Create(HrEmployee employee);

        /// <summary>
        /// Edit existed employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employee">employee.</param>
        /// <returns>bool.</returns>
        public Task<bool> Edit(int id, HrEmployee employee);

        /// <summary>
        /// Delete existed employee.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public Task<bool> Delete(int id);
    }
}


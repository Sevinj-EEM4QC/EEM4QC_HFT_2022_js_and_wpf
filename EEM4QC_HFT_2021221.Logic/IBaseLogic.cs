using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public interface IBaseLogic
    {
        /// <summary>
        /// Gets bridge for Employee Logic.
        /// </summary>
        IEmployeeLogic EmployeeLogic { get; }

        /// <summary>
        /// Gets bridge for EmployeCredentials Logic.
        /// </summary>
        IEmployeCredentialsLogic EmployeCredentialsLogic { get; }

        /// <summary>
        /// Gets bridge for EmployeeExitDetail Logic.
        /// </summary>
        IEmployeeExitDetailLogic EmployeeExitDetailLogic { get; }

        /// <summary>
        /// Gets bridge for EmployeeStatus Logic.
        /// </summary>
        IEmployeeStatusLogic EmployeeStatusLogic { get; }

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail Logic.
        /// </summary>
        IEmployeeWorkDetailLogic EmployeeWorkDetailLogic { get; }

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail Logic.
        /// </summary>
        ISalaryRecordLogic SalaryRecordLogic { get; }
    }
}

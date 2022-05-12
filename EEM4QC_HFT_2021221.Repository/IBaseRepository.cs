using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Gets bridge for Employee repository.
        /// </summary>
        IEmployeeRepository EmployeeRepo { get; }

        /// <summary>
        /// Gets bridge for EmployeCredentials repository.
        /// </summary>
        IEmployeCredentialsRepository EmployeCredentialsRepo { get; }

        /// <summary>
        /// Gets bridge for EmployeeExitDetail repository.
        /// </summary>
        IEmployeeExitDetailRepository EmployeeExitDetailRepo { get; }

        /// <summary>
        /// Gets bridge for EmployeeStatus repository.
        /// </summary>
        IEmployeeStatusRepository EmployeeStatusRepo { get; }

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail repository.
        /// </summary>
        IEmployeeWorkDetailRepository EmployeeWorkDetailRepo { get; }

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail repository.
        /// </summary>
        ISalaryRecordRepository SalaryRecordRepo { get; }
    }
}


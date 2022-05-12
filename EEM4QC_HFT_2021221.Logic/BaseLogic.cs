using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class BaseLogic : IBaseLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLogic"/> class.
        /// Controller of Logic.
        /// </summary>
        /// <param name="repo">repository.</param>
        public BaseLogic(IBaseRepository repo) => this.repo = repo;

        private IEmployeeLogic employeeLogic;

        /// <summary>
        /// Gets bridge for Employee Logic.
        /// </summary>
        public IEmployeeLogic EmployeeLogic
        {
            get
            {
                this.employeeLogic ??= new EmployeeLogic(this.repo);
                return this.employeeLogic;
            }
        }

        private IEmployeCredentialsLogic employeCredentialsLogic;

        /// <summary>
        /// Gets bridge for EmployeCredentials Logic.
        /// </summary>
        public IEmployeCredentialsLogic EmployeCredentialsLogic
        {
            get
            {
                this.employeCredentialsLogic ??= new EmployeCredentialsLogic(this.repo);
                return this.employeCredentialsLogic;
            }
        }

        private IEmployeeExitDetailLogic employeeExitDetailLogic;

        /// <summary>
        /// Gets bridge for EmployeeExitDetail Logic.
        /// </summary>
        public IEmployeeExitDetailLogic EmployeeExitDetailLogic
        {
            get
            {
                this.employeeExitDetailLogic ??= new EmployeeExitDetailLogic(this.repo);
                return this.employeeExitDetailLogic;
            }
        }

        private IEmployeeStatusLogic employeeStatusLogic;

        /// <summary>
        /// Gets bridge for EmployeeSalary Logic.
        /// </summary>
        public IEmployeeStatusLogic EmployeeStatusLogic
        {
            get
            {
                this.employeeStatusLogic ??= new EmployeeStatusLogic(this.repo);
                return this.employeeStatusLogic;
            }
        }

        private IEmployeeWorkDetailLogic employeeWorkDetailLogic;

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail Logic.
        /// </summary>
        public IEmployeeWorkDetailLogic EmployeeWorkDetailLogic
        {
            get
            {
                this.employeeWorkDetailLogic ??= new EmployeeWorkDetailLogic(this.repo);
                return this.employeeWorkDetailLogic;
            }
        }

        private ISalaryRecordLogic salaryRecordLogic;

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail Logic.
        /// </summary>
        public ISalaryRecordLogic SalaryRecordLogic
        {
            get
            {
                this.salaryRecordLogic ??= new SalaryRecordLogic(this.repo);
                return this.salaryRecordLogic;
            }
        }
    }
}


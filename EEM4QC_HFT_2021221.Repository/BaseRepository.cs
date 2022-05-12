using EEM4QC_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DataContext cntx;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// Controller of repository.
        /// </summary>
        /// <param name="cntx">context.</param>
        public BaseRepository(DataContext cntx)
        {
            this.cntx = cntx;
        }

        private IEmployeeRepository employeeRepo;

        /// <summary>
        /// Gets bridge for Employee repository.
        /// </summary>
        public IEmployeeRepository EmployeeRepo
        {
            get
            {
                this.employeeRepo ??= new EmployeeRepository(this.cntx);
                return this.employeeRepo;
            }
        }

        private IEmployeCredentialsRepository employeCredentialsRepo;

        /// <summary>
        /// Gets bridge for EmployeCredentials repository.
        /// </summary>
        public IEmployeCredentialsRepository EmployeCredentialsRepo
        {
            get
            {
                this.employeCredentialsRepo ??= new EmployeCredentialsRepository(this.cntx);
                return this.employeCredentialsRepo;
            }
        }

        private IEmployeeExitDetailRepository employeeExitDetailRepo;

        /// <summary>
        /// Gets bridge for EmployeeExitDetail repository.
        /// </summary>
        public IEmployeeExitDetailRepository EmployeeExitDetailRepo
        {
            get
            {
                this.employeeExitDetailRepo ??= new EmployeeExitDetailRepository(this.cntx);
                return this.employeeExitDetailRepo;
            }
        }

        private IEmployeeStatusRepository employeeStatusRepo;

        /// <summary>
        /// Gets bridge for EmployeeSalary repository.
        /// </summary>
        public IEmployeeStatusRepository EmployeeStatusRepo
        {
            get
            {
                this.employeeStatusRepo ??= new EmployeeStatusRepository(this.cntx);
                return this.employeeStatusRepo;
            }
        }

        private IEmployeeWorkDetailRepository employeeWorkDetailRepo;

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail repository.
        /// </summary>
        public IEmployeeWorkDetailRepository EmployeeWorkDetailRepo
        {
            get
            {
                this.employeeWorkDetailRepo ??= new EmployeeWorkDetailRepository(this.cntx);
                return this.employeeWorkDetailRepo;
            }
        }

        private ISalaryRecordRepository salaryRecordRepo;

        /// <summary>
        /// Gets bridge for EmployeeWorkDetail repository.
        /// </summary>
        public ISalaryRecordRepository SalaryRecordRepo
        {
            get
            {
                this.salaryRecordRepo ??= new SalaryRecordRepository(this.cntx);
                return this.salaryRecordRepo;
            }
        }
    }
}


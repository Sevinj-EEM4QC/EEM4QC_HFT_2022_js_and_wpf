using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class EmployeeStatusLogic : IEmployeeStatusLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatusLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public EmployeeStatusLogic(IBaseRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns><![CDATA[HrEmployeeStatus]]></returns>
        public HrEmployeeStatus GetSingle(int id)
        => this.repo.EmployeeStatusRepo.GetSingle(id);

        /// <summary>
        /// Create simple employee status.
        /// </summary>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns><![CDATA[int]]></returns>
        public int Create(HrEmployeeStatus employeeStatus)
           
            {
                try
                {
                this.repo.EmployeeStatusRepo.Create(employeeStatus);

                    return employeeStatus.Emps_Id;
                }
                catch
                {
                    throw;
                }
            }

        /// <summary>
        /// Delete existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns><![CDATA[bool]]></returns>
        public bool Delete(int id)
            {
                try
                {
                this.repo.EmployeeStatusRepo.Delete(id);
                    return true;
                }
                catch
                {
                    throw;
                }
            }

        /// <summary>
        /// Edit existed employee status.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employeeStatus">employeeStatus.</param>
        /// <returns><![CDATA[bool]]></returns>
        public bool Edit(int id, HrEmployeeStatus employeeStatus) 
            {
                try
                {
                this.repo.EmployeeStatusRepo.Edit(id, employeeStatus);
                    return true;
                }
                catch
                {
                    throw;
                }
            }

        public List<HrEmployeeStatus> GetList()
        => repo.EmployeeStatusRepo.GetList();
    }
}


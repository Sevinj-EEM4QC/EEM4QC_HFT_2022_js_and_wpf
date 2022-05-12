using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Logic
{
    public class EmployeeExitDetailLogic : IEmployeeExitDetailLogic
    {
        private readonly IBaseRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeExitDetailLogic"/> class.
        /// Constructor of Logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public EmployeeExitDetailLogic(IBaseRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>HrEmployeeExitDetail.</returns>
        public HrEmployeeExitDetail GetSingle(int eedWorkDetailId)
        => this.repo.EmployeeExitDetailRepo.GetSingle(eedWorkDetailId);

        /// <summary>
        /// Create simple employee exit detail.
        /// </summary>
        /// <param name="emloyeeExitDetail">emloyeeExitDetail.</param>
        /// <returns>bool.</returns>
        public int Create(HrEmployeeExitDetail emloyeeExitDetail)
        {
            try
            {
                

                return this.repo.EmployeeExitDetailRepo.Create(emloyeeExitDetail);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Edit existed employee exit detail by employee  id.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <param name="employeeExitDetail">employeeExitDetail.</param>
        /// <returns>bool.</returns>
        public bool Edit(int eedWorkDetailId, HrEmployeeExitDetail employeeExitDetail)
           
            {
                try
                {
                     this.repo.EmployeeExitDetailRepo.Edit(eedWorkDetailId, employeeExitDetail);

                    return true;
                }
                catch
                {
                    throw;
                }
            }

        /// <summary>
        /// Delete existed employee exit detail by employee  id.
        /// </summary>
        /// <param name="eedWorkDetailId">eedWorkDetailId.</param>
        /// <returns>bool.</returns>
        public bool Delete(int eedWorkDetailId)
            
            {
                try
                {
                    this.repo.EmployeeExitDetailRepo.Delete(eedWorkDetailId);

                    return true;
                }
                catch
                {
                    throw;
                }
            }
    }
}


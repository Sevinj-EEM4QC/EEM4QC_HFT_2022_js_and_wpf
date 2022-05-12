using EEM4QC_HFT_2021221.Data;
using EEM4QC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Repository
{
    public class EmployeCredentialsRepository : IEmployeCredentialsRepository
    {
        private readonly DataContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeCredentialsRepository"/> class.
        /// Constructor of repository.
        /// </summary>
        /// <param name="context">context.</param>
        public EmployeCredentialsRepository(DataContext context)
        {
            this.ctx = context;
        }

        /// <summary>
        /// Get exists model.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <returns>HrEmployeeCredentials.</returns>
        public HrEmployeeCredentials GetSingle(int ei)
            => this.ctx.Hr_Employee_Credentials.FirstOrDefault(x => x.Empc_Employee_Id == ei);

        /// <summary>
        /// Create employee credentials.
        /// </summary>
        /// <param name="employeeCredentials">employeeCredentials.</param>
        /// <returns>Task.</returns>
        public Task Create(HrEmployeeCredentials employeeCredentials)
            => Task.Run(() =>
            {
                try
                {
                    employeeCredentials.Empc_Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(employeeCredentials.Empc_Password));
                    if (this.Exists(employeeCredentials.Empc_Employee_Id))
                    {
                        throw new Exception("Model already exists");
                    }

                    if (!this.CheckUserIfExistOrNot(employeeCredentials.Empc_Employee_Id))
                    {
                        throw new Exception("Employee is not exists!");
                    }

                    this.ctx.Hr_Employee_Credentials.Add(employeeCredentials);
                    this.ctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            });

        /// <summary>
        /// Delete existed employee credentials.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <returns>Task.</returns>
        public Task Delete(int employeeId)
            => Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(employeeId))
                    {
                        throw new Exception("Model is not exist!");
                    }

                    var employee_credentials = this.GetSingle(employeeId);
                    this.ctx.Hr_Employee_Credentials.Remove(employee_credentials);
                    this.ctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            });

        /// <summary>
        /// Edit existed employee credentials.
        /// </summary>
        /// <param name="ei">ei.</param>
        /// <param name="employeeCredentials">employeeCredentials.</param>
        /// <returns>Task.</returns>
        public Task Edit(int ei, HrEmployeeCredentials employeeCredentials)
            => Task.Run(() =>
            {
                try
                {
                    if (!this.Exists(ei))
                    {
                        throw new Exception("Model is not exist!");
                    }

                    if (!this.CheckUserIfExistOrNot(ei))
                    {
                        throw new Exception("Employeyee is not exist!");
                    }

                    var model = this.GetSingle(ei);
                    this.ctx.Attach(model);
                    model.Empc_Mail = employeeCredentials.Empc_Mail;
                    model.Empc_Employee_Id = employeeCredentials.Empc_Employee_Id;
                    model.Empc_Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(employeeCredentials.Empc_Password));

                    this.ctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            });

        /// <summary>
        /// Check if employee credentials exists or not.
        /// </summary>
        /// <param name="employeeId">employeeId.</param>
        /// <returns>bool.</returns>
        private bool Exists(int employeeId)
            => this.ctx.Hr_Employee_Credentials.Any(x => x.Empc_Employee_Id == employeeId);

        private bool CheckUserIfExistOrNot(int employee_id)
            => this.ctx.Hr_Employees.Any(x => x.Emp_Id == employee_id);
    }
}


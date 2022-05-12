using EEM4QC_HFT_2021221.Logic;
using EEM4QC_HFT_2021221.Models;
using EEM4QC_HFT_2021221.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EEM4QC_HFT_2021221.Controllers
{
    /// <summary>
    /// Author: Sevinj Abdullayeva
    /// Description:
    /// All operations have general pattern and implements try...catch... exception handling.
    /// All functions connects users to repo layer and no operations are performed inskode controller.
    /// It includes following operations: Crud operation for employee work details model
    /// </summary>
    /// <response code="200">Returns object according to response of action.</response>
    /// <response code="400">Can be returned by other errors with error reason.</response>    
    /// <response code="401">If proper authentication not provkoded.</response> 
    /// <response code="403">If user doesn't have access to method.</response> 
    [Route("api/EEM4QC_HFT_2021221.Endpoint/[controller]/[action]")]
    [ApiController]
    public class EmployeeSalaryRecordController : ControllerBase
    {
        private readonly IBaseRepository _repo;
        private readonly ISalaryRecordLogic _salaryLogic;
        private readonly Data.DataContext dataContext;
        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="repo"></param>
        public EmployeeSalaryRecordController(Data.DataContext dataCon)
        {
            dataContext = dataCon;
            _repo = new BaseRepository(dataCon);
            _salaryLogic = new SalaryRecordLogic(_repo); 
        }

        /// <summary>
        /// Get employee 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMaxSalary()
        {
            try
            {
                var list = _salaryLogic.GetMaxSalary();
                
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get employee 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMinSalary()
        {
            try
            {
                var list = _salaryLogic.GetMinSalary();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAvrSalary()
        {
            try
            {
                var list = _salaryLogic.GetAvrSalary();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Create new employee salary record
        /// </summary>
        /// <param name="_da"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Create([FromBody] HrEmployeeSalaryRecord _da)
        {
            try
            {
                return Created("", _repo.SalaryRecordRepo.Create(_da));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update existed employee salary record by employee id
        /// </summary>
        /// <param name="employee_id"></param>
        /// <param name="_da"></param>
        /// <returns></returns>
        /// 
        [HttpPut("{employee_id}")]
        public IActionResult Update([FromRoute]int employee_id,[FromBody] HrEmployeeSalaryRecord _da)
        {
            try
            {
                return Ok(_repo.SalaryRecordRepo.Edit(employee_id,_da));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete existed salary record
        /// </summary>
        /// <param name="employee_id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{employee_id}")]
        public IActionResult Delete([FromRoute] int employee_id)
        {
            try
            {
                return Ok(_repo.SalaryRecordRepo.Delete(employee_id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

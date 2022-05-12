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
    /// It includes following operations: Crud operation for employee status model
    /// </summary>
    /// <response code="200">Returns object according to response of action.</response>
    /// <response code="400">Can be returned by other errors with error reason.</response>    
    /// <response code="401">If proper authentication not provkoded.</response> 
    /// <response code="403">If user doesn't have access to method.</response> 
    [Route("api/EEM4QC_HFT_2021221.Endpoint/[controller]/[action]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IBaseRepository _repo;
        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="repo"></param>
        public EmployeeStatusController(IBaseRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Create new employee status
        /// </summary>
        /// <param name="_dac"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Create([FromBody] HrEmployeeStatus _dac)
        {
            try
            {
                var result = _repo.EmployeeStatusRepo.Create(_dac);
                return Created("", new 
                {
                    _id = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new 
                {
                    _id = -1,
                    _e = ex.Message
                });
            }
        }

        /// <summary>
        /// Update existed employee status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_dac"></param>
        /// <returns></returns>
        /// 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HrEmployeeStatus _dac)
        {
            try
            {
                return Ok(_repo.EmployeeStatusRepo.Edit(id, _dac));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete existed employee status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repo.EmployeeStatusRepo.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

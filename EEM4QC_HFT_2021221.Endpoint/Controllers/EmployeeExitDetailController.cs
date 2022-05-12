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
    /// It includes following operations: Crud operation for employee exit detail model
    /// </summary>
    /// <response code="200">Returns object according to response of action.</response>
    /// <response code="400">Can be returned by other errors with error reason.</response>    
    /// <response code="401">If proper authentication not provkoded.</response> 
    /// <response code="403">If user doesn't have access to method.</response> 
    [Route("api/EEM4QC_HFT_2021221.Endpoint/[controller]/[action]")]
    [ApiController]
    public class EmployeeExitDetailController : ControllerBase
    {
        private readonly IBaseRepository _repo;
        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="repo"></param>
        public EmployeeExitDetailController(IBaseRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Create new department announcement
        /// </summary>
        /// <param name="_da"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Create([FromBody] HrEmployeeExitDetail _da)
        {
            try
            {
                return Created("", _repo.EmployeeExitDetailRepo.Create(_da));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update existed department announcement by employee id
        /// </summary>
        /// <param name="ei"></param>
        /// <param name="_da"></param>
        /// <returns></returns>
        /// 
        [HttpPut("{ei}")]
        public IActionResult Update([FromRoute] int ei, [FromBody] HrEmployeeExitDetail _da)
        {
            try
            {
                return Ok(_repo.EmployeeExitDetailRepo.Edit(ei,_da));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete existed department by employee id
        /// </summary>
        /// <param name="ei"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{ei}")]
        public IActionResult Delete([FromRoute] int ei)
        {
            try
            {
                return Ok(_repo.EmployeeExitDetailRepo.Delete(ei));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

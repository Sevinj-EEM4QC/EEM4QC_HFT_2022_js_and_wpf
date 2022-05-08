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
    public class EmployeeWorkDetailController : ControllerBase
    {
        private readonly IBaseRepository _repo;
        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="repo"></param>
        public EmployeeWorkDetailController(IBaseRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Create new employee work detail
        /// </summary>
        /// <param name="_da"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Create([FromBody] HrEmployeeWorkDetails _da)
        {
            try
            {
                return Created("", _repo.EmployeeWorkDetailRepo.Create(_da));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update existed employee word detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_da"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public IActionResult Update(int id,[FromBody] HrEmployeeWorkDetails _da)
        {
            try
            {
                return Ok(_repo.EmployeeWorkDetailRepo.Edit(id,_da));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete existed department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repo.EmployeeWorkDetailRepo.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

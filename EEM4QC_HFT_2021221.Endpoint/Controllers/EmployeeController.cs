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
    /// It includes following operations: Crud operation for employee model
    /// </summary>
    /// <response code="200">Returns object according to response of action.</response>
    /// <response code="400">Can be returned by other errors with error reason.</response>    
    /// <response code="401">If proper authentication not provkoded.</response> 
    /// <response code="403">If user doesn't have access to method.</response> 
    [Route("api/EEM4QC_HFT_2021221.Endpoint/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseRepository _repo;
        private readonly IEmployeeLogic _employeeLogic;
        private readonly Data.DataContext dataContext;

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="employeeLogic"></param>
        public EmployeeController(Data.DataContext dataCon)
        {
            dataContext = dataCon;
            _repo = new BaseRepository(dataCon);
            _employeeLogic = new EmployeeLogic(_repo);
           
           
        }


        /// <summary>
        /// Get employee 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_employeeLogic.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get existed employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUnExitedEmployees()
        {
            try
            {
                return Ok(_employeeLogic.GetUnExitedEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get existed employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetExitedEmployees()
        {
            try
            {
                return Ok(_employeeLogic.GetExitedEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get existed employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_employeeLogic.GetSingle(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="_ed"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Create([FromBody] HrEmployee _ed)
        {
            try
            {

                var result = _repo.EmployeeRepo.Create(_ed).Result.ToString();

                var emp = _repo.EmployeeRepo.GetSingle(Int32.Parse(result));
                return Ok(emp);
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
        /// Update existed employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_ed"></param>
        /// <returns></returns>
        /// 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HrEmployee _ed)
        {
            try
            {
                var updateStatus = _repo.EmployeeRepo.Edit(id, _ed).Result.ToString();

                if (updateStatus == "True")
                {
                    var emp = _repo.EmployeeRepo.GetSingle(id);
                    return Ok(emp);
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Delete existed employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var updateStatus =  _repo.EmployeeRepo.Delete(id).Result.ToString();
                if (updateStatus == "True")
                    return Ok();
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

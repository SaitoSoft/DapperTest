using Azure;
using DapperTest.Data.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.WebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly IDataLayer _dataLayer;
        public EmployeesController(IDataLayer dataLayer) 
        { 
            _dataLayer = dataLayer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employeeList = await _dataLayer.GetEmployees();
                return Ok(employeeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, decimal salary)
        {
            try
            {
                var result = await _dataLayer.UpdateEmployee(id, salary);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.Application.Entities;
using Com.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace Com.Application.API.Controllers
{

    [Route("api/[controller]")]
   // [Authorize] // Secure the Controller
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // 1. Define the Service Depednency for Department Data Access
        private readonly IDbAccess<Department, int> deptServ;

        /// <summary>
        /// 2. Inject the DepertmentDbAccess Service
        /// </summary>
        public DepartmentController(IDbAccess<Department,int> serv)
        {
            deptServ = serv;
        }

        /// <summary>
        /// https://localhost:[PORT]/api/Department
        /// </summary>
        /// <returns></returns>
        /// 
        //[Authorize(Roles = "Manager,Clerk,Operator")]
        [Authorize(Policy = "ReadPolicy")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await deptServ.GetAsync();
            return Ok(response);
        }

        // The Route Parameter 
        /// <summary>
        /// https://localhost:[PORT]/api/Department/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        // [Authorize(Roles = "Manager,Clerk,Operator")]
        [Authorize(Policy = "ReadPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await deptServ.GetAsync(id);
            return Ok(response);
        }
        // [Authorize(Roles = "Manager,Clerk")]
        [Authorize(Policy = "WritePolicy")]
        [HttpPost]
        public async Task<IActionResult> Post(Department department)
        {
            //try
            //{
                if (ModelState.IsValid)
                {

                    if (!IsDeptNameExist(department.DeptName))
                    {
                        var response = await deptServ.CreateAsync(department);
                        return Ok(response);
                    }
                    else
                    {
                        //return Conflict($"The DeptName : {department.DeptName} is already exist");
                        throw new Exception($"The DeptName : {department.DeptName} is already exist");
                    }

                }
                return BadRequest(ModelState);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
           
        }
        // [Authorize(Roles = "Manager,Clerk")]
        [Authorize(Policy = "WritePolicy")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department department)
        {
            var response = await deptServ.UpdateAsync(id,department);
            return Ok(response);
        }
        //[Authorize(Roles = "Manager")]
        [Authorize(Policy = "DeletePolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await deptServ.DeleteAsync(id);
            return Ok("Record is Deleted");
        }


        private bool IsDeptNameExist(string deptName)
        {
            bool isExist = false;

            var dept = deptServ.GetAsync().Result
                               .Where(d => d.DeptName.Trim() == deptName.Trim())
                               .First();
            if (dept != null)
                isExist = true; // DeptName already exist

            return isExist;
        }
    }
}

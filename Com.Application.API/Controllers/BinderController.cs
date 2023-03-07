using Com.Application.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Application.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BinderController : ControllerBase
    {
        [HttpPost]
        [ActionName("frombody")]
        public IActionResult PostFromBody([FromBody] Department dept)
        {
            return Ok(dept);
        }

        [HttpPost]
        [ActionName("fromqueryold")]
        public IActionResult PostFromQueryOld(int DeptNo, string DeptName,int Capacity, string Location)
        {
            Department dept = new Department() 
            {
               DeptNo = DeptNo,
                DeptName = DeptName,
                Capacity = Capacity,
                Location = Location

            };
            return Ok(dept);
        }

        [HttpPost]
        [ActionName("fromquery")]
        public IActionResult PostFromQuery([FromQuery]Department dept)
        {
             
            return Ok(dept);
        }


        [HttpPost("{DeptNo}/{DeptName}/{Capacity}/{Lcoation}")]
        [ActionName("fromroute")]
        public IActionResult PostFromRoute([FromRoute]Department dept)
        {
            
            return Ok(dept);
        }
    }
}

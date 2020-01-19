using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.CodeBase.ServiceLayer;
using TimeTracking.Entities;

namespace TimeTracking.Controllers
{
    [Route("api/jobtypes")]
    [ApiController]
    public class JobTypesController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<JobType> GetAllJobTypes()
        {
            return MainService.GetAllJobTypes();
        }

        [Route("{ID}"), HttpGet]
        public JobType GetSingleJobType([FromRoute] int ID)
        {
            return MainService.GetSingleJobType(ID);
        }

        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteJobType([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteJobType(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route(""), HttpPost]
        public int InsertJobType([FromBody] JobType jobType)
        {
            return MainService.InsertJobType(jobType);
        }

        [Route(""), HttpPut]
        public IActionResult UpdateJobType([FromBody] JobType jobType)
        {
            try
            {
                MainService.UpdateJobType(jobType);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
    }
}

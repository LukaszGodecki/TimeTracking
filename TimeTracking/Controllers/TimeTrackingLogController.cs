using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.CodeBase.ServiceLayer;
using TimeTracking.Entities;

namespace TimeTracking.Controllers 
{
    [Route("api/timeTrackingLog")]
    [ApiController]
    public class TimeTrackingLogController : ControllerBase
    {

        [Route(""), HttpPost]
        public IActionResult InsertTimeTrackingLogs([FromBody] TimeTrackingLog timeTrackingLog)
        {
            try
            {
                MainService.InsertTimeTrackingLog(timeTrackingLog);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route("{Job}"), HttpGet]
        public List<TimeTrackingLog> GetAllTimeTrackingLogsForSelectedJob([FromRoute] string job)
        {
            return MainService.GetAllTimeTrackingLogsForSelectedJob(job);
        }
    }    
}

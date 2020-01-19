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
    [Route("api/timeTrackingGroup")]
    [ApiController]
    public class TimeTrackingGroupController : ControllerBase
    {
        [HttpGet]
        public List<TimeTrackingGroup> GetTimeTrackingGroups([FromQuery] string guid, string job, int jobTypeId)
        {
            return MainService.GetTimeTrackingGroups(guid, job, jobTypeId);
        }
    }
}

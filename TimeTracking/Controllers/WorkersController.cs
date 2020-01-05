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
    [Route("api/workers")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<Worker> GetAllWorkers()
        {
            return MainService.GetAllWorkers();
        }

        [Route("{ID}"), HttpGet]
        public Worker GetSingleWorker([FromRoute] int ID)
        {
            return MainService.GetSingleWorker(ID);
        }

        [Route(""), HttpPost]
        public int InsertWorker([FromBody] Worker worker)
        {
            return MainService.InsertWorker(worker);
        }

        [Route(""), HttpPut]
        public IActionResult UpdateWorker([FromBody] Worker worker)
        {
            try
            {
                MainService.UpdateWorker(worker);
                return Ok();
            } catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }            
        }

        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteWorker([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteWorker(ID);
                return Ok();
            } catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }                
        }
    }
}
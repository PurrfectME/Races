using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.WebSockets;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForServices;
using CockroachRaces.Models;

namespace CockroachRaces.Areas.Admin.Controllers
{
    
    public class RaceController : ApiController
    {
        private readonly IRaceService _service;


        public RaceController(IRaceService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("Race/ActiveRaces")]
        public async Task<IHttpActionResult> GetActiveRaces()
        {
            var result = await _service.GetActiveRaces();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("Race/AllRaces")]
        public async Task<IHttpActionResult> AllRaces()
        {
            var result = (await _service.GetAllRaces()).Select(x => new RaceModel(x));
            
            return Ok(result);
        }

        [HttpPost]
        [Route("Admin/StartRace")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> StartRace(RaceModel raceModel)
        {
            raceModel.Id = Guid.NewGuid();
            raceModel.StartTime = DateTime.Now;
            raceModel.IsFinished = false;
       
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.Create((Race)raceModel);

            return Ok(raceModel);
        }

        [HttpGet]
        [Route("Race/FinishedRaces")]
        public async Task<IHttpActionResult> FinishedRaces()
        {
            var activeRaces = (await _service.GetActiveRaces()).Select(x => new RaceModel(x));
            
            return Ok(activeRaces);
        }
    }
}

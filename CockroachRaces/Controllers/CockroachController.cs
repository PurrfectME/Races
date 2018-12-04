using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForServices;
using CockroachRaces.Models;

namespace CockroachRaces.Controllers
{
    public class CockroachController : ApiController
    {
        private readonly ICockroachService _service;

        public CockroachController(ICockroachService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Cockroach/Create/")]
        public async Task<IHttpActionResult> Create(CockroachModel cockroach)
        {
            var id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cr = new Cockroach{Id = id, Name = cockroach.Name, RaceId = cockroach.RaceId};

            await _service.Create(cr);

            return Ok(cockroach);
        }

        [HttpGet]
        [Route("Cockroach/GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = (await _service.GetAllCockroaches()).Select(x => new CockroachModel(x));


            return Ok(result);
        }

        
    }
}

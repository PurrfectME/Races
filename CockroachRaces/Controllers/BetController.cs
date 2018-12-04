using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForServices;
using CockroachRaces.Managers;
using CockroachRaces.Models;
using Microsoft.AspNet.Identity;

namespace CockroachRaces.Controllers
{
    public class BetController : ApiController
    {
        private readonly ApplicationUserManager _manager;
        private readonly IBetService _service;


        public BetController(IBetService service, ApplicationUserManager manager)
        {
            _service = service;
            _manager = manager;
        }


        [HttpGet]
        [Route("Bet/UserBets")]
        public async Task<IHttpActionResult> GetUserBets()
        {
            var userId = new Guid(User.Identity.GetUserId());

            var result = await _service.GetBetByUser(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("Bet/PlaceBet")]
        public async Task<IHttpActionResult> PlaceBet(BetModel model)
        {
            var userId = new Guid(User.Identity.GetUserId());
            var user = await _manager.FindByIdAsync(userId);

            model.Id = Guid.NewGuid();
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bet = (Bet) model;
            bet.UserId = userId;
            await _manager.UpdateAsync(user);

            
            await _service.Create(bet);

            return Ok(model);
        }

        [HttpPost]
        [Route("Bet/CalculateBet/")]
        public async Task<IHttpActionResult> CalculateBet(RaceModel race)
        {
            var users = new List<User>();

           

            var allBetsInCurrentRace = await _service.GetBetByRace(race.Id);

            var winSum = 0d;
            var lowestCockroachBet = 0d;

            lowestCockroachBet = allBetsInCurrentRace.Min(x => x.TotalAmount);

            
            foreach (var bet in allBetsInCurrentRace)
            {
                var isWinner = await _manager.FindByIdAsync(bet.UserId);

                if (lowestCockroachBet.Equals(bet.TotalAmount))
                {
                    users.Add(isWinner);
                }
                winSum += bet.TotalAmount;
            }
            
            winSum = (winSum - ((winSum / 100) * 10)) / lowestCockroachBet;

            foreach (var user in users)
            {
                user.Balance += winSum;
                await _manager.UpdateAsync(user);

            }

            return Ok(users);
        }
    }
}

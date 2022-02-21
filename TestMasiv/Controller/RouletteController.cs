using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestMasiv.DTO;
using TestMasiv.Models;
using TestMasiv.Services;

namespace TestMasiv.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteServices RouletteServices;

        public RouletteController(IRouletteServices rouletteServices)
        {
            RouletteServices = rouletteServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(RouletteServices.GetAll());
        }

        [HttpPost]
        public IActionResult NewRulette()
        {
            Roulette Roulette = RouletteServices.Create();
            return Ok(Roulette);
        }

        [HttpPut("{id}/close")]
        public IActionResult Close([FromRoute(Name ="id")] string id)
        {
            try
            {
                Roulette Roulette = RouletteServices.Close(id);
                return Ok(Roulette);

            }
            catch (System.Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(404);
            }
        }

        [HttpPost("{id}/bet")]
        public IActionResult Bet([FromHeader(Name = "user-id")] string UserId,[FromRoute(Name = "id")] string id, [FromBody] BetRequest request )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "bad request, call administrator"
                });
            }

            try
            {
                Roulette Roulette = RouletteServices.Bet(id, UserId, request.Position, request.Money);
                return Ok(Roulette);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(404);
            }
        }

    }
}

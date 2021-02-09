using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomCharacter.Data;
using CustomCharacter.Models;
using CustomCharacter.Models.Interface;
using CustomCharacter.Models.API;

namespace CustomCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IRace _race;

        public RacesController(IRace race)
        {
            _race = race;
        }

        // GET: api/Races
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceDTO>>> GetRaces()
        {
            return Ok(await _race.GetRaces());
        }

        // GET: api/Races/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
            return await _race.GetRace(id);
        }

        // PUT: api/Races/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(RaceDTO race)
        { 

            var updateRace = await _race.UpdateRace(race);
            return Ok(updateRace);
        }

        // POST: api/Races
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Race>> PostRace(RaceDTO race)
        {
            await _race.CreateRace(race);
            return CreatedAtAction("GetRace", new { Id = race.Id, race });
        }

        // DELETE: api/Races/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Race>> DeleteRace(int id)
        {
            await _race.DeleteRace(id);
            return NoContent();
        }
    }
}

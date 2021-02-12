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
    public class AbilitiesController : ControllerBase
    {
        private readonly IAbility _context;

        public AbilitiesController(IAbility context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbilityDTO>>> GetAbilities()
        {
            return Ok(await _context.GetAbilities());
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(int id)
        {
            AbilityDTO ability = await _context.GetAbility(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }

        // PUT: api/Abilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbility(int id, AbilityDTO ability)
        {
            if (id != ability.Id)
            {
                return BadRequest();
            }

            var updateability = await _context.UpdateAbilities(ability);
            return Ok(updateability);
        }

        // POST: api/Abilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ability>> PostAbility(AbilityDTO ability)
        {
            await _context.Create(ability);
            return CreatedAtAction("GetAbilities", new { id = ability.Id }, ability);
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ability>> DeleteAbility(int id)
        {
            await _context.DeleteAbility(id);
            return NoContent();
        }
    }
}

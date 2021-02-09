using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomCharacter.Data;
using CustomCharacter.Models;
using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;

namespace CustomCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkill _skill;

        public SkillsController(ISkill skill)
        {
            _skill = skill;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills()
        {
            return Ok(await _skill.GetSkills());
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDTO>> GetSkill(int id)
        {
            var skill = await _skill.GetSkill(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, SkillDTO skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            var updateSkill = await _skill.UpdateSkill(id, skill);
            return Ok(updateSkill);
        }

        // POST: api/Skills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(SkillDTO skill)
        {
            await _skill.Create(skill);
            return CreatedAtAction("GetSkill", new { Id = skill.Id, skill });

        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Skill>> DeleteSkill(int id)
        {
            await _skill.DeleteSkill(id);
            return NoContent();
        }
    }
}

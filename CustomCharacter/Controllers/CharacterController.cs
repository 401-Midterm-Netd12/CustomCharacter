using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;

        public CharacterController(ICharacter character)
        {
            _character = character;
        }

        // Get: api/Character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharaters()
        {
            return Ok(await _character.GetCharacters());
        }

        // Get: api/Character/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharater(int Id)
        {
            var character = await _character.GetCharacter(Id);

            if (character == null) return NotFound();
            return character;
        }

        // Post: api/Character
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> PostCharater(CharacterDTO characterDTO)
        {
            await _character.Create(characterDTO);
            return CreatedAtAction("GetCharater", new { Id = characterDTO.Id, characterDTO});

        }

        // Put: api/Character/1
        [HttpPut("{Id}")]
        public async Task<ActionResult<CharacterDTO>> UpdateCharacter(int Id, CharacterDTO characterDTO)
        {
            if (Id != characterDTO.Id) return BadRequest();

            var updateCharacter= await _character.UpdateCharacter(Id, characterDTO);
            return Ok(updateCharacter);
        }

        // Delete: api/Character/1
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CharacterDTO>> DeleteCharater(int Id)
        {
            await _character.DeleteCharacter(Id);
            return NoContent();
        }
    }
}

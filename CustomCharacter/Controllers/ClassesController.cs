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
    public class ClassesController : ControllerBase
    {
        private readonly IClass _class;

        public ClassesController(IClass classData)
        {
            _class = classData;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return Ok(await _class.GetClasses());
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            Class classObj = await _class.GetClass(id);

            if (classObj == null)
            {
                return NotFound();
            }

            return classObj;
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(ClassDTO classDTO)
        {
            var updatedClass = await _class.UpdateClass(classDTO);
            return Ok(updatedClass);
        }

        // POST: api/Classes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(ClassDTO classDTO)
        {
            await _class.CreateClass(classDTO);
            return CreatedAtAction("GetRooms", new { id = classDTO.Id }, classDTO);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClass(int id)
        {
            await _class.DeleteClass(id);
            return NoContent();
        }

    }
}

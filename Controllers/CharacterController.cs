using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet7_webapi_mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            var character = _characterService.GetSingle(id);
            if (character == null) return NotFound("No character found.");
            return Ok(character);       
        }

        [HttpPost]
        public ActionResult<List<Character>> Create(Character newCharacter)
        {
            return Ok(_characterService.Create(newCharacter));
        }
    }
}
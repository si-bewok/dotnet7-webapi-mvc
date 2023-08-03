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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            return Ok(await _characterService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
        {
            var response = await _characterService.GetSingle(id);
            if (response.Data == null) return NotFound(response);
            return Ok(response);       
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Create(CreateCharacterDTO newCharacter)
        {
            return Ok(await _characterService.Create(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> Update(UpdateCharacterDTO updateCharacter)
        {
            var response = await _characterService.Update(updateCharacter);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }
    }
}
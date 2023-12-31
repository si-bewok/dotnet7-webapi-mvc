using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_webapi_mvc.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        // private static List<Character> characters = new List<Character> {
        //     new Character(),
        //     new Character { Id = 1, Name = "Sam" }
        // };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> Get()
        {
            var dbCharacters = await _context.Characters.ToListAsync();
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>
            {
                //Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList()
                Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {
                // var character = characters.FirstOrDefault(c => c.Id == id);
                // if (character == null) throw new Exception($"Character with Id '{id}' not found.");
                // serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
                var dbCharacter = await _context.Characters.FindAsync(id);
                if (dbCharacter == null) throw new Exception($"Character with Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> Create(CreateCharacterDTO newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            // var character = _mapper.Map<Character>(newCharacter);
            // character.Id = characters.Max(c => c.Id) + 1;
            // characters.Add(character);
            // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            _context.Characters.Add(_mapper.Map<Character>(newCharacter));
            await _context.SaveChangesAsync();

            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> Update(UpdateCharacterDTO updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {
                // var character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
                // if (character == null) throw new Exception($"Character with Id '{updateCharacter.Id}' not found.");
                // character.Name = updateCharacter.Name;
                // character.HitPoints = updateCharacter.HitPoints;
                // character.Strength = updateCharacter.Strength;
                // character.Defense = updateCharacter.Defense;
                // character.Intelligence = updateCharacter.Intelligence;
                // character.Class = updateCharacter.Class;
                // serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
                
                var dbCharacter = await _context.Characters.FindAsync(updateCharacter.Id);
                if (dbCharacter == null) throw new Exception($"Character with Id '{updateCharacter.Id}' not found.");
                
                dbCharacter.Name = updateCharacter.Name;
                dbCharacter.HitPoints = updateCharacter.HitPoints;
                dbCharacter.Strength = updateCharacter.Strength;
                dbCharacter.Defense = updateCharacter.Defense;
                dbCharacter.Intelligence = updateCharacter.Intelligence;
                dbCharacter.Class = updateCharacter.Class;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);           
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try
            {
                // var character = characters.FirstOrDefault(c => c.Id == id);
                // if (character == null) throw new Exception($"Character with Id '{id}' not found.");

                // characters.Remove(character);
                // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

                var deleteCharacter = await _context.Characters.FindAsync(id);
                if (deleteCharacter == null) throw new Exception($"Character with Id '{id}' not found.");

                _context.Characters.Remove(deleteCharacter);
                await _context.SaveChangesAsync();
                var dbCharacters = await _context.Characters.ToListAsync();

                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_webapi_mvc.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> Get();
        Task<ServiceResponse<GetCharacterDTO>> GetSingle(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> Create(CreateCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> Update(UpdateCharacterDTO updateCharacter);
        Task<ServiceResponse<List<GetCharacterDTO>>> Delete(int id);
    }
}
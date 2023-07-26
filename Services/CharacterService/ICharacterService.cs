using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_webapi_mvc.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> Get();
        Character GetSingle(int id);
        List<Character> Create(Character newCharacter);
    }
}
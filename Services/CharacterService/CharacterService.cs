using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_webapi_mvc.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };

        public List<Character> Get()
        {
            return characters;
        }

        public Character GetSingle(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }

        public List<Character> Create(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }
    }
}
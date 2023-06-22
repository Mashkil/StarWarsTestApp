using StarWarsTestApp.Data;
using StarWarsTestApp.Data.BLOEntities;
using StarWarsTestApp.Data.Entities;

namespace StarWarsTestApp.Interfaces
{
    public interface ICharacterService
    {
        public Task AddCharacter(CharacterWithFilms character);

        public Task RemoveCharacter(int characterId);

        public Task UpdateCharacter(int idCharacter, CharacterAdd character);

        public Task<List<Character>> GetCharacters(DateTime? startDate, DateTime? endDate, string filmName, string planet, string sex);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StarWarsTestApp.Data;
using StarWarsTestApp.Data.BLOEntities;
using StarWarsTestApp.Data.Entities;
using StarWarsTestApp.Interfaces;

namespace StarWarsTestApp.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly StarWarsDbContext _context;
        private readonly IMapper _mapper;
        public CharacterService(StarWarsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCharacter(CharacterWithFilms characterToAdd)
        {
            var newCharacter = _mapper.Map<Character>(characterToAdd);

            _context.Characters.Add(newCharacter);

            List<Film> newFilms = new();

            foreach (var film in characterToAdd.Films)
                newFilms.Add(_mapper.Map<Film>(film));

            _context.Films.AddRange(newFilms);

            await _context.SaveChangesAsync();

            List<CharacterFilms> characterFilms = new();

            foreach (var film in newFilms)
            {
                _context.CharactersFilms.Add(new CharacterFilms
                {
                    CharacterId = newCharacter.Id,
                    FilmId = film.Id
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Character>> GetCharacters(DateTime? startDate, DateTime? endDate, string filmName, string planet, string sex)
        {
            var film = await _context.Films
                .Include(e => e.CharacterFilms)
                .ThenInclude(e => e.Character)
                .FirstOrDefaultAsync(e => e.Name == filmName);

            if (film == null)
                throw new Exception($"Not Found Film with Name {filmName}");

            List<Character> characters = new();

            foreach (var character in film.CharacterFilms)
            {
                if (character.Character.DateOfBirth >= startDate && character.Character.DateOfBirth <= endDate
                    && character.Character.Planet == planet && character.Character.Sex == sex)
                    characters.Add(character.Character);
            }

            return characters;
        }

        public async Task RemoveCharacter(int characterId)
        {
            var character = _context.Characters.FirstOrDefault(e => e.Id == characterId);

            if (character != null)
            {
                _context.Characters.Remove(character);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCharacter(int idCharacter, CharacterAdd character)
        {
            var updateCharacter = await _context.Characters.FirstOrDefaultAsync(e => e.Id == idCharacter);

            updateCharacter = _mapper.Map<Character>(character);

            await _context.SaveChangesAsync();
        }
    }
}

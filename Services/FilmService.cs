using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StarWarsTestApp.Data;
using StarWarsTestApp.Data.BLOEntities;
using StarWarsTestApp.Data.Entities;
using StarWarsTestApp.Interfaces;

namespace StarWarsTestApp.Services
{
    public class FilmService : IFilmService
    {
        private readonly StarWarsDbContext _context;
        private readonly IMapper _mapper;
        public FilmService(StarWarsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(FilmWithCharacters film)
        {
            var filmToAdd = _mapper.Map<Film>(film);

            List<Character> characters = new List<Character>();

            foreach (var character in film.Characters)
                characters.Add(_mapper.Map<Character>(character));

            _context.Films.Add(filmToAdd);
            _context.Characters.AddRange(characters);

            await _context.SaveChangesAsync();

            foreach (var character in characters)
            {
                _context.CharactersFilms.Add(new CharacterFilms
                {
                    CharacterId = character.Id,
                    FilmId = filmToAdd.Id
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int filmId)
        {
            var filmToRemove = await _context.Films.FirstOrDefaultAsync(e => e.Id == filmId);

            if (filmToRemove != null)
            {
                _context.Films.Remove(filmToRemove);

                await _context.SaveChangesAsync();
            }

        }
    }
}

using StarWarsTestApp.Data.BLOEntities;

namespace StarWarsTestApp.Interfaces
{
    public interface IFilmService
    {
        public Task Add(FilmWithCharacters film);
        public Task Remove(int filmId);
    }
}

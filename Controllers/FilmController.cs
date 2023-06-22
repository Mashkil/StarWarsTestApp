using Microsoft.AspNetCore.Mvc;
using StarWarsTestApp.Data.BLOEntities;
using StarWarsTestApp.Interfaces;
using System.Net;

namespace StarWarsTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        /// <summary>
        /// Добавляет фильм и персонажей
        /// </summary>
        /// <param name="film">Объект фильма и персонажей, которые в нем учавстуют</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task Add([FromBody] FilmWithCharacters film)
        {
            await _filmService.Add(film);
        }

        /// <summary>
        /// Удаляет фильм
        /// </summary>
        /// <param name="filmId">Id фильма</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpDelete]
        public async Task Remove(int filmId)
        {
            await _filmService.Remove(filmId);
        }

    }
}

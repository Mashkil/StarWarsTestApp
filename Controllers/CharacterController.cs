using Microsoft.AspNetCore.Mvc;
using StarWarsTestApp.Data;
using StarWarsTestApp.Data.BLOEntities;
using StarWarsTestApp.Data.Entities;
using StarWarsTestApp.Interfaces;
using System.Net;

namespace StarWarsTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService service)
        {
            _characterService = service;
        }

        /// <summary>
        /// Добавляет персонажа
        /// </summary>
        /// <param name="character">Объект персонажа и фильмов с его участием</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task AddCharacter([FromBody] CharacterWithFilms character)
        {
            await _characterService.AddCharacter(character);
        }

        /// <summary>
        /// Получает список персонажей согласно фильтру
        /// </summary>
        /// <param name="startDate">Объект персонажа</param>
        ///  <param name="endDate">Объект персонажа</param>
        ///  <param name="filmName">Объект персонажа</param>
        ///  <param name="planet">Объект персонажа</param>
        ///  <param name="sex">Объект персонажа</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{startDate}/{endDate}/{filmName}/{planet}/{sex}")]
        public async Task<List<Character>> GetCharacters(DateTime? startDate, DateTime? endDate, string filmName, string planet, string sex)
        {
            return await _characterService.GetCharacters(startDate, endDate, filmName, planet, sex);
        }


    }
}

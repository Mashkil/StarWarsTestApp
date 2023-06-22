using System.ComponentModel.DataAnnotations;

namespace StarWarsTestApp.Data.Entities
{
    public class CharacterFilms
    {
        [Key]
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public int FilmId { get; set; }

        public Character Character { get; set; }

        public Film Film { get; set; }
    }
}

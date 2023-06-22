using System.ComponentModel.DataAnnotations;

namespace StarWarsTestApp.Data.Entities
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<CharacterFilms> CharacterFilms { get; set; }
    }
}

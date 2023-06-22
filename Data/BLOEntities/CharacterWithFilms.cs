using System.ComponentModel.DataAnnotations;

namespace StarWarsTestApp.Data.BLOEntities
{
    public class CharacterWithFilms
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string OriginalName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Planet { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public double Growth { get; set; }

        [Required]
        public string ColorOfHair { get; set; }

        [Required]
        public string ColorOfEyes { get; set; }

        public List<FilmAdd> Films { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsTestApp.Data.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

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

        public List<CharacterFilms> CharacterFilms { get; set; }

    }
}

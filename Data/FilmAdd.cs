using System.ComponentModel.DataAnnotations;

namespace StarWarsTestApp.Data
{
    public class FilmAdd
    {
        [Required]
        public string Name { get; set; }
    }
}

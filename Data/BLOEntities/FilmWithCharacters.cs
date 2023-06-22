namespace StarWarsTestApp.Data.BLOEntities
{
    public class FilmWithCharacters
    {
        public string Name { get; set; }

        public List<CharacterAdd> Characters { get; set; }
    }
}

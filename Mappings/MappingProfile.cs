using AutoMapper;
using StarWarsTestApp.Data;
using StarWarsTestApp.Data.BLOEntities;
using StarWarsTestApp.Data.Entities;

namespace StarWarsTestApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CharacterWithFilms, Character>()
                .ForMember(e => e.Id, c => c.Ignore())
                .ForMember(e => e.CharacterFilms, c => c.Ignore());

            CreateMap<FilmWithCharacters, Film>()
                .ForMember(e => e.Id, c => c.Ignore())
                .ForMember(e => e.CharacterFilms, c => c.Ignore());

            CreateMap<FilmAdd, Film>()
                .ForMember(e => e.Id, c => c.Ignore())
                .ForMember(e => e.CharacterFilms, c => c.Ignore());

            CreateMap<CharacterAdd, Character>()
                .ForMember(e => e.Id, c => c.Ignore())
                .ForMember(e => e.CharacterFilms, c => c.Ignore());
        }
    }
}

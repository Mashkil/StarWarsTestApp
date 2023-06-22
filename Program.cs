using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StarWarsTestApp.Data;
using StarWarsTestApp.Interfaces;
using StarWarsTestApp.Mappings;
using StarWarsTestApp.Services;

namespace StarWarsTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            builder.Services.AddDbContext<StarWarsDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString")));

            builder.Services.AddScoped<ICharacterService, CharacterService>();

            builder.Services.AddScoped<IFilmService, FilmService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain To Dto
            Mapper.CreateMap<Movie, MovieDto>().ForMember(
              Dest => Dest.GenreDto,
              opt => opt.MapFrom(src => src.Genre));

            Mapper.CreateMap<Genre, GenreDto>();


            // Dto To Domain  
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}
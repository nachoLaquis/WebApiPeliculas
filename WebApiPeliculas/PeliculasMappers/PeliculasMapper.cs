using AutoMapper;
using WebApiPeliculas.Modelos;
using WebApiPeliculas.Modelos.Dtos;

namespace WebApiPeliculas.PeliculasMapper
{
    public class PeliculasMapper: Profile
    {
        public PeliculasMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaCrearDto>().ReverseMap();
        }
    }
}

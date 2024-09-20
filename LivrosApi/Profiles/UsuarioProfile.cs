using AutoMapper;
using LivrosApi.Data.Dtos.Admin;
using LivrosApi.Models;

namespace LivrosApi.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
		CreateMap<CreateUsuarioDto, Usuario>();
	}
}

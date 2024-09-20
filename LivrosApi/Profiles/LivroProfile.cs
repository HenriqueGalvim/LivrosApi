using AutoMapper;
using ComexAPI.Data.Dtos.Livro;
using LivrosApi.Data.Dtos.Cliente;
using LivrosApi.Data.Dtos.Livro;
using LivrosApi.Models;

namespace LivrosApi.Profiles;

public class LivroProfile: Profile
{
    public LivroProfile()
    {
		CreateMap<CreateLivroDto, Livro>();
		CreateMap<UpdateLivroDto, Livro>();
		CreateMap<Livro, UpdateLivroDto>();
		CreateMap<Livro, ReadLivroDto>();
	}
}

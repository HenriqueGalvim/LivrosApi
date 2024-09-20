using LivrosApi.Data.Dtos.Cliente;
using AutoMapper;
using LivrosApi.Models;
using ComexAPI.Data.Dtos.Cliente;

namespace LivrosApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
		CreateMap<CreateClienteDto, Cliente>();
		CreateMap<UpdateClienteDto, Cliente>();
		CreateMap<Cliente, UpdateClienteDto>();
		CreateMap<Cliente, ReadClienteDto>()
			.ForMember(clienteDto => clienteDto.LivrosEmprestados,
				opt => opt.MapFrom(cliente => cliente.LivrosEmprestados));
	}
}

using AutoMapper;
using LivrosApi.Data.Dtos.Admin;
using LivrosApi.Models;

namespace LivrosApi.Profiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
		CreateMap<CreateAdminDto, Admin>();
	}
}

using AutoMapper;
using LivrosApi.Data.Dtos.Admin;
using LivrosApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class AdminController: ControllerBase
{
	private IMapper _mapper;
	private UserManager<Admin> _userManager;

	public AdminController(IMapper mapper, UserManager<Admin> userManager)
	{
		_mapper = mapper;
		_userManager = userManager;
	}

	[HttpPost("cadastro")]
	public async Task<IActionResult>
		CadastraAdmin(CreateAdminDto CreateAdminDto)
	{
		Admin admin = _mapper.Map<Admin>(CreateAdminDto);
		admin.DataNascimento = CreateAdminDto.DataNascimento.ToUniversalTime();
		IdentityResult resultado = await _userManager.CreateAsync(admin, CreateAdminDto.Password);

		if (resultado.Succeeded)
			return Ok("Administrador cadastrado!");

		throw new ApplicationException("Falha ao cadastrar administrador!");
	}
}

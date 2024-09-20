using AutoMapper;
using LivrosApi.Data.Dtos.Admin;
using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController: ControllerBase
{
	private IMapper _mapper;
	private UserManager<Usuario> _userManager;
	private UsuarioService _userService;
	public UsuarioController(IMapper mapper, UserManager<Usuario> userManager, UsuarioService userService)
	{
		_mapper = mapper;
		_userManager = userManager;
		_userService = userService;
	}

	/// <summary>
	/// Cadastra um novo usuário.
	/// </summary>
	/// <param name="CreateUsuarioDto">Objeto com os dados do novo usuário.</param>
	/// <returns>
	/// Retorna 200 OK se o usuário foi cadastrado com sucesso.
	/// </returns>
	[HttpPost("cadastro")]
	public async Task<IActionResult>
		CadastroUsuario(CreateUsuarioDto CreateUsuarioDto)
	{
		await _userService.Cadastrar(CreateUsuarioDto);
		return Ok("Usuario Cadastrado com sucesso");
	}

	/// <summary>
	/// Efetua o login de um usuário.
	/// </summary>
	/// <param name="LoginUsuarioDto">Objeto com as credenciais de login do usuário.</param>
	/// <returns>
	/// Retorna 200 OK com o token de acesso do usuário, se o login for bem-sucedido.
	/// </returns>
	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginUsuarioDto LoginUsuarioDto)
	{
		var token = await _userService.Login(LoginUsuarioDto);
		return Ok(token);

	}

}

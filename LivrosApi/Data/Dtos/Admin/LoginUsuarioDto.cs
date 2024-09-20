using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.Dtos.Admin;

public class LoginUsuarioDto
{
	[Required]
	public string Username { get; set; }

	[Required]
	public string Password { get; set; }
}

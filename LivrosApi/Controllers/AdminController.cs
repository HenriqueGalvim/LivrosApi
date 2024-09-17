using LivrosApi.Data.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class AdminController: ControllerBase
{
	[HttpPost]
	public IActionResult CadastraAdmin(CreateAdminDto CreateAdminDto)
	{
		throw new NotImplementedException();
	}
}

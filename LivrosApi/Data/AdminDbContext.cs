using LivrosApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data;

public class AdminDbContext : IdentityDbContext<Admin>
{
	public AdminDbContext
	 (DbContextOptions<AdminDbContext> opts) : base(opts) { }
}

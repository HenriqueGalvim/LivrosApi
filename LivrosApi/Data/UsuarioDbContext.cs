using LivrosApi.Data.Dtos.Cliente;
using LivrosApi.Data.Dtos.Livro;
using LivrosApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data;

public class UsuarioDbContext : IdentityDbContext<Usuario>
{
	public UsuarioDbContext
	 (DbContextOptions<UsuarioDbContext> opts) : base(opts) { }
	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Livro> Livros { get; set; }
}

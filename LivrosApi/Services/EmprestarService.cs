using LivrosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Services;

public class EmprestarService
{
	private UsuarioDbContext _context;

	public EmprestarService(UsuarioDbContext context)
	{
		_context = context;
	}

	public async Task<bool> EmprestarLivro(int livroId, int clienteId)
	{
		// Verifica se o livro está disponível
		var livro = _context.Livros.FirstOrDefault(l => l.Id == livroId && l.ClienteId == null);
		if (livro == null)
		{
			return false; // Livro não disponível
		}

		// Verifica se o cliente já possui 3 livros emprestados
		var livrosEmprestados = _context.Clientes.FirstOrDefault(c => c.Id == clienteId)?.LivrosEmprestados;
		if (livrosEmprestados != null && livrosEmprestados.Count >= 3)
		{
			return false; // Cliente já possui 3 livros emprestados
		}

		// Empresta o livro para o cliente
		livro.ClienteId = clienteId;
		livro.Emprestado = true;
		_context.SaveChanges();

		return true;
	}

	public async Task<bool> DevolverLivro(int livroId)
	{
		// Busca o livro
		var livro = _context.Livros.FirstOrDefault(l => l.Id == livroId);
		if (livro == null || !livro.Emprestado)
		{
			return false; // Livro não encontrado
		}

		// Devolve o livro
		livro.ClienteId = null;
		livro.Emprestado = false;
		_context.SaveChanges();

		return true;
	}
}

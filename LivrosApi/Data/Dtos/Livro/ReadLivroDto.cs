using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivrosApi.Data.Dtos.Cliente;
using LivrosApi.Models;

namespace LivrosApi.Data.Dtos.Livro;

public class ReadLivroDto
{
	public int Id { get; set; }
	public string Titulo { get; set; }
	public string Autor { get; set; }
	public string ISBN { get; set; }
	public DateTime DataPublicacao { get; set; }
	public bool Emprestado { get; set; } = false;
	public int? ClienteId { get; set; }

}

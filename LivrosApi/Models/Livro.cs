using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace LivrosApi.Models;

public class Livro
{
	[Key]
	[Required]
	public int Id { get; set; }
	[Required]
	public string Titulo { get; set; }
	[Required]
	public string Autor { get; set; }
	[Required]
	public string ISBN { get; set; }
	[Required]
	public DateTime DataPublicacao { get; set; }

	public bool Emprestado { get; set; } = false;

	[ForeignKey("Id")]
	public int? ClienteId { get; set; }

}

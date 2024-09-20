using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using LivrosApi.Data;
using LivrosApi.Data.Dtos.Livro;

namespace LivrosApi.Models;

public class Cliente
{
	[Key]
	[Required]
	public int Id { get; set; }

	[Required]
	public string Nome { get; set; }

	[Required]
	public string Cpf { get; set; }

	public virtual ICollection<Livro> LivrosEmprestados { get; set; }

}

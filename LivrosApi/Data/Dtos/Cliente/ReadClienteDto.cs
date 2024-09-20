using LivrosApi.Data.Dtos.Livro;

namespace LivrosApi.Data.Dtos.Cliente;

public class ReadClienteDto
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Cpf { get; set; }
	public ICollection<ReadLivroDto> LivrosEmprestados { get; set; }
}

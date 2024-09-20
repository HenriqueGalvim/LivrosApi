namespace ComexAPI.Data.Dtos.Livro;

public class UpdateLivroDto
{
	public string Titulo { get; set; }
	public string Autor { get; set; }
	public string ISBN { get; set; }
	public DateTime DataPublicacao { get; set; }

	public bool Emprestado { get; set; } = false;

	public int? ClientId { get; set; }
}

namespace LivrosApi.Data.Dtos.Livro;

public class CreateLivroDto
{
	public string Titulo { get;set ; }
	public string Autor { get; set; }
	public string ISBN { get; set; }
	public DateTime DataPublicacao { get; set; }
	public bool Emprestado { get; set; } = false;
}

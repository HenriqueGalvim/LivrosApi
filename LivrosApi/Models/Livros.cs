using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Models;

public class Livros
{
	[Key]
	[Required]
	public int Id { get; set; }
	[Required]
	public string Titulo { get; }
	[Required]
	public string Autor { get; }
	[Required]
	public string ISBN { get; }
	[Required]
	public DateOnly DataPublicacao { get; }
	[Required]
	public bool Emprestado { get; set; }

	public Livros(string titulo, string autor, string iSBN, DateOnly dataPublicacao, bool emprestado)
	{
		Titulo = titulo;
		Autor = autor;
		ISBN = iSBN;
		DataPublicacao = dataPublicacao;
		Emprestado = emprestado;
	}

	public void Emprestar()
	{
		if (Emprestado)
		{
			Console.WriteLine("\nEste livro já foi emprestado, aguarde o retorno\n");
		}
		else
		{
			Console.WriteLine($"Livro {Titulo} emprestado com sucesso");
			Emprestado = true;
		}
	}
	public void Devolver()
	{
		if (Emprestado)
		{
			Console.WriteLine($"\nLivro {Titulo} devolvido com sucesso\n");
			Emprestado = false;
		}
		else
		{
			Console.WriteLine($"Não tem como devolver um livro que não foi emprestado");
		}
	}

	public string VerificarLivro()
	{
		if (Emprestado)
		{
			return "Sim";
		}
		else
		{
			return "Não";
		}
	}
	public void ExibirInformacoes()
	{
		Console.WriteLine($"----- Informações do Livro {Titulo}");
		Console.WriteLine($"Autor: {Autor}");
		Console.WriteLine($"ISBN: {ISBN}");
		Console.WriteLine($"Data de publicação: {DataPublicacao}");
		Console.WriteLine($"Emprestado: {VerificarLivro()}");
	}
}

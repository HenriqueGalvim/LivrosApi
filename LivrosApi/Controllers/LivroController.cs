using AutoMapper;
using ComexAPI.Data.Dtos.Livro;
using LivrosApi.Data;
using LivrosApi.Data.Dtos.Admin;
using LivrosApi.Data.Dtos.Cliente;
using LivrosApi.Data.Dtos.Livro;
using LivrosApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class LivroController : ControllerBase
{
	private UsuarioDbContext _context;
	private IMapper _mapper;

	public LivroController(UsuarioDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	/// <summary>
	/// Adiciona um Livro no banco de dados
	/// </summary>
	/// <param name="livroDto">Objeto com os campos necessários para criação de um Livro</param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso inserção seja feita com sucesso</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult AdicionaLivro([FromBody] CreateLivroDto livroDto)
	{
		Console.WriteLine("Adicionando Livro");
		Livro livro = _mapper.Map<Livro>(livroDto);
		livro.DataPublicacao = livroDto.DataPublicacao.ToUniversalTime();

		_context.Livros.Add(livro);
		_context.SaveChanges();
		return CreatedAtAction(nameof(ListarLivroPorId), new { id = livro.Id }, livro);
	}

	/// <summary>
	/// Lista todos os Livros.
	/// </summary>
	/// <param name="skip">Número de Livros a serem ignorados.</param>
	/// <param name="take">Número de Livros a serem retornados.</param>
	/// <returns>Uma lista de Livros.</returns>
	/// <response code="200">Retorna uma lista de livros.</response>
	[HttpGet]
	[AllowAnonymous]
	public IEnumerable<ReadLivroDto> ListarLivros([FromQuery] int skip = 0,
	[FromQuery] int take = 50)
	{
		return _mapper.Map<List<ReadLivroDto>>(_context.Livros.Skip(skip).Take(take).ToList());
	}

	/// <summary>
	/// Retorna um livro pelo seu ID.
	/// </summary>
	/// <param name="id">ID do livro.</param>
	/// <returns>Um livro.</returns>
	/// <response code="200">Retorna um livro.</response>
	/// <response code="404">Livro não encontrado.</response>
	[HttpGet("{id}")]
	[AllowAnonymous]
	public IActionResult ListarLivroPorId(int id)
	{
		var livro = _context.Livros.FirstOrDefault(produto => produto.Id == id);

		if (livro == null) return NotFound();

		var livroDto = _mapper.Map<ReadLivroDto>(livro);
		return Ok(livroDto);
	}

	/// <summary>
	/// Atualiza um livro existente.
	/// </summary>
	/// <param name="id">ID do livro.</param>
	/// <param name="livroDto">Objeto com os dados do livro a serem atualizados.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Livro atualizado com sucesso.</response>
	/// <response code="404">Livro não encontrado.</response>
	[HttpPut("{id}")]
	public ActionResult AtualizandoLivro(int id, [FromBody] UpdateLivroDto livroDto)
	{
		var livro = _context.Livros.FirstOrDefault(filme => filme.Id == id)!;
		if (livro == null) return NotFound();

		_mapper.Map(livroDto, livro);

		livro.DataPublicacao = livroDto.DataPublicacao.ToUniversalTime();
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Deleta um Livro.
	/// </summary>
	/// <param name="id">ID do Livro.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Livro deletado com sucesso.</response>
	/// <response code="404">Livro não encontrado.</response>
	[HttpDelete("{id}")]
	public ActionResult DeletarLivro(int id)
	{
		var livro = _context.Livros.FirstOrDefault(endereco => endereco.Id == id)!;
		if (livro == null) return NotFound();

		_context.Remove(livro);
		_context.SaveChanges();
		return NoContent();
	}
}

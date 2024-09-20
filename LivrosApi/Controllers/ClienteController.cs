using AutoMapper;
using ComexAPI.Data.Dtos.Cliente;
using LivrosApi.Data;
using LivrosApi.Data.Dtos.Cliente;
using LivrosApi.Data.Dtos.Livro;
using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ClienteController : ControllerBase
{
	private UsuarioDbContext _context;
	private IMapper _mapper;
	private EmprestarService emprestimoService;

	public ClienteController(UsuarioDbContext context, IMapper mapper, EmprestarService emprestimoService)
	{
		_context = context;
		_mapper = mapper;
		this.emprestimoService = emprestimoService;
	}

	/// <summary>
	/// Adiciona um Cliente no banco de dados
	/// </summary>
	/// <param name="clienteDto">Objeto com os campos necessários para criação de um cliente</param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso inserção seja feita com sucesso</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult AdicionaCLiente([FromBody] CreateClienteDto clienteDto)
	{
		Console.WriteLine("Adicionando Cliente");
		Cliente cliente = _mapper.Map<Cliente>(clienteDto);
		_context.Clientes.Add(cliente);
		_context.SaveChanges();
		return CreatedAtAction(nameof(ListarClientePorId), new { id = cliente.Id }, cliente);
	}

	/// <summary>
	/// Lista todos os Clientes.
	/// </summary>
	/// <param name="skip">Número de clientes a serem ignorados.</param>
	/// <param name="take">Número de clientes a serem retornados.</param>
	/// <returns>Uma lista de clientes.</returns>
	/// <response code="200">Retorna uma lista de clientes.</response>
	[HttpGet]
	[AllowAnonymous]
	public IEnumerable<ReadClienteDto> ListarClientes([FromQuery] int skip = 0,
	[FromQuery] int take = 50)
	{
		return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.Skip(skip).Take(take).ToList())
			.Select(clienteDto =>
			{
				clienteDto.LivrosEmprestados = clienteDto.LivrosEmprestados.Select(livro => _mapper.Map<ReadLivroDto>(livro)).ToList();
				return clienteDto;
			});
	}

	/// <summary>
	/// Retorna um cliente pelo seu ID.
	/// </summary>
	/// <param name="id">ID do cliente.</param>
	/// <returns>Um cliente.</returns>
	/// <response code="200">Retorna um cliente.</response>
	/// <response code="404">Cliente não encontrado.</response>
	[HttpGet("{id}")]
	public IActionResult ListarClientePorId(int id)
	{
		var cliente = _context.Clientes.FirstOrDefault(produto => produto.Id == id);

		if (cliente == null) return NotFound();

		var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
		return Ok(clienteDto);
	}

	/// <summary>
	/// Atualiza um cliente existente.
	/// </summary>
	/// <param name="id">ID do cliente a ser atualizado.</param>
	/// <param name="clienteDto">Objeto com os dados atualizados do cliente.</param>
	/// <returns>
	/// Retorna 204 No Content se o cliente foi atualizado com sucesso.
	/// Retorna 404 Not Found se o cliente não foi encontrado.
	/// </returns>
	[HttpPut("{id}")]
	public ActionResult AtualizandoCliente(int id, [FromBody] UpdateClienteDto clienteDto)
	{
		var cliente = _context.Clientes.FirstOrDefault(filme => filme.Id == id)!;
		if (cliente == null) return NotFound();
		_mapper.Map(clienteDto, cliente);
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Exclui um cliente existente.
	/// </summary>
	/// <param name="id">ID do cliente a ser excluído.</param>
	/// <returns>
	/// Retorna 204 No Content se o cliente foi excluído com sucesso.
	/// Retorna 404 Not Found se o cliente não foi encontrado.
	/// </returns>
	[HttpDelete("{id}")]
	public ActionResult DeletarCliente(int id)
	{
		var cliente = _context.Clientes.FirstOrDefault(endereco => endereco.Id == id)!;
		if (cliente == null) return NotFound();

		_context.Remove(cliente);
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Empresta um livro para um cliente.
	/// </summary>
	/// <param name="id">ID do cliente que está emprestando o livro.</param>
	/// <param name="emprestarDto">Objeto com o ID do livro e do cliente.</param>
	/// <returns>
	/// Retorna 204 No Content se o livro foi emprestado com sucesso.
	/// Retorna 400 Bad Request se o livro ou o cliente não foram encontrados.
	/// </returns>
	[HttpPost("emprestar")]
	public async Task<ActionResult> EmprestarLivro(int id, [FromBody] EmprestarLivroDto emprestarDto)
	{
		var livroEmprestado = await emprestimoService.EmprestarLivro(emprestarDto.IdLivro, emprestarDto.IdCliente);

		if (!livroEmprestado) return BadRequest("Livro ou Cliente não encontrado");

		return NoContent();
	}

	/// <summary>
	/// Devolve um livro emprestado.
	/// </summary>
	/// <param name="id">ID do cliente que está devolvendo o livro.</param>
	/// <param name="devolverDto">Objeto com o ID do livro.</param>
	/// <returns>
	/// Retorna 204 No Content se o livro foi devolvido com sucesso.
	/// Retorna 400 Bad Request se o livro não foi emprestado ou não foi encontrado.
	/// </returns>
	[HttpPost("devolver")]
	public async Task<ActionResult> DevolverLivro(int id, [FromBody] DevolverLivroDto devolverDto)
	{
		Console.WriteLine("Passei por aqui");
		var livroDevolvido = await emprestimoService.DevolverLivro(devolverDto.IdLivro);

		if (!livroDevolvido) return BadRequest("Livro não foi emprestado ou não encontrado");

		return NoContent();
	}
}

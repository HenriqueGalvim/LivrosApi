﻿using LivrosApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivrosApi.Services;

public class TokenService
{
	public IConfiguration _configuration { get; set; }
	public TokenService(IConfiguration configuration)
	{
		_configuration = configuration;
	}
	public string GenerateToken(Usuario usuario)
	{
		Claim[] claims = new Claim[]
		{
			new Claim("username",usuario.UserName),
			new Claim("id",usuario.Id),
			new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString()),
		};

		var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0fwfn2o3f2j3fouq2uffevfuv3vf2po3gfbwjkeefkjn"));


		var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(expires: DateTime.Now.AddHours(1), claims: claims, signingCredentials: signingCredentials);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}

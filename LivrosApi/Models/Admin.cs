﻿using Microsoft.AspNetCore.Identity;

namespace LivrosApi.Models;

public class Admin : IdentityUser
{
	public DateTime DataNascimento{ get; set; }
	public string Cpf { get; set; }
	public Admin() : base() { }
}

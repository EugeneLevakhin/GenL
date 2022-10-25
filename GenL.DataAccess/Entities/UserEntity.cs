using Microsoft.AspNetCore.Identity;

namespace GenL.DataAccess.Entities;

public class UserEntity : IdentityUser
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
}
using Microsoft.AspNetCore.Identity;

namespace GenL.Presentation.Models.Users
{
	public class UsersViewModel
	{
		public IdentityUser[] Users { get; set; }

		public UsersViewModel(IdentityUser[] users)
		{
			Users = users;
		}
	}
}
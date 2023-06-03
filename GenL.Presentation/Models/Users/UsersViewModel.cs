using GenL.DataAccess.Entities;

namespace GenL.Presentation.Models.Users
{
    public class UsersViewModel
	{
		public UserEntity[] Users { get; set; }

		public UsersViewModel(UserEntity[] users)
		{
			Users = users;
		}
	}
}
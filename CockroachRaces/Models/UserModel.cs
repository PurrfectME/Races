using CockroachRaces.BLL.Entities;

namespace CockroachRaces.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        //public double Balance { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public UserModel()
        {
            
        }

        public static explicit operator User(UserModel user)
        {
            return new User
            {
                Email = user.Email,
                //Balance = user.Balance

            };
        }
    }
}
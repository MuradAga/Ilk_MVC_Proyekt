using Ilk_MVC_Proyekt.Context;
using Ilk_MVC_Proyekt.Entites;

namespace Ilk_MVC_Proyekt.Services
{
    public class UserService : IUserService
    {
        private readonly ProductContext _context;
        public UserService(ProductContext context)
        {
            _context = context;
        }
        public bool CheckUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public void CreateUser(string username, string password)
        {
            _context.Users.Add(new User() { UserName = username, UserPassword = password });
            _context.SaveChanges();
        }
    }
}

namespace Ilk_MVC_Proyekt.Services
{
    public interface IUserService
    {
        bool CheckUser(string username, string password);
        void CreateUser(string username, string password);
    }
}

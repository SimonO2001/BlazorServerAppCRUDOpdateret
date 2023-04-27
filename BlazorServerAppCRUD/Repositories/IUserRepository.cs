using BlazorServerAppCRUD.Models;

namespace BlazorServerAppCRUD.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();

        public bool AddUser(User user);

        public bool UpdateUser(User user);

        public bool DeleteUser(int? Id);
    }
}

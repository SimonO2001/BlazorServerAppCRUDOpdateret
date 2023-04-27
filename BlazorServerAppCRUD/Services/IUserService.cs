using BlazorServerAppCRUD.Models;

using BlazorServerAppCRUD.Repositories;

namespace BlazorServerAppCRUD.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();

        public bool AddUser(User student);

        public bool UpdateUser(User student);

        public bool DeleteUser(int? Id);
    }
}

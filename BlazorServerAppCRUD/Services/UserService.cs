using Dapper;
using Microsoft.AspNetCore.Components;
using BlazorServerAppCRUD.Models;
using System.Data.SqlClient;
using BlazorServerAppCRUD.Repositories;

namespace BlazorServerAppCRUD.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly NavigationManager _navigationManager;

        public UserService(IConfiguration config, NavigationManager nav)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _navigationManager = nav;


        }

        public async Task<int> CreateUser(User user)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                // Check if email is already in use
                var emailExists = await conn.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT Id FROM [User] WHERE Email = @Email) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", new { Email = user.Email });
                if (emailExists)
                {
                    return -1;
                }

                // Create user in database
                var result = await conn.ExecuteAsync("INSERT INTO [User] (FirstName, LastName, Email, Login, Password, CreateDate) VALUES (@FirstName, @LastName, @Email, @Login, @Password, @CreateDate)", new { user.FirstName, user.LastName, user.Email, user.Login, user.Password, CreateDate = DateTime.UtcNow });
                if (result == 0)
                {
                    return 0;
                }

                // Navigate to profile page
                _navigationManager.NavigateTo("/Profile", true);

                return result;
            }
        }
    }

}

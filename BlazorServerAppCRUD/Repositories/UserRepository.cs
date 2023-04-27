using BlazorServerAppCRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace BlazorServerAppCRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        string connectionString = string.Empty;

        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }
        public bool AddUser(User user)
        {
            bool returnValue = true;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_AddNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Login", user.Login);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Password2", user.Password2);
                cmd.Parameters.AddWithValue("@CreateDate", user.CreateDate);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res != 1) { returnValue = false; }
            }
            return returnValue;
        }

        public bool DeleteUser(int? Id)
        {
            bool returnValue = true;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteUserRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res != 1) { returnValue = false; }
            }
            return returnValue;
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> lstStudent = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllUsers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Login = rdr["Login"].ToString();
                    user.Password = rdr["Password"].ToString();
                    user.Password2 = rdr["Password2"].ToString();
                    user.CreateDate = Convert.ToDateTime(rdr["CreateDate"].ToString());
                    user.DeleteDate = Convert.ToDateTime(rdr["DeleteDate"].ToString());

                    lstStudent.Add(user);
                }
                con.Close();
            }
            return lstStudent;
        }

        public bool UpdateUser(User user)
        {
            bool returnValue = true;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateUserRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", user.Id);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Login", user.Login);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Password2", user.Password2);
                cmd.Parameters.AddWithValue("@CreateDate", user.CreateDate);
                cmd.Parameters.AddWithValue("@DeleteDate", user.DeleteDate);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res != 1) { returnValue = false; }
            }
            return returnValue;
        }
    }
}

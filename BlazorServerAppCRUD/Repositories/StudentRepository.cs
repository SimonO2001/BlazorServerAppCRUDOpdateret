using BlazorServerAppCRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace BlazorServerAppCRUD.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        string connectionString = string.Empty;

        private readonly IConfiguration configuration;
        public StudentRepository(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }

        public IEnumerable<StudentEntity> GetAllStudents()
        {
            List<StudentEntity> lstStudent = new List<StudentEntity>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_GetStudentsRecord", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    StudentEntity student = new StudentEntity();
                    student.StudentId = Convert.ToInt32(rdr["StudentID"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.EmailAddress = rdr["EmailAddress"].ToString();
                    student.Gender = Convert.ToInt32(rdr["Gender"]);
                    student.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"].ToString());

                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }

        public void AddStudent(StudentEntity student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_AddNewStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(StudentEntity student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", student.StudentId);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteStudent(int? StudentId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", StudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

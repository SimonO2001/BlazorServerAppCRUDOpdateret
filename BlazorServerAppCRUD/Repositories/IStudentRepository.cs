using BlazorServerAppCRUD.Models;

namespace BlazorServerAppCRUD.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentEntity> GetAllStudents();

        public void AddStudent(StudentEntity student);

        public void UpdateStudent(StudentEntity student);

        public void DeleteStudent(int? StudentId);

    }
}

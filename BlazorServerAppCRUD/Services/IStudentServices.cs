using BlazorServerAppCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerAppCRUD.Services
{
    public interface IStudentServices
    {
        // public IEnumerable<StudentEntity> GetAllStudents();
        public Task<List<StudentEntity>> GetStudentsList();

        // public void AddStudent(StudentEntity student);

        public Task<bool> AddNewStudent(StudentEntity studentEntity);
        // public void UpdateStudent(StudentEntity student);
        public Task<bool> UpdateStudent(StudentEntity studentEntity);

        // public void DeleteStudent(int? StudentId);

        public Task<bool> DeleteStudent(int StudentId);
        
    }
}

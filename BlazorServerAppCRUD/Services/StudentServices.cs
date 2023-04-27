using BlazorServerAppCRUD.Models;
using BlazorServerAppCRUD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerAppCRUD.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository repository;

        public StudentServices(IStudentRepository _repository)
        {
            repository = _repository;
        }
        public async Task<bool> AddNewStudent(StudentEntity studentEntity)
        {
            try
            {
                repository.AddStudent(studentEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> DeleteStudent(int StudentId)
        {
            try
            {
                repository.DeleteStudent(StudentId);
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<List<StudentEntity>> GetStudentsList()
        {
            List<StudentEntity> students = new List<StudentEntity>();

            students = repository.GetAllStudents().ToList();

            return students;
        }

        public async Task<bool> UpdateStudent(StudentEntity studentEntity)
        {
            try
            {
                repository.UpdateStudent(studentEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}

using StudentsApp.Domain;
using System.Collections.Generic;

namespace StudentsApp.Infrastructure.Abstractions
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Update(Student student);
        void Delete(string idNumber);
        IEnumerable<Student> GetAll();
        Student GetByIdNumber(string idNumber);
        bool DoesStudentExist(string idNumber);
        IEnumerable<Student> GetBySearchText(string searchText);
    }
}
using System;
using StudentsApp.Domain;
using StudentsApp.Infrastructure.Abstractions;
using StudentsApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace StudentsApp.Infrastructure.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsDbContext _db;
        public StudentRepository(StudentsDbContext studentsDbContext)
        {
            _db = studentsDbContext;
        }
        public void Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        public void Delete(string idNumber)
        {
            _db.Students.Remove(GetByIdNumber(idNumber));
            _db.SaveChanges();
        }
        
        public void Update(Student student)
        {   
            _db.Students.Update(student);
            _db.SaveChanges();
        }
        
        public IEnumerable<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public Student GetByIdNumber(string idNumber)
        {
            return _db.Students.FirstOrDefault(x => x.IDNumber.Equals(idNumber));
        }

        public bool DoesStudentExist(string idNumber)
        {
            return _db.Students.Any(x => x.IDNumber.Equals(idNumber));
        }

        public IEnumerable<Student> GetBySearchText(string searchText)
        {
            var query = _db.Students.AsQueryable();
            query = query.Where(x => x.IDNumber.Contains(searchText) || x.Name.Contains(searchText) || x.Surname.Contains(searchText));
            return query.ToList();
        }
    }
}
using System;

namespace StudentsApp.Domain
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderTypeEnum Gender { get; set; }
    }

    public enum GenderTypeEnum
    {
        Male = 0,
        Female = 1
    }
}
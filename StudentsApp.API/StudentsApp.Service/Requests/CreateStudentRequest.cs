using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Service.Requests
{
    public class CreateStudentRequest : RequestBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
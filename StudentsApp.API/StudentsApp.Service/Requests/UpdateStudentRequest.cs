using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Service.Requests
{
    public class UpdateStudentRequest : RequestBase
    {
        [RegularExpression(@"\d{11}", ErrorMessage = "IDNumber should be 11 digits")]
        [Required]
        public string IDNumber { get; set; }
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

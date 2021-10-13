using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Service.Requests
{
    public abstract class RequestBase
    {
        [RegularExpression(@"\d{11}", ErrorMessage = "IDNumber should be 11 digits")]
        [Required]
        public string IDNumber { get; set; }
    }
}

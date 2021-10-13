using StudentsApp.Domain;
using System.Collections.Generic;

namespace StudentsApp.Service.Responses
{
    public class ReadStudentResponse : ResponseBase
    {
        public IEnumerable<Student> Data { get; set; }
    }
}
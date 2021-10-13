using StudentsApp.Service.Requests;
using StudentsApp.Service.Responses;

namespace StudentsApp.Service.Abstractions
{
    public interface IStudentService
    {
        public CreateStudentResponse Create(CreateStudentRequest request);
        public ReadStudentResponse GetByIdNumber(ReadStudentRequest request);
        public UpdateStudentResponse Update(UpdateStudentRequest request);
        public DeleteStudentResponse Delete(DeleteStudentRequest request);
        public ReadStudentResponse GetAll();
        public ReadStudentResponse GetBySearchText(ReadStudentRequest request);
    }
}
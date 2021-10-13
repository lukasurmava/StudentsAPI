using Microsoft.EntityFrameworkCore.Internal;
using StudentsApp.Domain;
using StudentsApp.Infrastructure.Abstractions;
using StudentsApp.Service.Abstractions;
using StudentsApp.Service.Requests;
using StudentsApp.Service.Responses;
using System;
using System.Collections.Generic;

namespace StudentsApp.Service.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public CreateStudentResponse Create(CreateStudentRequest request)
        {
            var response = new CreateStudentResponse();
            if (DateTime.Now.Year - request.DateOfBirth?.Year < 16)
            {
                response.IsSuccess = false;
                response.Error = "Age should be greater than 16";
                return response;
            }

            var doesStudentExist = _studentRepository.DoesStudentExist(request.IDNumber);

            if (!doesStudentExist)
            {
                var student = new Student
                {
                    DateOfBirth = request.DateOfBirth.Value,
                    Gender = request.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ? GenderTypeEnum.Male : GenderTypeEnum.Female,
                    IDNumber = request.IDNumber,
                    Name = request.Name,
                    Surname = request.Surname
                };
                _studentRepository.Create(student);

                response.IsSuccess = true;
                return response;
            }

            response.IsSuccess = false;
            response.Error = $"Student with IDNumber: {request.IDNumber} already exists";
            return response;
        }

        public DeleteStudentResponse Delete(DeleteStudentRequest request)
        {
            var response = new DeleteStudentResponse();

            var doesStudentExist = _studentRepository.DoesStudentExist(request.IDNumber);
            if (!doesStudentExist)
            {
                response.IsSuccess = false;
                response.Error = $"No record exists with IDNumber: {request.IDNumber}";
                return response;
            }

            _studentRepository.Delete(request.IDNumber);

            response.IsSuccess = true;
            return response;
        }

        public ReadStudentResponse GetAll()
        {
            return new ReadStudentResponse
            {
                Data = _studentRepository.GetAll(),
                IsSuccess = true
            };
        }

        public ReadStudentResponse GetByIdNumber(ReadStudentRequest request)
        {
            var response = new ReadStudentResponse();

            var result = _studentRepository.GetByIdNumber(request.IDNumber);

            if (result != null)
            {
                response.IsSuccess = true;
                response.Data = new List<Student>(1) { result };
                return response;
            }

            response.IsSuccess = false;
            response.Error = $"Could not find any record with IDNumber: {request.IDNumber}";
            return response;
        }

        public ReadStudentResponse GetBySearchText(ReadStudentRequest request)
        {
            var response = new ReadStudentResponse();

            var result = _studentRepository.GetBySearchText(request.SearchText);

            if (result.Any())
            {
                response.IsSuccess = true;
                response.Data = result;
                return response;
            }

            response.IsSuccess = false;
            response.Error = $"Could not find anything based on SearchText: {request.SearchText}";
            return response;
        }

        public UpdateStudentResponse Update(UpdateStudentRequest request)
        {
            var response = new UpdateStudentResponse();

            if (DateTime.Now.Year - request.DateOfBirth?.Year < 16)
            {
                response.IsSuccess = false;
                response.Error = "Age should be greater than 16";
                return response;
            }
            var existingStudent = _studentRepository.GetByIdNumber(request.IDNumber);

            if (existingStudent == null)
            {
                response.IsSuccess = false;
                response.Error = $"No record exists with IDNumber {request.IDNumber}";
                return response;
            }

            existingStudent.DateOfBirth = request.DateOfBirth.Value;
            existingStudent.Gender = request.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)
                ? GenderTypeEnum.Male
                : GenderTypeEnum.Female;
            existingStudent.Name = request.Name;
            existingStudent.Surname = request.Surname;

            _studentRepository.Update(existingStudent);

            response.IsSuccess = true;
            return response;
        }
    }
}
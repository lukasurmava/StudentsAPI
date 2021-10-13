using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Service.Abstractions;
using StudentsApp.Service.Requests;
using StudentsApp.Service.Responses;

namespace StudentsApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadStudentResponse))]
        [Route("/getall")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateStudentResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateStudentResponse))]
        public IActionResult Create([FromBody] CreateStudentRequest request)
        {
            var result = _studentService.Create(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteStudentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DeleteStudentResponse))]
        public IActionResult Delete([FromBody] DeleteStudentRequest request)
        {
            var response = _studentService.Delete(request);
            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadStudentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ReadStudentResponse))]
        public IActionResult Get([FromQuery] ReadStudentRequest request)
        {
            ReadStudentResponse response;
            if (request.SearchText != null)
            {
                response = _studentService.GetBySearchText(request);
            }
            else
            {
                response = _studentService.GetByIdNumber(request);
            }

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response);
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateStudentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(UpdateStudentResponse))]
        public IActionResult Update([FromBody] UpdateStudentRequest request)
        {
            var response = _studentService.Update(request);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response);
        }
    }
}
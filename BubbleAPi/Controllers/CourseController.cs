using Microsoft.AspNetCore.Mvc; 
using Doopinger;
using BubbleAPi;
using BubbleAPi.Dtoes;
using Microsoft.AspNetCore.Authorization;

namespace Doopinger 
{ 
    [ApiController]
    [Route("[controller]")] 
    public class CourseController : ControllerBase 
    { 
        private readonly ICourse _course; 
        private readonly Response _response; 
 
        public CourseController(ICourse course, Response response) 
        { 
            _course = course; 
            _response = response; 
        }


        [HttpGet("GetCourse")]
        public async Task<IActionResult> Get()
        {
            var data = await _course.GetAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _course.GetAllAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCourseByName")]
        public async Task<IActionResult> GetbyNAme([FromQuery] string Name)
        {
            var data = await _course.GetByNameAsync(Name);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] CoursePostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _course.PostAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCourse")]
        public async Task<IActionResult> Put([FromQuery] CoursePostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _course.PutAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Create([FromQuery] string Name)
        {
            var data = await _course.DeleteFakeAsync(Name);

            IActionResult response;
            if (data)
                response = _response.GetResponse("Succesful");
            else
                response = _response.GetResponse("Failed");
            return response;
        }


        [HttpDelete("DeleteReal")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteREal([FromQuery] string Name)
        {
            var data = await _course.DeleteFakeAsync(Name);

            IActionResult response;
            if (data)
                response = _response.GetResponse("Succesful");
            else
                response = _response.GetResponse("Failed");
            return response;
        }

    } 
} 

using Microsoft.AspNetCore.Mvc; 
using Doopinger;
using BubbleAPi;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Dtoes;
using Microsoft.AspNetCore.Authorization;

namespace Doopinger 
{ 
    [ApiController]
    [Route("[controller]")] 
    public class CourseReportController : ControllerBase 
    { 
        private readonly ICourseReport _coursereport; 
        private readonly Response _response; 
 
        public CourseReportController(ICourseReport coursereport, Response response) 
        { 
            _coursereport = coursereport;
            _response = response;
        }


        [HttpGet("GetCourse")]
        public async Task<IActionResult> Get()
        {
            var data = await _coursereport.GetAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _coursereport.GetAllAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCourseByName")]
        public async Task<IActionResult> GetbyNAme([FromQuery] int id)
        {
            var data = await _coursereport.GetByIdAsync(id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] CourseReportPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _coursereport.PostAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCourse")]
        public async Task<IActionResult> Put([FromQuery] CourseReportPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _coursereport.PutAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Create([FromQuery] int id)
        {
            var data = await _coursereport.DeleteFakeAsync(id);

            IActionResult response;
            if (data)
                response = _response.GetResponse("Succesful");
            else
                response = _response.GetResponse("Failed");
            return response;
        }


        [HttpDelete("DeleteReal")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteREal([FromQuery] int id)
        {
            var data = await _coursereport.DeleteFakeAsync(id);

            IActionResult response;
            if (data)
                response = _response.GetResponse("Succesful");
            else
                response = _response.GetResponse("Failed");
            return response;
        }

    }
} 

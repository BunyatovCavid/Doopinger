using BubbleAPi.Dtoes;
using BubbleAPi.Interfaces;
using BubbleAPi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Text.Json;

namespace BubbleAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JWTService _token;
        private readonly Response _response;
        private readonly IUser _user;

        public UserController(JWTService token, Response response, IUser user)
        {
            _token = token;
            _response = response;
            _user = user;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery] LoginDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _token.LogIn(dto);
            var request = JsonSerializer.Serialize(data);

            var response = _response.GetResponse(request);
            return response;
        }

 

        [HttpPost("Register")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Register([FromQuery] UserPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _user.CreateUSer(dto);
            IActionResult response;
            if(data)
                 response = _response.GetResponse("Succesful");
            else
                response = _response.GetResponse("Failed");
            return response;
        }


    }
}

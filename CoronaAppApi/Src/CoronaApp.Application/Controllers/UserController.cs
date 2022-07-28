using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _service;

    public UserController(IUserRepository service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task PostUser([FromBody] User user)
    {
        await _service.PostUser(user);
    }

    [HttpPost("token")]
    public async Task<IActionResult> CreateToken(string userName, string password)
    {
        var token = await _service.CreateToken(userName, password);
        return token != null ? Ok(token) :
            BadRequest(new { message = "Username or password is incorrect" });
    }

    [HttpGet("userName")]
    public async Task<IActionResult> GetUserName()
    {
        string userName = await _service.getUserName(User);
        return userName != null ? Ok(userName) :
            BadRequest(new { message = "Could not get userName from given token." });
    }
}

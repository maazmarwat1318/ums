using Microsoft.AspNetCore.Mvc;
using UMS.Data;
using UMS.Models;

namespace UMS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly InMemoryUserService _userService;

    public UserController(InMemoryUserService userService)
    {
        _userService = userService;
    }

    // GET: api/user
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_userService.GetAll());
    }

    // GET: api/user/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
            return NotFound();
        return user;
    }

    // POST: api/user
    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        var createdUser = _userService.Create(user);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    // PUT: api/user/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        if (_userService.Update(id, user))
            return NoContent();
        return NotFound();
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (_userService.Delete(id))
            return NoContent();
        return NotFound();
    }
}

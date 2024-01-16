using System.Collections.Generic;
using System.Linq;
using ecommerce_experiment.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_experiment.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserContext userContext) : ControllerBase
{
    private readonly UserContext _userContext = userContext;

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _userContext.Users.ToList();
    }
    
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userContext.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        _userContext.Users.Add(user);
        _userContext.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var user = _userContext.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        user.UserName = updatedUser.UserName;
        _userContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userContext.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        _userContext.Users.Remove(user);
        _userContext.SaveChanges();
        return NoContent();
    }
}
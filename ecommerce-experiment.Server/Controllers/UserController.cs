using System.Collections.Generic;
using System.Linq;
using ecommerce_experiment.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ecommerce_experiment.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserContext userContext) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return userContext.Users.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = userContext.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)//[FromBody] User user)
    {
        // Console.WriteLine(user.UserId);
        // userContext.Users.Add(user);
        // userContext.SaveChanges();
        // Console.WriteLine(user.UserId);
        // return CreatedAtAction(nameof(GetUserById), new { id = user.UserId,  }, user);
        var con = new NpgsqlConnection(
            connectionString: "Server=localhost;Database=ecommerce;Port=5432;Username=zetademon;Password=2001123;");
        con.Open();
        //const string query = "INSERT INTO users (user_name, email) VALUES (@user_name, @email)";
        //await con.ExecuteAsync(query, new { user_name = user.UserName, email = user.Email });
        // return Ok(await con.ExecuteAsync(query, new { user_name = user.UserName, email = user.Email}));
        var id = con.QuerySingle<int>( @"
                                                INSERT INTO users (user_name, email)
                                                VALUES (@user_name, @email) RETURNING id;", new { user_name = user.UserName, email = user.Email});
        user.UserId = id;
        //return CreatedAtAction(nameof(GetUserById), new { id = user.UserId,  }, user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId}, user);
        //TODO: OR RETURN A NOTFOUND() IF IT DOES NOT GET CREATED!
        //return Ok(id);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var user = userContext.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        user.UserName = updatedUser.UserName;
        userContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = userContext.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        userContext.Users.Remove(user);
        userContext.SaveChanges();
        return NoContent();
    }
}

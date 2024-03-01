using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_experiment.Server.Models;

[Table("users")]
public class User
{
    [Column("id")]
    public int UserId { get; set; }
    [Column("user_name")]
    public string UserName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    // TODO: add the address and other fields here
    // public User(int userId, string userName, string email)
    // {
    //     UserId = userId;
    //     UserName = userName;
    //     Email = email;
    // }
}

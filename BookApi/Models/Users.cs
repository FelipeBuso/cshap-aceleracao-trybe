namespace BookApi.Models;

public enum UserRole { Admin, Normal }

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }

}
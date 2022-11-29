namespace backend.Models;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FatherName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? AdminToken { get; set; }
}
using PschoolFrontEnd.Models;

public class Parent
{
    public int ParentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public string UserName { get; set; }
    public string HomeAddress { get; set; }
    public string Phone1 { get; set; }
    public string WorkPhone { get; set; }
    public string HomePhone { get; set; }
    public string? Siblings { get; set; } 
    public List<Student> Children { get; set; } = new List<Student>();
}
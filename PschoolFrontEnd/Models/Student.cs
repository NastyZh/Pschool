﻿using Newtonsoft.Json;

namespace PschoolFrontEnd.Models;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int ParentId { get; set; } 
}
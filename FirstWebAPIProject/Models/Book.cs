﻿namespace FirstWebAPIProject.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Pages { get; set; }
    public int Price { get; set; }
}

﻿namespace AsyncDbUpdaterApi;

public class RegisterProductDTO
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
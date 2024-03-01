﻿using PieProject.Models;

namespace PieProject.ViewModels;

public class PieListViewModel()
{
    public required IEnumerable<Pie> Pies { get; init; }
    public string? CurrentCategory { get; init; }
}
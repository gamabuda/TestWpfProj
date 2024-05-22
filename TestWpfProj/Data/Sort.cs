using System;
using System.Collections.Generic;

namespace TestWpfProj.Data;

public class Sort(string title, Func<List<Cat>, List<Cat>> func)
{
    public string Title { get; set; } = title;
    public Func<List<Cat>, List<Cat>> SortingFunc { get; set; } = func;
}
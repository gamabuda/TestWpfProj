using System;
using System.Collections.Generic;
using Cats;

public class Sort
{
    public Sort(string title, Func<List<Cat>, List<Cat>> func)
    {
        Title = title;
        SortingFunc = func;
    }
    public string Title { get; set; }
    public Func<List<Cat>, List<Cat>> SortingFunc { get; set; }
}
using System;
using System.Collections.Generic;

public class PaginatedList<T>
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public int TotalPages { get; private set; }
    public IEnumerable<T> Items { get; private set; }

    public PaginatedList()
    {
        Items = new List<T>();
    }

    public PaginatedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}


public class PaginationParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public string OrderBy { get; set; } = "UpdateDateTime";
    public string SortOrder { get; set; } = "desc";
}
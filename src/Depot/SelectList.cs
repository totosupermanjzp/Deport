using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SelectList<T> :List<T>
{
    public int PageIndex { get; private set; }
    public int ToTalPage { get; private set; }


    public SelectList(List<T> items,int count,int pageIndex,int pageSize)
    {
        PageIndex = pageIndex;
        ToTalPage = (int)Math.Ceiling(count / (double)pageSize);

        this.AddRange(items);
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < ToTalPage);
        }
    }

    public static async Task<SelectList<T>> CreateAsync(IQueryable<T> source,int pageIndex,int pageSize)
    {
        var count = await source.CountAsync();
        var item = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new SelectList<T>(item, count, pageIndex, pageSize);
    }
}

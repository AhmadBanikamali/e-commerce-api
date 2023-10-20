 
namespace Application.Common.Extension
{
    public static class Pagination
    { 
        public static IQueryable<TSource> PagedResult<TSource>(this IQueryable<TSource> query, int pageNum, int pageSize)
        {
            if (pageSize <= 0) pageSize = 20;  
            if (pageNum <= 0) pageNum = 1; 
            var excludedRows = (pageNum - 1) * pageSize; 
            return query.Skip(excludedRows).Take(pageSize);
        }
    }
}

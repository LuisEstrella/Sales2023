using Sales.Shared.DTOs;

namespace Sales.API.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.RecordsNumber) // es la cantidad de registros que usted se va a saltar
                .Take(pagination.RecordsNumber);
        }
    }

}

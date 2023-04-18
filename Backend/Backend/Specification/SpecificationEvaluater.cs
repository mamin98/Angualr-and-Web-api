using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Specification
{
    public class SpecificationEvaluater<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> InputQuery, ISpecification<TEntity> spec)
        {
            var query = InputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy!= null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescending!= null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}

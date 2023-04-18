using System.Linq.Expressions;

namespace Backend.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T, bool>> criteria) 
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> includes)
        {
            Includes.Add(includes);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExp)
        {
            OrderBy = orderByExp;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExp)
        {
            OrderByDescending = orderByDescExp;
        }
    }
}

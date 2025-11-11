using HelioApp.Domain.Entities.Reviews;
using HelioApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Domain.Specifications
{
    public class ReviewSpecification : BaseSpecifications<Review, Guid>
    {
        public ReviewSpecification(Guid serviceId, ReviewStatus? status = null, int? minRating = null, int? maxRating = null, int? take = null, int? skip = null)
            : base(r => r.ServiceId == serviceId)
        {
            AddIncludes();
            AddOrderBy();

            if (status != null)
            {
                Criteria = Criteria != null
                    ? CombineExpressions(Criteria, r => r.Status == status)
                    : (r => r.Status == status);
            }

            if (minRating.HasValue)
            {
                Criteria = Criteria != null
                    ? CombineExpressions(Criteria, r => r.Rating >= minRating.Value)
                    : (r => r.Rating >= minRating.Value);
            }

            if (maxRating.HasValue)
            {
                Criteria = Criteria != null
                    ? CombineExpressions(Criteria, r => r.Rating <= maxRating.Value)
                    : (r => r.Rating <= maxRating.Value);
            }

            if (take.HasValue && skip.HasValue)
            {
                AddPagination(take.Value, skip.Value);
            }
        }

        protected override void AddIncludes()
        {
            Includes = new List<Expression<Func<Review, object>>>()
            {
                r => r.Author,
                r => r.Service,
                r => r.Reply
            };
        }

        protected override void AddOrderBy()
        {
            OrderBy = r => r.CreatedAt;
        }

        private Expression<Func<Review, bool>> CombineExpressions(Expression<Func<Review, bool>> expr1, Expression<Func<Review, bool>> expr2)
        {
            var param = Expression.Parameter(typeof(Review));

            var body = Expression.AndAlso(
                Expression.Invoke(expr1, param),
                Expression.Invoke(expr2, param)
            );

            return Expression.Lambda<Func<Review, bool>>(body, param);
        }
    }
}

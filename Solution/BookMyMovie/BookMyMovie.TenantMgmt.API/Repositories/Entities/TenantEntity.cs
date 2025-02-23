using Dapper.FluentMap.Mapping;
using System.Linq.Expressions;

namespace BookMyMovie.TenantMgmt.API.Repositories.Entities
{
    public class TenantEntity : BaseEntity
    {
        public required string Name { get; set; }
    }

    public class TenantEntityMap : BaseEntityMap<TenantEntity>
    {
        public TenantEntityMap()
        {
            Map(m => m.Id).ToColumn("TenantID");
            Map(m => m.Name).ToColumn("TenantName");
        }
    }

    public class BaseEntityMap<T> : EntityMap<T> where T : class
    {
        protected BaseEntityMap()
        {
            var createdDtProperty = typeof(T).GetProperty("CreatedDt");

            if (createdDtProperty != null)
            {
                Map(GetPropertyExpression<T>("CreatedDt")).ToColumn("CreateDateTime");  
            }

            var lastUpdateDtProperty = typeof(T).GetProperty("LastUpdatedDt");

            if (lastUpdateDtProperty != null)
            {
                Map(GetPropertyExpression<T>("LastUpdatedDt")).ToColumn("UpdateDateTime");
            }

            var lastUpdateByProperty = typeof(T).GetProperty("LastUpdatedBy");

            if (lastUpdateDtProperty != null)
            {
                Map(GetPropertyExpression<T>("LastUpdatedBy")).ToColumn("UpdatedBy");
            }
        }

        private static Expression<Func<T, object>> GetPropertyExpression<T>(string propertyName)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, propertyName);
            var conversion = Expression.Convert(property, typeof(object)); // Convert to object
            return Expression.Lambda<Func<T, object>>(conversion, param);
        }
    }
}

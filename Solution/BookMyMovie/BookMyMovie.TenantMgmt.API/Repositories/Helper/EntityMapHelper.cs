using Dapper.FluentMap.Mapping;
using Dapper.FluentMap;
using System.Collections.Concurrent;

namespace BookMyMovie.TenantMgmt.API.Repositories.Helper
{
    public static class EntityMapHelper
    {
        private static readonly ConcurrentDictionary<(Type, string), string> _columnNameCache = new();

        public static string GetColumnName<T>(string propertyName) where T : class
        {
            var key = (typeof(T), propertyName);

            // Check cache first
            if (_columnNameCache.TryGetValue(key, out string cachedColumnName))
            {
                return cachedColumnName;
            }

            // Get mapping from FluentMapper
            var mapping = FluentMapper.EntityMaps.TryGetValue(typeof(T), out var entityMap)
                ? entityMap as EntityMap<T>
                : null;

            if (mapping != null)
            {
                var propertyMap = mapping.PropertyMaps
                    .FirstOrDefault(p => p.PropertyInfo.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

                if (propertyMap != null)
                {
                    _columnNameCache[key] = propertyMap.ColumnName; // Store in cache
                    return propertyMap.ColumnName;
                }
            }

            // If no mapping found, return property name (fallback)
            return "UpdateDateTime";
        }
    }
}

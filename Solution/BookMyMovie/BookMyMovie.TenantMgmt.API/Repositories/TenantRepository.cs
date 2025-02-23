using BookMyMovie.TenantMgmt.API.Repositories.Entities;
using BookMyMovie.TenantMgmt.API.Repositories.Interfaces;
using System.Data;
using Dapper;
using System.Diagnostics;
using BookMyMovie.TenantMgmt.API.Business.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Transactions;
using BookMyMovie.TenantMgmt.API.Repositories.Helper;

namespace BookMyMovie.TenantMgmt.API.Repositories
{
    public class TenantRepository : IRepository<TenantEntity>
    {
        private readonly IDbConnection _dbConnection;

        public TenantRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PaginatedList<TenantEntity>> GetAllAsync(PaginationParameters parameters)
        {
            var countSql = "SELECT COUNT(*) FROM Tenants";
            var totalCount = await _dbConnection.ExecuteScalarAsync<int>(countSql);

            string columnName = EntityMapHelper.GetColumnName<TenantEntity>(parameters.OrderBy); 

            var query = $@"SELECT * FROM Tenants ORDER BY {columnName} {parameters.SortOrder}
                        OFFSET @Offset ROWS
                        FETCH NEXT @PageSize ROWS ONLY";
            var queryParameters = new
            {
                Offset = (parameters.PageNumber - 1) * parameters.PageSize,
                parameters.PageSize,
                parameters.OrderBy,
                parameters.SortOrder
            };

            var tenants = await _dbConnection.QueryAsync<TenantEntity>(query, queryParameters);
            return new PaginatedList<TenantEntity>(tenants, totalCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<TenantEntity?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Tenants WHERE TenantID = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<TenantEntity>(query, new { Id = id });
        }

        public async Task<int> AddAsync(TenantEntity entity)
        {
            var query = @"
                    INSERT INTO Tenants (TenantName, CreatedBy, CreateDateTime, UpdatedBy, UpdateDateTime, TransactionID)
                    VALUES (@TenantName, @CreatedBy, @CreateDateTime, @UpdatedBy, @UpdateDateTime, @TransactionID)";
            await _dbConnection.ExecuteAsync(query, entity);
            return 1;
        }

        public async Task<bool> UpdateAsync(TenantEntity entity)
        {
            var query = @"
                    UPDATE Tenants
                    SET TenantName = @TenantName,
                        CreatedBy = @CreatedBy,
                        CreateDateTime = @CreateDateTime,
                        UpdatedBy = @UpdatedBy,
                        UpdateDateTime = @UpdateDateTime,
                        TransactionID = @TransactionID
                    WHERE TenantID = @TenantID";
            return await _dbConnection.ExecuteAsync(query, entity) > 1;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = "DELETE FROM Tenants WHERE TenantID = @Id";
            return await _dbConnection.ExecuteAsync(query, new { Id = id }) > 1;
        }
    }
}

using Cemex.Core.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Cemex.Core.Data
{
    public sealed class DbContext : IDbContext
    {
        private const int CommandTimeOut = 600;

        public DbContext(IDbConnection connection)
        {
            this.Connection = connection;
        }

        public IDbConnection Connection
        {
            get;
            private set;
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, object parameters = null)
        {
            return await this.Connection.ExecuteScalarAsync<T>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: CommandTimeOut);
        }

        public async Task<T> QuerySingleAsync<T>(string query, object parameters = null)
        {
            return await this.Connection.QuerySingleAsync<T>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: CommandTimeOut);
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameters = null)
        {
            return await this.Connection.QuerySingleOrDefaultAsync<T>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: CommandTimeOut);
        }        

        public IEnumerable<T> Query<T>(string query, object parameters = null)
        {
            return this.Connection.Query<T>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: CommandTimeOut);
        }

        public async Task<int> ExecuteAsync(string query, object parameters = null)
        {
            return await this.Connection.ExecuteAsync(sql: query, commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: CommandTimeOut);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null)
        {
            return await this.Connection.QueryAsync<T>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: CommandTimeOut);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object parameters = null)
        {
            return await this.Connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, map: map, splitOn: splitOn, commandTimeout: CommandTimeOut);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object parameters = null)
        {
            return await this.Connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, map: map, splitOn: splitOn, commandTimeout: CommandTimeOut);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object parameters = null)
        {
            return await this.Connection.QueryAsync<TFirst, TSecond, TReturn>(sql: query, commandType: CommandType.StoredProcedure, param: parameters, map: map, splitOn: splitOn, commandTimeout: CommandTimeOut);
        }

        public GridReader QueryMultiple(string query, object parameters = null)
        {
            return this.Connection.QueryMultiple(query, parameters, commandType: CommandType.StoredProcedure, commandTimeout: CommandTimeOut);
        }

        public void Dispose()
        {
            this.Connection.Close();
            this.Connection.Dispose();
        }

    }
}

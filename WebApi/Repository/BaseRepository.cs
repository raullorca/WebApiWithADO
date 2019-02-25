using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public abstract class BaseRepository<TEntity>  where TEntity : class
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected async Task<int> ExecuteNonQueryAsync(string commandText, List<SqlParameter> parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    parameters.ForEach(x => command.Parameters.Add(x));
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        protected async Task<int> ExecuteNonQueryAsync(string commandText)
        {
            return await ExecuteNonQueryAsync(commandText, new List<SqlParameter>());
        }

        protected async Task<int> ExecuteNonQueryAsync(string commandText, SqlParameter parameter)
        {
            var parameters = new List<SqlParameter>
            {
                parameter
            };
            return await ExecuteNonQueryAsync(commandText, parameters);
        }

        protected async Task<IQueryable<TEntity>> ExecuteReaderAsync(string commandText)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    var reader = await command.ExecuteReaderAsync();
                    return Maps(reader);
                }
            }
        }

        protected async Task<IQueryable<TEntity>> ExecuteReaderAsync(string commandText, SqlParameter parameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.Add(parameter);
                    var reader = await command.ExecuteReaderAsync();
                    return Maps(reader);
                }
            }
        }

        protected DateTime GetDate(SqlDataReader reader, string columnName)
        {
            return reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        protected int GetInt(SqlDataReader reader, string columnName)
        {
            return reader.GetInt32(reader.GetOrdinal(columnName));
        }

        protected TEntity Map(SqlDataReader reader)
        {
            return Maps(reader).FirstOrDefault();
        }

        protected IQueryable<TEntity> Maps(SqlDataReader reader)
        {
            var entities = new List<TEntity>();

            if (!reader.HasRows)
            {
                return entities.AsQueryable();
            }

            while (reader.Read())
            {
                entities.Add(SetItem(reader));
            }
            return entities.AsQueryable();
        }

        protected abstract TEntity SetItem(SqlDataReader reader);

        protected SqlParameter SetParameter(string parameterName, object value)
        {
            var parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Value = value
            };
            return parameter;
        }
    }
}
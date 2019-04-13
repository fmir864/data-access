using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Sql : IDataProvider
    {
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }

        #region Transaction

        public void BeginTransaction()
        {
            if (Connection == null || !Connection.State.Equals(ConnectionState.Open))
                return;

            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
        }

        #endregion

        #region Connection

        public void Disconnect()
        {
            if (Connection == null || Connection.State.Equals(ConnectionState.Closed))
                return;

            Connection.Close();
            Connection.Dispose();
        }

        public string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ConfigurationManager.AppSettings["DataSource"],
                InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"],
                UserID = ConfigurationManager.AppSettings["UserID"],
                Password = ConfigurationManager.AppSettings["Password"],
                IntegratedSecurity = ConfigurationManager.AppSettings["IntegratedSecurity"].Equals("true", StringComparison.OrdinalIgnoreCase) ? true : false
            };

            return connectionStringBuilder.ConnectionString;
        }

        public async Task Connect(Dictionary<string, string> connectionOpts)
        {
            if (Connection != null && Connection.State.Equals(ConnectionState.Open))
                return;

            string connectionString = GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString", "Connection String cannot be empty.");

            Connection = new SqlConnection(connectionString);
            await Connection.OpenAsync();
        }

        #endregion

        #region Execution

        public async Task<int> ExecuteSqlQuery(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = statement;
                command.CommandType = GetCommandType(commandType);
                command.Parameters.AddRange(GetSqlParameterCollection(parameters).ToArray());

                if (forceTimeoutOff)
                    command.CommandTimeout = 0;

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<DataSet> GetDataSet(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = statement;
                command.CommandType = GetCommandType(commandType);
                command.Parameters.AddRange(GetSqlParameterCollection(parameters).ToArray());

                if (forceTimeoutOff)
                    command.CommandTimeout = 0;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        await Task.Run(() => adapter.Fill(dataSet));
                        return dataSet;
                    }
                }
            }
        }

        public async Task<DataTable> GetDataTable(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = statement;
                command.CommandType = GetCommandType(commandType);
                command.Parameters.AddRange(GetSqlParameterCollection(parameters).ToArray());

                if (forceTimeoutOff)
                    command.CommandTimeout = 0;

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    using (DataTable data = new DataTable())
                    {
                        await Task.Run(() => data.Load(reader));
                        return data;
                    }
                }
            }
        }

        public async Task<object> GetValue(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = statement;
                command.CommandType = GetCommandType(commandType);
                command.Parameters.AddRange(GetSqlParameterCollection(parameters).ToArray());

                if (forceTimeoutOff)
                    command.CommandTimeout = 0;

                return await command.ExecuteScalarAsync();
            }
        }

        private CommandType GetCommandType(CmdType cmdType)
        {
            switch (cmdType)
            {
                case CmdType.Text:
                    return CommandType.Text;
                case CmdType.StoredProcedure:
                    return CommandType.StoredProcedure;
                case CmdType.TableDirect:
                    return CommandType.TableDirect;
                default:
                    return CommandType.Text;
            }
        }

        private List<SqlParameter> GetSqlParameterCollection(Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count.Equals(0))
                return null;

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            foreach (var parameter in parameters)
            {
                sqlParameters.Add(new SqlParameter(parameter.Key, parameter.Value));
            }

            return sqlParameters;
        }

        #endregion

        #region Database Manipulations

        public Task<bool> CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDatabase()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Not Implemented

        public Task<int> SqlDelete(string statement, Dictionary<string, object> parameters, CmdType commandType)
        {
            throw new NotImplementedException();
        }

        public Task<int> SqlInsert(string statement, Dictionary<string, object> parameters, CmdType commandType)
        {
            throw new NotImplementedException();
        }

        public Task<int> SqlUpdate(string statement, Dictionary<string, object> parameters, CmdType commandType)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqLite : IDataProvider
    {
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public Task ConnectAsync(Dictionary<string, string> connectionOpts)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteSqlQueryAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetDataSetAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public Task<DataTable> GetDataTableAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetValueAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}

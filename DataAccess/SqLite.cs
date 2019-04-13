using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

        public Task Connect(Dictionary<string, string> connectionOpts)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDatabase()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteSqlQuery(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetDataSet(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public Task<DataTable> GetDataTable(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetValue(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}

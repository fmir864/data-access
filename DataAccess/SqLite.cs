using System;
using System.Collections.Generic;
using System.Data;

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

        public void Connect(Dictionary<string, string> connectionOpts)
        {
            throw new NotImplementedException();
        }

        public bool CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public bool DeleteDatabase()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlQuery(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public object GetValue(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}

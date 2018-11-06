using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Sql : IDataProvider
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

        public int ExecuteSqlQuery(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public object GetValue(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public bool SetDataTable(DataTable table, string tableName, string fields)
        {
            throw new NotImplementedException();
        }

        public int SqlDelete(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public int SqlInsert(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public int SqlUpdate(string statement, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}

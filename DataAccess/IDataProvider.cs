using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataProvider
    {
        void Connect(Dictionary<String, String> connectionOpts);
        void Disconnect();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        bool CreateDatabase();
        bool DeleteDatabase();
        string GetConnectionString();

        object GetValue(string statement, Dictionary<string, object> parameters);
        DataSet GetDataSet(string statement, Dictionary<string, object> parameters);
        DataTable GetDataTable(string statement, Dictionary<string, object> parameters);

        bool SetDataTable(DataTable table, string tableName, string fields);

        int SqlInsert(string statement, Dictionary<string, object> parameters);
        int SqlUpdate(string statement, Dictionary<string, object> parameters);
        int SqlDelete(string statement, Dictionary<string, object> parameters);
        int ExecuteSqlQuery(string statement, Dictionary<string, object> parameters);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataProvider
    {
        Task Connect(Dictionary<String, String> connectionOpts);
        void Disconnect();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task<bool> CreateDatabase();
        Task<bool> DeleteDatabase();
        string GetConnectionString();

        Task<object> GetValue(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
        Task<DataSet> GetDataSet(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
        Task<DataTable> GetDataTable(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);

        //Task<bool> SetDataTable(DataTable table, string tableName, string fields);

        //Task<int> SqlInsert(string statement, Dictionary<string, object> parameters, CmdType commandType);
        //Task<int> SqlUpdate(string statement, Dictionary<string, object> parameters, CmdType commandType);
        //Task<int> SqlDelete(string statement, Dictionary<string, object> parameters, CmdType commandType);
        Task<int> ExecuteSqlQuery(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
    }

    public enum CmdType
    {
        Text = 1,
        StoredProcedure = 2,
        TableDirect = 3
    }
}

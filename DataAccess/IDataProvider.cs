using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataProvider
    {
        Task ConnectAsync(Dictionary<String, String> connectionOpts);
        void Disconnect();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task<bool> CreateDatabaseAsync();
        Task<bool> DeleteDatabaseAsync();
        string GetConnectionString();

        Task<object> GetValueAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
        Task<DataSet> GetDataSetAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
        Task<DataTable> GetDataTableAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);

        //Task<bool> SetDataTable(DataTable table, string tableName, string fields);

        //Task<int> SqlInsert(string statement, Dictionary<string, object> parameters, CmdType commandType);
        //Task<int> SqlUpdate(string statement, Dictionary<string, object> parameters, CmdType commandType);
        //Task<int> SqlDelete(string statement, Dictionary<string, object> parameters, CmdType commandType);
        Task<int> ExecuteSqlQueryAsync(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
    }

    public enum CmdType
    {
        Text = 1,
        StoredProcedure = 2,
        TableDirect = 3
    }
}

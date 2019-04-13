using System;
using System.Collections.Generic;
using System.Data;

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

        object GetValue(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
        DataSet GetDataSet(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
        DataTable GetDataTable(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);

        //bool SetDataTable(DataTable table, string tableName, string fields);

        //int SqlInsert(string statement, Dictionary<string, object> parameters, CmdType commandType);
        //int SqlUpdate(string statement, Dictionary<string, object> parameters, CmdType commandType);
        //int SqlDelete(string statement, Dictionary<string, object> parameters, CmdType commandType);
        int ExecuteSqlQuery(string statement, Dictionary<string, object> parameters, CmdType commandType, bool forceTimeoutOff);
    }

    public enum CmdType
    {
        Text = 1,
        StoredProcedure = 2,
        TableDirect = 3
    }
}

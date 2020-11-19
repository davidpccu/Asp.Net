using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class OCP_Sample_01_Interface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataProvider2 DataProviderObject = new SqlDataProvider2(); // 用抽象的型別，裝載一個物件
            DataProviderObject.OpenConnection();
            DataProviderObject.ExecuteCommand();
            DataProviderObject.CloseConnection();

            DataProviderObject = new OracleDataProvider2();
            DataProviderObject.OpenConnection();
            DataProviderObject.ExecuteCommand();
            DataProviderObject.CloseConnection();
        }
    }

    // Define other methods and classes here
    interface DataProvider2
    {
        string OpenConnection();
        string CloseConnection();
        string ExecuteCommand();
    }
    class SqlDataProvider2 : DataProvider2
    {
        public string OpenConnection()
        {
            return "Sql Connection opened successfully";
        }
        public string CloseConnection()
        {
            return "Sql Connection closed successfully";
        }
        public string ExecuteCommand()
        {
            return "Sql Command Executed successfully";
        }
    }
    class OracleDataProvider2 : DataProvider2
    {
        public string OpenConnection()
        {
            return "Oracle Connection opened successfully";
        }
        public string CloseConnection()
        {
            return "Oracle Connection closed successfully";
        }
        public string ExecuteCommand()
        {
            return "Oracle Command Executed successfully";
        }
    }

    class OledbDataProvider2 : DataProvider2
    {
        public string OpenConnection()
        {
            return "OLEDB Connection opened successfully";
        }
        public string CloseConnection()
        {
            return "OLEDB Connection closed successfully";
        }
        public string ExecuteCommand()
        {
            return "OEDB Command Executed successfully";
        }
    }
}
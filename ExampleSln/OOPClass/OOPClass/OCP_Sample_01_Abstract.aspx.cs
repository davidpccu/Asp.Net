using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class OCP_Sample_01_Abstract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 抽象類別基本限制，不可被new
            //DataProvider DataProviderObject = new DataProvider(); //erroor

            DataProvider DataProviderObject = new SqlDataProvider(); // 用抽象的型別，裝載一個物件
            DataProviderObject.OpenConnection();
            DataProviderObject.ExecuteCommand();
            DataProviderObject.CloseConnection();

            DataProviderObject = new OracleDataProvider();
            DataProviderObject.OpenConnection();
            DataProviderObject.ExecuteCommand();
            DataProviderObject.CloseConnection();
        }
    }

    // Define other methods and classes here
    abstract class DataProvider
    {
        public abstract string OpenConnection();
        public abstract string CloseConnection();
        public abstract string ExecuteCommand();
    }
    class SqlDataProvider : DataProvider
    {
        public override string OpenConnection()
        {
            return "Sql Connection opened successfully";
        }
        public override string CloseConnection()
        {
            return "Sql Connection closed successfully";
        }
        public override string ExecuteCommand()
        {
            return "Sql Command Executed successfully";
        }
    }
    class OracleDataProvider : DataProvider
    {
        public override string OpenConnection()
        {
            return "Oracle Connection opened successfully";
        }
        public override string CloseConnection()
        {
            return "Oracle Connection closed successfully";
        }
        public override string ExecuteCommand()
        {
            return "Oracle Command Executed successfully";
        }
    }

    class OledbDataProvider : DataProvider
    {
        public override string OpenConnection()
        {
            return "OLEDB Connection opened successfully";
        }
        public override string CloseConnection()
        {
            return "OLEDB Connection closed successfully";
        }
        public override string ExecuteCommand()
        {
            return "OEDB Command Executed successfully";
        }
    }
}
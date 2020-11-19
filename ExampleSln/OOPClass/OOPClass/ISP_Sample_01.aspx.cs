using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class ISP_Sample_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 將未使用到的method介面隔離出來
            DataProviderWithoutTransaction DataProviderObject = new SqlDataProvider();
            DataProviderObject.OpenConnection();
            DataProviderObject.ExecuteCommand();
            DataProviderObject.CloseConnection();
        }

        // Define other methods and classes here

        interface DataProviderWithoutTransaction
        {
            int OpenConnection();
            int CloseConnection();
            int ExecuteCommand();
        }

        interface DataProvider : DataProviderWithoutTransaction
        {
            int BeginTransaction();
        }

        class SqlDataProvider : DataProvider, DataProviderWithoutTransaction
        {
            public int OpenConnection()
            {
                Console.WriteLine("\nSql Connection opened successfully");
                return 1;
            }
            public int CloseConnection()
            {
                Console.WriteLine("Sql Connection closed successfully");
                return 1;
            }
            public int ExecuteCommand()
            {
                Console.WriteLine("Sql Command Executed successfully");
                return 1;
            }
            public int BeginTransaction()
            {
                Console.WriteLine("Sql BeginTransaction started");
                return 1;
            }
        }
    }
}
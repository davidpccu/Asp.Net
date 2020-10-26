using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClassExample
{
    public partial class Static : System.Web.UI.Page
    {
        /*
         * 類別中的靜態成員
         * 我們可以使用static關鍵字定義的類成員為靜態。當我們聲明一個類的靜態成員，這意味著無論多少許多類的對象被創建，有靜態成員隻有一個副本。關鍵字static意味著構建一個實例存在類別。
         * 靜態變量用於定義常量，因為它們的值可以通過調用類別，而無需創建它的一個實例進行檢索。靜態變量可以在成員函數或類別定義之外被初始化。
         * 
         * 也可以聲明一個成員函數為靜態。這些函數隻能訪問靜態變量
         */
        class StaticVar
        {
            public static int num;

            public void count()
            {
                num++;
            }

            public int getNum()
            {
                return num;
            }

            public static int getNum2()
            {
                return num;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StaticVar s1 = new StaticVar();
            StaticVar s2 = new StaticVar();
            s1.count();
            s1.count();
            s1.count();
            s2.count();
            s2.count();
            s2.count();
            Response.Write(string.Format("Variable num for s1: {0}", s1.getNum()));
            Response.Write(string.Format("Variable num for s2: {0}", s2.getNum()));


            StaticVar s3 = new StaticVar();
            s3.count();
            s3.count();
            s3.count();   
            Response.Write(string.Format("Variable num: {0}", s3.getNum()));
        }
    }
}
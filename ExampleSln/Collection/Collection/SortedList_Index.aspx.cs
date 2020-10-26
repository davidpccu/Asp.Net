using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collection
{
    public partial class SortedList_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            #region SortedList 基本用法
            /** [屬性]
             * Capacity	獲取或設置排序列表的容量
             * Count	獲取包含在排序列表元素的數量 
             * IsFixedSize	獲取一個值，指示排序列表是否具有固定大小
             * IsReadOnly	獲取一個值，指示排序列表是否為隻讀
             * Item	Gets and sets the value associated with a specific key in the SortedList.
             * Keys	獲取的排序列表的鍵
             * Values	獲取的排序列表(SortedList)中的值
             * ==============================================================
             */

            /** [方法]
             * void Add (object key, object value)：將帶有指定鍵和值到排序列表的元素
             * void Clear()：
             * bool ContainsKey( object key )：
             * bool ContainsValue( object value )：確定SortedList 是否包含特定的值
             * object GetByIndex( int index )：獲取SortedList中指定索引處的值
             * object GetKey( int index )：獲取SortedList中指定索引處的鍵
             * IList GetKeyList()：獲取SortedList的鍵
             * IList GetValueList()：獲取SortedList中的值
             * int IndexOfKey( object key )：返回在排序列表中指定鍵從零開始的索引
             * int IndexOfValue( object value )：返回在SortedList中指定的值第一次出現的從零開始的索引
             * void Remove( object key )：刪除從SortedList表中指定鍵的元素
             * void RemoveAt( int index )：刪除SortedList中指定索引處的元素
             * void TrimToSize()：設置在SortedList元素的實際數量
             */
            #endregion


            SortedList sl = new SortedList();

            sl.Add("001", "Zara Ali");
            sl.Add("002", "Abida Rehman");
            sl.Add("003", "Joe Holzner");
            sl.Add("004", "Mausam Benazir Nur");
            sl.Add("005", "M. Amlan");
            sl.Add("006", "M. Arif");
            sl.Add("007", "Ritesh Saikia");

            if ( sl.ContainsValue("Nuha Ali") )
            {
                Response.Write("This student name is already in the list");
            }
            else
            {
                sl.Add("008", "Nuha Ali");
            }

            // Query
            Response.Write("<h2>方法一</h2>");
            ICollection key = sl.Keys;
            foreach ( string k in key )
            {
                Response.Write(k + ": " + sl[k] + "<br>");
            }

            Response.Write("<h2>方法二</h2>");
            foreach ( DictionaryEntry item in sl )
            {
                Response.Write(item.Key + ": " + item.Value + "<br>");
            }


            // Remove elements from SortedList:
            SortedList sortedList1 = new SortedList();
            sortedList1.Add("one", 1);
            sortedList1.Add("two", 2);
            sortedList1.Add("three", 3);
            sortedList1.Add("four", 4);

            sortedList1.Remove("one"); //removes element whose key is 'one'
            sortedList1.RemoveAt(0);   //removes element at zero index i.e first element: four

            foreach ( DictionaryEntry kvp in sortedList1 )
                Response.Write(string.Format("key: {0}, value: {1}", kvp.Key, kvp.Value));



            // Check for existing key in SortedList
            SortedList sortedList = new SortedList();
            sortedList.Add(3, "Three");
            sortedList.Add(2, "Two");
            sortedList.Add(4, "Four");
            sortedList.Add(1, "One");
            sortedList.Add(8, "Five");

            sortedList.Contains(2); // returns true
            sortedList.Contains(4); // returns true
            sortedList.Contains(6); // returns false

            sortedList.ContainsKey(2); // returns true
            sortedList.ContainsKey(6); // returns false

            sortedList.ContainsValue("One"); // returns true
            sortedList.ContainsValue("Ten"); // returns false
        }
    }
}
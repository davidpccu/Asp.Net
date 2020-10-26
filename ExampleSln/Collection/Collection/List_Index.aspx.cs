using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collection
{
    public partial class List_Index : System.Web.UI.Page
    {
        public class MyGenericArray<T>
        {
            private T[] array;
            public MyGenericArray(int size)
            {
                array = new T[size + 1];
            }
            public T getItem(int index)
            {
                return array[index];
            }
            public void setItem(int index, T value)
            {
                array[index] = value;
            }
            public int ArrayLength() 
            {
                return array.Length;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //setting values
            for (int c = 0; c < intArray.ArrayLength(); c++)
            {
                intArray.setItem(c, c*intArray.ArrayLength());
            }
            //retrieving the values
            for (int c = 0; c < intArray.ArrayLength(); c++)
            {
                Response.Write(intArray.getItem(c) + " ");
            }


            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            //setting values
            for (int c = 0; c < intArray.ArrayLength(); c++)
            {
                charArray.setItem(c, (char)(c+97));
            }
            //retrieving the values
            for (int c = 0; c< intArray.ArrayLength(); c++)
            {
                Response.Write(charArray.getItem(c) + " ");
            }
        }
    }
}
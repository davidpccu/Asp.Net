using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linq
{
    public class User : IComparable<User>
    {
        public string name { get; set; }
        public int age { get; set; }

        #region IComparable<User> Members
        public int CompareTo(User other)
        {
            //return age - other.age;
            return name.CompareTo(other.name);
        }
        #endregion

        public class SortByAge : IComparer<User>
        {
            public int Compare(User x1, User y1)
            {
                //User x1 = x as User;
                //User y1 = y as User;
                return x1.age.CompareTo(y1.age);
            }
        }

    }
}
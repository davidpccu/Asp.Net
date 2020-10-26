using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Linq
{
    public partial class IComparer_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Car[] arr = new Car[]   
            {
                new Car(){Maker = "Ford", Year = 1992, Price = 2500},
                new Car(){Maker = "Fiat",Year = 1988,Price = 1500},
                new Car(){Maker = "Buick",Year = 1932,Price = 2400},
                new Car(){Maker = "Ford", Year = 1932, Price = 1300},
                new Car(){Maker = "Dodge",Year = 1999,Price = 1000},
                new Car(){Maker = "Honda",Year = 1977,Price = 5600}
            };

            Array.Sort(arr, Car.依年份排序);
            foreach (Car item in arr)
            {
                Response.Write(item.ToString() + "<br/>");
            }
            Response.Write("<hr/>");

            List<User> users = new List<User>();
            users.Add(new User { name = "Ming", age = 50 });
            users.Add(new User { name = "Wang", age = 35 });
            users.Add(new User { name = "Ben", age = 30 });
            users.Add(new User { name = "Kevin", age = 48 });

            users.Sort();
            foreach (User item in users)
            {
                Response.Write(item.name + ", age = " + item.age + "<br/>");
            }
            Response.Write("<hr/>");

            users.Sort(new User.SortByAge());
            foreach (User item in users)
            {
                Response.Write(item.name + ", age = " + item.age + "<br/>");
            }
        }

        public class Car
        {
            public string Maker { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }

            class SortByMaker : IComparer
            {
                public int Compare(object x, object y)
                {
                    Car x1 = x as Car;
                    Car y1 = y as Car;
                    return x1.Maker.CompareTo(y1.Maker);
                }
            }

            class SortByMakerDesc : IComparer
            {
                public int Compare(object x, object y)
                {
                    Car x1 = x as Car;
                    Car y1 = y as Car;
                    return y1.Maker.CompareTo(x1.Maker);
                }
            }

            class SortByYear : IComparer
            {
                public int Compare(object x, object y)
                {
                    Car x1 = x as Car;
                    Car y1 = y as Car;
                    return x1.Year.CompareTo(y1.Year);
                }
            }

            class SortByYearDesc : IComparer
            {
                public int Compare(object x, object y)
                {
                    Car x1 = x as Car;
                    Car y1 = y as Car;
                    return y1.Year.CompareTo(x1.Year);
                }
            }

            class SortByPrice : IComparer
            {
                public int Compare(object x, object y)
                {
                    Car x1 = x as Car;
                    Car y1 = y as Car;
                    return x1.Price.CompareTo(y1.Price);
                }
            }

            class SortByPriceDesc : IComparer
            {
                public int Compare(object x, object y)
                {
                    Car x1 = x as Car;
                    Car y1 = y as Car;
                    return y1.Price.CompareTo(x1.Price);
                }
            }

            private static IComparer[] Sorters = new IComparer[]
            {
            new SortByMaker(),
            new SortByMakerDesc(),
            new SortByYear(),
            new SortByYearDesc(),
            new SortByPrice(),
            new SortByPriceDesc(),
            };

            public static IComparer 依廠牌排序
            {
                get { return Sorters[0]; }
            }

            public static IComparer 依廠牌遞減排序
            {
                get { return Sorters[1]; }
            }

            public static IComparer 依年份排序
            {
                get { return Sorters[2]; }
            }

            public static IComparer 依年份遞減排序
            {
                get { return Sorters[3]; }
            }

            public static IComparer 依價格排序
            {
                get { return Sorters[4]; }
            }

            public static IComparer 依價格遞減排序
            {
                get { return Sorters[5]; }
            }

            public override string ToString()
            {
                return string.Format("{0} - {1} - {2}", this.Maker, this.Year, this.Price);
            }
        }
    }
}
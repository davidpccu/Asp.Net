using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaOfGridView
{
    public partial class MegaOfGridView : System.Web.UI.Page
    {
        /// <summary>
        /// 類別
        /// </summary>
        public class Salary
        {
            /// <summary>
            /// 姓名
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 工資項目
            /// </summary>
            public string Item { get; set; }
            /// <summary>
            /// 工資子項目
            /// </summary>
            public string SubItem { get; set; }
            /// <summary>
            /// 月份
            /// </summary>
            public string Month { get; set; }
            /// <summary>
            /// 薪資
            /// </summary>
            public string Money { get; set; }
        }

        class RowArg
        {
            public int StartRowIndex { get; set; }
            public int EndRowIndex { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 假資料
            List<Salary> salaryList = new List<Salary>();
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "應發工資",
                SubItem = "基本工資",
                Month = "1月",
                Money = "3000"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "應發工資",
                SubItem = "獎金",
                Month = "1月",
                Money = "500"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "應發工資",
                SubItem = "獎金",
                Month = "1月",
                Money = "130"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "應發工資",
                SubItem = "獎金",
                Month = "1月",
                Money = "150"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "應發工資",
                SubItem = "加班",
                Month = "1月",
                Money = "100"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "應發工資",
                SubItem = "加班",
                Month = "1月",
                Money = "100"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "保險",
                SubItem = "醫療保險",
                Month = "1月",
                Money = "500"
            });
            salaryList.Add(new Salary()
            {
                Name = "碼農哲",
                Item = "保險",
                SubItem = "房租",
                Month = "1月",
                Money = "370"
            });
            salaryList.Add(new Salary()
            {
                Name = "",
                Item = "",
                SubItem = "",
                Month = "合計",
                Money = "3500"
            });
            #endregion

            GridView1.DataSource = salaryList;
            GridView1.DataBind();
            MergeRow(GridView1, 0, 3);
        }

        /// <summary>
        /// 合併單列的行
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="currentCol">當前列</param>
        /// <param name="startRow">開始合併的行索引</param>
        /// <param name="endRow">結束合併的行索引</param>
        private static void MergeRow(GridView gv, int currentCol, int startRow, int endRow)
        {
            for ( int rowIndex = endRow; rowIndex >= startRow; rowIndex-- )
            {
                GridViewRow currentRow = gv.Rows[rowIndex];
                GridViewRow prevRow = gv.Rows[rowIndex + 1];
                if ( currentRow.Cells[currentCol].Text != "" && currentRow.Cells[currentCol].Text != " " )
                {
                    if ( currentRow.Cells[currentCol].Text == prevRow.Cells[currentCol].Text )
                    {
                        currentRow.Cells[currentCol].RowSpan = prevRow.Cells[currentCol].RowSpan < 1 ? 2 : prevRow.Cells[currentCol].RowSpan + 1;
                        prevRow.Cells[currentCol].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 遍歷前一列
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="prevCol">當前列的前一列</param>
        /// <param name="list"></param>
        private static void TraversesPrevCol(GridView gv, int prevCol, List<RowArg> list)
        {
            if ( list == null )
            {
                list = new List<RowArg>();
            }
            RowArg ra = null;
            for ( int i = 0; i < gv.Rows.Count; i++ )
            {
                if ( !gv.Rows[i].Cells[prevCol].Visible )
                {
                    continue;
                }
                ra = new RowArg();
                ra.StartRowIndex = gv.Rows[i].RowIndex;
                ra.EndRowIndex = ra.StartRowIndex + gv.Rows[i].Cells[prevCol].RowSpan - 2;
                list.Add(ra);
            }
        }

        /// <summary>
        /// GridView合併行，
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="startCol">開始列</param>
        /// <param name="endCol">結束列</param>
        public static void MergeRow(GridView gv, int startCol, int endCol)
        {
            RowArg init = new RowArg()
            {
                StartRowIndex = 0,
                EndRowIndex = gv.Rows.Count - 2
            };

            for ( int i = startCol; i < endCol + 1; i++ )
            {
                if ( i > 0 )
                {
                    List<RowArg> list = new List<RowArg>();
                    //從第二列開始就要遍歷前一列
                    TraversesPrevCol(gv, i - 1, list);
                    foreach ( var item in list )
                    {
                        MergeRow(gv, i, item.StartRowIndex, item.EndRowIndex);
                    }
                }
                else //合併開始列的行
                {
                    MergeRow(gv, i, init.StartRowIndex, init.EndRowIndex);
                }
            }
        }

    }
}
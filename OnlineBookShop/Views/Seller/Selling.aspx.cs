using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Seller
{
    public partial class Selling : System.Web.UI.Page
    {
        Models.Functions Con;
        int Seller = Login.User;
        string SName = Login.UName;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Book"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                });
                ViewState["Bill"] = dt;
                this.BindGrid();
            }
        }

        protected void BindGrid() 
        {
            BillList.DataSource = ViewState["Bill"];
            BillList.DataBind();
        }

        private void ShowBooks()
        {
            string Query = "SELECT BId as Code, BName as Name, BQty as Stock, BPrice as Price FROM BookTbl";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }

        int Key = 0;
        int Stock = 0;

        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTitleTb.Value = BooksList.SelectedRow.Cells[2].Text;
            BPriceTb.Value = BooksList.SelectedRow.Cells[4].Text;
            Stock = Convert.ToInt32(BooksList.SelectedRow.Cells[4].Text);
            //DateTb.Value = BooksList.SelectedRow.Cells[5].Text;

            if (BTitleTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }

        private void UpdateStock()
        {
            int NewQty;
            NewQty = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text) - Convert.ToInt32(BQtyTb.Value);
            string Query = "UPDATE BookTbl SET BQty = {0} WHERE BId = {1}";
            Query = string.Format(Query, NewQty, BooksList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowBooks();
        }

        private void InsertBill()
        {
            string Query = "INSERT INTO BillTbl VALUES('{0}', {1}, {2})";
            Query = string.Format(Query, System.DateTime.Today.Date.ToString(), Seller, Convert.ToInt32(GrdTotalTb.Text.Substring(2)));
            Con.SetData(Query);
        }

        int grdTotal = 0;
        int amount;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Value == "" || BPriceTb.Value == "" || BQtyTb.Value == "")
            {
                ErrMsg.Text = "Missing Data!!!";
            }
            else {
                ErrMsg.Text = "";
                int total = Convert.ToInt32(BQtyTb.Value) * Convert.ToInt32(BPriceTb.Value);
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(BillList.Rows.Count + 1,
                    BTitleTb.Value,
                    BPriceTb.Value,
                    BQtyTb.Value,
                    total);
                ViewState["Bill"] = dt;
                this.BindGrid();
                this.UpdateStock();
               
                for (int i = 0; i < BillList.Rows.Count - 1; i++)
                {
                    grdTotal += Convert.ToInt32(BillList.Rows[i].Cells[5].Text);
                }
                amount = grdTotal;
                GrdTotalTb.Text = "Rs" + grdTotal;
                BTitleTb.Value = "";
                BPriceTb.Value = "";
                BQtyTb.Value = "";
                DateTb.Value = "";
            }
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();
        }
    }
}
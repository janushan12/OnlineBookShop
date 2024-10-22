using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
                GetCategories();
                GetAuthors();
            }
        }

        private void ShowBooks()
        {
            string Query = "SELECT * FROM BookTbl";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }

        private void GetCategories()
        {
            string Query = "SELECT * FROM CategoryTbl";
            BCatTb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            BCatTb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
            BCatTb.DataSource = Con.GetData(Query);
            BCatTb.DataBind();
        }

        private void GetAuthors()
        {
            string Query = "SELECT * FROM AuthTbl";
            BAuthTb.DataTextField = Con.GetData(Query).Columns["AuthName"].ToString();
            BAuthTb.DataValueField = Con.GetData(Query).Columns["AuthId"].ToString();
            BAuthTb.DataSource = Con.GetData(Query);
            BAuthTb.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BTitleTb.Value == "" || BAuthTb.SelectedIndex == -1 || BCatTb.SelectedIndex == -1 || BPriceTb.Value == "" || BQuantityTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string BTitle = BTitleTb.Value;
                    string BAuthor = BAuthTb.SelectedValue.ToString();
                    string BCategory = BCatTb.SelectedValue.ToString();
                    int BQuantity = Convert.ToInt32(BQuantityTb.Value);
                    int BPrice = Convert.ToInt32(BPriceTb.Value);

                    string Query = "INSERT INTO BookTbl values('{0}', {1}, '{2}', {3}, {4})";
                    Query = string.Format(Query, BTitle, BAuthor, BCategory, BQuantity, BPrice);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "New Book Inserted!!!";

                    BTitleTb.Value = "";
                    BAuthTb.SelectedIndex = -1;
                    BCatTb.SelectedIndex = -1;
                    BPriceTb.Value = "";
                    BQuantityTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;

        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTitleTb.Value = BooksList.SelectedRow.Cells[2].Text;
            BAuthTb.SelectedValue = BooksList.SelectedRow.Cells[3].Text;
            BCatTb.SelectedValue = BooksList.SelectedRow.Cells[4].Text;
            BQuantityTb.Value = BooksList.SelectedRow.Cells[5].Text;
            BPriceTb.Value = BooksList.SelectedRow.Cells[6].Text;

            if (BTitleTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BTitleTb.Value == "" || BAuthTb.SelectedIndex == -1 || BCatTb.SelectedIndex == -1 || BPriceTb.Value == "" || BQuantityTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string BTitle = BTitleTb.Value;
                    string BAuthor = BAuthTb.SelectedValue.ToString();
                    string BCategory = BCatTb.SelectedValue.ToString();
                    int BQuantity = Convert.ToInt32(BQuantityTb.Value);
                    int BPrice = Convert.ToInt32(BPriceTb.Value);

                    int BID = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);

                    string Query = "UPDATE BookTbl SET BName = '{0}', BAuthor = {1}, BCategory = {2}, BQty = {3}, BPrice = {4} WHERE BId = {5}";
                    Query = string.Format(Query, BTitle, BAuthor, BCategory, BQuantity, BPrice, BID);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Updated!!!";

                    BTitleTb.Value = "";
                    BAuthTb.SelectedIndex = -1;
                    BCatTb.SelectedIndex = -1;
                    BPriceTb.Value = "";
                    BQuantityTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BTitleTb.Value == "" || BAuthTb.SelectedIndex == -1 || BCatTb.SelectedIndex == -1 || BPriceTb.Value == "" || BQuantityTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string BTitle = BTitleTb.Value;
                    string BAuthor = BAuthTb.SelectedValue.ToString();
                    string BCategory = BCatTb.SelectedValue.ToString();
                    int BQuantity = Convert.ToInt32(BQuantityTb.Value);
                    int BPrice = Convert.ToInt32(BPriceTb.Value);

                    int BID = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);

                    string Query = "DELETE FROM BookTbl WHERE BId = {0}";
                    Query = string.Format(Query, BID);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Deleted!!!";

                    BTitleTb.Value = "";
                    BAuthTb.SelectedIndex = -1;
                    BCatTb.SelectedIndex = -1;
                    BPriceTb.Value = "";
                    BQuantityTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}
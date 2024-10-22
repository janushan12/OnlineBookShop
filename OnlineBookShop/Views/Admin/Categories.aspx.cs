using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            showCategories();
        }

        private void showCategories() 
        {
            string Query = "SELECT * FROM CategoryTbl";
            CategoriesList.DataSource = Con.GetData(Query);
            CategoriesList.DataBind();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || CatDescTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string Description = CatDescTb.Value;

                    string Query = "INSERT INTO CategoryTbl values('{0}', '{1}')";
                    Query = string.Format(Query, CName, Description);
                    Con.SetData(Query);
                    showCategories();
                    ErrMsg.Text = "Category Inserted!!!";

                    CatNameTb.Value = "";
                    CatDescTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatNameTb.Value = CategoriesList.SelectedRow.Cells[2].Text;
            CatDescTb.Value = CategoriesList.SelectedRow.Cells[3].Text;

            //System.Diagnostics.Debug.WriteLine(CountryCb.SelectedItem.Value);

            if (CatNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRow.Cells[1].Text);
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || CatDescTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string Description = CatDescTb.Value;

                    int CID = Convert.ToInt32(CategoriesList.SelectedRow.Cells[1].Text);

                    string Query = "UPDATE CategoryTbl SET CatName = '{0}', CatDesc = '{1}' WHERE CatId = {2}";
                    Query = string.Format(Query, CName, Description, CID);
                    Con.SetData(Query);
                    showCategories();
                    ErrMsg.Text = "Author Updated!!!";

                    CatNameTb.Value = "";
                    CatDescTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || CatDescTb.Value == "")
                {
                    ErrMsg.Text = "Select an Author!!!";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string Description = CatDescTb.Value;

                    int CID = Convert.ToInt32(CategoriesList.SelectedRow.Cells[1].Text);

                    string Query = "DELETE FROM CategoryTbl WHERE CatId = {0}";
                    Query = string.Format(Query, CID);
                    Con.SetData(Query);
                    showCategories();
                    ErrMsg.Text = "Category Deleted!!!";

                    CatNameTb.Value = "";
                    CatDescTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}
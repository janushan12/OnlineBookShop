using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowSellers();
        }

        private void ShowSellers() 
        {
            string Query = "SELECT * FROM selTbl";
            SellersList.DataSource = Con.GetData(Query);
            SellersList.DataBind();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || SEmailTb.Value == "" || SPhoneTb.Value == "" || SPasswordTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string SPhone = SPhoneTb.Value;
                    string SAddress = SPasswordTb.Value;

                    string Query = "INSERT INTO SelTbl values('{0}', '{1}', '{2}', '{3}')";
                    Query = string.Format(Query, SName, SEmail, SPhone, SAddress);
                    Con.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Seller Inserted!!!";

                    SNameTb.Value = "";
                    SEmailTb.Value = "";
                    SPhoneTb.Value = "";
                    SPasswordTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || SEmailTb.Value == "" || SPhoneTb.Value == "" || SPasswordTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string SPhone = SPhoneTb.Value;
                    string SPassword = SPasswordTb.Value;

                    int SID = Convert.ToInt32(SellersList.SelectedRow.Cells[1].Text);

                    string Query = "UPDATE SelTbl SET SelName = '{0}', SelEmail = '{1}', SelPhone = '{2}', SelPassword = '{3}' WHERE SelId = {4}";
                    Query = string.Format(Query, SName,SEmail, SPhone, SPassword, SID);
                    Con.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Seller Updated!!!";

                    SNameTb.Value = "";
                    SEmailTb.Value = "";
                    SPhoneTb.Value = "";
                    SPasswordTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void SellersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SNameTb.Value = SellersList.SelectedRow.Cells[2].Text;
            SEmailTb.Value = SellersList.SelectedRow.Cells[3].Text;
            SPhoneTb.Value = SellersList.SelectedRow.Cells[4].Text;
            SPasswordTb.Value = SellersList.SelectedRow.Cells[5].Text;

            if (SNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellersList.SelectedRow.Cells[1].Text);
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || SEmailTb.Value == "" || SPhoneTb.Value == "" || SPasswordTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string SPhone = SPhoneTb.Value;
                    string SAddress = SPasswordTb.Value;

                    int SID = Convert.ToInt32(SellersList.SelectedRow.Cells[1].Text);

                    string Query = "DELETE FROM SelTbl WHERE SelId = {0}";
                    Query = string.Format(Query, SID);
                    Con.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Seller Deleted!!!";

                    SNameTb.Value = "";
                    SEmailTb.Value = "";
                    SPhoneTb.Value = "";
                    SPasswordTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}
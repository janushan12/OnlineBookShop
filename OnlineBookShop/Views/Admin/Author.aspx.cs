using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Author : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowAuthors();
        }

        private void ShowAuthors()
        {
            string Query = "SELECT * FROM AuthTbl";
            AuthorsList.DataSource = Con.GetData(Query);
            AuthorsList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ( ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1 )
                {
                    ErrMsg.Text = "Missing Data!!!";
                } else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = "INSERT INTO AuthTbl values('{0}', '{1}', '{2}')";
                    Query = string.Format(Query, AName, Gender, Country);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Inserted!!!";

                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ANameTb.Value = AuthorsList.SelectedRow.Cells[2].Text;
            GenCb.SelectedValue = AuthorsList.SelectedRow.Cells[3].Text;
            CountryCb.SelectedValue = AuthorsList.SelectedRow.Cells[4].Text;

            //System.Diagnostics.Debug.WriteLine(CountryCb.SelectedItem.Value);

            if (ANameTb.Value == "")
            {
                Key = 0;
            } else
            {
                Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    int AID = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);

                    string Query = "UPDATE AuthTbl SET AuthName = '{0}', AuthGender = '{1}', AuthCountry = '{2}' WHERE AuthId = {3}";
                    Query = string.Format(Query, AName, Gender, Country, AID);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Updated!!!";

                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
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
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select an Author!!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    int AID = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);

                    string Query = "DELETE FROM AuthTbl WHERE AuthId = {0}";
                    Query = string.Format(Query, AID);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Deleted!!!";

                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}
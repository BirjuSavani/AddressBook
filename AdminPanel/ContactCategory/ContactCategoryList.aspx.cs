using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGirdView();
        }
    }
    #region FillGridView
    private void FillGirdView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        objConn.Open();

        SqlCommand objComd = new SqlCommand();
        objComd.Connection = objConn;
        objComd.CommandType = CommandType.StoredProcedure;
        objComd.CommandText = "PR_ContactCategory_SelectALL";
        SqlDataReader objSDR = objComd.ExecuteReader();
        gvContactCategory.DataSource = objSDR;
        gvContactCategory.DataBind();

        objConn.Close();
    }
    #endregion FillGridView
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                DeleteCotactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }

    #region DeleteContactCategory

    private void DeleteCotactCategory(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactCategory_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillGirdView();
            lblMessage.Text += "Delete Record County ID = " + ContactCategoryID.ToString();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }

    #endregion DeleteContactCategory
}
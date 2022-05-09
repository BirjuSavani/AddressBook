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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #region FillGridView
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        objConn.Open();

        SqlCommand objComd = new SqlCommand();
        objComd.Connection = objConn;
        objComd.CommandType = CommandType.StoredProcedure;
        objComd.CommandText = "PR_Contact_SelectALL";
        SqlDataReader objSDR = objComd.ExecuteReader();
        gvContact.DataSource = objSDR;
        gvContact.DataBind();

        objConn.Close();
    }
    #endregion FillGridView
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));              
            }
        }
    }

    #region DeleteContact

    private void DeleteContact(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillGridView();
            lblMessage.Text += "Delete Record County ID = " + ContactID.ToString();
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

    #endregion DeleteContact

}
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

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
        objComd.CommandText = "PR_Country_SelectALL";
        SqlDataReader objSDR = objComd.ExecuteReader();
        gvCounrty.DataSource = objSDR;
        gvCounrty.DataBind();

        objConn.Close();
    }
    #endregion FillGridView
    protected void gvCounrty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }
        }
    }

    #region DeleteCountry

    private void DeleteCountry(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillGridView();
            lblMessage.Text += "Delete Record County ID = " + CountryID.ToString();
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

    #endregion DeleteCountry
}
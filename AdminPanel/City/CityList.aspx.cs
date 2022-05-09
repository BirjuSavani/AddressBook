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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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
        objComd.CommandText = "PR_City_SelectALL";
        SqlDataReader objSDR = objComd.ExecuteReader();
        gvCity.DataSource = objSDR;
        gvCity.DataBind();

        objConn.Close();
    }
    #endregion FillGridView
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }

    }

    #region Delete

    private void DeleteCity(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_City_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillGridView();
            lblMessage.Text += "Delete Record County ID = " + CityID.ToString();
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

    #endregion Delete
}
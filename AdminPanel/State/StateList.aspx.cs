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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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
        objComd.CommandText = "PR_State_SelectALL";
        SqlDataReader objSDR = objComd.ExecuteReader();
        gvState.DataSource = objSDR;

        if (objSDR.HasRows)
        {
            gvState.DataSource = objSDR;
            gvState.DataBind();
        }
        objConn.Close();
    }
    #endregion FillGridView
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }

    }

    #region DeleteState
    private void DeleteState(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillGridView();
            lblMessage.Text += "Delete Record State ID = " + StateID.ToString();
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
    #endregion DeleteState

}
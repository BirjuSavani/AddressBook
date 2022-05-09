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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDrownList();
            if (Request.QueryString["StateID"] != null)
            {
                lblMassege.Text = "Edit Mode | StateID = " + Request.QueryString["StateID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {
                lblMassege.Text = "Add Mode";
            }
            
        }
    }

    #region btnSave
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;

        #region Server side validation
        String strErrorMessage = "";
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "Please Select Country Name <br>";
        }
        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter State Name <br>";
        }
        if (txtStateCode.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter State Code <br>";
        }
        if (strErrorMessage != "")
        {
            lblMassege.Text = strErrorMessage;
            return;
        }
        #endregion Server side validation

        #region Gether the information
        if (ddlCountryID.SelectedIndex > 0)
        {
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (txtStateName.Text.Trim() != "")
        {
            strStateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim() != "")
        {
            strStateCode = txtStateCode.Text.Trim();
        }
        #endregion Gether the information


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        try{
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);



        if (Request.QueryString["StateID"] != null)
        {
            // Edit mode
            #region Update Record
            objCmd.CommandText = "PR_State_UpdateByPK";
            objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"].ToString().Trim());
            objCmd.ExecuteNonQuery();
            Response.Redirect("~/AdminPanel/State/StateList.aspx", true);
            #endregion Update Record
        }
        else
        {
            // Add mode
            #region Insert Record
            objCmd.CommandText = "[dbo].[PR_State_Insert]";
            objCmd.ExecuteNonQuery();
            txtStateName.Text = "";
            txtStateCode.Text = "";
            ddlCountryID.SelectedIndex = 0;
            ddlCountryID.Focus();
            lblMassege.ForeColor = System.Drawing.Color.Green;
            lblMassege.Text = "Data Inserted Sucessfully";
            #endregion Insert Record

        }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
       }
        catch (Exception ex)
        {
            lblMassege.Text=ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion btnSave

    #region FillDropDownList
    private void FillDropDrownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[dbo].[PR_Country_SelectForDropDownList]";
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlCountryID.DataSource = objSDR;
            ddlCountryID.DataValueField = "CountryID";
            ddlCountryID.DataTextField = "CountryName";
            ddlCountryID.DataBind();
        }
        ddlCountryID.Items.Insert(0, new ListItem("------------Select Country------------", "-1"));

        objConn.Close();
    }

    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_SelectByPK]";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the value and set the contros
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }

                    if (!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMassege.Text = "No Data avaliable for the StateID = " + StateID.ToString();
            }
            #endregion Read the value and set the contros
        }
        catch (Exception ex)
        {
            lblMassege.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }

    }
    #endregion FillControls

    #region btnCancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx", true);
    }
    #endregion btnCancel
}
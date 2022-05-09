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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Request.QueryString["CityID"] != null)
            {
                lblMassege.Text = "Edit Mode | CityID = " + Request.QueryString["CityID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
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
        #region Local Veriable
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        #endregion Local Veriable

        #region Server Side Validation
        String strErrorMessage = "";
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "Please Select State Name <br>";
        }
        if (txtCityName.Text.Trim() == "") 
        {
            strErrorMessage += "Please Enter City Name <br>";
        }
        if (strErrorMessage != "")
        {
            lblMassege.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gether the Information
        if (ddlStateID.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (txtCityName.Text.Trim() != "")
        {
            strCityName = txtCityName.Text.Trim();
        }
        if (txtSTDCode.Text.Trim() != "")
        {
            strSTDCode = txtSTDCode.Text.Trim();
        }
        if (txtPinCode.Text.Trim() != "")
        {
            strPinCode = txtPinCode.Text.Trim();
        }
        #endregion Gether the Information


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);

            
            if (Request.QueryString["CityID"] != null)
            {
                // Edit mode
                #region Update Record
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
                #endregion Update Record
            }
            else
            {
                // Add mode
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();
                objConn.Close();
                lblMassege.Text = "Data Inserted Successfully";
                ddlStateID.SelectedIndex = 0;
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPinCode.Text = "";
                ddlStateID.Focus();
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMassege.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion btnSave

    #region FillDropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownList]";
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlStateID.DataSource = objSDR;
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
        }
        ddlStateID.Items.Insert(0, new ListItem("------------Select City------------", "-1"));

        objConn.Close();
    }
    #endregion FillDropDownList

    #region FillControls

    private void FillControls(SqlInt32 CityID)
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
            objCmd.CommandText = "PR_City_SelectByPK";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the value and set the contros
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }

                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMassege.Text = "No Data avaliable for the CityID = " + CityID.ToString();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
    }
}
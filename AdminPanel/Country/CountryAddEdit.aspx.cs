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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblMassege.Text = "Edit Mode | CountryID = " + Request.QueryString["CountryID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
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

        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;

        #region Server side Validtion
        String strErrorMessge = "";
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessge += "Please Enter Country Name <br>";
        }
        if (txtCountryCode.Text.Trim() == "")
        {
            strErrorMessge += "Please Enter Country Code <br>";
        }
        if (strErrorMessge != "")
        {
            lblMassege.Text = strErrorMessge;
            return;
        }
        #endregion Server side Validtion

        #region Gether the information
        if (txtCountryName.Text.Trim() != "")
        {
            strCountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            strCountryCode = txtCountryCode.Text.Trim();
        }
        #endregion Gether the information


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

           


            if (Request.QueryString["CountryID"] != null)
            {
                // Edit mode
                #region Update Record
                objCmd.CommandText = "[dbo].[PR_Country_UpdateByPK]";
                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
                #endregion Update Record
            }
            else
            {
                // Add mode
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_Country_Insert]";

                //strCountryName = txtCountryName.Text.Trim();
                //strCountryCode = txtCountryCode.Text.Trim();

                objCmd.ExecuteNonQuery();

                objConn.Close();

                lblMassege.Text = "Data Inserted Successfully";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
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

    #region FillControls

    private void FillControls(SqlInt32 CountryID)
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
            objCmd.CommandText = "[dbo].[PR_Country_SelectByPK]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the value and set the contros
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMassege.Text = "No Data avaliable for the CounrtyID = " + CountryID.ToString();
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
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
    }
}
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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownListCountry();
            FillDropDownListState();
            FillDropDownListCity();
            FillDropDownListContactCategory();
            if (Request.QueryString["ContactID"] != null)
            {
                lblMassege.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
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
        #region Local Variable
        SqlInt32 strCountyID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNumber = SqlString.Null;
        SqlString strWhatsappNumber = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strBirthDate = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "Please Select Country Name <br>";
        }
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "Please Select State Name <br>";
        }
        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "Please Select City Name <br>";
        }
        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMessage += "Please Select Contact Category Name <br>";
        }
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter Contact Name <br>";
        }
        if (txtConatactNumber.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter Contact Number <br>";
        }
        if (txtWhatsappNumber.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter Whatsapp Number <br>";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter Email<br>";
        }
        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter Address<br>";
        }
        //if (txtAge.Text.Trim() == "")
        //{
        //    strErrorMessage += "Please Enter  Name <br>";
        //}
        //if (txtBirthDate.Text.Trim() == "")
        //{
        //    strErrorMessage += "Please Enter City Name <br>";
        //}
        //if (txtBloodGroup.Text.Trim() == "")
        //{
        //    strErrorMessage += "Please Enter City Name <br>";
        //}
        if (strErrorMessage != "")
        {
            lblMassege.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gether the Information
        if (ddlCountryID.SelectedIndex > 0)
        {
            strCountyID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (ddlCityID.SelectedIndex > 0)
        {
            strCityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }
        if (ddlContactCategoryID.SelectedIndex > 0)
        {
            strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        }

        if (txtContactName.Text.Trim() != "")
        {
            strContactName = txtContactName.Text.Trim();
        }
        if (txtConatactNumber.Text.Trim() != "")
        {
            strContactNumber = txtConatactNumber.Text.Trim();
        }
        if (txtWhatsappNumber.Text.Trim() != "")
        {
            strWhatsappNumber = txtWhatsappNumber.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            strEmail = txtEmail.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            strAddress = txtAddress.Text.Trim();
        }
        if (txtAge.Text.Trim() != "")
        {
            strAge = txtAge.Text.Trim();
        }
        if (txtBirthDate.Text.Trim() != "")
        {
            strBirthDate = txtBirthDate.Text.Trim();
        }
        if (txtBloodGroup.Text.Trim() != "")
        {
            strBloodGroup = txtBloodGroup.Text.Trim();
        }

        #endregion Gether the Information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            

            objCmd.Parameters.AddWithValue("@CountryID", strCountyID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNumber", strContactNumber);
            objCmd.Parameters.AddWithValue("@WhatsappNumber", strWhatsappNumber);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);

           

            if (Request.QueryString["ContactID"] != null)
            {
                // Edit mode
                #region Update Record
                objCmd.CommandText = "PR_Contact_UpdateByPK";
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                #endregion Update Record
            }
            else
            {
                // Add mode
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_Contact_Insert]";
                objCmd.ExecuteNonQuery();

                objConn.Close();

                lblMassege.Text = "Data Inserted Successfully";
                ddlCountryID.SelectedIndex = 0;
                ddlStateID.SelectedIndex = 0;
                ddlCityID.SelectedIndex = 0;
                ddlContactCategoryID.SelectedIndex = 0;
                txtContactName.Text = "";
                txtConatactNumber.Text = "";
                txtWhatsappNumber.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtAge.Text = "";
                txtBirthDate.Text = "";
                txtBloodGroup.Text = "";
                ddlCountryID.Focus();
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

    #region FillDropDownListCountry
    private void FillDropDownListCountry()
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
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    private void FillDropDownListState()
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
        ddlStateID.Items.Insert(0, new ListItem("--------------Select State--------------", "-1"));

        objConn.Close();
    }
    #endregion FillDropDownListState

    #region FillDropDownListCity
    private void FillDropDownListCity()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[dbo].[PR_City_SelectForDropDownList]";
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlCityID.DataSource = objSDR;
            ddlCityID.DataValueField = "CityID";
            ddlCityID.DataTextField = "CityName";
            ddlCityID.DataBind();
        }
        ddlCityID.Items.Insert(0, new ListItem("--------------Select City--------------", "-1"));

        objConn.Close();
    }
    #endregion FillDropDownListCity

    #region FillDropDownListContactCategory
    private void FillDropDownListContactCategory()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownList]";
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlContactCategoryID.DataSource = objSDR;
            ddlContactCategoryID.DataValueField = "ContactCategoryID";
            ddlContactCategoryID.DataTextField = "ContactCategoryName";
            ddlContactCategoryID.DataBind();
        }
        ddlContactCategoryID.Items.Insert(0, new ListItem("--------Select Contact Category--------", "-1"));

        objConn.Close();
    }
    #endregion FillDropDownListContactCategory

    #region FillControls

    private void FillControls(SqlInt32 ContactID)
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
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByPK]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the value and set the contros
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }

                    if (!objSDR["ContactNumber"].Equals(DBNull.Value))
                    {
                        txtConatactNumber.Text = objSDR["ContactNumber"].ToString().Trim();
                    }
                    if (!objSDR["WhatsappNumber"].Equals(DBNull.Value))
                    {
                        txtWhatsappNumber.Text = objSDR["WhatsappNumber"].ToString().Trim();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMassege.Text = "No Data avaliable for the ContactID = " + ContactID.ToString();
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
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
    }
}
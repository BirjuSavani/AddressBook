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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblMassege.Text = "Edit Mode | ContactCategoryID = " + Request.QueryString["ContactCategoryID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
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
        SqlString strConatactCategory = SqlString.Null;

        #region Sarver Side Validtion
        String strErrorMessge = "";
        if (txtCategoryName.Text.Trim() == "")
        {
            strErrorMessge += "Please Enter Category Name <br>";
        }
        if (strErrorMessge != "")
        {
            lblMassege.Text = strErrorMessge;
            return;
        }
        #endregion Sarver Side Validtion

        #region Gether the information

        if (txtCategoryName.Text.Trim() != "")
        {
            strConatactCategory = txtCategoryName.Text.Trim();
        }

        #endregion Gether the information



        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strConatactCategory);

           

            strConatactCategory = txtCategoryName.Text.Trim();

            objCmd.Parameters.AddWithValue("@ContactCategoryName", strConatactCategory);

           

            if (Request.QueryString["ContactCategoryID"] != null)
            {
                // Edit mode
                #region Update Record
                objCmd.CommandText = "PR_ContactCategory_UpdateByPK";
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"].ToString().Trim());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx", true);
                #endregion Update Record
            }
            else
            {
                // Add mode
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
                objCmd.ExecuteNonQuery();
                objConn.Close();
                lblMassege.Text = "Data Inserted Successfully";
                txtCategoryName.Text = "";
                txtCategoryName.Focus();
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



    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
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
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectByPK]";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the value and set the contros
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMassege.Text = "No Data avaliable for the ContactCategoryID = " + ContactCategoryID.ToString();
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
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx", true);
    }
}
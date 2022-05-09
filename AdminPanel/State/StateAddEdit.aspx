<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 34px;
        }
        .auto-style5 {
            width: 127px;
        }
        .auto-style6 {
            width: 15px;
        }
        .auto-style7 {
            width: 139px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server"><br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3 style="color:rgb(148, 148, 148)">State Add Edit Page</h3>
            </div>
        </div><br />
        <table>
            <tr>
                <td style="color:red" class="auto-style6">*</td>
                <td class="auto-style5">Country Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="from form-control form-select " Width="300px"></asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td style="color:red" class="auto-style6">*</td>
                <td class="auto-style5">State Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtStateName" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryName"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Name" ControlToValidate="txtCountryName" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
            <tr>
                <td style="color:red" class="auto-style6">*</td>
                <td class="auto-style5">State Code</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtStateCode" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style5"></td>
                <td class="auto-style2"></td>
                <td colspan="3" class="auto-style7">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary"  ValidationGroup="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click"    />

                </td>
            </tr>
    </table>
    <div class="col-md-12" style="color:red">
        <asp:Label ID="lblMassege" runat="server" EnableViewState="false"  ></asp:Label>
    </div>

    </div>
</asp:Content>


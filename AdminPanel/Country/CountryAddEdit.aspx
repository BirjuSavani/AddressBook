<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 40px;
        }
        .auto-style3 {
            width: 124px;
        }
        .auto-style4 {
            width: 7px;
        }
        .auto-style5 {
            width: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server"><br />
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <h3 style="color:rgb(148, 148, 148)">Country Add Edit Page</h3>
        </div>
    </div><br />
    <table>
        <tr>
            <td style="color:red" class="auto-style4">*</td>
            <td class="auto-style5">Country Name</td>
            <td class="auto-style2">:</td>
            <td class="auto-style1 ">
                <asp:TextBox runat="server" ID="txtCountryName" CssClass="from form-control" Width="300px" />
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="rfvCountryName"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Name" ControlToValidate="txtCountryName" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
            <td style="color:red" class="auto-style4">*</td>
            <td class="auto-style5">Country Code</td>
            <td class="auto-style2">:</td>
            <td class="auto-style3">
                <asp:TextBox runat="server" ID="txtCountryCode" CssClass="from form-control" Width="300px" />
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
            <td class="auto-style2"></td>
            <td colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" ValidationGroup="Save" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click"    />
            </td>
        </tr>
    </table>
    <div class="col-md-12" style="color:red">
        <asp:Label ID="lblMassege" runat="server" EnableViewState="false"  ></asp:Label>
    </div>
   
</div>
</asp:Content>


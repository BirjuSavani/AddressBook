<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        .auto-style2 {
        width: 51px;
    }

        .auto-style5 {
        width: 201px;
    }

        .auto-style6 {
            width: 15px;
        }

        .auto-style7 {
        width: 209px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server"><br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3 style="color:rgb(148, 148, 148)">Contact Add Edit Page</h3>
            </div>
        </div>
        <br />
        <table>
            <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Country Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="from form-control form-select " Width="300px"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">State Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlStateID" runat="server" CssClass="from form-control form-select " Width="300px"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">City Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlCityID" runat="server" CssClass="from form-control form-select " Width="300px"></asp:DropDownList>
                </td>

            </tr>
             <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Contact Category Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlContactCategoryID" runat="server" CssClass="from form-control form-select " Width="300px"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Contact Name</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtContactName" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryName"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Name" ControlToValidate="txtCountryName" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
            <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Conatact Number</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtConatactNumber" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
            <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Whatsapp Number</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtWhatsappNumber" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
             <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Email</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
             <tr>
                <td style="color: red" class="auto-style6">*</td>
                <td class="auto-style5">Address</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
             <tr>
                <td style="color: red" class="auto-style6"></td>
                <td class="auto-style5">Age</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtAge" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
             <tr>
                <td style="color: red" class="auto-style6"></td>
                <td class="auto-style5">Birth Date</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtBirthDate" CssClass="from form-control" Width="300px" />
                </td>
                <%--<td>
                    <asp:RequiredFieldValidator ID="rfvCountryCode"  runat="server" Display="Dynamic" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode" ValidationGroup="Save" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
             <tr>
                <td style="color: red" class="auto-style6"></td>
                <td class="auto-style5">Blood Group</td>
                <td class="auto-style2">:</td>
                <td class="auto-style7">
                    <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="from form-control" Width="300px" />
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
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Save" OnClick="btnSave_Click" />
                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click"     />

                </td>
            </tr>
        </table>
        <div class="col-md-12" style="color: red">
            <asp:Label ID="lblMassege" runat="server" EnableViewState="false"></asp:Label>
        </div>

    </div>
</asp:Content>


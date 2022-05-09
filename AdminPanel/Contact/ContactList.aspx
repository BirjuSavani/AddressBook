<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2 style="color:rgb(108, 108, 108)">Contact List</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center" >
                <asp:GridView ID="gvContact" runat="server" Width="100%" Class="table table-striped table-bordered table-hover table-responsive " AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand" >
                     <Columns>
                        <asp:BoundField DataField="ContactID" HeaderText="ID" />
                        <asp:BoundField DataField="ContactName" HeaderText="Name" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Number" />
                        <asp:BoundField DataField="WhatsappNumber" HeaderText="Whatsapp Number" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" />
                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Category" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />&nbsp;&nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>&nbsp;&nbsp;
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-primary" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString() %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="color:red">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
            </div>
        </div>
    </div>
    <br />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2 style="color: rgb(108, 108, 108)">Country List</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvCounrty" runat="server" Width="100%" CssClass="table  table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvCounrty_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CountryID" HeaderText="ID" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' />&nbsp;&nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                &nbsp;&nbsp;
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-primary" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString() %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="color: red">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
            </div>
        </div>
    </div>
    </div>
    <br />
</asp:Content>


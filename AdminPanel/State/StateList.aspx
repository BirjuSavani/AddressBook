<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2 style="color:rgb(108, 108, 108)">State List</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvState" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="StateID" HeaderText="ID" />
                        <asp:BoundField DataField="StateName" HeaderText="State Name" />
                        <asp:BoundField DataField="StateCode" HeaderText="State Code" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-primary" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>'></asp:HyperLink>
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


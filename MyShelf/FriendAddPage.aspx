<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FriendAddPage.aspx.cs" Inherits="MyShelf.FriendAddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="left-justify">Add some bros bro</h2>
    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblFriendInput" runat="server" Text="Enter friend ID here:"></asp:Label>
        </div>
        <div class="col-md-12">
            <asp:TextBox ID="txtFriendInput" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-12">
            <br />
            <asp:Button ID="btnAddEntry" runat="server" Text="Add" OnClick="btnAddEntry_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-md-12">
            <br />
            <asp:GridView ID="gvFriendList" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" OnRowCommand="gvFriendList_RowCommand" OnRowDataBound="gvFriendList_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Friend" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnDeleteEntry" runat="server" CssClass="btn btn-danger" Text="X" CommandName="DeleteEntry" CausesValidation="False"
                                OnClientClick="return confirm('Unbro this bro?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

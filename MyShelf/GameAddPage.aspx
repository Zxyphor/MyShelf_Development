<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameAddPage.aspx.cs" Inherits="MyShelf.GameAddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblGameInput" runat="server" Text="Enter game name here:"></asp:Label>
        </div>
        <div class="col-md-10">
            <asp:TextBox ID="txtGameInput" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnAddEntry" runat="server" Text="Add" OnClick="btnAddEntry_Click" CssClass="btn btn-primary" />
        </div><br />
        <div class="col-md-12">
            <asp:GridView ID="gvGameList" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" OnRowCommand="gvGameList_RowCommand" OnRowDataBound="gvGameList_RowDataBound">
                <Columns>
                <asp:BoundField DataField="GameName" HeaderText="Game" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteEntry" runat="server" CssClass="btn btn-danger" Text="X" CommandName="DeleteEntry" CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

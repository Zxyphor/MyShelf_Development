<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyShelfProfile.aspx.cs" Inherits="MyShelf.MyShelfProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 bg-info text-primary">
            <h2 class="left-justify">
    <asp:Label ID="lblUsername" runat="server" Text="Oops! We lost your username. Please refresh and try again."></asp:Label></h2>
        <asp:Image ID="imgProfile" ImageUrl="~/Content/beegyoshi.png" CssClass="img-fluid" runat="server" Height="100" Width="100" />
        <br /><br /><br />
    </div>
    <div class="col-md-12">
        <br />
    </div>
    <br /><div class="row">
    <div class="col-md-5">
        <asp:GridView ID="gvFriendList" CssClass="table table-striped bg-info" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="My Friends" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-5">
        <asp:GridView ID="gvGameList" CssClass="table table-striped bg-info" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="GameName" HeaderText="My Shelf" />
            </Columns>
        </asp:GridView>
    </div></div>
</asp:Content>

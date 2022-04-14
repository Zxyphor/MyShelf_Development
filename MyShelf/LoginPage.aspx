<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MyShelf.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
             <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox> 
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblPasswordconfirm" runat="server" Text="Confirm Password"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtPasswordConfirm" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="cpvConfirmPassword" runat="server" ControlToCompare="txtPasswordConfirm" ControlToValidate="txtPassword" ErrorMessage="Passwords do not match." SetFocusOnError="True" ValidationGroup="ConfirmPassword"></asp:CompareValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btnCreateProfile" runat="server" OnClick="btnCreateProfile_Click" Text="Sign Up!" />
                    <asp:Button ID="btnDebugTable" runat="server" Text="Show/Hide" OnClick="btnDebugTable_Click" CommandName="btnDebugTable_Click" />
                </div>
            </div>
                <asp:GridView ID="gvDebugTable" runat="server" Visible="False">
                </asp:GridView>
</asp:Content>

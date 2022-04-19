<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MyShelf.LoginPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter an email"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter the password"></asp:RequiredFieldValidator>
                </div>

            </div>
</asp:Content>

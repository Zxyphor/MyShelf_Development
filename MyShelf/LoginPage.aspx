<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MyShelf.LoginPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="left-justify">Log In!</h2>
            <div class="row">
                <div class="col-md-4">
                    <br />
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
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter the password"></asp:RequiredFieldValidator>
                </div>
                
                <div class="col-md-12">
                    <br />
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" CssClass="btn btn-primary" />

                    <asp:Label ID="lblLoginFail" runat="server" Text="Login failed" Visible="false"></asp:Label>
                </div>
                
                <div class ="col-md-12">
                    <br />
                   <asp:Label ID="lblOr" runat="server" Text="Or go here to Sign up"  Visible="true"></asp:Label>
                
                </div>
                 
                <div class ="col-md-12">
                    <br />
                    <asp:Button ID="btnSignup" runat="server" Text="Signup" CausesValidation="False" CssClass="btn btn-success" OnClick="btnSignup_Click" />
                </div>
            </div>
</asp:Content>

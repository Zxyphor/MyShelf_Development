<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MyShelf.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h4 class="text-center">MyShelf is a board game repository. It is designed to allow users to add and remove board games they own or want. 
        As well, MyShelf provides its users with a platform for comparing their board games with friends. 
        So, if you&#39;re interested, give it a shot and don&#39;t forget to invite your friends!
    <asp:Button ID="btnLogIn" runat="server" CssClass="btn btn-success" Text="Log in or sign up here!" OnClick="btnLogIn_Click" /></h4>
</asp:Content>

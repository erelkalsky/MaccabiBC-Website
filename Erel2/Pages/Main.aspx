<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Erel2.Pages.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/MainPage.css" rel="stylesheet" />
    <link href="../Css/Images.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="square text">
        <h1>
            ברוכים הבאים לאתר של אראל
        </h1>
        <h2>
           באתר שלי תוכלו לקבל מידע על קבוצת הכדורסל מכבי תל אביב  
        </h2>
    </div>
    <img src="../Images/Other/AllTeam.png" class="AllPlayers ImagePlace"/>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Erel2.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Sign.css" rel="stylesheet" />
    <link href="../Css/Images.css" rel="stylesheet" />
    <script src="../JS/Login.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="sing-up-form">
        <img src="../Images/Other/MaccabiSign.png"/>
        <h1>כניסה</h1>
        <br />
            <input class="input-box" type="text" name="userName" placeholder="שם משתמש" id="userName" oninput="userNameValidate()" />
            <%--<h1 id="unameMsg" class="msgError"></h1>--%>

            <input class="input-box" type="password" name="password" placeholder="סיסמא" id="password" oninput="passwordValidate()" />
            <%--<h1 id="passMsg" class="msgError"></h1>--%>

            <button class="button" type="submit" onclick="return loginValidate()">כניסה</button>
            <button class="button" type="reset" onclick="return resetLogin()">ניקוי</button>
    </div>
    <center>
            <h2 runat="server" id="message" style="color: red; position: absolute; top: 700px; right: 795px"></h2>
    </center>

    <h1 id="unameMsg" class="msgError" style="position: absolute; top: 455px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="passMsg" class="msgError" style="position: absolute; top: 498px; right: 790px; width: 340px; text-align: center"></h1>
    <a href="passwordRecovery.aspx" style="position: absolute; top: 620px; right: 795px; text-align: center">שחזור סיסמא</a>
</asp:Content>
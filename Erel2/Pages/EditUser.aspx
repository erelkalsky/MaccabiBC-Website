<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Erel2.Pages.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JS/SignUp.js"></script>
    <link href="../Css/Sign.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="sing-up-form">
        <img src="../Images/Other/MaccabiSign.png" />
        <h1>עריכת משתמש</h1>
        <br />

        <input class="input-box" type="text" id="firstName" name="firstname" oninput="valFirstName()" placeholder="שם פרטי" runat="server"/>
        <%--<h1 id="firstNameAlert" class="msgError"></h1>--%>

        <input class="input-box" type="text" id="lastName" name="lastname" oninput="valLastName()" placeholder="שם משפחה" runat="server"/>
        <%--<h1 id="lastNameAlert" class="msgError" runat="server"></h1>--%>

        <input class="input-box" type="text" id="userName" name="username" oninput="valUserName()" placeholder="שם משתמש" runat="server"/>
        <%--<h1 id="userNameAlert" class="msgError" runat="server"></h1>--%>

        <input class="input-box" type="password" id="password" name="password" oninput="valPassword()" placeholder="סיסמא" runat="server"/>
        <%--<h1 id="passAlert" class="msgError"></h1>--%>

        <input class="input-box" type="password" id="cpassword" name="cpassword" oninput="valCPassword()" placeholder="אישור סיסמא" />
        <%--<h1 id="cpassAlert" class="msgError"></h1>--%>

        <input class="input-box" type="email" id="email" name="email" oninput="valEmail()" placeholder="אימייל" runat="server"/>
        <%--<h1 id="emailAlert" class="msgError"></h1>--%>

        <select class="select-box-small" id="phoneAreaCode" name="phoneAreaCode" onchange="valPhone()" runat="server">
            <option disabled="disabled">קידומת</option>
            <option>02</option>
            <option>03</option>
            <option>04</option>
            <option>050</option>
            <option>052</option>
            <option>053</option>
            <option>054</option>
            <option>055</option>
            <option>058</option>
        </select>
        <input class="phone-box" type="text" id="phone" name="phone" oninput="valPhone()" placeholder="טלפון" runat="server"/>
        <%--<h1 id="phoneAlert" class="msgError"></h1>--%>

        <select class="select-box-big" id="gender" name="gender" runat="server">
            <option disabled="disabled">מגדר</option>
            <option value="Male">זכר</option>
            <option value="Female">נקבה</option>
        </select>
        <%--<h1 id="genderAlert" class="msgError"></h1>--%>

        <input class="button" type="button" value="עדכן" onclick="if (!Validate()) return;" runat="server" onserverclick="UpdateUser" />
        <button runat="server" class="button" type="reset" onclick="return resetForm()">ניקוי</button>
    </div>

    <h1 id="firstNameAlert" class="msgError" style="position: absolute; top: 455px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="lastNameAlert" class="msgError" style="position: absolute; top: 498px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="userNameAlert" class="msgError" style="position: absolute; top: 541px; right: 790px; width: 340px; text-align: center" runat="server" ></h1>
    <h1 id="passAlert" class="msgError" style="position: absolute; top: 584px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="cpassAlert" class="msgError" style="position: absolute; top: 627px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="emailAlert" class="msgError" style="position: absolute; top: 670px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="phoneAlert" class="msgError" style="position: absolute; top: 715px; right: 790px; width: 340px; text-align: center"></h1>
    <h1 id="genderAlert" class="msgError" style="position: absolute; top: 760px; right: 790px; width: 340px; text-align: center"></h1>
    <a href="UsersTable.aspx" style="position: absolute; top: 883px; right: 795px; text-align: center">חזרה לטבלה</a>
</asp:Content>
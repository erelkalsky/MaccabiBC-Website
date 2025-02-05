<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="UsersTable.aspx.cs" Inherits="Erel2.Pages.UsersTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/UsersTable.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <br />
    <br />
    <br />
    <center>
            <h1>טבלת משתמשים</h1>
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />

    <div>
        <div class="box">
            <label for="Columns">Sort by Column:</label>
            <select id="Columns" runat="server">
                <option value="userId">userId</option>
                <option value="userName">userName</option>
                <option value="lastName">lastName</option>
                <option value="firstName">firstName</option>
            </select>

            <select id="Select1" runat="server">
                <option value="ASC">ASC</option>
                <option value="DESC">DESC</option>
            </select>
            <button class="btn" name="btnSort" id="btnSort2" runat="server" onserverclick="Click_Sort">Sort</button>

            <br />
            &nbsp

            <div>
                <label for="filter">Search by first or last name:</label>
                <input type="text" name="filter" id="filter"/>
                <button class="btn" name="btnFilter" id="btnFilter" runat="server" onserverclick="Click_Filter">Filter</button>
            </div>
        </div>
        
        <div class="helpButtons">
            <button class="roundBtn" name="btnDelete" id="ButtonDelete" runat="server" onserverclick="Click_Delete">Delete</button>
            <button class="roundBtn" name="btnEdit" id="btnEdit" runat="server" onserverclick="Click_Edit">Edit</button>
            <button class="roundBtn" name="btnAdd" id="btnAdd" runat="server" onserverclick="Click_Add">Add</button>
            <button class="roundBtn" name="btnAdmin" id="btnAdmin" runat="server" onserverclick="ChangeToAdmin">Change to Admin</button>
            <button class="roundBtn" name="btnUser" id="btnUser" runat="server" onserverclick="ChangeToUser">Change to User</button>
        </div>
    </div>

    <div runat="server" id="tableDiv"></div>
    <div class="errorMsg" runat="server" id="message"></div>
</asp:Content>

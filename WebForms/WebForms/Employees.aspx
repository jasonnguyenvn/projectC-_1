<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="WebForms.Employees" %>


<!DOCTYPE html>

<html  >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="filter">
            <div class="a_row">
                <div class="row_left">
                    Name:
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    Title:
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    City:
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    Region
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    Postal Code
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    Country:
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    Phone:
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    Manager ID:
                </div>
                <div class="row_right">
                    <asp:TextBox ID="txtManagerID" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="a_row">
                <div class="row_left">
                    _
                </div>
                <div class="row_right">
                   unat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="dataTable">
            <asp:GridView ID="gvEmployees" runat="server" 
                onpageindexchanging="gvEmployees_PageIndexChanging">
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>

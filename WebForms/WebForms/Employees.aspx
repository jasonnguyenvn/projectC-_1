<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="WebForms.Employees" %>


<!DOCTYPE html>

<html  >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style>
        #content 
        {
        	width: 100%;
        }
        #left_side, #dataTable 
        {
        	display: block;
        	float: left;
        }
        #left_side 
        {
        	width: 40%;
        }
        
        #dataTable 
        {
        	width: 60%;
        	overflow: scroll;
        }
        div.a_row 
        {
        	width: 100%;
        }
        div.row_left, div.row_right 
        {
        	display: block;
        	float: left;
        }
        div.row_left 
        {
        	width: 30%;
        }
        div.row_right 
        {
        	width: 70%;
        }
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div id="content">
        <div id="left_side">
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
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
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
                            <asp:Button ID="btnClear" runat="server" Text="Clear Filter" 
                                onclick="btnClear_Click" />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                onclick="btnSearch_Click" />
                        </div>
                    </div>
            </div>
            <div id="edit_form">
                Selected ID:  
                <asp:TextBox ID="txtID" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <asp:Button ID="bntDelete" runat="server" Text="Delete" Enabled="False" 
                    onclick="bntDelete_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Enabled="False" 
                    onclick="btnUpdate_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add new..." 
                    onclick="btnAdd_Click" />
            </div>
        </div>
        <div id="dataTable">
            <asp:GridView ID="gvEmployees" runat="server" 
                onpageindexchanging="gvEmployees_PageIndexChanging" CellPadding="4" 
                ForeColor="#333333" GridLines="None" 
                onselectedindexchanged="gvEmployees_SelectedIndexChanged">
                <RowStyle BackColor="#EFF3FB" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Left" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>

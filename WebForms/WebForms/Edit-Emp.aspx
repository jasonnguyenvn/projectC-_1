<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit-Emp.aspx.cs" Inherits="WebForms.Edit_Emp" %>

<!DOCTYPE html>

<html  >
<head runat="server">
    <title>Untitled Page</title>
     <style>
        .inputText
        {
        	width: 400px;
        }
        #content 
        {
        	width: 100%;
        }
        div.a_row 
        {
        	width: 100%;
        	height: 20px;
        	margin-bottom: 10px;
        }
        div.row_left, div.row_right 
        {
        	display: block;
        	float: left;
        }
        div.row_left 
        {
        	width: 10%;
        }
        div.row_right 
        {
        	width: 90%;
        }
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
        <div class="a_row">
            <div class="row_left">
                ID:</div>
            <div class="row_right">
                <asp:TextBox ID="txtEmpID" runat="server" CssClass="inputText" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Last Name:</div>
            <div class="row_right">
                <asp:TextBox ID="txtLastname" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                First Name:</div>
            <div class="row_right">
                <asp:TextBox ID="txtFirstname" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Title:</div>
            <div class="row_right">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Title of Courtesy:</div>
            <div class="row_right">
                <asp:TextBox ID="txtTitleOfCoursy" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Birthday:</div>
            <div class="row_right">
                <asp:TextBox ID="txtBirthday" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Hireday:</div>
            <div class="row_right">
                <asp:TextBox ID="txtHireday" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Address:</div>
            <div class="row_right">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                City:</div>
            <div class="row_right">
                <asp:TextBox ID="txtCity" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Region:</div>
            <div class="row_right">
                <asp:TextBox ID="txtRegion" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Postal Code:</div>
            <div class="row_right">
                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Country:</div>
            <div class="row_right">
                <asp:TextBox ID="txtCountry" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Phone:
            </div>
            <div class="row_right">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
                Manager ID:</div>
            <div class="row_right">
                <asp:TextBox ID="txtManagerID" runat="server" CssClass="inputText"></asp:TextBox>
            </div>
        </div>
        <div class="a_row">
            <div class="row_left">
             </div>
            <div class="row_right">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="122px" 
                    onclick="btnSave_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>

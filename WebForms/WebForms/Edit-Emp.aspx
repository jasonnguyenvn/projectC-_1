<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit-Emp.aspx.cs" Inherits="WebForms.Edit_Emp" %>
<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
    <title>Add/Edit an Employee</title>
    
      <link rel="stylesheet" href="plugins/datepicker/datepicker3.css">
</asp:Content>


<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <style>
        .inputText
        {
        	min-width: 230px;
        	width: 70%;
        }
        .inputTextDate
        {
        	min-width: 230px;
        	width: 70%;
        }
        #content 
        {
        	width: 100%;
        }
        div.a_row 
        {
        	width:90%;
        	min-height: 40px;
        	margin-bottom: 5x;
        	
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
        	min-width: 70%;
        	text-align: right;
        }
        
      
    </style>
    
    
     <div class="box box-primary"  >
        <div class="box-header with-border">
          <h3 class="box-title">Add/Edit an Employee</h3>
          
        </div><!-- /.box-header -->
        <div class="box-body no-padding" style="min-height:700px;width:100%;">
            <div class="modal-body">
                <div class="a_row">
                    <div class="row_left">
                        ID:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtEmpID" runat="server"  CssClass="form-control input-sm" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Last Name:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtLastname" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        First Name:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtFirstname" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtFirstname" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Title:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtTitle" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtTitle" ErrorMessage="Required Field" 
                            Display="Dynamic">Required Field</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Title of Courtesy:</div>
                    <div class="row_right">
                        <asp:DropDownList ID="txtTitleOfCoursy" CssClass="form-control input-sm" runat="server"  >
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Ms.</asp:ListItem>
                            <asp:ListItem>Mrs.</asp:ListItem>
                            <asp:ListItem>Mr.</asp:ListItem>
                            <asp:ListItem>Dr.</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            BorderStyle="None" ControlToValidate="txtTitleOfCoursy" 
                            ErrorMessage="Required Field" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Birthday:</div>
                    <div class="row_right">
                        <div class="input-group date">
                            <asp:TextBox ID="txtBirthday" CssClass="form-control input-sm" runat="server"  data-provide="datepicker"></asp:TextBox>
                            <div class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></div>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtBirthday" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Hireday:</div>
                    <div class="row_right">
                        <div class="input-group date">
                            <asp:TextBox ID="txtHireday" CssClass="form-control input-sm" runat="server" data-provide="datepicker"></asp:TextBox>
                            <div class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></div>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtHireday" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Address:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtAddress" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtAddress" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        City:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtCity" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtCity" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Region:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtRegion" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Postal Code:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtPostalCode" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Country:</div>
                    <div class="row_right">
                        <asp:TextBox ID="txtCountry"  CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtCountry" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Phone:
                    </div>
                    <div class="row_right">
                        <asp:TextBox ID="txtPhone" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtPhone" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        Manager ID:</div>
                    <div class="row_right">
                        <asp:DropDownList ID="cbManagerID" runat="server" CssClass="form-control input-sm" >
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="a_row">
                    <div class="row_left">
                        _</div>
                    <div style="text-align:right;" class="row_right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="122px" 
                            onclick="btnSave_Click" CssClass="btn btn-default btn-sm" />
                    </div>
                </div>
          </div>
        </div><!-- /.box-body -->
        <div class="box-footer no-padding">
            
        </div>
      </div><!-- /. box -->
            
            
 
   
    <asp:Label ID="script" runat="server"></asp:Label>
    
    
</asp:Content>

<asp:Content ID="endScript" ContentPlaceHolderID="endScript" Runat="Server">
    <script src="plugins/datepicker/bootstrap-datepicker.js"></script>
    <script>
    $(function() {
        $( "#txtBirthday" ).datepicker( );
         $( "#txtHireday" ).datepicker( );
            /* $( "#txtHireday" ).datepicker( {
          showOn: "button",
          buttonImage: "css/images/calendar.gif",
          buttonImageOnly: true,
          buttonText: "Select date"
        });*/
    });
    
    </script>
</asp:Content>


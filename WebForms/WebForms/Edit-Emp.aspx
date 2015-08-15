<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit-Emp.aspx.cs" Inherits="WebForms.Edit_Emp" %>
<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
    <title>Add/Edit an Employee</title>
    
      <link rel="stylesheet" href="plugins/datepicker/datepicker3.css">
</asp:Content>

<asp:Content ID="content_header" ContentPlaceHolderID="content_header" runat=server>
    <section class="content-header">
      <h1>
        Human Resources
        <small>Add/Edit an Employee</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">HR</li>
      </ol>
    </section>
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
        div.row 
        {
        	width:90%;
        	min-height: 40px;
        	margin-bottom: 5x;
        	
        }
      
    </style>
    
    
     <div class="box box-primary"  >
        <div class="box-header with-border">
        <i class="fa fa-edit"></i>
          <h3 class="box-title">Add/Edit an Employee</h3>
          
        </div><!-- /.box-header -->
        <div class="box-body no-padding" style="min-height:700px;width:100%;padding-top:15px;pading-left:15px;">
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-4">
                        ID:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtEmpID" runat="server"  CssClass="form-control input-sm" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Last Name:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtLastname" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        First Name:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtFirstname" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtFirstname" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Title:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTitle" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtTitle" ErrorMessage="Required Field" 
                            Display="Dynamic">Required Field</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Title of Courtesy:</div>
                    <div class="col-md-8">
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
                <div class="row">
                    <div class="col-md-4">
                        Birthday:</div>
                    <div class="col-md-8">
                        <div class="input-group date">
                            <asp:TextBox  ID="txtBirthday" CssClass="form-control" runat="server"  data-provide="datepicker"></asp:TextBox>
                            <div class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></div>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtBirthday" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Hireday:</div>
                    <div class="col-md-8">
                        <div class="input-group date">
                            <asp:TextBox ID="txtHireday" CssClass="form-control input-sm" runat="server" data-provide="datepicker"></asp:TextBox>
                            <div class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></div>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtHireday" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Address:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAddress" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtAddress" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        City:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCity" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtCity" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Region:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtRegion" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Postal Code:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPostalCode" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Country:</div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCountry"  CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtCountry" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Phone:
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPhone" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtPhone" ErrorMessage="Required Field" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Manager ID:</div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="cbManagerID" runat="server" CssClass="form-control input-sm" >
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        _</div>
                    <div style="text-align:right;" class="col-md-8">
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


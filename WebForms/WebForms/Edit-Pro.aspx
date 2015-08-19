<%@ Page Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Edit-Pro.aspx.cs" Inherits="WebForms.Edit_Pro" %>
<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
    <title>Add/Edit an Product</title>
    
      <link rel="stylesheet" href="plugins/datepicker/datepicker3.css">
</asp:Content>

<asp:Content ID="content_header" ContentPlaceHolderID="content_header" runat=server>
    <section class="content-header">
      <h1>
        Production - Products Manager
        <small>Add/Edit an Product</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Production</li>
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
          <h3 class="box-title">Add/Edit an Product</h3>
          
        </div><!-- /.box-header -->
        <div class="box-body no-padding" style="min-height:700px;width:100%;padding-top:15px;pading-left:15px;">
            <div class="modal-body">
                <div class="col-md-5">
                        <div class="row">
                            <div class="col-md-4">
                                Product Name:
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">
                                Supplier ID:
                            </div>
                            <div class="col-md-8">
                                 <asp:DropDownList ID="cbSupplierID" runat="server" 
                                     CssClass="form-control input-sm">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                     ControlToValidate="cbSupplierID" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        
                        <div class="row">
                            <div class="col-md-4">
                                Category ID:
                            </div>
                            <div class="col-md-8">
                                 <asp:DropDownList ID="cbCatID" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                     ControlToValidate="cbCatID" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                       
                        
                        
                        <div class="row">
                            <div class="col-md-4">
                               Unit Price
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtUnitPrice" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">
                               _
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="checkDiscontinue" runat="server" />
                                Discontinue
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
   
</asp:Content>


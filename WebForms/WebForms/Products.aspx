<%@ Page Language="C#"  MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebForms.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Products Manager</title>
</asp:Content>

<asp:Content ID="content_header" ContentPlaceHolderID="content_header" runat=server>
    <section class="content-header">
      <h1>
        Production
        <small>Products Manager</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Production</li>
      </ol>
    </section>
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
     <style>
         .page_row > td > table > tbody > tr > td
         {
         	min-width: 20px;
         	margin-right: 20px;
         }
        #content 
        {
        	min-height: 600px;
        	padding-top: 25px;
        	padding-left: 15px;
        	padding-right: 10px;
        	padding-bottom: 10px;
        }
        
        #dataTable 
        {
        	display: block;
        	overflow: scroll;
        	max-height: 300px;
        	width: 100%;
        }
        div.a_row 
        {
        	width: 100%;
        	min-height: 40px;
        	margin-bottom: 3px;
        }
        div.row_left, div.row_right 
        {
        	display: block;
        	float: left;
        }
        div.row_left 
        {
        	width: 20%;
        }
        div.row_right 
        {
        	width: 70%;
        	text-align: right;
        }
        #filter
        {
        	position: relative;
        	margin-bottom: 10px;
        	
        }
        #edit_form
        {
        	display: block;
        	margin-top: 10px;
        	width: 100%;
        }
        
        
    </style>
     <asp:Label ID="scriptLb" runat="server"></asp:Label>
     
      <div class="box box-primary" style="height:auto;">
        <div class="box-header with-border">
          <h3 class="box-title">Products Manager</h3>
          <div class="box-tools pull-right">
                    <div class="has-feedback">
                     
                    </div>
                  </div><!-- /.box-tools -->
            </div><!-- /.box-header -->
            
        
        <div class="box-body no-padding" style="height:auto;">
           
            <div id="content" class="row">
             
                <div class="col-md-5">
                    <div id="filter">
                        <div class="a_row">
                            <div class="row_left">
                                Product Name:
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="a_row">
                            <div class="row_left">
                               Supplier ID:
                            </div>
                            <div class="row_right">
                                 <asp:DropDownList ID="cbSupplierID" runat="server" 
                                     CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                        
                        
                        <div class="a_row">
                            <div class="row_left">
                                Category ID:
                            </div>
                            <div class="row_right">
                                 <asp:DropDownList ID="cbCatID" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                       
                        
                        
                        <div class="a_row">
                            <div class="row_left">
                               Unit Price
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="a_row">
                            <div class="row_left">
                               _
                            </div>
                            <div class="row_right">
                                <asp:CheckBox ID="checkDiscontinue" runat="server" />
                                Discontinue
                            </div>
                        </div>
                        
                        
                        <div class="a_row">
                            <div class="row_left">
                                _
                            </div>
                            <div class="row_right">
                                <asp:Button ID="btnClear" runat="server" Text="Clear Filter" 
                                    onclick="btnClear_Click" CssClass="btn btn-default" />
                                <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                    onclick="btnSearch_Click" CssClass="btn btn-default"  />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7" style="height:auto;" >
                    <div class="box-tools pull-right">
                    <div class="has-feedback">
                     <asp:Button ID="bntDelete" runat="server" Text="Delete" Enabled="False" 
                                onclick="bntDelete_Click" CssClass="btn  btn-danger btn-default"  />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Enabled="False" 
                            onclick="btnUpdate_Click" CssClass="btn btn-info btn-default"  />
                        <asp:Button ID="btnAdd" runat="server" Text="Add new..." 
                            onclick="btnAdd_Click"  CssClass="btn  btn-primary btn-default"  />
                    </div>
                    </div>
                    <div id="dataTable">
                        <asp:GridView ID="gvProducts" runat="server" AutoGenerateSelectButton="True" 
                            CellPadding="0" CellSpacing="6" EnableTheming="True" ForeColor="#333333" 
                            GridLines="None" HorizontalAlign="Left" AllowPaging="True" 
                            EnableModelValidation="True" 
                            onpageindexchanging="gvProducts_PageIndexChanging" 
                            onselectedindexchanged="gvProducts_SelectedIndexChanged" 
                            CssClass="table table-bordered table-hover dataTable" >
                            <PagerSettings Position="TopAndBottom" />
                            <RowStyle ForeColor="#000066" Height="20px" 
                                HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                                Wrap="False" CssClass="page_row" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                                Height="25px" HorizontalAlign="Center" Width="80px" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        </asp:GridView>
                        
                        
                    </div>
                    <div id="edit_form">
                            <div class="a_row">
                                <div class="row_left">
                                    Selected ID:  
                                </div>
                                <div class="row_right" >
                                   <asp:TextBox ID="txtID" runat="server" Enabled="False" 
                                        Width="132px" ></asp:TextBox>
                                </div>
                            </div>
                            
                            
                        </div>
                    
                </div>
            </div>
        </div><!-- /.box-body -->
        <div class="box-footer no-padding">
            
        </div>
      </div><!-- /. box -->
            
            
    
</asp:Content>




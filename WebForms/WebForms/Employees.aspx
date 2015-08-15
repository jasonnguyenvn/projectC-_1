<%@ Page Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="WebForms.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Employee Manager</title>
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
     <style>
        #content 
        {
        	width: 95%;
        	min-height: 600px;
        	padding-top: 25px;
        	padding-left: 15px;
        	padding-right: 5px;
        	padding-bottom: 10px;
        }
        #left_side, #right_side
        {
        	display: block;
        	float: left;
        	min-height: 200px;
        }
        #left_side 
        {
        	width: 40%;
        	
        }
        #right_side
        {
        	width: 60%;
        }
        
        #dataTable 
        {
        	display: block;
        	overflow: scroll;
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
        }
        
        
    </style>
     <asp:Label ID="scriptLb" runat="server"></asp:Label>
     
      <div class="box box-primary" style="max-height:500px;">
        <div class="box-header with-border">
          <h3 class="box-title">Employee Manager</h3>
          
        </div><!-- /.box-header -->
        <div class="box-body no-padding">
           
            <div id="content">
                <div id="left_side">
                    <div id="filter">
                        <div class="a_row">
                            <div class="row_left">
                                Name:
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                Title:
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                City:
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                Region
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtRegion" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                Postal Code
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                Country:
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>       
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                Phone:
                            </div>
                            <div class="row_right">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="a_row">
                            <div class="row_left">
                                Manager ID:
                            </div>
                            <div class="row_right">
                                <asp:DropDownList ID="cbManagerID" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
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
                <div id="right_side">
                    <div id="dataTable">
                        <asp:GridView ID="gvEmployees" runat="server" 
                            onpageindexchanging="gvEmployees_PageIndexChanging" CellPadding="4" 
                            onselectedindexchanged="gvEmployees_SelectedIndexChanged" 
                            AutoGenerateSelectButton="True" CellSpacing="3" ForeColor="#333333" 
                            GridLines="None" HorizontalAlign="Center" CaptionAlign="Top" 
                            EmptyDataText="###NULL###">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" 
                                Height="25px" VerticalAlign="Middle" Wrap="False" />
                            <EmptyDataRowStyle HorizontalAlign="Center" Wrap="False" />
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" 
                                HorizontalAlign="Left" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" 
                                HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" 
                                HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
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
                            <div class="a_row">
                                <div class="row_left">
                                    _
                                </div>
                                <div class="row_right">
                                  <asp:Button ID="bntDelete" runat="server" Text="Delete" Enabled="False" 
                                onclick="bntDelete_Click" CssClass="btn btn-default"  />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Enabled="False" 
                                    onclick="btnUpdate_Click" CssClass="btn btn-default"  />
                                <asp:Button ID="btnAdd" runat="server" Text="Add new..." 
                                    onclick="btnAdd_Click"  CssClass="btn btn-default"  />
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




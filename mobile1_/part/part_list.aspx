﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="part_list.aspx.cs" Inherits="mobile1.part.part_list" %>
<%@ Register src="~/Common/leftmenu.ascx" tagname="uc_menu" tagprefix="uc1" %>
<%@ Register src="~/Common/bottom.ascx" tagname="uc_bottom" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
     <link rel='stylesheet' href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/AdminLTE.min.css" />
    <link rel="stylesheet" href="../Content/font-awesome.min.css" />
    <link rel="stylesheet" href="../Content/_all-skins.min.css" />
    <link rel="stylesheet" href="../Content/ionicons.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap.min2.css" />
    
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Content/JavaScript.js"></script>
    <script src="../Scripts/AdminLTE.css"></script>
      <link rel="stylesheet"  href="../Scripts/datepicker3.min.css" />
    <title></title>
     <script type = text/javascript>
         $(function () {
            $('#startdate').datepicker({
                calendarWeeks: false,
                todayHighlight: true,
                autoclose: true,
                format: "yyyy-mm-dd",
                language: "kr"
            });
        });
        $(function () {
            $('#enddate').datepicker({
                calendarWeeks: false,
                todayHighlight: true,
                autoclose: true,
                format: "yyyy-mm-dd",
                language: "kr"
            });
        });
    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server" style="height:100%;">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <div class="row">
                 <section class="content" style="margin-left:2%; margin-right:2%;">
                     <table>
                         <tr>
                             <td>
                                 <asp:DropDownList ID="DropDownList2" Visible="false" runat="server" Height="30"  Class="form-control" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                 <asp:ListItem Value="15">15</asp:ListItem>
                                 <asp:ListItem Value="50">50</asp:ListItem>
                                 <asp:ListItem Value="100">100</asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                         </tr>
                     </table>
                     <table style="float:right;">
                           <tr >
                              <td>
                                 
                             </td>
                             <td>
                                 기간 :  
                             </td>
                             <td>
                                 <asp:TextBox ID="startdate" runat="server" Class="form-control " Width="100px"></asp:TextBox>
                             </td>
                             <td>
                                 ~
                             </td>
                             <td>
                                 <asp:TextBox ID="enddate" runat="server" Class="form-control " Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                     </table>
                     <br /><br />
                     <table  style="float:right;" >
                         <tr style="float:right">
                             <td>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="구분 : " CssClass="" ></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server" Height="35"  Class="form-control " Width="100px">
                                  <asp:ListItem>선택</asp:ListItem>
                                  <asp:ListItem Value="4">제품</asp:ListItem>
                                  <asp:ListItem Value="5">제품번호</asp:ListItem>
                                  </asp:DropDownList>
                             </td>
                             <td>
                                 &nbsp;<asp:Label ID="Label5" runat="server" Text="검색 : " CssClass=""></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox Height="30" ID="Search" runat="server" Class="form-control " Width="100px"  AutoComplete="off" ></asp:TextBox>
                             </td>
                             <td>
                                 &nbsp;&nbsp;<asp:Button  ID="Button3" runat="server" Text="검색" CssClass="btn btn-primary btn-sm " OnClick="Button3_Click" />
                             </td>
                         </tr>
                     </table>
               <br /><br />
                         <div class="box box-info" style="margin-top:0px; float:right; ">
                              <div class="box-header">
                                    <h3 class="box-title">부서 게시판</h3>
                              </div>
                             <div class="box-body no-padding">
                             <asp:Table ID="TBLLIST"    runat="server" CssClass="table  custab table-hover "  Width="100%" ></asp:Table>
                                </div>
                             <div class="box-footer clearfix" align="center" style="margin-top:0px; height:50px;" >
                           <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                           </div>
                         </div>
                     
                     </section>
                     </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
        </div>
        
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.kr.js"></script>
       
       
</body>
</html>

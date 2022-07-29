<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="IN.aspx.cs" Inherits="mobile1.Product.IN" %>
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
             function go2(No,flag)
            {
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                    obj.value = No; 

                var obj = document.getElementById("<%=HiddenField2.ClientID %>");
                if (obj)
                    obj.value = flag; 
               <%= Page.GetPostBackEventReference(Button2) %>

         }
          function go3(No)
            {
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                    obj.value = No; 

      
               <%= Page.GetPostBackEventReference(Button4) %>

         }
         function view(No) {
                 var obj = document.getElementById("<%=HiddenField3.ClientID %>");
                if (obj)
                 obj.value = No; 
             if (document.getElementById(No).style.display === "none") {
                 document.getElementById(No).style.display = "";
                 document.getElementById(No).style.width = "100%";
             }
             else {
                 document.getElementById(No).style.display = "none";
             }
         }

          function allview() {
             var startno = document.getElementById("<%=startno.ClientID %>");
             var endno = document.getElementById("<%=endno.ClientID %>");
            
             for (var i = startno.value; i < endno.value+1; i++) {
                 if (document.getElementById(i).style.display === "none") {
                 document.getElementById(i).style.display = "";
                 document.getElementById(i).style.width = "100%";
                 }
                 else {
                     document.getElementById(i).style.display = "none";
                 }
             }
             
         }

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
                           <table   style=" float:left; right:10px;  position: absolute;">
                           <tr >
                             <td>
                                 기간 :  
                             </td>
                             <td>
                                 <asp:TextBox ID="startdate" runat="server" Class="form-control " Width="100px"  onclick="$('#startdate').blur();"></asp:TextBox>
                             </td>
                             <td>
                                 ~
                             </td>
                             <td>
                                 <asp:TextBox ID="enddate" runat="server" Class="form-control " Width="100px"  onclick="$('#enddate').blur();" ></asp:TextBox>
                             </td>
                         </tr>
                     </table>
                     <br /><br />
                     <table  style="float:right;" >
                         <tr style="float:right">
                             <td>
                                 <button type="button"  class="btn btn-default btn-sm" runat="server" onserverclick="Unnamed_ServerClick"><i class="fa fa-refresh"></i></button>&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="구분 : " CssClass="" ></asp:Label>
                                 
                             </td>
                             <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server" Height="35"  Class="form-control " Width="100px">
                                  <asp:ListItem>선택</asp:ListItem>
                                  <asp:ListItem Value="4">제품</asp:ListItem>
                                  <asp:ListItem Value="5">제품번호</asp:ListItem>
                                     <asp:ListItem Value="3">반출처</asp:ListItem>
                                  </asp:DropDownList>
                             </td>
                             <td>
                                 &nbsp;<asp:Label ID="Label5" runat="server" Text="검색 : " CssClass=""></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox Height="30" ID="Search" runat="server" Class="form-control " Width="80px"  AutoComplete="off" ></asp:TextBox>
                             </td>
                             <td>
                                 &nbsp;&nbsp;<asp:Button  ID="Button3" runat="server" Text="검색" CssClass="btn btn-primary btn-sm " OnClick="Button3_Click" />
                             </td>
                         </tr>
                     </table>
               <br /><br />
                         <div class="box box-info" style="margin-top:0px; float:right; ">
                              <div class="box-header">
                                    <h3 class="box-title">자산 재고 목록</h3>
                                  <button id="excelbutton" style="float:right; margin-left:1%;" type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Unnamed_ServerClick1"><i class="fa fa-file-excel-o"></i></button>
                                  <button id="Button1" style="float:right; margin-left:1%;" type="button" class="btn btn-default btn-sm" runat="server"  onclick="allview();"><i class="fa fa-list-alt"> 전체상세</i></button>
                                  <button id="Button6" style="float:right; margin-left:1%;" type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Button6_ServerClick">반출</button>
                                  <button id="Button5" style="float:right; margin-left:1%;" type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Button5_ServerClick">재고</button>
                              </div>
                             <div class="box-body no-padding">
                             <asp:Table ID="TBLLIST"    runat="server" CssClass="table table-bordered table-striped"  Width="100%" ></asp:Table>
                                </div>
                             <div class="box-footer clearfix" align="center" style="margin-top:0px; height:50px;" >
                           <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                           </div>
                         </div>
                     
                     </section>
                     </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
             <asp:HiddenField ID="HiddenField3" runat="server" />
             <asp:HiddenField ID="startno" runat="server" />
        <asp:HiddenField ID="endno" runat="server" />
             <asp:Button ID="Button2" runat="server" Text="Button"  Visible="false"  OnClick="Button2_Click"/>
             <asp:Button ID="Button4" runat="server" Text="Button"  Visible="false"  OnClick="Button3_Click1"/>
        </div>
        
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.kr.js"></script>
       
       
</body>
</html>

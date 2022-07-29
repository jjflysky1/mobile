<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="notice.aspx.cs" Inherits="mobile1.notice.notice" %>
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
    <%--<link rel="stylesheet" href="Content/style.css" />--%>
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Content/JavaScript.js"></script>
    <script src="../Scripts/AdminLTE.css"></script>
    
    <script src="../Scripts/highcharts.js"></script>
    <script src="../Scripts/highcharts-3d.js"></script>
    <script src="../Scripts/exporting.js"></script>
    <script src="../Scripts/export-data.js"></script>
    <script src="../Scripts/jschart.js"></script>
    <link href="../Scripts/Allcss.css" rel="stylesheet" />
    <title></title>
    <script type = text/javascript>
         function go(No,writer)
            {
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                    obj.value = No; 

                var obj = document.getElementById("<%=HiddenField2.ClientID %>");
                if (obj)
                    obj.value = writer; 
               <%= Page.GetPostBackEventReference(Button2) %>

        }
        
        function go2(NO) {
            if (confirm("삭제 하시겠습니까?") == true) {
                var obj = document.getElementById("<%=HiddenField3.ClientID %>");
                if (obj)
                    obj.value = NO;


               <%= Page.GetPostBackEventReference(Button5) %>
            }
        }
    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server" style="height:100%;">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <section class="content">
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
                     <table  style="float:right;" >
                         <tr style="float:right">
                             <td>
                                 <asp:Label ID="Label4" runat="server" Text="구분 : " CssClass="" ></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server" Height="35"  Class="form-control " Width="100px">
                                  <asp:ListItem>선택</asp:ListItem>
                                  <asp:ListItem Value="4">IP</asp:ListItem>
                                  <asp:ListItem Value="5">Category</asp:ListItem>
                                  </asp:DropDownList>
                             </td>
                             <td>
                                 <asp:Label ID="Label5" runat="server" Text="검색 : " CssClass=""></asp:Label>
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
                                    <h3 class="box-title">공지사항</h3>
                              </div>
                             <div class="box-body no-padding">
                             <asp:Table ID="TBLLIST"    runat="server" CssClass="table  custab table-hover "  Width="100%" ></asp:Table>
                                </div>
                             <div class="box-footer clearfix" align="center" style="margin-top:0px; height:50px;" >
                           <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                           </div>
                         </div>
                     
                     <asp:Button ID="Button4" runat="server" Text="Button"  OnClick="Button4_Click" Visible="false"/>
                      <div style=" width:100%; text-align:right; ">
                                  <asp:Button ID="Button1" runat="server"  CssClass="btn btn-primary btn-sm " Text="글쓰기" OnClick="Button1_Click" />
                      </div>
                   
                     </section>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:Button ID="Button2" runat="server" Text="Button"  Visible="false"  OnClick="Button2_Click"/>
    <asp:Button ID="Button5" runat="server" Text="Button" Visible="false" OnClick="Button5_Click"/>
    </form>
    
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    
</body>
</html>

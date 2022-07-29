<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail_list_get.aspx.cs" Inherits="mobile1.mail.mail_list_get" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                                    <h3 class="box-title">받은편지함</h3>
                              </div>
                             <div class="box-body no-padding">
                                         <asp:Table ID="TBLLIST"    runat="server" CssClass="table  custab table-hover "  Width="100%" ></asp:Table>
                                </div>
                             <div class="box-footer clearfix" align="center" style="margin-top:0px; height:50px;" >
                           <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                           </div>
                         </div>
    </form>
</body>
</html>

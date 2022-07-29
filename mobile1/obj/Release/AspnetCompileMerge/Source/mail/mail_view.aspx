<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail_view.aspx.cs" Inherits="mobile1.mail.mail_view" %>
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
    <link rel="stylesheet" href="../Content/bootstrap3-wysihtml5.min.css" />
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
<body class="hold-transition skin-blue sidebar-mini" style="width:auto; overflow-x: auto;">
    <form id="form1" runat="server">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <section class="content" >
                     <asp:Button ID="Button7" runat="server" class="btn btn-default" Text="이전" OnClick="Button2_Click" /><br /><br />
                     <div class="box box-info">
                         <div class="box-header with-border">
                            <h3 class="box-title">
                                <asp:Label ID="Label1" runat="server" Text="메일내용"></asp:Label></h3>
                             <asp:Button  ID="Button6" runat="server" Text="삭제" CssClass="btn btn-primary btn-xs " OnClick="Button6_Click" />
                             <asp:Button  ID="Button3" runat="server" Text="회신" CssClass="btn btn-primary btn-xs " OnClick="Button3_Click" />
                             <asp:Button  ID="Button4" runat="server" Text="전체 회신" CssClass="btn btn-primary btn-xs " OnClick="Button4_Click" />
                             <asp:Button  ID="Button5" runat="server" Text="전달" CssClass="btn btn-primary btn-xs " OnClick="Button5_Click" />
                         </div>
                         
                         <div class="box-body">
                             <div class="form-group" >
                                 <div class="mailbox-controls with-border" style="width:100%">
                                     <label><font size="3">보낸사람</font></label><br />
                                     <asp:Label ID="Label6" runat="server" Text=""  ></asp:Label><br />
                                 </div>

                                 <div class="mailbox-controls with-border" style="width:100%">
                                     <label><font size="3">참조</font></label><br />
                                     <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                 </div>
                                 <div class="mailbox-controls with-border" style="width:100%">
                                      <label><font size="3">첨부파일</font></label><br />
                                         <div runat="server" id="div1">
                                         </div>
                                 </div>
                                 <div class="mailbox-controls with-border" style="width:100%">
                                     <label><font size="3">제목</font></label><br />
                                     <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                 </div>
                              <div class="form-group" style="width:100%; overflow-y:auto">
                                  <div class="mailbox-controls " >
                                      <label><font size="3">내용</font></label>
                                      <div style="float:right;">
                                      <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                      </div>
                                      <br />
                                      <asp:Label ID="Label2" runat="server" Text="Label" Width="100%" ></asp:Label>                             
                                  </div>
                            </div>
                             <div class="box-footer">
                                 <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="이전" OnClick="Button2_Click" />
                                 <asp:Button ID="Button1" runat="server" Text="저장" Visible="false" class="btn btn-info pull-right" OnClick="Button1_Click"/>
                              </div>
                         </div>
                     </div>
                 </section>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="title" runat="server" />
             <asp:HiddenField ID="body" runat="server" />
        </div>
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
        <script src="../Scripts/bootstrap3-wysihtml5.all.min.js"></script>
</body>
</html>


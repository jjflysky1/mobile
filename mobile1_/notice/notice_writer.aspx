<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notice_writer.aspx.cs" Inherits="mobile1.notice.notice_writer" %>
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
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <section class="content">
                     <div class="box box-info">
                         <div class="box-header with-border">
                            <h3 class="box-title">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>
                         </div>
                         <div class="box-body">
                             <div class="form-group">
                              <label>제목</label>
                                 <div id="title1" runat="server">
                                     <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Enter ..."></asp:TextBox>
                                 </div>
                                 <div id="title2" runat="server">
                                     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                 </div>
                              
                                 
                             </div>
                              <div class="form-group">
                              
                                  <label>내용</label>
                                  <div id="bodytext" runat="server">
                                      <asp:TextBox ID="TextBox1" class="form-control" runat="server" TextMode="MultiLine" rows="3" placeholder="Enter ..."></asp:TextBox>
                                 </div>
                                  <div id="bodytext1" runat="server">
                                      <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                 </div>
                              
                                  
                            </div>
                             <div class="box-footer">
                                 <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="취소" OnClick="Button2_Click" />
                                 <asp:Button ID="Button1" runat="server" Text="저장" class="btn btn-info pull-right" OnClick="Button1_Click"/>
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
       
</body>
</html>

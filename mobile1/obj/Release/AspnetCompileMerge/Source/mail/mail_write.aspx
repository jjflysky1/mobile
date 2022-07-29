<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail_write.aspx.cs" Inherits="mobile1.mail.mail_write"  ValidateRequest="false" %>
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
  <script type="text/javascript">
          function JavaScriptFunction()
         {
          
              document.getElementById('<%= HiddenField2.ClientID %>').value = document.getElementById("areabody").innerHTML;
         }
    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <section class="content">
                    <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">새 메시지</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <div class="form-group">
                <b>받는사람</b> 
               <asp:TextBox class="form-control" id="to" runat="server" placeholder="받는사람:example@a.co.kr, example@b.com"></asp:TextBox>
                  <p></p>
                  <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" AutoPostBack="true">
                      <asp:ListItem>선택</asp:ListItem>
                  </asp:DropDownList>
              </div>
                <div class="form-group">
                 <b>참조</b>
                <asp:TextBox class="form-control" id="cc" runat="server" placeholder="참조:"></asp:TextBox>
              </div>
              <div class="form-group">
                <b>제목</b>
                <asp:TextBox class="form-control"  id="subject" runat="server" placeholder="제목:"></asp:TextBox>
              </div>
                <b>내용</b>
              <div class="form-control" id="areabody" contenteditable="true" runat="server"  style="overflow-y:auto; height:auto;">
               
                  
                    
              </div>
                <asp:TextBox  class="form-control"  id="area" runat="server"  TextMode="MultiLine" Rows="4" Visible="false"  placeholder="본문" ></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
              <div class="form-group" id="attach" runat="server">
              <%--    <br />
                <div class="btn btn-default btn-file">
                  <i class="fa fa-paperclip"></i> Attachment
                  <input type="file" name="attachment" runat="server" id="file"  >
                </div>--%><br />
                  <%--첨부파일 :--%> <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                  <div id="FileUpload1_div" runat="server">
                      <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" /> (최대 20Mb)
                  </div>
                  
              </div>
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
              <div class="pull-right">
                  <asp:LinkButton ID="SubmitBtn" runat="server" OnClientClick="JavaScriptFunction();" OnClick="Button3_Click" CssClass="btn btn-small btn-primary">
                      <i class="fa fa-envelope-o"></i>&nbsp;보내기</asp:LinkButton>
              </div>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-small btn-default">
                      <i class="fa fa-times"></i>&nbsp;이전</asp:LinkButton>
                
            </div>
            <!-- /.box-footer -->
          </div>              
                     
                 </section>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="title" runat="server" />
             <asp:HiddenField ID="body" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
             <asp:HiddenField ID="yy" runat="server" />
             <asp:HiddenField ID="mm" runat="server" />
             <asp:TextBox ID="TextBox1" runat="server" Width="10px"  Visible="false" ></asp:TextBox>
             
        </div>
        <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    <script src="../Scripts/bootstrap3-wysihtml5.all.min.js"></script>
    
    <script>
    
  </script>
    
</body>
</html>

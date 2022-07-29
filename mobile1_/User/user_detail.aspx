<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="user_detail.aspx.cs" Inherits="mobile1.User.user_detail" %>
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
    
    
    <title></title>
      <script type = text/javascript>
         function go(No)
            {
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                 obj.value = No; 

               <%= Page.GetPostBackEventReference(Button2) %>
          }
    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             
             <div class="content-wrapper">
                 <div class="row">
                 <section class="content" style="margin-left:2%; margin-right:2%; ">
                     <div class="box box-info " >
                         <div class="box-header with-border">
                            
                                <asp:Label ID="Label1" runat="server" Text="정보"></asp:Label>
                         </div>
                         <div class="box-body" runat="server" id="info">
                <font size="2">
                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputName" class="col-sm-2 control-label">회사</label>

                    <div style="margin-left:4%;">
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputEmail" class="col-sm-2 control-label">부서</label>

                    <div style="margin-left:4%;">
                      <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputName" class="col-sm-2 control-label">이름</label>

                    <div style="margin-left:4%;">
                      <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputExperience" class="col-sm-2 control-label">직위</label>
                    <div style="margin-left:4%;">
                      <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                    </div>
                  </div>
                             
                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputSkills" class="col-sm-2 control-label">전자우편</label>
                    <div style="margin-left:4%;">
                     <font color="blue"><u><asp:Label ID="Label8" runat="server" Text=""></asp:Label></u></font>
                    </div>
                  </div>
                             
                   <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputSkills" class="col-sm-2 control-label">사내번호</label>
                    <div style="margin-left:4%;" >
                      <asp:Label ID="Label9" runat="server" Text="" ></asp:Label>
                    </div>
                  </div>
                             
                  <div  class="mailbox-controls with-border" style="width:100%" >
                    <label for="inputSkills" class="col-sm-2 control-label">이동전화</label>
                    <div style="margin-left:4%;">
                      <asp:Label ID="Label10" runat="server" Text="" ></asp:Label>
                    </div>
                  </div>
        </font>
                             
                         </div>
                            <div class="box-footer">
                         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-small btn-default">
                      <i class="fa fa-times"></i>&nbsp;이전</asp:LinkButton>
                                </div>
                     </div>
                     
                 </section>
                 </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:Button ID="Button2" runat="server" Text="Button" Visible="false" OnClick="Button1_Click" />
             <asp:HiddenField ID="title" runat="server" />
             <asp:HiddenField ID="body" runat="server" />
        </div>
        
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
       
</body>
</html>
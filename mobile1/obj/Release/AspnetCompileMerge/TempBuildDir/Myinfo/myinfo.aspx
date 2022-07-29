<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myinfo.aspx.cs" Inherits="mobile1.Myinfo.myinfo" %>
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
                                <asp:Label ID="Label1" runat="server" Text="나의 정보관리"></asp:Label>
                         </div>
                         <div class="box-body" runat="server" id="info">
                <font size="2">
                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputName" class="col-sm-2 control-label">아이디</label>

                    <div style="margin-left:4%;">
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>
                    <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputName" class="col-sm-2 control-label">패스워드</label>

                    <div style="margin-left:4%;">
                        <asp:TextBox  TextMode="Password" ID="TextBox7" runat="server" class="form-control"  placeholder="Enter ..." ></asp:TextBox>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputEmail" class="col-sm-2 control-label">이름</label>

                    <div style="margin-left:4%;">
                      <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputName" class="col-sm-2 control-label">이메일</label>

                    <div style="margin-left:4%;">
                      <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputExperience" class="col-sm-2 control-label">직위</label>
                    <div style="margin-left:4%;">
                      <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="form-control"></asp:DropDownList>
                    </div>
                  </div>
                             
                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputSkills" class="col-sm-2 control-label">부서</label>
                    <div style="margin-left:4%;">
                    <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="form-control"></asp:DropDownList>
                    </div>
                  </div>
                
                    
                   <div  class="mailbox-controls " style="width:100%">
                    <label for="inputSkills" class="col-sm-2 control-label">전화번호</label>
                    <div style="margin-left:4%;" >
                      <asp:TextBox ID="TextBox6" runat="server" class="form-control" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>
             
        </font>
                             
                         </div>
                            <div class="box-footer">
                         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-small btn-default" Visible="false">
                      <i class="fa fa-times"></i>&nbsp;이전</asp:LinkButton>
                                <asp:Button ID="Button1" runat="server" Text="저장" class="btn btn-primary pull-right" OnClick="Button1_Click1" OnClientClick="click();"/>
                                </div>
                     </div>
                    
                 </section>
                 </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:Button ID="Button2" runat="server" Text="Button" Visible="false" OnClick="Button1_Click" />
             <asp:HiddenField ID="pwd" runat="server" />
             <asp:HiddenField ID="name" runat="server" />
             <asp:HiddenField ID="email" runat="server" />
             <asp:HiddenField ID="phone" runat="server" />
             <asp:HiddenField ID="dept_code" runat="server" />
             <asp:HiddenField ID="duty_code" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
             
        </div>
        
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
       
</body>
</html>
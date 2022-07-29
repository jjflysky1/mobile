<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="mobile1.User.user_list" %>
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
      <style>
        .form-control10
        {
         width:100%;
         height:34px;
         padding:6px 12px;
         font-size:14px;
         line-height:1.42857143;
         color:#555;
         background-color:#fff;
         background-image:none;
         border:1px solid #ccc;
         border-radius:4px;
         -webkit-box-shadow:inset 0 1px 1px rgba(0,0,0,.075);
         box-shadow:inset 0 1px 1px rgba(0,0,0,.075);
         -webkit-transition:border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
         -o-transition:border-color ease-in-out .15s,box-shadow ease-in-out .15s;
         transition:border-color ease-in-out .15s,box-shadow ease-in-out .15s
        }
    </style>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             
             <div class="content-wrapper">
                 <div class="row">
                 <section class="content" style="margin-left:2%; margin-right:2%; ">
                     
                     <div class="box box-info col-xs-5" style="margin-right:10px;" >
                         <div class="box-header with-border">
                            
                                <asp:Label ID="Label3" runat="server" Text="부서 리스트"></asp:Label>
                         </div>
                         <asp:TreeView ID="TreeView1" runat="server">
                                 <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                    NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                    VerticalPadding="0px" />
                             </asp:TreeView>
                             <div style="height:10px">

                             </div>
                     </div>
                     <div class="box box-info col-xs-6" style="margin-right:10px;" >
                         <div class="box-header with-border">
                            
                                <asp:Label ID="Label2" runat="server" Text="사원 리스트"></asp:Label>
                              
                             <div class=" " style="width:100%;">
                                 <input type="text" id="Search" style="width:80px;" class="form-control10 input-sm" runat="server" placeholder="사원 이름">
                                 <asp:Button  ID="Button3" runat="server" Text="검색" CssClass="btn btn-primary btn-xs " OnClick="Button3_Click" />
                                </div>
                              <div class=" " style="float:left; margin-top:4px; margin-left:4px;">
                                   
                               </div>
                         </div>
                                  <asp:TreeView ID="TreeView2" runat="server">
                                 <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                    NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                    VerticalPadding="0px" />
                             </asp:TreeView>
                         <div style="height:10px">

                             </div>
                     </div>
                     
                     
                 </section>
                 </div>
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

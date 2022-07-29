<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="mobile1.main" %>
<%@ Register src="~/Common/leftmenu.ascx" tagname="uc_menu" tagprefix="uc1" %>
<%@ Register src="~/Common/bottom.ascx" tagname="uc_bottom" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
     <link rel='stylesheet' href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/AdminLTE.min.css" />
    <link rel="stylesheet" href="Content/font-awesome.min.css" />
    
    <link rel="stylesheet" href="Content/_all-skins.min.css" />
    <link rel="stylesheet" href="Content/ionicons.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min2.css" />
    <%--<link rel="stylesheet" href="Content/style.css" />--%>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Content/JavaScript.js"></script>
    <script src="Scripts/AdminLTE.css"></script>
    
    <script src="Scripts/highcharts.js"></script>
    <script src="Scripts/highcharts-3d.js"></script>
    <script src="Scripts/exporting.js"></script>
    <script src="Scripts/export-data.js"></script>
    <script src="Scripts/jschart.js"></script>
    <link href="Scripts/Allcss.css" rel="stylesheet" />
    <title></title>

   <script>
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
   </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <section class="content">
                     
                         <div class="box box-info">
                             <div style="margin-left:2%">
                              <h4>
                                <i class="fa fa-comments-o"></i> 공지사항
                              </h4>
                              </div>
                             <asp:Table ID="TBLLIST" BackColor="Transparent"   runat="server" CssClass="table no-border"  Width="100%" ></asp:Table>
                         </div>
        <style>
            td { white-space:pre }
        </style>
                     
         <div class="col-lg-1 col-xs-4">
          <!-- small box -->
          <div class="box box-info" style="text-align:center;">
              <a href="mail/mail_list.aspx" class="small-box-footer" style="color:black;">
            <div class="inner">
              <i class="fa fa-envelope" ></i>   
              <p>메일</p>
            </div>
            보기 <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>

        <div class="col-lg-1 col-xs-4">
          <!-- small box -->
          <div class="box box-info" style="text-align:center;">
              <a href="user/user_list.aspx" class="small-box-footer" style="color:black;">
            <div class="inner">
              <i class="fa fa-users" ></i>   
              <p>조직도</p>
            </div>
            보기 <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>

        <div class="col-lg-1 col-xs-4">
          <!-- small box -->
          <div class="box box-info" style="text-align:center;">
              <a href="work/work.aspx" class="small-box-footer" style="color:black;">
            <div class="inner">
              <i class="fa fa-smile-o" ></i>   
              <p>고객사 이력</p>
            </div>
            보기 <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>


        <div class="col-lg-1 col-xs-4">
          <!-- small box -->
          <div class="box box-info" style="text-align:center;">
              <a href="Product/sell.aspx" class="small-box-footer" style="color:black;">
            <div class="inner">
              <i class="fa fa-cart-arrow-down" ></i>   
              <p>판매 목록</p>
            </div>
            보기 <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>

         <div class="col-lg-1 col-xs-4">
          <!-- small box -->
          <div class="box box-info" style="text-align:center;">
              <a href="Product/in.aspx" class="small-box-footer" style="color:black;">
            <div class="inner">
              <i class="fa fa-cart-arrow-down" ></i>   
              <p>자산 목록</p>
            </div>
            보기 <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
                         
        <div class="col-lg-1 col-xs-4">
          <!-- small box -->
          <div class="box box-info" style="text-align:center;">
              <a href="Product/demo.aspx" class="small-box-footer" style="color:black;">
            <div class="inner">
              <i class="fa fa-cart-arrow-down" ></i>   
              <p>데모 목록</p>
            </div>
            보기 <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>


                      <div class="box box-info" style="visibility:hidden">
                             <div style="margin-left:2%">
                              <h4>
                              <span style="color:black;" class="glyphicon glyphicon-stats" aria-hidden="true"></span> 게시판
                              </h4>
                              </div>
                             <asp:Table ID="Table1" BackColor="Transparent"   runat="server" CssClass="table no-border"  Width="100%"  >
                             </asp:Table>
                        
                         
                     </section>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
             <asp:Button ID="Button2" runat="server" Text="Button"  Visible="false"  OnClick="Button2_Click"/>
        </div>
    </form>
        <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/adminlte.min.js"></script>
       
       
       
</body>
</html>

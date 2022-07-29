<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Work_list_detail.aspx.cs" Inherits="mobile1.Work.Work_list_detail" %>
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
    <link rel="stylesheet"  href="../Scripts/datepicker3.min.css" />
    
    <title></title>
      <script type = text/javascript>
         function go(No)
            {
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                 obj.value = No; 

               <%= Page.GetPostBackEventReference(Button2) %>
          }
          
         $(function () {
            $('#outdate').datepicker({
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
                               <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-small btn-default">
                      <i class="fa fa-times"></i>&nbsp;이전</asp:LinkButton>
                             &nbsp;&nbsp;&nbsp;&nbsp;
                     
                                <asp:LinkButton ID="LinkButton6" runat="server" OnClick="Button4_Click" CssClass="btn btn-small btn-default">
                      <i class="fa fa-check-circle"></i>&nbsp;수정</asp:LinkButton>

                <font size="2">
                  <div  class="mailbox-controls with-border" style="width:100%; margin-top:10px;">
                    <div style="" class="input-group">
                        <%--<asp:Label ID="Label4" runat="server" Text=""></asp:Label>--%>
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success"  style="width:160px;   text-align:left;">고객사</button>
                     </div>
                           <div style=" margin-top:8px; margin-left:8px;">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="serial" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">계약사</button>
                     </div>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div1" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">유지보수 장비</button>
                     </div>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div2" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">고객사 담당자</button>
                     </div>
                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div3" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">고객사 담당자 연락처</button>
                     </div>
                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div4" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">고객사 담당자 Email</button>
                     </div>
                    <asp:TextBox ID="TextBox5" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div5" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">주소</button>
                     </div>
                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                       <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div13" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">담당 엔지니어</button>
                     </div>
                    <asp:TextBox ID="TextBox13" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div6" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">담당 영업</button>
                     </div>
                    <asp:TextBox ID="TextBox7" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div7" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">협력사</button>
                     </div>
                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div8" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">협력사 담당자</button>
                     </div>
                    <asp:TextBox ID="TextBox9" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                        <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div12" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">협력사 연락처</button>
                     </div>
                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div9" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; text-align:left;">협력사 Email</button>
                     </div>
                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" Width="100%" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>

                    
                  <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div10" runat="server" class="input-group">
                        <div class="input-group-btn">
                       <button type="button" class="btn btn-success" style="width:160px; Height:80px; text-align:left;">일정확인</button>
                     </div>
                    <asp:TextBox ID="TextBox12" runat="server" class="form-control" Width="100%" TextMode="MultiLine" Height="80" placeholder="Enter ..."></asp:TextBox>
                    </div>
                  </div>


                    <div  class="mailbox-controls with-border" style="width:100%">
                <div style="" id="Div11" runat="server" class="input-group">
                        <div class="input-group-btn" >
                       <button type="button" class="btn btn-success" style="width:160px;  text-align:left;">유지보수 완료 여부</button>
                     </div>
                    <div style=" margin-top:8px; margin-left:8px;">
                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>완료
                    </div>
                    
                    </div>
                  </div>
                  


             


                         </div>
        

                            <div class="box-footer">
                         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-small btn-default">
                      <i class="fa fa-times"></i>&nbsp;이전</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="Button4_Click" CssClass="btn btn-small btn-default">
                      <i class="fa fa-check-circle"></i>&nbsp;수정</asp:LinkButton>
                                
                                </div>
                         
                              </div>
                     
                 </section>
                 </div>
                 </div>
                  
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
             <asp:HiddenField ID="HiddenField3" runat="server" />
             <asp:HiddenField ID="HiddenField4" runat="server" />
             <asp:HiddenField ID="HiddenField5" runat="server" />
             <asp:HiddenField ID="HiddenField6" runat="server" />
             <asp:HiddenField ID="HiddenField7" runat="server" />
             <asp:HiddenField ID="HiddenField8" runat="server" />
             <asp:HiddenField ID="HiddenField9" runat="server" />
             <asp:HiddenField ID="HiddenField10" runat="server" />
             <asp:HiddenField ID="HiddenField11" runat="server" />
             <asp:HiddenField ID="HiddenField12" runat="server" />
             <asp:HiddenField ID="HiddenField13" runat="server" />
             <asp:HiddenField ID="HiddenField14" runat="server" />
             <asp:HiddenField ID="HiddenField15" runat="server" />
             <asp:HiddenField ID="HiddenField16" runat="server" />
             <asp:Button ID="Button2" runat="server" Text="Button" Visible="false" OnClick="Button1_Click" />
             <asp:HiddenField ID="title" runat="server" />
             <asp:HiddenField ID="body" runat="server" />
        </div>
        
    </form>
       <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.kr.js"></script>
       
</body>
</html>
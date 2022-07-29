<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="send_mail_list.aspx.cs" Inherits="mobile1.mail.send_mail_list"  %>
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

    //  $.get('mail_list_get.aspx', function (data) {
    //    $('#maindounut').html(data);
    //});

    //$(function() {
    //startRefresh();
    //});

    //function startRefresh() {
    //         setTimeout(startRefresh, 5000);  
    //        var scrollPosition = $(document).scrollTop();
    //        //alert(scrollPosition);     
    //            $.get('mail_list_get.aspx', function (data) {
    //                $('#maindounut').html(data);
    //                window.scrollTo(0, scrollPosition);
    //        });
    //    }
         
             
             
         
    //$(document).ready(function () {
    //$.ajax({
    //    type:"POST",
    //    url:"mail_list.aspx/getlist",
    //    data:'{user_id:"'+user_id+'"}',
    //    ContentType:"application/Json; Charset=utf-8",
    //    datatype:"Json",
    //    Success:OnSuccess,
    //        failure: function (response) {
    //                alert(response.d);
    //        },
    //        error: function (response) {
    //               alert(response.d);
    //        }
            
    //     });

   
        
        
    //});
          function OnSuccess(response) {
             alert(responce.d);
         }

    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server" style="height:100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <div class="row">
                 <section class="content" style="margin-left:2%; margin-right:2%; " >
                     
                <%--   
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
                     </table>--%>

                     <div class="cssload-piano" style="z-index:200; position:relative; visibility:hidden; " >
	                    <div class="cssload-rect1"></div>
	                    <div class="cssload-rect2"></div>
	                    <div class="cssload-rect3"></div>
                    </div>
          <div class="box box-primary" style="z-index:100;">
            <div class="box-header with-border">
              <h3 class="box-title">보낸 편지함</h3>  
                  <div class=" pull-right" style="float:left; margin-top:4px; margin-left:4px;">
                    <asp:Button  ID="Button1" runat="server" Text="검색" CssClass="btn btn-primary btn-xs " OnClick="Button1_Click" />
                      <asp:Button  ID="Button3" runat="server" Text="메일 쓰기" CssClass="btn btn-primary btn-xs " OnClick="Button3_Click" />
                    </div>
              <div class="pull-right"  style="float:left;">
                  <input type="text" id="Search" style="width:140px;" class="form-control input-sm" runat="server" placeholder="메일 검색">
                  
              </div>
              
              <!-- /.box-tools -->
            </div>
              
            <!-- /.box-header -->
            <div class="box-body no-padding">
              <div class="mailbox-controls">
                
                <!-- /.btn-group -->
                <button type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Unnamed_ServerClick"><i class="fa fa-refresh"></i></button>
                <div class="pull-right">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>
                                         <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                  <!-- /.btn-group -->
                </div>
                <!-- /.pull-right -->
              </div>
              <div class="table-responsive mailbox-messages">
                  <div class="box-body no-padding">
                                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                     <ContentTemplate>
                                         <asp:Timer ID="Timer2" runat="server" Interval="3000" ></asp:Timer>
                                         <asp:Table ID="TBLLIST"    runat="server" CssClass="table  custab table-hover "  Width="100%" ></asp:Table>
                              </ContentTemplate>
                                 </asp:UpdatePanel>
                                </div>
                <!-- /.table -->
              </div>
              <!-- /.mail-box-messages -->
            </div>
            <!-- /.box-body -->
            <div class="box-footer no-padding">
              <div class="mailbox-controls">
                <!-- Check all button -->
                
                <!-- /.btn-group -->
                <button type="button" class="btn btn-default btn-sm" runat="server"  onserverclick="Unnamed_ServerClick"><i class="fa fa-refresh"></i></button>
                <div class="pull-right">
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                     <ContentTemplate>
                                         <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                  
                  <!-- /.btn-group -->
                </div>
                <!-- /.pull-right -->
              </div>
            </div>
          </div>
          <!-- /. box -->
        



<%--                         <div class="box box-info" style="margin-top:0px; float:right; ">
                              <div class="box-header">
                                    <h3 class="box-title">받은편지함</h3>
                              </div>
                             <div class="box-body no-padding">
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>
                                         <asp:Timer ID="Timer1" runat="server" Interval="3000" ></asp:Timer>
                                         <asp:Table ID="TBLLIST"    runat="server" CssClass="table  custab table-hover "  Width="100%" ></asp:Table>
                              </ContentTemplate>
                                 </asp:UpdatePanel>
                                </div>
                             <div class="box-footer clearfix" align="center" style="margin-top:0px; height:50px;" >
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                     <ContentTemplate>
                                         <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                           
                           </div>
                         </div>--%>
                     </section>
                     </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:Button ID="Button2" runat="server" Text="Button"  Visible="false"  OnClick="Button2_Click"/>
    </form>
        <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
       
       <script>
        $(document).ready(function() {
              $(Search).keydown(function(event){
                //if(event.keyCode == 13) {
                  //event.preventDefault();
                    //location.reload();
                  //return false;
                //}
              });
            });


        

           var user_id = document.getElementById("HiddenField2").value;
            

         //  $(function () {
         //      $.ajax({
         //       type: "POST",
         //       url: "mail_list.aspx/getlist",
         //       data: '{user_id:"'+user_id+'"}',
         //       contentType: "application/json; charset=utf-8",
         //       dataType: "json",
         //       //async: false,
         //          success: OnSuccess1,
         //          Complete:Complete1

                 
         //      });
               
         //});
        
        
    
          function OnSuccess1(response) {
              //alert("1");
              //$(".cssload-piano").hide();
           }
           function Complete1(response) {
              //alert("1");
              //$(".cssload-piano").hide();
           }

           $( document ).ajaxComplete(function() {
               //alert("2");
               //$(".cssload-piano").hide();
            });
       </script>
        <style>
                         .cssload-piano {
	margin: auto;
	width: 39px;
	height: 10px;
	font-size: 10px;
}
.cssload-piano > div {
	height: 100%;
	width: 100%;
	display: block;
	margin-bottom: 0.6em;
	animation: stretchdelay 1.38s infinite ease-in-out;
		-o-animation: stretchdelay 1.38s infinite ease-in-out;
		-ms-animation: stretchdelay 1.38s infinite ease-in-out;
		-webkit-animation: stretchdelay 1.38s infinite ease-in-out;
		-moz-animation: stretchdelay 1.38s infinite ease-in-out;
}
.cssload-piano .cssload-rect2 {
	animation-delay: -1.15s;
		-o-animation-delay: -1.15s;
		-ms-animation-delay: -1.15s;
		-webkit-animation-delay: -1.15s;
		-moz-animation-delay: -1.15s;
}
.cssload-piano .cssload-rect3 {
	animation-delay: -0.92s;
		-o-animation-delay: -0.92s;
		-ms-animation-delay: -0.92s;
		-webkit-animation-delay: -0.92s;
		-moz-animation-delay: -0.92s;
}



@keyframes stretchdelay {
	0%, 40%, 100% {
		transform: scaleX(0.8);
		background-color: rgb(46,88,101);
		box-shadow: 0 0 0 rgba(10,10,10,0.1);
	}
	20% {
		transform: scaleX(1);
		background-color: rgb(0,177,146);
		box-shadow: 0 5px 6px rgba(10,10,10,0.4);
	}
}

@-o-keyframes stretchdelay {
	0%, 40%, 100% {
		-o-transform: scaleX(0.8);
		background-color: rgb(46,88,101);
		box-shadow: 0 0 0 rgba(10,10,10,0.1);
	}
	20% {
		-o-transform: scaleX(1);
		background-color: rgb(0,177,146);
		box-shadow: 0 5px 6px rgba(10,10,10,0.4);
	}
}

@-ms-keyframes stretchdelay {
	0%, 40%, 100% {
		-ms-transform: scaleX(0.8);
		background-color: rgb(46,88,101);
		box-shadow: 0 0 0 rgba(10,10,10,0.1);
	}
	20% {
		-ms-transform: scaleX(1);
		background-color: rgb(0,177,146);
		box-shadow: 0 5px 6px rgba(10,10,10,0.4);
	}
}

@-webkit-keyframes stretchdelay {
	0%, 40%, 100% {
		-webkit-transform: scaleX(0.8);
		background-color: rgb(46,88,101);
		box-shadow: 0 0 0 rgba(10,10,10,0.1);
	}
	20% {
		-webkit-transform: scaleX(1);
		background-color: rgb(0,177,146);
		box-shadow: 0 5px 6px rgba(10,10,10,0.4);
	}
}

@-moz-keyframes stretchdelay {
	0%, 40%, 100% {
		-moz-transform: scaleX(0.8);
		background-color: rgb(46,88,101);
		box-shadow: 0 0 0 rgba(10,10,10,0.1);
	}
	20% {
		-moz-transform: scaleX(1);
		background-color: rgb(0,177,146);
		box-shadow: 0 5px 6px rgba(10,10,10,0.4);
	}
}
                     </style>   
</body>

</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insa_detail.aspx.cs" Inherits="mobile1.Insa.insa_detail" %>
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
            $('#startdate').datepicker({
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
                                <b><center><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></center></b>
                          <br />
                             <div style="float:left; margin-top:7px;">
                                 찾기 &nbsp;
                             </div>
                             <div style="float:left;">
                                 <asp:DropDownList ID="DropDownList1" runat="server"  Width="100%" CssClass="form-control" AutoPostBack="true" 
                                     OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                                     <asp:ListItem>선택</asp:ListItem>
                                 </asp:DropDownList>
                             </div>
                            <%-- <div style="float:left; visibility:hidden;" >
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="이번달 등록" class="btn btn-primary pull-right" OnClick="Button3_Click" OnClientClick="click();"/>
                             </div>--%>
                         <div  class="box-header " style="float:left; ">
                                  등록날짜 &nbsp;
                             </div>
                         <div style=" margin-left:-5px">
                                <asp:TextBox ID="startdate" runat="server" Class="form-control " Width="100px"  AutoPostBack="true" OnTextChanged="startdate_TextChanged" onclick="$('#startdate').blur();"></asp:TextBox>
                            </div>                                           
                         </div>
                         
                         <div class="box-body" runat="server" id="info" style="padding-left:0px; padding-right:0px;">
                
                
                  <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputEmail" class="col-sm-2 control-label">피고과자</label>

                    <div style="margin-left:5%;">
                      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
                  </div>

                    <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputEmail" class="col-sm-2 control-label">부서</label>

                    <div style="margin-left:5%;">
                      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                  </div>

                   <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputEmail" class="col-sm-2 control-label">직위</label>

                    <div style="margin-left:5%;">
                      <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </div>
                  </div>
 
                  <div  class="mailbox-controls with-border" style="width:100%;">
                    <label for="inputEmail" class="control-label">1. 실적   <font size="1" color="blue">(단위:만원)</font></label>
                      <br />
                      <div style="float:left;  margin-right:50px;">
                      <b>월</b><br />
                      <div style="float:left; width:120px ">
                      목표치 : <asp:TextBox ID="TextBox1" runat="server"  Width="100px" autocomplete="off"  class="form-control" Text="0" placeholder=""></asp:TextBox>  
                      </div>
                      <div style="float:left; width:120px">
                      달성율 : <asp:TextBox ID="TextBox2" runat="server"  Width="100px" autocomplete="off" class="form-control" Text="0" placeholder=""></asp:TextBox> 
                      </div>
                          <div>
                              <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                          </div>
                      </div>
                      
                      <div style="float:left; margin-right:50px;">
                      <b>분기</b><br />
                      <div style="float:left; width:120px ">
                      목표치 : <asp:TextBox ID="TextBox4" runat="server"  Width="100px" autocomplete="off" class="form-control" Text="0" placeholder=""></asp:TextBox> 
                      </div>
                      <div style="float:left; width:120px" >
                      달성율 : <asp:TextBox ID="TextBox5" runat="server"  Width="100px" autocomplete="off" class="form-control" Text="0" placeholder=""></asp:TextBox> 
                      </div>
                          <div>
                              <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                          </div>
                      </div>
                      
                      <div style="float:left; margin-right:50px;" >
                      <b>연</b><br />
                      <div style="float:left; width:120px">
                      목표치 : <asp:TextBox ID="TextBox6" runat="server"  Width="100px" autocomplete="off"  class="form-control" Text="0" placeholder=""></asp:TextBox> 
                      </div>
                      <div style="float:left; width:120px">
                      달성율 : <asp:TextBox ID="TextBox7" runat="server"  Width="100px" autocomplete="off"  class="form-control" Text="0" placeholder=""></asp:TextBox> 
                      </div>
                          <div>
                              <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                          </div>
                      </div>
                      <br /><br /><br /><br /><br /><br />
                        <div class="radio radio-primary" style="margin-left:5%">
                      <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="100%"  RepeatDirection="Horizontal">
                            <asp:ListItem Value="2">&nbsp;&nbsp;2</asp:ListItem>
                            <asp:ListItem Value="4">&nbsp;&nbsp;4</asp:ListItem>
                            <asp:ListItem Value="6">&nbsp;&nbsp;6</asp:ListItem>
                            <asp:ListItem Value="8">&nbsp;&nbsp;8</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>  
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="14">14</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="18">18</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                      
                 
                  </div>

                   <div  class="mailbox-controls with-border" style="width:100%;">
                    <label for="inputEmail" class="col-sm-6 control-label">2. 성공률<br /><font color="blue">(프로젝트 성공률)</font></label>
                     
                      <div class="radio radio-primary" style="margin-left:5%">
                      <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="100%"  RepeatDirection="Horizontal">
                            <asp:ListItem Value="4">&nbsp;&nbsp;4</asp:ListItem>
                            <asp:ListItem Value="8">&nbsp;&nbsp;8</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                  </div>


                 <div  class="mailbox-controls with-border" style="width:100%;">
                    <label for="inputEmail" class="col-sm-6 control-label">3. 영업 범위<br /><font color="blue">(공공, 기업, 금융)</font></label>
                     
                      <div class="radio radio-primary" style="margin-left:5%">
                      <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="100%"   RepeatDirection="Horizontal">
                            <asp:ListItem Value="4">&nbsp;&nbsp;4</asp:ListItem>
                            <asp:ListItem Value="8">&nbsp;&nbsp;8</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                  </div>


                   <div  class="mailbox-controls with-border" style="width:100%;">
                    <label for="inputEmail" class="col-sm-6 control-label">4. 애사심<br /><font color="blue">(맡은바 일을 책임감 있게 수행하고 그 결과에 대해 책임을 지는 태도)</font></label>
                     
                      <div class="radio radio-primary" style="margin-left:5%">
                      <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="100%"   RepeatDirection="Horizontal">
                            <asp:ListItem Value="4">&nbsp;&nbsp;4</asp:ListItem>
                            <asp:ListItem Value="8">&nbsp;&nbsp;8</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                  </div>


                  <div  class="mailbox-controls with-border" style="width:100%;">
                    <label for="inputEmail" class="col-sm-6 control-label">5. 근무태도<br /><font color="blue">(당사 직원으로서의 기본적인 인격을 갖추고 있는지 여부)</font></label>
                     
                      <div class="radio radio-primary" style="margin-left:5%; ">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="100%"   RepeatDirection="Horizontal">
                            <asp:ListItem Value="4">&nbsp;&nbsp;4</asp:ListItem>
                            <asp:ListItem Value="8">&nbsp;&nbsp;8</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                        </asp:RadioButtonList>
                      
                    </div>
                  </div>

                    <div  class="mailbox-controls with-border" id="theDiv" runat="server" style="width:100%">
                    <label for="inputEmail" class="col-sm-2 control-label">종합</label>

                    <div style="margin-left:5%;">
                      <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    </div>
                  </div>

                 <div  class="mailbox-controls with-border" style="width:100%">
                    <label for="inputName" class="col-sm-2 control-label">비고</label>

                    <div style="margin-left:5%; ">
                      <asp:TextBox ID="TextBox3" runat="server"  Width="100%" Rows="5" TextMode="MultiLine"  class="form-control" placeholder="메모"></asp:TextBox>
                    </div>
                  </div>


       
                     <style>
                         .radio {
    padding-left: 20px; }
.radio label {
    display: inline-block;
    position: relative;
    padding-left: 5px; }
.radio label::before {
    content: "";
    display: inline-block;
    position: absolute;
    width: 17px;
    height: 17px;
    left: 0;
    margin-left: -20px;
    border: 1px solid #cccccc;
    border-radius: 50%;
    background-color: #fff;
    -webkit-transition: border 0.15s ease-in-out;
    -o-transition: border 0.15s ease-in-out;
    transition: border 0.15s ease-in-out; }
.radio label::after {
    display: inline-block;
    position: absolute;
    content: " ";
    width: 11px;
    height: 11px;
    left: 3px;
    top: 3px;
    margin-left: -20px;
    border-radius: 50%;
    background-color: #555555;
    -webkit-transform: scale(0, 0);
    -ms-transform: scale(0, 0);
    -o-transform: scale(0, 0);
    transform: scale(0, 0);
    -webkit-transition: -webkit-transform 0.1s cubic-bezier(0.8, -0.33, 0.2, 1.33);
    -moz-transition: -moz-transform 0.1s cubic-bezier(0.8, -0.33, 0.2, 1.33);
    -o-transition: -o-transform 0.1s cubic-bezier(0.8, -0.33, 0.2, 1.33);
    transition: transform 0.1s cubic-bezier(0.8, -0.33, 0.2, 1.33); }
.radio input[type="radio"] {
    opacity: 0; }
.radio input[type="radio"]:focus + label::before {
    outline: thin dotted;
    outline: 5px auto -webkit-focus-ring-color;
    outline-offset: -2px; }
.radio input[type="radio"]:checked + label::after {
    -webkit-transform: scale(1, 1);
    -ms-transform: scale(1, 1);
    -o-transform: scale(1, 1);
    transform: scale(1, 1); }
.radio input[type="radio"]:disabled + label {
    opacity: 0.65; }
.radio input[type="radio"]:disabled + label::before {
    cursor: not-allowed; }
.radio.radio-inline {
    margin-top: 0; }

.radio-primary input[type="radio"] + label::after {
    background-color: #428bca; }
.radio-primary input[type="radio"]:checked + label::before {
    border-color: #428bca; }
.radio-primary input[type="radio"]:checked + label::after {
    background-color: #428bca; }

.radio-danger input[type="radio"] + label::after {
    background-color: #d9534f; }
.radio-danger input[type="radio"]:checked + label::before {
    border-color: #d9534f; }
.radio-danger input[type="radio"]:checked + label::after {
    background-color: #d9534f; }

.radio-info input[type="radio"] + label::after {
    background-color: #5bc0de; }
.radio-info input[type="radio"]:checked + label::before {
    border-color: #5bc0de; }
.radio-info input[type="radio"]:checked + label::after {
    background-color: #5bc0de; }

.radio-warning input[type="radio"] + label::after {
    background-color: #f0ad4e; }
.radio-warning input[type="radio"]:checked + label::before {
    border-color: #f0ad4e; }
.radio-warning input[type="radio"]:checked + label::after {
    background-color: #f0ad4e; }

.radio-success input[type="radio"] + label::after {
    background-color: #5cb85c; }
.radio-success input[type="radio"]:checked + label::before {
    border-color: #5cb85c; }
.radio-success input[type="radio"]:checked + label::after {
    background-color: #5cb85c; }
    </style>            
                         </div>
                            <div class="box-footer">
                         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-small btn-default" >
                      <i class="fa fa-times"></i>&nbsp;이전</asp:LinkButton>
                                <asp:Button ID="Button1" runat="server" Text="제출" class="btn btn-primary pull-right" OnClick="Button1_Click1" OnClientClick="click();"/>
                                </div>
                     </div>
                    
                 </section>
                 </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:Button ID="Button2" runat="server" Text="Button" Visible="false" OnClick="Button1_Click" />
             <asp:HiddenField ID="dept_name" runat="server" />
             <asp:HiddenField ID="name" runat="server" />
             <asp:HiddenField ID="email" runat="server" />
             <asp:HiddenField ID="phone" runat="server" />
             <asp:HiddenField ID="dept_code" runat="server" />
             <asp:HiddenField ID="duty_code" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
             <asp:HiddenField ID="HiddenField3" runat="server" />

             <asp:HiddenField ID="month_1" runat="server" />
             <asp:HiddenField ID="month_2" runat="server" />
             <asp:HiddenField ID="half_1" runat="server" />
             <asp:HiddenField ID="half_2" runat="server" />
             <asp:HiddenField ID="year_1" runat="server" />
             <asp:HiddenField ID="year_2" runat="server" />

             

        </div>
        
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.kr.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.dataTables.min.js"></script>
</body>
</html>
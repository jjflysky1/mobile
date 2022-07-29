<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mobile1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
      <link rel='stylesheet' href="Content/bootstrap.min.css" />
      <%--<link rel="stylesheet" href="Content/login.css">--%>
     <link rel="stylesheet" href="Content/AdminLTE.min.css" />
    <link rel="stylesheet" href="Content/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/ionicons.min.css" />
    <link rel="stylesheet" href="Content/blue.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
    <title></title>
</head>
   
    <body class="hold-transition login-page" ">
<div class="" style="margin-left:5%; margin-right:5%;" >
  <div class="login-logo">
    <a href="default.aspx"><b>Potal</b></a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">로그인하여 주십시오</p>

    <form  runat="server" id="form">
      
        <div style="float:right; width:20%;  position:relative;" >
            <asp:Button  id="enter" runat="server" Text="Login" OnClick="LOGIN" CssClass="btn btn-primary btn-block btn-flat" Height="83px" />
        </div>
        <div class="form-group has-feedback " style="width:78%; float:left;">
          <input type="text" runat="server" class="form-control" name="name"  id ="name" placeholder="ID" />
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback" style="width:78%; float:left;">
          <%--<input type="password" runat="server" class="form-control" name="password" id="password"  />--%>    
          <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" placeholder="Password" />
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
        
      <div class="row">
        <div class="col-xs-7" style="margin-left:20px;">
          <div class="checkbox icheck">
            <label>
              <asp:CheckBox ID="CheckBox1" runat="server" /><font size='2'>계정정보 저장</font>
            </label>
          </div>
        </div>
        <!-- /.col -->
        <div class="col-xs-4" style="float:right">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <!-- /.col -->
      </div>
        <div>
            <font size="2">
            <a href="http://27.117.167.22:86/apk/potal.apk" type="application/vnd.android.package-archive"  >Potal 최신버전 다운로드</a>
            <br /><br />
            <a href="http://27.117.167.22:86/apk/barcode.apk" type="application/vnd.android.package-archive"  >Scan 최신버전 다운로드</a>
                </font>
        </div>
    </form>
  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 3 -->
<script src="Scripts/jquery.min.js"></script>
    
<!-- Bootstrap 3.3.7 -->
<script src="Scripts/bootstrap.min.js"></script>
<!-- iCheck -->


</body>
   
</html>

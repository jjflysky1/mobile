<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="leftmenu.ascx.cs" Inherits="mobile1.Common.leftmenu" %>


 <script type = text/javascript>
     /** add active class and stay opened when selected */
var url = window.location;

// for sidebar menu entirely but not cover treeview
$('ul.sidebar-menu a').filter(function() {
	 return this.href == url;
}).parent().addClass('active');

// for treeview
$('ul.treeview-menu a').filter(function() {
	 return this.href == url;
     }).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');

     var mySkins = [
         'skin-blue',
         'skin-black',
         'skin-red',
         'skin-yellow',
         'skin-purple',
         'skin-green',
         'skin-blue-light',
         'skin-black-light',
         'skin-red-light',
         'skin-yellow-light',
         'skin-purple-light',
         'skin-green-light'
     ];


 function changeSkin(cls) {
     $.each(mySkins, function (i) {
         $('body').removeClass(mySkins[i]);
     });
     $('body').addClass(cls);
     store('skin', cls);
     return false;
     }

       function store(name, val) {
    if (typeof (Storage) !== 'undefined') {
        localStorage.setItem(name, val);
    } else {
        window.alert('Please use a modern browser to properly view this template!');
    }
  }
       function get(name) {
    if (typeof (Storage) !== 'undefined') {
      return localStorage.getItem(name);
    } else {
        window.alert('Please use a modern browser to properly view this template!');
    }
     }


       function setup() {
           var tmp = get('skin');
           if (tmp && $.inArray(tmp, mySkins))
               changeSkin(tmp);

    // Add the change skin listener
           $('[data-skin]').on('click', function (e) {
               if ($(this).hasClass('knob'))
                   return;
               e.preventDefault();
               changeSkin($(this).data('skin'));
           });

    // Add the layout manager
           $('[data-layout]').on('click', function () {
               changeLayout($(this).data('layout'));
           });

           $('[data-controlsidebar]').on('click', function () {
               changeLayout($(this).data('controlsidebar'));
               var slide = !$controlSidebar.options.slide;

               $controlSidebar.options.slide = slide;
               if (!slide)
                   $('.control-sidebar').removeClass('control-sidebar-open');
           });

           $('[data-sidebarskin="toggle"]').on('click', function () {
               var $sidebar = $('.control-sidebar');
               if ($sidebar.hasClass('control-sidebar-dark')) {
                   $sidebar.removeClass('control-sidebar-dark');
                   $sidebar.addClass('control-sidebar-light');
               } else {
                   $sidebar.removeClass('control-sidebar-light');
                   $sidebar.addClass('control-sidebar-dark');
               }
           });

           $('[data-enable="expandOnHover"]').on('click', function () {
               $(this).attr('disabled', true);
               $pushMenu.expandOnHover();
               if (!$('body').hasClass('sidebar-collapse'))
                   $('[data-layout="sidebar-collapse"]').click();
           });

    //  Reset options
    if ($('body').hasClass('fixed')) {
        $('[data-layout="fixed"]').attr('checked', 'checked');
    }
    if ($('body').hasClass('layout-boxed')) {
        $('[data-layout="layout-boxed"]').attr('checked', 'checked');
    }
    if ($('body').hasClass('sidebar-collapse')) {
        $('[data-layout="sidebar-collapse"]').attr('checked', 'checked');
    }
  }

     setup();


          function logout() {
            if (confirm("로그아웃 하시겠습니까?") == true) {
              window.location.href="/Default.aspx";
            }
          }

</script>





<header class="main-header">
    <!-- Logo -->
    <a href="/main.aspx" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>P</b></span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Potal</b></span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>

      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
          <!-- Messages: style can be found in dropdown.less-->
    <%--      <li class="dropdown messages-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-envelope-o"></i>
              <span class="label label-success">4</span>
            </a>
            
          </li>
          <!-- Notifications: style can be found in dropdown.less -->
          <li class="dropdown notifications-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-bell-o"></i>
              <span class="label label-warning">10</span>
            </a>
            
          </li>
          <!-- Tasks: style can be found in dropdown.less -->
          <li class="dropdown tasks-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-flag-o"></i>
              <span class="label label-danger">9</span>
            </a>
          
          </li>--%>

           <li >
            <a href="#" class="btn btn-flat ">
              <i class="fa fa-user"></i>
              <asp:Label ID="Label111" runat="server" Text="Label"></asp:Label>
            </a>
           
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li >
              <a href='javascript:void(0);' onclick="logout();" class="btn btn-flat "> <i class="fa  fa-sign-out"></i> 로그아웃</a>
          </li>

           <li class="dropdown user user-menu" >
               <a href="#" class="dropdown-toggle" data-toggle="dropdown">  
              <i class="fa fa-gears"></i>
            </a>
               <ul class="dropdown-menu" style="width:330px">
              <!-- User image -->
                   
                      <li class="user-header" style="height:80px">
                        <p>
                         Skins
                        </p> 
                     </li>
              <!-- Menu Body -->
              <li class="user-body">
                <div class="row" style="margin-bottom:15px; font-size:12px;">
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-blue');">Blue</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-black');">Black</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-purple');">Purple</a>
                  </div>
                </div>
                  <div class="row" style="margin-bottom:15px; font-size:12px;">
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-green');">Green</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-red');">Red</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-yellow');">Yellow</a>
                  </div>
                </div>
                  <div class="row" style="margin-bottom:15px; font-size:12px;">
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-blue-light');">Blue Light</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-black-light');">Black Light</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-purple-light');">Purple Light</a>
                  </div>
                </div>
                  <div class="row" style="margin-bottom:15px; font-size:12px;">
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-green-light');">Green Light</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-red-light');">Red Light</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href='javascript:void(0);' onclick="changeSkin('skin-yellow-light');">Yellow Light</a>
                  </div>
                </div>
                <!-- /.row -->
              </li>
                   
              <!-- Menu Footer-->
           <%--   <li class="user-footer">
                <div class="pull-left">
                  <a href="#" class="btn btn-default btn-flat">Profile</a>
                </div>
                <div class="pull-right">
                  <a href="#" class="btn btn-default btn-flat">Sign out</a>
                </div>
              </li>--%>
            </ul>
          </li>
        </ul>
      </div>
    </nav>
  </header>


<font size="2">

<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">MAIN NAVIGATION</li>
        <li class=""><a href="/notice/notice.aspx"><i class="fa fa-laptop"></i> <span>공지사항</span></a></li>
         <li class="treeview">
          <a href="#">
            <i class="fa fa-laptop"></i> <span>메 일</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>  
          <ul class="treeview-menu">
            <li class=""><a href="/mail/mail_write.aspx"><i class="fa fa-laptop"></i> <span>메일쓰기</span></a></li>
            <li class=""><a href="/mail/mail_list.aspx"><i class="fa fa-laptop"></i> <span>받은메일</span></a></li>
            <li class=""><a href="/mail/send_mail_list.aspx"><i class="fa fa-laptop"></i> <span>보낸메일</span></a></li>
          </ul>
        </li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-laptop"></i> <span>고객사 정보</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li class=""><a href="/work/work.aspx"><i class="fa fa-laptop"></i> <span>고객사 이력</span></a></li>
            <li class=""><a href="/work/work_list.aspx"><i class="fa fa-laptop"></i> <span>고객사 리스트</span></a></li>
          </ul>
        </li>
        
        <li class=""><a href="/user/user_list.aspx"><i class="fa fa-laptop"></i> <span>조직도</span></a></li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-laptop"></i> <span>재고 관리</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="/Product/sell.aspx"><i class="fa fa-circle-o"></i><font size="2"> 판매</font></a></li>
            <li><a href="/Product/in.aspx"><i class="fa fa-circle-o"></i><font size="2"> 자산</font></a></li>
            <li><a href="/Product/demo.aspx"><i class="fa fa-circle-o"></i><font size="2"> 데모</font></a></li>
          </ul>
        </li>
        <li class=""><a href="/myinfo/myinfo.aspx"><i class="fa fa-laptop"></i> <span>나의 정보관리</span></a></li>
        <li id="insa" runat="server" class=""><a href="/insa/insa_list.aspx"><i class="fa fa-laptop"></i> <span>인사 고과</span></a></li>

          
<%--        <li class="header">LABELS</li>
        <li class="treeview"><a href="#"><i class="fa fa-circle-o text-red"></i> <span>Important</span></a></li>
        <li class="treeview"><a href="#"><i class="fa fa-circle-o text-yellow"></i> <span>Warning</span></a></li>
        <li class="treeview"><a href="#"><i class="fa fa-circle-o text-aqua"></i> <span>Information</span></a></li>--%>
      </ul>
    </section>
    <!-- /.sidebar -->
  </aside>

    </font>


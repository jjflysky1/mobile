<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Insa_list_personal.aspx.cs" Inherits="mobile1.Insa.Insa_list_personal" %>
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
    
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Content/JavaScript.js"></script>
    <script src="../Scripts/AdminLTE.css"></script>
      <link rel="stylesheet"  href="../Scripts/datepicker3.min.css" />


    <script src="Scripts/highcharts.js"></script>
    <script src="Scripts/highcharts-3d.js"></script>
    <script src="Scripts/exporting.js"></script>
    <script src="Scripts/export-data.js"></script>
    <script src="Scripts/jschart.js"></script>
    <link href="Scripts/Allcss.css" rel="stylesheet" />



    <title></title>
     <script type = text/javascript>

            function go2(date,id_no)
            {
                
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                    obj.value = date; 

                var obj = document.getElementById("<%=HiddenField2.ClientID %>");
                if (obj)
                    obj.value = id_no; 

                

                         
               <%= Page.GetPostBackEventReference(Button2) %>

            }

         
            function go3(No)
            {
                var obj = document.getElementById("<%=HiddenField1.ClientID %>");
                if (obj)
                    obj.value = No; 

      
               <%= Page.GetPostBackEventReference(Button4) %>

         }

         function view(No) {
                 var obj = document.getElementById("<%=HiddenField3.ClientID %>");
                if (obj)
                 obj.value = No; 
             if (document.getElementById(No).style.display === "none") {
                 document.getElementById(No).style.display = "";
                 document.getElementById(No).style.width = "100%";
             }
             else {
                 document.getElementById(No).style.display = "none";
             }
         }

         
         function allview() {
             var startno = document.getElementById("<%=startno.ClientID %>");
             var endno = document.getElementById("<%=endno.ClientID %>");
            
             for (var i = startno.value; i < endno.value+1; i++) {
                 if (document.getElementById(i).style.display === "none") {
                 document.getElementById(i).style.display = "";
                 document.getElementById(i).style.width = "100%";
                 }
                 else {
                     document.getElementById(i).style.display = "none";
                 }
             }
             
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
        $(function () {
            $('#enddate').datepicker({
                calendarWeeks: false,
                todayHighlight: true,
                autoclose: true,
                format: "yyyy-mm-dd",
                language: "kr" 
            });
         });

    
 
      $(function(){   
    $(document).keydown(function(objEvent) {        
        if (objEvent.ctrlKey) {          
            if (objEvent.keyCode == 80) {                
                //objEvent.preventDefault();            
                //objEvent.stopPropagation();
                
                //$("#yourdiv").width(200);

                document.getElementById("Label2").style.visibility = "hidden";
                //document.getElementById("chart").style.width = 90%;

                window.print();


                return false;
            }            
        }        
    });
});    
    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server" style="height:100%;">
         <div class="wrapper"> 
            <uc1:uc_menu ID="uc_menu" runat="server" />
             <div class="content-wrapper">
                 <div class="row" >
                 <section class="content" style="margin-left:2%; margin-right:2%;">
                     <table>
                         <tr>
                             <td>
                                 <asp:DropDownList ID="DropDownList2" Visible="false" runat="server" Height="30"  Class="form-control" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                 <asp:ListItem Value="15">15</asp:ListItem>
                                 <asp:ListItem Value="50">50</asp:ListItem>
                                 <asp:ListItem Value="100">100</asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                         </tr>
                     </table>
               
              
                     <table  style="float:right;" >
                         <tr >
                             <td>
                                 처음으로 <button type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Unnamed_ServerClick"><i class="fa fa-refresh"></i></button>&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="연도" CssClass="" ></asp:Label>&nbsp;&nbsp;
                             </td>
                             <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server"  Width="100%" CssClass="form-control" AutoPostBack="true" 
                                     OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                     <asp:ListItem>선택</asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                            <%-- <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server" Height="35"  Class="form-control " Width="100px">
                                  <asp:ListItem>선택</asp:ListItem>
                                  <asp:ListItem Value="3">이름</asp:ListItem>
                                  </asp:DropDownList>
                             </td>
                             <td>
                                 &nbsp;<asp:Label ID="Label5" runat="server" Text="검색 : " CssClass=""></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox Height="30" ID="Search" runat="server" Class="form-control " Width="80px"  AutoComplete="off" ></asp:TextBox>
                             </td>
                             <td>
                                 &nbsp;&nbsp;<asp:Button  ID="Button3" runat="server" Text="검색" CssClass="btn btn-primary btn-sm " OnClick="Button3_Click" />
                             </td>--%>
                         </tr>
                     </table>
               <br /><br />
                         <div class="box box-info" style="margin-top:0px; float:right;   ">
                              <div class="box-header">
                                    <h3 class="box-title"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 인사 고과</h3>
                                  <div style="float:none">
                                  <%--<font size="2" color="#3a7fa5">Q1:실적  Q2:성공률  Q3:영업 범위  Q4:애사심  Q5:근무태도</font>--%>
                                  </div>  
                                  <%--<button id="excelbutton" style="float:right; margin-left:1%;" type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Unnamed_ServerClick1"><i class="fa fa-file-excel-o"></i></button>--%>
                                  <%--<button id="Button1" style="float:right" type="button" class="btn btn-default btn-sm" runat="server"  onclick="allview();"><i class="fa fa-list-alt"> 전체상세</i></button>--%>
                              </div>
                             
                                 
                             
                             <div class="box-body no-padding">
                             <asp:Table ID="TBLLIST"   runat="server" CssClass="table table-bordered table-striped"   Width="100%" >

                             </asp:Table>
                                </div>
                             <div class="box-footer clearfix" align="center" style="margin-top:0px; height:50px; " >
                           <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                           </div>
                         </div>
                  
                     <center>
                       <div style="margin-top:0px;   background-color:white; width:100%;  height:20%;" id="chart"  class="chart" >                 
                                <canvas id="myChart" width="400" height="60"></canvas>
                                    <script src='https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js'></script>
                            </div>   
                     </center>
                     
                     </section>
                     </div>
                 </div>
             <uc2:uc_bottom ID="uc_bottom" runat="server" />
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="startno" runat="server" />
        <asp:HiddenField ID="endno" runat="server" />
        <asp:HiddenField ID="HiddenField4" runat="server" />

        <asp:Button ID="Button2" runat="server" Text="Button"  Visible="false"  OnClick="Button2_Click"/>
        <asp:Button ID="Button4" runat="server" Text="Button"  Visible="false"  OnClick="Button3_Click1"/>
    </form>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/adminlte.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datepicker.kr.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.dataTables.min.js"></script>
        <script>
            window.onload = function () {
                     $(function () {
                                        <%-- var serverip = document.getElementById("<%=serverip.ClientID %>").value;
                             
                                         var starttime = document.getElementById("<%=HiddenField1.ClientID %>").value;--%>
                        var no = document.getElementById("<%=HiddenField4.ClientID %>").value;
                        var year = document.getElementById("<%=HiddenField3.ClientID %>").value;
                        var startno = document.getElementById("<%=startno.ClientID %>").value;
                        var endno = document.getElementById("<%=endno.ClientID %>").value;
                             
        
         
                     $.ajax({
                            type: "POST",
                         url: "/Insa/Insa_list_personal.aspx/chart",
                         //data: "{'serverip':'" + serverip + "', 'startdate':'" + startdate + "', 'enddate':'" + enddate + "' , 'HiddenField1':'" + starttime + "' , 'HiddenField2':'" + endtime +"'}",
                         data: "{'no':'" + no +"','year':'"+year+"','startno':'"+startno+"','endno':'"+endno+"' }",
                         contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: OnSuccess,
                            failure: function (response) {
                                alert(response.d);
                            },
                            error: function (response) {
                                alert(response.d);
                            }
                        });
                    });


                function OnSuccess(response) {
                    var customers = response.d;
                    var temp_traffic = "";
                    var serverip = "";
                    var temp_time = "";
                    var count = 0;
                    var max = "";
                     $(customers).each(function () {
                         count++;
                    });
                    $(customers).each(function () {
                        serverip = this.name;
                        temp_traffic += this.total + ",";   
                        temp_time += this.date + ",";           
                    });
                    temp_traffic = temp_traffic.slice(0, -1);
                    temp_time = temp_time.slice(0, -1);
                    var trafficArray = temp_traffic.split(',');
                    var timeArray = temp_time.split(',');
                    trafficArray.reverse();
                    timeArray.reverse();
                    let data = trafficArray;
                    //alert(data2);
       


                    function addData(chart, data) {
                      chart.data.datasets.forEach(dataset => {
                        let data = dataset.data;
                        const first = data.shift();
                        data.push(first);
                        dataset.data = data;
                      });

                      chart.update();
                     }




                    var ctx = document.getElementById("myChart").getContext("2d");
                    var myChart = new Chart(ctx, {
                      type: "line",
                      data: {
                        labels: timeArray,
                        datasets: [
                          {
                                label: serverip,
                                data: trafficArray,
                            backgroundColor: ["rgba(113, 88, 203, .15)"],
                            borderColor: ["rgba(113, 88, 203, 1)"],
                            borderWidth: 1,
                            fill: "start"
                          }
     
                        ]
                      },
                        options: {
       
                            animation: {
                          duration: 250
                        },
                        tooltips: {
                          intersect: false,
                          backgroundColor: "rgba(113, 88, 203, 1)",
                          titleFontSize: 16,
                          titleFontStyle: "400",
                          titleSpacing: 4,
                          titleMarginBottom: 8,
                          bodyFontSize:	12,
                          bodyFontStyle:	'400',
                          bodySpacing: 4,
                          xPadding: 8,
                          yPadding: 8,
                          cornerRadius: 4,
                          displayColors: false,
      
                          callbacks: {
                            title: function (t, d) {
                              const o = d.datasets.map((ds) => ds.data[t[0].index] + " 점")
          
                              return o.join(', ');
                            },
                            label: function (t, d) {
                              return d.labels[t.index];
                            }
                          }
                        },
                        title: {
                            text: "Public Bandwidth",
                            display: false
                        },
                        maintainAspectRatio: true,
                        spanGaps: false,
                        elements: {
                          line: {
                            tension: 0.3
                          }
                        },
                        plugins: {
                          filler: {
                            propagate: false
                          }
                        },
                        scales: {
                            xAxes: [
       
                              {
              
                              ticks: {
                                autoSkip: true,
                                maxTicksLimit: 20
                              }
                            }
                          ]
                        }
                      }
                            });
                            //setInterval(() => addData(myChart), 5000);

                        };
        


            }
       

    
        


 

    </script>
       
</body>
</html>

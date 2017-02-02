<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Chat_Demo.aspx.vb" Inherits="_365ThreeSixty_v3.Chat_Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, shrink-to-fit=no, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    

    <!-- Bootstrap Core CSS -->
    <link href="content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="content/simple-sidebar.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .auto-style1 {
            width: 442px;
            height: 114px;
        }
        #form1 {
            background-color: #CCCCCC;
        }
    </style>
</head>
<body>
 

    <div id="wrapper">
        <img alt="this is definitley not slack" class="auto-style1" src="Slack_Logo.png" />
        <!-- Sidebar -->
        <div id="sidebar-wrapper">
            
            <ul class="sidebar-nav">
                 
                <li class="sidebar-brand">
  
                </li>
                <li>                  <a href="#">
                        Employee List <br />
                        Tag someone to leave a review
                    </a>
                </li>
                    <asp:PlaceHolder ID="userList" runat="server"></asp:PlaceHolder>
                <li>
                    <a href="#">Dashboard</a>
                </li>
                <li>
                    <a href="#">Shortcuts</a>
                </li>
                <li>
                    <a href="#">Overview</a>
                </li>


            </ul>
        </div>
        <!-- /#sidebar-wrapper -->

        <!-- Page Content -->
        <div id="page-content-wrapper">
            <div class="container-fluid">
               <form id="form1" runat="server">
       
        <asp:PlaceHolder ID="chatWindow" runat="server"></asp:PlaceHolder>
        <br />
        <asp:TextBox ID="txtNewComment" runat="server" TextMode="MultiLine" Width="1909px"></asp:TextBox>
        <asp:Button ID="btnchatComment" runat="server" Text="comment"  />
    </form>
 <a href="Default.aspx">back to dashboard</a>
            </div>
                      
        </div>
        <!-- /#page-content-wrapper -->

    </div>
    
    
      <script lang="javascipt">
        function insertUser(txt){
            var currentTxt = document.getElementById('txtNewComment').value;
            document.getElementById('txtNewComment').value = currentTxt + " " + txt.innerhtml;
            }
    </script>   
 
 
 
</body>
</html>

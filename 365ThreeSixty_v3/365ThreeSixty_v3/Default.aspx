<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="_365ThreeSixty_v3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"></meta>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Portfolio Item - Start Bootstrap Template</title>

    <!-- Bootstrap Core CSS -->
    <link href="content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="content/portfolio-item.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    


   <%-- --------------new stuff------------------%>

    <!-- Page Content -->
<div class="container">

        <form align="left" id="form1" runat="server" >
        <!-- Portfolio Item Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">365ThreeSixty - Coninuous Feedback demo for 
                    <small>Liberdix Labs</small>
                </h1>
               
                <h2>Mission Statement
                    <small><asp:Label ID="lblMission" runat="server" Text="Mission"></asp:Label></small>
                </h2>
                 
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Item Row -->
        <div class="row">

            <div class="col-md-6">
                <h3>Start Demo</h3>
                        
                    <asp:DropDownList ID="frmReviewer" runat="server"></asp:DropDownList>
                    <asp:Button ID="createReviewer" runat="server" Text="Start" />
               
            </div>
         
             <div class="col-md-6">
             <h3>Set up and Admin</h3>
            
                <h3>Update Staff List</h3>
                        
                    <asp:FileUpload ID="staffUpload" runat="server"/><asp:Button ID="btnUpload" runat="server" Text="Upload Staff" />
                        

                     <h3>Update Mission Statement</h3><br />
                        
                        <asp:TextBox ID="txtNewMission" runat="server" TextMode="MultiLine"></asp:TextBox>&nbsp;
                        <asp:Button ID="btnUpdateValues" runat="server" Text="Update Mission" />
                        
            </div>

</div>
        <!-- /.row -->

        <!-- Related Projects Row -->
        <div class="row">

            <div class="col-lg-12">
                <h3 class="page-header">Stats Dashboard #TODO#</h3>
            </div>

            <div class="col-lg-12">
                
                    &nbsp;<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
               
            </div>

          

        </div>
         </form>
</div>
            <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

</body>
</html>

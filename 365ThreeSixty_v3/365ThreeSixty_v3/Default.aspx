<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="_365ThreeSixty_v3.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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

        <form id="form1" runat="server" >
        <!-- Portfolio Item Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">365ThreeSixty - Continuous Feedback demo for 
                    <small>Liberdix Labs</small>
                </h1>
               
                <h2>Mission Statement<br />
                    <small><asp:Label ID="lblMission" runat="server" Text="[enter a mission statement]"></asp:Label></small>
                </h2>
               <h3><asp:LinkButton ID="LinkButton1" runat="server">clear down database for fresh start</asp:LinkButton></h3>
                 
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Item Row -->
        <div class="row">

            <div class="col-md-6">
                <h3>Start Demo</h3>
                     <p>First choose your reviewer<br />
                         This is to mimic the input that will come in from Slack or wherever
                     </p>   
                    <asp:DropDownList ID="frmReviewer" runat="server"></asp:DropDownList>
                    <asp:Button ID="createReviewer" runat="server" Text="Start" />
               
            </div>
         
             <div class="col-md-6">
             <h3>Set up and Admin</h3>
            
                <h3>Update Staff List</h3>
                 <a href ="resources/Staff.xlsx"> Download input template here</a>
                        
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
                <h3 class="page-header">Stats Dashboard</h3>
            </div>

            <div class="col-lg-12">
                <h2>Employee Total Scores</h2>
                    <asp:Chart ID="Chart1" runat="server" DataSourceID="reviewData" Width="1096px">
                        <series>
                            <asp:Series Name="Series1" XValueMember="employeeName" YValueMembers="score">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                    <asp:SqlDataSource ID="reviewData" runat="server" ConnectionString="<%$ ConnectionStrings:365ThreeSixtyConnectionString1 %>" SelectCommand="SELECT employees.employeeName, SUM(reviews.weightedScore) AS score FROM employees INNER JOIN reviews ON employees.employeeRef = reviews.recipientRef GROUP BY employees.employeeName"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                
                <h2>Employee Average Score</h2>
                    &nbsp;<asp:Chart ID="Chart2" runat="server" DataSourceID="AveReviewData" Width="922px">
                    <series>
                        <asp:Series Name="Series1" XValueMember="employeeName" YValueMembers="Average Score">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
                <br />
                <br />
         
               
                <asp:SqlDataSource ID="AveReviewData" runat="server" ConnectionString="<%$ ConnectionStrings:365ThreeSixtyConnectionString1 %>" SelectCommand="SELECT employees.employeeName, AVG(reviews.weightedScore) AS [Average Score] FROM employees INNER JOIN reviews ON employees.employeeRef = reviews.recipientRef GROUP BY employees.employeeName"></asp:SqlDataSource>
               
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="employee" HeaderText="employee" SortExpression="employee" />
                        <asp:BoundField DataField="Reviewed by" HeaderText="Reviewed by" SortExpression="Reviewed by" />
                        <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                        <asp:BoundField DataField="rawScore" HeaderText="rawScore" SortExpression="rawScore" />
                        <asp:BoundField DataField="reviewerScore" HeaderText="reviewerScore" SortExpression="reviewerScore" />
                        <asp:BoundField DataField="recipientScore" HeaderText="recipientScore" SortExpression="recipientScore" />
                        <asp:BoundField DataField="deltaFactor" HeaderText="deltaFactor" SortExpression="deltaFactor" />
                        <asp:BoundField DataField="commentFactor" HeaderText="commentFactor" SortExpression="commentFactor" />
                        <asp:BoundField DataField="weightedScore" HeaderText="weightedScore" SortExpression="weightedScore" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:365ThreeSixtyConnectionString1 %>" SelectCommand="SELECT employees.employeeName AS employee, e1.employeeName AS [Reviewed by], reviews.comment, reviews.rawScore, reviews.reviewerScore, reviews.recipientScore, reviews.deltaFactor, reviews.commentFactor, reviews.weightedScore FROM reviews INNER JOIN employees AS e1 ON reviews.reviewerRef = e1.employeeRef INNER JOIN employees ON reviews.recipientRef = employees.employeeRef"></asp:SqlDataSource>
                <br />
                <br />
                <br />
               
            </div>

          

        </div>
         </form>
</div>
            <!-- jQuery -->
    <script src="scripts/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="scripts/bootstrap.min.js"></script>


</body>
</html>

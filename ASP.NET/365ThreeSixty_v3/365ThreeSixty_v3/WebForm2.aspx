<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="_365ThreeSixty_v3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
 
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="chatWindow" runat="server"></asp:PlaceHolder>
        <br />
        <asp:TextBox ID="txtNewComment" runat="server" TextMode="MultiLine" Width="1909px"></asp:TextBox>
        <asp:Button ID="btnchatComment" runat="server" Text="comment" />
    </form>
 <a href="WebForm1.aspx">back to dashboard</a>   
 
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Slackish.aspx.vb" Inherits="_365ThreeSixty_v3.Slackish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
    <div>
    <asp:PlaceHolder ID="chatWindow" runat="server"></asp:PlaceHolder>
    </div>
        <div>
        <asp:TextBox ID="txtNewComment" runat="server" TextMode="MultiLine" Width="100%" AutoPostBack="True"></asp:TextBox>
        <asp:Button ID="btnchatComment" runat="server" Text="comment"  />
        </div>
        <a href="Default.aspx">back to dashboard</a>
    </form>
</body>
</html>

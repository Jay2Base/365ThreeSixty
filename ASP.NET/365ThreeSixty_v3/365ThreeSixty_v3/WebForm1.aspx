<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="_365ThreeSixty_v3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form align="center" id="form1" runat="server" >
    <div>
    
    </div>
        <asp:DropDownList ID="frmReviewer" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox ID="isAdmin" runat="server" />
&nbsp;I am an Admin<br />
        <br />
        <asp:Button ID="createReviewer" runat="server" Text="Start" />
        <p>
            &nbsp;</p>
        <asp:Panel ID="submitAreview" runat="server" Height="312px" Visible="false">
            <asp:DropDownList ID="frmRecipients" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:TextBox ID="frmComment" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="frmSubmitReview" runat="server" Text="Submit Review" />
            <br />
        </asp:Panel>
        
    </form>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</body>
</html>

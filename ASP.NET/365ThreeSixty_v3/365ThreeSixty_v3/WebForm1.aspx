<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="_365ThreeSixty_v3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form align="center" id="form1" runat="server" >
    <div>
    
        Current Staff List<br />
        (select a reviewer)</div>
        <asp:DropDownList ID="frmReviewer" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblMission" runat="server" Text="Mission"></asp:Label>
        <br />
        <br />
        <asp:Button ID="createReviewer" runat="server" Text="Start" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdmin" runat="server" Text="Admin Tools" />
        &nbsp;&nbsp;&nbsp;
        Select File &nbsp;<asp:FileUpload ID="staffUpload" runat="server" /><br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload Staff" />
        &nbsp;&nbsp;
        <asp:TextBox ID="txtNewMission" runat="server" TextMode="MultiLine"></asp:TextBox>
&nbsp;<asp:Button ID="btnUpdateValues" runat="server" Text="Update Company Values" />
        <br />
&nbsp;</form>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</body>
</html>

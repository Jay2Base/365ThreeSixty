<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="_365ThreeSixty_v3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <div>

    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="voteRef" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="voteRef" HeaderText="voteRef" ReadOnly="True" SortExpression="voteRef" />
            <asp:BoundField DataField="reviewerRef" HeaderText="reviewerRef" SortExpression="reviewerRef" />
            <asp:BoundField DataField="recipientRef" HeaderText="recipientRef" SortExpression="recipientRef" />
            <asp:BoundField DataField="reviewDate" HeaderText="reviewDate" SortExpression="reviewDate" />
            <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
            <asp:BoundField DataField="rawScore" HeaderText="rawScore" SortExpression="rawScore" />
            <asp:BoundField DataField="reviewerFactor" HeaderText="reviewerFactor" SortExpression="reviewerFactor" />
            <asp:BoundField DataField="recipientFactor" HeaderText="recipientFactor" SortExpression="recipientFactor" />
            <asp:BoundField DataField="reviewerScore" HeaderText="reviewerScore" SortExpression="reviewerScore" />
            <asp:BoundField DataField="recipientScore" HeaderText="recipientScore" SortExpression="recipientScore" />
            <asp:BoundField DataField="deltaFactor" HeaderText="deltaFactor" SortExpression="deltaFactor" />
            <asp:BoundField DataField="commentFactor" HeaderText="commentFactor" SortExpression="commentFactor" />
            <asp:BoundField DataField="weightedScore" HeaderText="weightedScore" SortExpression="weightedScore" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:365ThreeSixtyConnectionString1 %>" DeleteCommand="DELETE FROM [reviews] WHERE [voteRef] = @voteRef" InsertCommand="INSERT INTO [reviews] ([reviewerRef], [recipientRef], [reviewDate], [comment], [rawScore], [reviewerFactor], [recipientFactor], [reviewerScore], [recipientScore], [deltaFactor], [commentFactor], [weightedScore]) VALUES (@reviewerRef, @recipientRef, @reviewDate, @comment, @rawScore, @reviewerFactor, @recipientFactor, @reviewerScore, @recipientScore, @deltaFactor, @commentFactor, @weightedScore)" ProviderName="<%$ ConnectionStrings:365ThreeSixtyConnectionString1.ProviderName %>" SelectCommand="SELECT [voteRef], [reviewerRef], [recipientRef], [reviewDate], [comment], [rawScore], [reviewerFactor], [recipientFactor], [reviewerScore], [recipientScore], [deltaFactor], [commentFactor], [weightedScore] FROM [reviews]" UpdateCommand="UPDATE [reviews] SET [reviewerRef] = @reviewerRef, [recipientRef] = @recipientRef, [reviewDate] = @reviewDate, [comment] = @comment, [rawScore] = @rawScore, [reviewerFactor] = @reviewerFactor, [recipientFactor] = @recipientFactor, [reviewerScore] = @reviewerScore, [recipientScore] = @recipientScore, [deltaFactor] = @deltaFactor, [commentFactor] = @commentFactor, [weightedScore] = @weightedScore WHERE [voteRef] = @voteRef">
        <DeleteParameters>
            <asp:Parameter Name="voteRef" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="reviewerRef" Type="Int32" />
            <asp:Parameter Name="recipientRef" Type="Int32" />
            <asp:Parameter DbType="Date" Name="reviewDate" />
            <asp:Parameter Name="comment" Type="String" />
            <asp:Parameter Name="rawScore" Type="Int32" />
            <asp:Parameter Name="reviewerFactor" Type="Decimal" />
            <asp:Parameter Name="recipientFactor" Type="Decimal" />
            <asp:Parameter Name="reviewerScore" Type="Decimal" />
            <asp:Parameter Name="recipientScore" Type="Decimal" />
            <asp:Parameter Name="deltaFactor" Type="Decimal" />
            <asp:Parameter Name="commentFactor" Type="Decimal" />
            <asp:Parameter Name="weightedScore" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="reviewerRef" Type="Int32" />
            <asp:Parameter Name="recipientRef" Type="Int32" />
            <asp:Parameter DbType="Date" Name="reviewDate" />
            <asp:Parameter Name="comment" Type="String" />
            <asp:Parameter Name="rawScore" Type="Int32" />
            <asp:Parameter Name="reviewerFactor" Type="Decimal" />
            <asp:Parameter Name="recipientFactor" Type="Decimal" />
            <asp:Parameter Name="reviewerScore" Type="Decimal" />
            <asp:Parameter Name="recipientScore" Type="Decimal" />
            <asp:Parameter Name="deltaFactor" Type="Decimal" />
            <asp:Parameter Name="commentFactor" Type="Decimal" />
            <asp:Parameter Name="weightedScore" Type="Decimal" />
            <asp:Parameter Name="voteRef" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


</body>
</html>

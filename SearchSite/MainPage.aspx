<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SearchSite.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            BearSearch<br />
            <br />
            <asp:TextBox ID="SearchTextBox" runat="server" Width="750px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Button" />
        </div>
    </form>
</body>
</html>

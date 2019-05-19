<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPersonalScheduleAnalytics.aspx.cs" Inherits="frmPersonalScheduleAnalytics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            User ID&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPasswordID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnUserLogin" runat="server" OnClick="btnUserLogin_Click" Text="User Login" />
            <asp:Button ID="btnUserCreate" runat="server" OnClick="btnUserCreate_Click" Text="Register" />
            <br />
        </div>
    </form>
</body>
</html>

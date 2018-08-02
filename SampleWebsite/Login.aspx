<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="IqamaID" runat="server" Text="Iqama: "></asp:Label>
    
        <asp:TextBox ID="txt_username" runat="server"  style="margin-left: 36px"></asp:TextBox>
    
        <br />
        <asp:Label ID="PasswordID" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
        <asp:Button ID="btn_login" runat="server" Text="Login" onclick="login"/>
    
    </div>
    </form>

</body>
</html>
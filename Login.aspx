<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FNS Login</title>
    <link href="css/StyleLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMain">
        <div id="divLogo">
            <img src="image/Logo.png" alt="" width="250" height="250" />
        </div>
        <div id="divLoginBox">
            <asp:Login ID="Login" runat="server" TextLayout="TextOnTop" TitleText="">
                <LoginButtonStyle CssClass="btnLogin" />
                <TextBoxStyle CssClass="txtBox" />
            </asp:Login>
        </div>
    </div>
    </form>
</body>
</html>

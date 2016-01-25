<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSWADemo.aspx.cs" Inherits="CSWA_Integration.CSWADemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CSWA Integration Sample</title>
    <link rel="stylesheet" type="text/css" href="main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainContainer">
        <iframe id="CSWAIFrame" scrolling="auto" runat="server" src="" frameborder="0" ></iframe>
        <div id="leftForm">
            <asp:Button runat="server" id="CSWAConnectButton" CssClass="browseButton" text="Sign with CoSign" OnClick="CSWAConnectButton_Click" />
            <div id="ViewFile">(<a id="linkViewFile" href="demo.pdf" target="_blank">View Sample PDF</a>)</div>
            <asp:Label runat="server" id="StatusLabel" />
        </div>
    </div>
    </form>
</body>
</html>

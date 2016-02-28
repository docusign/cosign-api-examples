<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="retrieveSignedFile.aspx.cs" Inherits="CSWA_Integration.retrieveSignedFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>WSC Demo Application</title>
    <link rel="stylesheet" type="text/css" href="main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainContainerFinishURL">
            <img class="finishURLLogo" src="Images/cosign-logo.png" alt="Logo" />
            <asp:Label ID="LabelResultMessage" runat="server" Text=""></asp:Label>
            <div id="signedDocLine" runat="server">Signed Document: <a href="" id="linkToDoc" runat="server"></a></div>
            <a href="CSWADemo.aspx" id="linkToFirstPage" runat="server">Return to Demo Application</a>
        </div>
    </form>
</body>
</html>

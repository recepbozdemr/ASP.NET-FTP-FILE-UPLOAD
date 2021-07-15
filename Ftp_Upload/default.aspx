<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ftp_Upload._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <asp:FileUpload ID="FileUpload1"  runat="server" />
<asp:Button Text="FTP'ye Yükle" runat="server" OnClick="FTPUpload" />
<hr />
<asp:Label ID="lblMessage" runat="server" />
    </div>
    </form>
</body>
</html>

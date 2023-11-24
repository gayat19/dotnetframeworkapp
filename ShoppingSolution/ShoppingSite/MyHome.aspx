<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyHome.aspx.cs" Inherits="ShoppingSite.MyHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center;" class="alert alert-success">Hello World!!!</h1>
        </div>
        <asp:Button class="btn btn-success" ID="btnFirst" runat="server" Text="First" OnClick="btnFirst_Click" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tools.aspx.cs" Inherits="ComputingServices.App.Tools" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:Button ID="btnImportQuestionsSet" runat="server" Text="导入QuestionsSet" OnClick="btnImportQuestionsSet_Click" />
    </div>
    <asp:Literal ID="ltlLog" runat="server" EnableViewState="false" />
    </form>
</body>
</html>

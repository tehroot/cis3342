<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz_results.aspx.cs" Inherits="Project1.Quiz_results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel='stylesheet'href='site-sheet.css'/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="information">
            <h1>Quiz Results for</h1>
            <h1>Student Name: <asp:Label id="name" runat="server"></asp:Label></h1>
            <h1>TUID: <asp:Label ID="tuid" runat="server"></asp:Label></h1>
        </div>
        <div class="container">
             <asp:Label id="label1" runat="server"></asp:Label>
        </div>
        <div class="">
             <h1>Your Score: <asp:Label id="score" runat="server"></asp:Label></h1>
        </div>
    </form>
</body>
</html>
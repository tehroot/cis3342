<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inbox.aspx.cs" Inherits="Project3.Pages.inbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel='stylesheet' href='site-sheet.css'/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="scripts.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="fixed-top" data-toggle="affix">
        <div class="navbar navbar-dark bg-dark navbar-expand-sm" id="first">
            <a class="navbar-toggler p-2 text-white border-0" data-toggle="collapse" data-target=".navbar-collapse">☰</a>
            <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                <ul class="nav navbar-nav">
                    <li class="nav-item">
                        <asp:Button id="Button1" text="Account" runat="server" type="submit" CssClass="btn btn-outline-light navbar-btn" OnClick="checkLogin_Click"/>
                    </li>
                </ul>
            </div>
            <div class="mx-auto my-2 order-0 order-md-1 position-relative">
                <a class="navbar-brand text-light mx-auto">FMail</a>
            </div>
            <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <asp:Button id="Button2" text="Logout" runat="server" type="submit" CssClass="btn btn-outline-light navbar-btn" OnClick="checkLogout_Click"/>
                    </li>
                </ul> 
            </div>
        </div>
        <div class="navbar navbar-light bg-light navbar-expand pl-2" id="second">
            <ul class="nav navbar-nav">
                <li class="nav-item">
                    <asp:Button id="composeEmail" text="Compose" runat="server" type="submit" CssClass="btn btn-primary" OnClick="composeEmail_Click"/>
                </li>
                <li class="nav-item">
                    <asp:Button ID="createFolder" Text="Create Folder" runat="server" type="submit" CssClass="btn btn-info" OnClick="createFolder_Click" />
                </li>

            </ul>
        </div>
    </div>
    <%--<nav class ="navbar navbar-expand-lg navbar-light bg-dark sticky-top">
        <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <asp:Button id="accountButton" text="Account" runat="server" type="submit" CssClass="btn btn-outline-light navbar-btn" OnClick="checkLogin_Click"/>
                </li>
            </ul>
        </div>
        <div class="mx-auto my-2 order-0 order-md-1 position-relative">
            <a class="navbar-brand text-light mx-auto">FMail</a>
        </div>
        <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <asp:Button id="logoutButton" text="Logout" runat="server" type="submit" CssClass="btn btn-outline-light navbar-btn" OnClick="checkLogout_Click"/>
                </li>
            </ul> 
        </div>
    </nav>--%>
        <div class="container">
            <asp:CustomValidator runat="server" ID="formvalidator" Display="Dynamic" OnServerValidate="formValidation"/>
            <div>
                <asp:GridView ID="gvEmails" runat="server" AutoGenerateColumns="false" CssClass="table-condensed table-bordered table-hover">
                    <Columns>
                        <ItemTemplate>
                            <asp:TemplateField HeaderText="">
                                <asp:Checkbox ID="checkbox" runat="server" />
                            </asp:TemplateField>
                        </ItemTemplate>
                        <asp:BoundField DataField="id" ItemStyle-CssClass="hiddenCol" HeaderStyle-CssClass="hiddenCol" ReadOnly="true" />
                        <asp:BoundField DataField="sender" HeaderText="From" ReadOnly="true" />
                        <asp:BoundField DataField="subject" HeaderText="Subject" ReadOnly="true" />
                        <asp:BoundField DataField="timestamp" HeaderText="Date, Time" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
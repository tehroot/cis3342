<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compose.aspx.cs" Inherits="Project3.Pages.compose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel='stylesheet' href='stylesheet.css'/>
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
                <a class="navbar-toggler p-2 text-white border-0" data-toggle="collapse" data-target=".navbar-collapse"></a>
                <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                    <ul class="nav navbar-nav">
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
            </div>
            <div class="navbar navbar-light bg-light navbar-expand pl-2" id="second">
                <div class="btn-toolbar w-100" role="toolbar">
                     <div class="btn-group mr-1" role="group">
                        <asp:Button id="returnInbox" text="Return to Inbox" runat="server" type="submit" CssClass="btn btn-primary" OnClick="checkInbox_Click"/>
                    </div>
                </div>
            </div>
        </div>
        <asp:CustomValidator runat="server" id="formvalidator" Display="Dynamic" OnServerValidate="formValidation" />
        <div class="container-fluid h-100 d-flex justify-content-center align-item-center bg-light">
        <div class="container" style="padding-top: 150px;">
            <div class="justify-content-center">
                <div runat="server" CssClass="warning" id="warningdiv"></div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label for="sender" class="text-dark">Sender: </label> 
                        <asp:TextBox runat="server" CssClass="form-control" ID="sender" name="emailSender" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label for="recipient" class="text-dark">Recipient: </label> 
                        <asp:DropDownList runat="server" CssClass="form-control" ID="recipientList" name="emailRecipient"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label for="sender" class="text-dark">Email Subject: </label> 
                        <asp:TextBox runat="server" CssClass="form-control" ID="subject" name="emailSubject"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label for="messageContent" class="text-dark">Content: </label> 
                        <asp:TextBox runat="server" TextMode="multiline" CssClass="form-control" ID="messageContent" name="messageContent"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <asp:Button id="sendEmail" text="Send Email" runat="server" type="submit" CssClass="btn btn-primary" OnClick="sendEmail_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
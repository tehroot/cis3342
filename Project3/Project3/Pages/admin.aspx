<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Project3.Pages.admin" %>

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
    </div>
    <div class="container-fluid w-100" style="padding-top: 150px;">
        <div CssClass="warning" id="invalidLogin" runat="server"></div>
        <div class="row">
            <div class="col-5">
                <asp:GridView ID="gvFlaggedEmails_IDs" runat="server" AutoGenerateColumns="false" Class="table-condensed table-bordered table-striped w-100">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="select_checkbox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View Sender Account">
                            <ItemTemplate>
                                <asp:Button ID="view_user_account" type="submit" Text="View Account" CssClass="btn btn-primary btn-sm" runat="server" OnClick="view_user_account_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ban User">
                            <ItemTemplate>
                                <asp:Button ID="banUserAccount" type="submit" Text="Ban User" CssClass="btn btn-danger btn-sm" runat="server" OnClick="banUserAccount_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unflag Email">
                            <ItemTemplate>
                                <asp:Button ID="unFlagEmail" type="Submit" Text="Unflag Email" CssClass="btn btn-warning btn-sm" runat="server" OnClick="unFlagEmail_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" ItemStyle-CssClass="hiddenCol" HeaderStyle-CssClass="hiddenCol" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-7">
                <asp:GridView ID="gvFlaggedEmails" OnRowDataBound="gvFlaggedEmails_RowDataBound" runat="server" AutoGenerateColumns="false" Class="table-condensed table-bordered table-striped table-hover w-100">
                    <Columns>
                        <asp:BoundField DataField="sender" HeaderText="From" ReadOnly="true" />
                        <asp:BoundField DataField="subject" HeaderText="Subject" ReadOnly="true" />
                        <asp:BoundField DataField="timestamp" HeaderText="Date, Time" ReadOnly="true" />
                        <asp:TemplateField ItemStyle-CssClass="hidden-submit-button">
                            <ItemTemplate>
                                <asp:Button id="flag_email" type="submit" Text="Text here" CssClass="btn btn-danger btn-sm hiddenCol" runat="server"/>  
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvAccountsList" OnRowDataBound="gvAccountsList_RowDataBound" runat="server" AutoGenerateColumns="false" Class="table-condensed table-bordered table-striped table-hover w-100">

                </asp:GridView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

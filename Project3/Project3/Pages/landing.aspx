<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landing.aspx.cs" Inherits="Project3.Pages.landing" %>

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
    <nav class ="navbar navbar-expand-lg navbar-light bg-dark sticky-top">
		<div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
		</div>
		<div class="mx-auto my-2 order-0 order-md-1 position-relative">
			<a class="navbar-brand text-light mx-auto">FMail</a>
		</div>
  		<div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
  		</div>
	</nav>
    <div class="container h-100 d-flex justify-content-center align-items-center bg-light">
	    <div class="d-flex justify-content-center align-items-center" style="height: 100vh">
	    <form id="loginform" runat="server">
		    <div class="warning" id="invalidLogin" runat="server"></div>
		    <div class="form-group row">
            <div class="btn-group">
                 <asp:Button id="createAccountButton" Text="Create Account" runat="server" type="submit" CssClass="btn btn-primary" OnClick="create_Click" UseSubmitBehavior="false"/>
                 <asp:Button id="loginButton" text="Login" runat="server" type="submit" CssClass="btn btn-secondary" OnClick="login_Click" UseSubmitBehavior="false"/>
            </div>
		    </div>
	    </form>
	    </div>
    </div>
</body>
</html>

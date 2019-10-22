<%@ Page Language="C#" Inherits="Project3.Pages.login" %>
<!DOCTYPE html>
<html>
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
<script>
	$(document).ready(function(){
		$.fn.login();
	});
</script>
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
	    <div class="d-flex justify-content-center">
	    <form id="loginform" runat="server">
		    <div class="warning" id="invalidLogin" runat="server"></div>
		    <div class="form-group">
			    <label for="email">Email Address</label>
			    <asp:TextBox runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" CssClass="form-control" id="email" aria-describedby="email" placeholder="Enter Email here" required></asp:TextBox>
			    <small id="emailHelp" class="form-text text-muted">Enter your email here to login.</small>
		    </div>
		    <div class="form-group">
			    <label for="passwordInput">Password</label>
			    <asp:TextBox runat="server" class="form-control" id="password" placeholder="Enter password here" required></asp:TextBox>
			    <small id="passwordHelp" class="form-text text-muted">Enter your password here to login.</small>
		    </div>
		    <asp:Button id="loginButton" text="Login" runat="server" type="submit" CssClass="btn btn-primary" OnClick="checkLogin_Click"/>
	    </form>
	    </div>
    </div>
</body>
</html>
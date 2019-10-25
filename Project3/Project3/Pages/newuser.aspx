<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="Project3.Pages.newuser" %>

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
<script>
	$(document).ready(function(){
		
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
    <div class="container-fluid h-100 d-flex justify-content-center align-item-center bg-light">
        <div class="container">
            <div class="justify-content-center">
                <form id="form1" runat="server">
                    <asp:CustomValidator runat="server" id="formvalidator" Display="Dynamic" OnServerValidate="formValidation" />
                    <div runat="server" CssClass="warning" id="warningdiv"></div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-md-12">
						    <label for="username" class="text-dark">Desired Username:</label>
						    <asp:Textbox runat="server" CssClass="form-control" id="email" placeholder="Enter Username" required pattern="[A-Za-z]+"></asp:Textbox>
                            <small id="emailHelp" class="form-text text-muted">Please enter only lowercase letters and numerical digits</small>
					    </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
			                <label for="passwordInput">Password</label>
			                <asp:TextBox runat="server" class="form-control" id="password" placeholder="Enter password here" required pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,50}"></asp:TextBox>
			                <small id="passwordHelp" class="form-text text-muted">Please enter a minimum of 8 characters including 1 digit and one upper-case and a maximum of 50 characters.</small>
		                </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
						    <label for="firstname" class="text-dark">First Name:</label>
						    <asp:Textbox runat="server" CssClass="form-control" id="firstname" placeholder="Enter First Name" required name="firstname" pattern="[A-Za-z]+"></asp:Textbox>
					    </div>
					    <div class="form-group col-md-4">
						    <label for="lastname" class="text-dark">Last Name:</label>
						    <asp:Textbox runat="server" CssClass="form-control" id="lastname" placeholder="Enter Last Name" required name="lastname" pattern="[A-Za-z]+"></asp:Textbox>
					    </div>
                        <div class="form-group col-md-4">
						    <label for="alternateemail" class="text-dark">Alternate Email: </label>
						    <asp:Textbox runat="server" CssClass="form-control" id="alternateemail" placeholder="Enter Alternate E-mail address." required name="lastname" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$"></asp:Textbox>
                            <small id="alternateEmailHelp" class="form-text text-muted">Please enter a recovery email address</small>
					    </div>
                    </div>
                        <div class="justify-content-center">
                            <h3>Pick an avatar</h3>
                        </div>
                    <div class="form-row">
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-1.svg" alt="avatar" style="width:25%">
                                <div class="caption center-block">
                                  <input type="radio" name="avatar" value="avatar-1.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-2.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-2.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-3.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-3.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-4.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-4.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-5.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-5.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                    </div>
                    <div class="form-row">
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-6.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-6.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-7.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-7.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-8.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-8.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-9.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-9.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                        <div class="col-md-2">
                            <div class="thumbnail">
                                <img src="/Pages/avatars/avatar-10.svg" alt="avatar" style="width:25%">
                                <div class="caption">
                                  <input type="radio" name="avatar" value="avatar-10.svg" required name="avatarVal">
                                </div>
                            </div>
                          </div>
                    </div>
                    <br />
                    <asp:Button id="createAccount" text="Create Account" runat="server" type="submit" CssClass="btn btn-primary" OnClick="checkAccount_Click"/>
                </form>
            </div>
        </div>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project2.Pages.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="stylesheet.css" />
    <script src="scripts.js"></script>
</head>
    <script>
        $(document).ready(function () {
            $('#button-reset').prop('disabled', true);
            $.fn.verify();
            $.fn.verifyTableData();
            $.fn.editTableData();
        })
    </script>
<body>
    <form id="order" runat="server">
            <div class="">
                <asp:Label ID="errorlabel" runat="server"></asp:Label>
            </div>
               <div>
                   <asp:RequiredFieldValidator ID="rfvfirstname" runat="server" ControlToValidate="firstname" ErrorMessage="Please enter something in the firstname textbox." InitialValue=""></asp:RequiredFieldValidator>
               </div>
                <div>
                    <asp:RequiredFieldValidator ID="rfvlastname" runat="server" ControlToValidate="lastname" ErrorMessage="Please enter something in the lastname textbox." InitialValue=""></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="rfvphonenumber" runat="server" ControlToValidate="phonenumber" ErrorMessage="Please enter something in the phonenumber textbox." InitialValue=""></asp:RequiredFieldValidator>
                </div>
            <div class="container" id="customerform" runat="server">
                <h1>Customer Information: </h1>
                <fieldset class="form-group">
                <div class="row">
                    <label for="firstname" class="col-sm-2 col-form-label">First Name: </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="firstname" runat="server" CssClass="form-control" placeholder="Please enter your first name here." pattern="[a-zA-Z]+" required></asp:TextBox>
                    </div>
                </div>
                    <br />
                <div class="row">
                    <label for="lastname" class="col-sm-2 col-form-label">Last Name: </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="lastname" runat="server" CssClass="form-control" placeholder="Please enter your last name here." pattern="[a-zA-Z]+" required></asp:TextBox>
                    </div>
                </div>
                    <br />
                <div class="warning" id="invalidPhoneNumber"></div>
                <div class="row">
                    <label for="phonenumber" class="col-sm-2 col-form-label">Phone Number: </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="phonenumber" runat="server" CssClass="form-control" placeholder="Please enter your phone number here." pattern="[a-zA-Z]+" required></asp:TextBox>
                     </div>
                </div>
                <br />
                <div class="row">
                    <label for="rewardsnumber" class="col-sm-2 col-form-label">Reward Number: </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="rewardsnumber" runat="server" CssClass="form-control" placeholder="Please enter your rewards number here if you have one." required></asp:TextBox>
                    </div>
                </div>
                    <br />
                    <div class="row">
                      <legend class="col-form-label col-sm-2 pt-0">Radios</legend>
                      <div class="col-sm-10">
                        <div class="form-check">
                          <input class="form-check-input" type="radio" name="gridRadios" value="Pickup at Store" required/>
                            <label class="form-check-label" for="gridRadios1">
                                Pickup at Store
                            </label>
                        </div>
                        <div class="form-check">
                          <input class="form-check-input" runat="server" type="radio" name="gridRadios" value="Normal Delivery" required/>
                          <label class="form-check-label" for="gridRadios2">
                            Normal Delivery
                          </label>
                        </div>
                        <div class="form-check disabled">
                          <input class="form-check-input" runat="server" type="radio" name="gridRadios" value="Curbside Delivery" required/>
                          <label class="form-check-label" for="gridRadios3">
                            Curbside Delivery
                          </label>
                        </div>
                      </div>
                    </div>
                  </fieldset>
                    <button type="button" id="button-submit" class="btn btn-primary">Complete Customer Information</button>
                    <button type="button" id="button-reset" class="btn btn-secondary btn-danger">Edit Information</button>
                </div>
            <div>
                <br />
                <br />
                <br />
        </div>
        <div class="container" runat="server" id="orderoutput" style="display: none">
            <div runat="server" id="customerdata">
                <h1>Your Order Information:</h1>
                <span class="badge badge-primary">Your Name:</span> <asp:Label ID="outputname" CssClass="badge badge-danger" runat="server"></asp:Label>
                <br />
                <span class="badge badge-primary">Your Phone Number:</span><asp:Label ID="outputphonenumber" CssClass="badge badge-danger" runat="server"></asp:Label>
                <br />
                <span class="badge badge-primary">Your Rewards Number:</span> <asp:Label ID="outputrewardsnumber" CssClass="badge badge-danger" runat="server"></asp:Label>
                <br />
                <span class="badge badge-primary">Your Delivery Choice:</span> <asp:Label ID="outputdelivery_choice" CssClass="badge badge-danger" runat="server"></asp:Label>
            </div>
            <div>
                <h1>Your Submitted Order:</h1>
                <asp:Gridview id="gvOutput" runat="server" ShowFooter="True" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed">
                    <Columns>
                        <asp:BoundField DataField="item_title" HeaderText="Drink Name" ReadOnly="true" />
                        <asp:BoundField DataField="item_description" HeaderText="Drink Description" ReadOnly="true" />
                        <asp:BoundField DataField="item_size" HeaderText="Drink Size" ReadOnly="true" />
                        <asp:BoundField DataField="item_category" HeaderText="Drink Temperature" ReadOnly="true" />
                        <asp:BoundField DataField="item_price" HeaderText="Drink Price" ReadOnly="true" />
                        <asp:BoundField DataField="item_order_amount" HeaderText="Order Amount" ReadOnly="true" />
                        <asp:BoundField DataField="item_total_price" DataFormatString="{0:c}" HeaderText="Total Item Cost" ReadOnly="true" />
                    </Columns>
                </asp:Gridview>
            </div>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button ID="neworderbutton" runat="server" Text="New Order" OnClick="resetForm_Click" CssClass="btn btn-primary" UseSubmitBehavior="false"/>
                    <asp:Button id="managementbutton" runat="server" Text="View Management Report" OnClick="showManagementReport_Click" CssClass="btn btn-secondary btn-danger" UseSubmitBehavior="false"/>
                </div> 
            </div>
        </div>
        <div class="hidden-form" id="orderform" runat="server" >
            <div class ="container">
                <h1>Order Products: </h1>
            <div>
                <div class="warning" id="invalidOrder"></div>
                <asp:GridView ID="gvCoffee" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed">
                    <Columns>
                        <asp:TemplateField HeaderText="Add to Order">
                            <ItemTemplate>
                                <asp:CheckBox ID="checkbox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="item_id" ItemStyle-CssClass="hiddenCol" HeaderStyle-CssClass="hiddenCol" ReadOnly="true"/>
                        <asp:BoundField DataField="item_title" HeaderText="Drink Name" ReadOnly="true" />
                        <asp:BoundField DataField="item_description" HeaderText="Drink Description" ReadOnly="true" />
                        <asp:BoundField DataField="item_base_price" HeaderText="Drink Price" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Hot or Cold?">
                            <ItemTemplate>
                                <asp:DropDownList ID="temperature_choice" runat="server">
                                    <asp:ListItem Text="Hot" Value="Hot"></asp:ListItem>
                                    <asp:ListItem Text="Cold" Value="Cold"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Drink Size">
                            <ItemTemplate>
                                <asp:DropdownList id="drink_size" runat="server">
                                    <asp:ListItem Text="Tall" Value="Tall"></asp:ListItem>
                                    <asp:ListItem Text="Grande" Value="Grande"></asp:ListItem>
                                    <asp:ListItem Text="Venti" Value="Venti"></asp:ListItem>
                                    <asp:ListItem Text="Trenta" Value="Trenta"></asp:ListItem>
                                </asp:DropdownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="order_quantity" runat="server" CssClass="form-control" pattern="[0-9]+" CausesValidation="true"></asp:TextBox>
                                <asp:CustomValidator ID="cfvorderquantity" runat="server" ControlToValidate="order_quantity" ErrorMessage ="Please enter something in the order textbox." OnServerValidate="validateTextbox_OnServerValidate"></asp:CustomValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:GridView id="gvTea" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed">
                    <Columns>
                        <asp:TemplateField HeaderText="Add to Order">
                                <ItemTemplate>
                                    <asp:CheckBox id="checkbox" runat="server" />
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="item_id" ItemStyle-CssClass="hiddenCol" HeaderStyle-CssClass="hiddenCol" ReadOnly="true"/>
                        <asp:BoundField DataField="item_title" HeaderText="Drink Name" ReadOnly="true" />
                        <asp:BoundField DataField="item_description" HeaderText="Drink Description" ReadOnly="true" />
                        <asp:BoundField DataField="item_base_price" HeaderText="Drink Price" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Hot or Cold">
                            <ItemTemplate>
                                <asp:DropDownList ID="temperature_choice" runat="server">
                                    <asp:ListItem Text="Hot" Value="Hot"></asp:ListItem>
                                    <asp:ListItem Text="Cold" Value="Cold"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Drink Size">
                            <ItemTemplate>
                                <asp:DropdownList id="drink_size" runat="server">
                                    <asp:ListItem Text="Tall" Value="Tall"></asp:ListItem>
                                    <asp:ListItem Text="Grande" Value="Grande"></asp:ListItem>
                                    <asp:ListItem Text="Venti" Value="Venti"></asp:ListItem>
                                    <asp:ListItem Text="Trenta" Value="Trenta"></asp:ListItem>
                                </asp:DropdownList>    
                            </ItemTemplate>            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="order_quantity" runat="server" CssClass="form-control" pattern="[0-9]+" CausesValidation="true"></asp:TextBox>
                                <asp:CustomValidator ID="cfvorderquantity" runat="server" ControlToValidate="order_quantity" ErrorMessage ="Please enter something in the order textbox." OnServerValidate="validateTextbox_OnServerValidate"></asp:CustomValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                <div id="outputbuttons">
                <div class="form-group row hidden-verify-button" id="order-verify-button">
                    <div class="col-sm-10">
                        <button type="button" class="btn btn-primary" id="button-verify">Verify Order</button>
                    </div>
                </div>
                <div class="form-group row hidden-submit-button" id="order-submit-button">
                    <div class="col-sm-10">
                        <asp:Button id="buildOrderObject" runat="server" Text="Submit Order" OnClick="buildOrderObject_Click" CssClass="btn btn-primary"/>
                        <button type="button" id="button-edit" class="btn btn-secondary btn-danger">Edit Information</button>
                    </div>
                </div> 
                </div>
                </div>
        </div>
        </form>
    </body>
</html>
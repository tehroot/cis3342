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
<body>
    <div class="container" id="customer-info">
    <form>
        <div class="form-group row">
            <label for="firstname" class="col-sm-2 col-form-label">First Name: </label>
            <div class="col-sm-8">
                <input type="text" class="form-control" id="firstnname" placeholder="Please enter your first name here." required/>
            </div>
        </div>
        <div class="form-group row">
            <label for="lastname" class="col-sm-2 col-form-label">Last Name: </label>
            <div class="col-sm-8">
                <input type="text" class="form-control" id="lastname" placeholder="Please enter your last name here." required/>
            </div>
        </div>
        <div class="form-group row">
            <label for="phonenumber" class="col-sm-2 col-form-label">Phone Number: </label>
            <div class="col-sm-8">
                <input type="text" class="form-control" id="phonenumber" placeholder="Please enter your phone number here." required/>
             </div>
        </div>
        <div class="form-group row">
            <label for="rewardsnumber" class="col-sm-2 col-form-label">Customer Reward Number: </label>
            <div class="col-sm-8">
                <input type="text" class="form-control" id="rewardsnumber" placeholder="Please enter your rewards number here."/>
            </div>
        </div>
        <fieldset class="form-group">
            <div class="row">
              <legend class="col-form-label col-sm-2 pt-0">Radios</legend>
              <div class="col-sm-10">
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="Pickup at Store" required/>
                    <label class="form-check-label" for="gridRadios1">
                        Pickup at Store
                    </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios2" value="Normal Delivery" required/>
                  <label class="form-check-label" for="gridRadios2">
                    Normal Delivery
                  </label>
                </div>
                <div class="form-check disabled">
                  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios3" value="Curbside Delivery" required/>
                  <label class="form-check-label" for="gridRadios3">
                    Curbside Delivery
                  </label>
                </div>
              </div>
            </div>
          </fieldset>
        <div class="form-group row">
            <div class="col-sm-10">
                <button type="submit" class="btn btn-primary">Sign in</button>
            </div>
        </div>
    </form>   
    </div>    
    <div class="container" id="order-form">
    <form id="form1" runat="server">
        <h1>Test</h1>
        <div>
            <asp:GridView ID="gvCoffee" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed">
                <Columns>
                    <asp:TemplateField HeaderText="Add to Order">
                        <ItemTemplate>
                            <asp:CheckBox ID="checkbox" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                            <asp:TextBox ID="order_quantity" runat="server" CssClass="form-control"></asp:TextBox>
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
                            <asp:TextBox ID="txtQtyAdd" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="buildOrderObject" runat="server" Text="Display Products" OnClick="buildOrderObject_Click" OnClientClick="return $.fn.verifyOrders()"/>
    </form>
    </div>
</body>
</html>
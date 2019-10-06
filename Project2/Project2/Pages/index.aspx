﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project2.Pages.index" %>

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
            $.fn.getTableData();
        })
    </script>
<body>
    <form id="order" runat="server">
            <div class="container" id="customerform">
                <h1>Customer Information: </h1>
                <fieldset class="form-group">
                <div class="row">
                    <label for="firstname" class="col-sm-2 col-form-label">First Name: </label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="firstnname" name="firstname" placeholder="Please enter your first name here." pattern="[a-zA-Z]+"/>
                    </div>
                </div>
                    <br />
                <div class="row">
                    <label for="lastname" class="col-sm-2 col-form-label">Last Name: </label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="lastname" name="lastname" placeholder="Please enter your last name here." pattern="[a-zA-Z]+" />
                    </div>
                </div>
                    <br />
                <div class="warning" id="invalidPhoneNumber"></div>
                <div class="row">
                    <label for="phonenumber" class="col-sm-2 col-form-label">Phone Number: </label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="phonenumber" name="phonenumber" placeholder="Please enter your phone number here."/>
                     </div>
                </div>
                <br />
                <div class="row">
                    <label for="rewardsnumber" class="col-sm-2 col-form-label">Reward Number: </label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="rewardsnumber" name="rewardsnumber" placeholder="Please enter your rewards number here."/>
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
                          <input class="form-check-input" type="radio" name="gridRadios" value="Normal Delivery" required/>
                          <label class="form-check-label" for="gridRadios2">
                            Normal Delivery
                          </label>
                        </div>
                        <div class="form-check disabled">
                          <input class="form-check-input" type="radio" name="gridRadios" value="Curbside Delivery" required/>
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
        <div class="hidden-form" id="order-form">
            <div class ="container">
                <h1>Order Products: </h1>
            <div>
                <asp:GridView ID="gvCoffee" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed">
                    <Columns>
                        <asp:TemplateField HeaderText="Add to Order">
                            <ItemTemplate>
                                <asp:CheckBox ID="checkbox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="item_id" ItemStyle-CssClass="hidden-form" HeaderStyle-CssClass="hidden-form" ReadOnly="true"/>--%>
                        <asp:BoundField DataField="item_id" HeaderText="Id" ReadOnly="true"/>
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
                                <asp:TextBox ID="order_quantity" runat="server" CssClass="form-control" pattern="[0-9]+"></asp:TextBox>
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
                        <%--<asp:BoundField DataField="item_id" ItemStyle-CssClass="hidden-form" HeaderStyle-CssClass="hidden-form" ReadOnly="true"/>--%>
                        <asp:BoundField DataField="item_id" HeaderText="Id" ReadOnly="true"/>
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
                                <asp:TextBox ID="txtQtyAdd" runat="server" CssClass="form-control" pattern="[0-9]+"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                <div class="form-group row">
                    <div class="col-sm-10">
                        <button type="button" class="btn btn-primary" id="button-verify">Verify Order</button>
                    </div>
                </div>
                <div class="form-group row hidden-form" id="order-submit-button">
                    <div class="col-sm-10">
                        <asp:Button ID="buildOrderObject" runat="server" Text="Submit Order" OnClick="buildOrderObject_Click" OnClientClick="" CssClass="btn btn-primary"/>
                    </div>
                </div> 
            </div>
        </div>
        </form>
    </body>
</html>
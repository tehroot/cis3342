﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userform.aspx.cs" Inherits="Project2.Pages.userform" %>

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
    <script><

    </script>
<body>
    <form id="form1" runat="server">
        <div class="">
            <h1>Management Report: </h1>
           <asp:GridView ID="gvManagementReport" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed">
               <Columns>
                   <asp:BoundField DataField="item_title" HeaderText="Drink Name" ReadOnly="true" />
                   <asp:BoundField DataField="item_description" HeaderText="Drink Description" ReadOnly="true" />
                   <asp:BoundField DataField="item_total_sales" HeaderText="Drink Gross Sales" ReadOnly="true" DataFormatString="{0:c}"/>
                   <asp:BoundField DataField="item_quantity_sold" HeaderText="Total Drink Units Sold" ReadOnly="true" />
               </Columns>
           </asp:GridView>
            <h1>Rewards Report: </h1>
            <asp:GridView ID="gvManagementRewards" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed"> 
                <Columns>
                    <asp:BoundField DataField="customer_reward_id" HeaderText="Rewards Customer ID" ReadOnly="true" />
                    <asp:BoundField DataField="customer_name" HeaderText="Rewards Customer Name" ReadOnly="true" />
                    <asp:BoundField DataField="customer_gross_sales" HeaderText="Rewards Customer Gross Sales" ReadOnly="true" DataFormatString="{0:c}"/>
                </Columns>
            </asp:GridView>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button ID="neworderbutton" runat="server" Text="New Order" OnClick="resetForm_Click" CssClass="btn btn-primary" UseSubmitBehavior="false"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

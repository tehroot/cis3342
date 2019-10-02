<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project2.Pages.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
    <form id="form1" runat="server">
            <asp:GridView ID="gvCoffee" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkbox" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="item_title" HeaderText="Drink Name" ReadOnly="true" />
                    <asp:BoundField DataField="item_description" HeaderText="Drink Description" ReadOnly="true" />
                    <asp:BoundField DataField="item_base_price" HeaderText="Drink Price" ReadOnly="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="size_choice" runat="server">
                                <asp:ListItem Text="Hot" Value="Hot"></asp:ListItem>
                                <asp:ListItem Text="Cold" Value="Cold"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
    </form>
    </div>
</body>
</html>

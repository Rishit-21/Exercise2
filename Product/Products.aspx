<%@ Page Title="" Language="C#" Theme="ProductPage" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Exercise2.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ProductPageHeading">
            <asp:Label ID="ProductHeading" runat="server" Text="Product List"></asp:Label>
        </div>
        <div class="btnDiv">
            <asp:Button CssClass="addBtn" ID="addProdBtn" runat="server" Text="Add New Product" PostBackUrl="~/Product/AddProducts.aspx" />
        </div>
        <div class="productMsgLblCls">
            <asp:Label ID="ProductlistMsgLbl" runat="server" Text=""></asp:Label>
        </div>

        <div class="productGridView">
            <asp:GridView CssClass="gridCls" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
                    <asp:TemplateField HeaderText="action">
                        <ItemTemplate>
                            <asp:Button ID="editBtn" CssClass="editBtn" runat="server" Text="edit" OnClick="editBtn_Click" />
                            <asp:Button CssClass="delBtn" ID="deleteBtn" runat="server" Text="delete" OnClientClick="Confirm()" OnClick="deleteBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="editBtn" CommandName="Edit" HeaderText="Action" ShowHeader="True" Text="Edit" />
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="delBtn" CommandName="Del" Text="Delete" />--%>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:partyProductConnectionString2 %>" SelectCommand="SELECT * FROM [product]"></asp:SqlDataSource>--%>
        </div>
    </div>
</asp:Content>

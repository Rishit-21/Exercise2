<%@ Page Title="" Language="C#" Theme="ProductRateListpage" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="productRateList.aspx.cs" Inherits="Exercise2.ProductRateListFldr.productRateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
     <div class="ProductRatePageHeading">
        <asp:Label ID="ProductRateHeading" runat="server" Text="Product Rate  List"></asp:Label>
     </div>
    <div class="productRateMsgLbl">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    <div class="btnDiv">
         <asp:Button CssClass="addBtn" ID="addProductRateBtn" runat="server" Text="Add new ProductRate" PostBackUrl="~/ProductRateListFldr/addProductRate.aspx" />
    </div>
    <div class="prodRateGridView">
        <asp:GridView CssClass="gridCls" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="productRateId" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="productRateId" HeaderText="productRateId" InsertVisible="False" ReadOnly="True" SortExpression="productRateId" />
                <asp:BoundField DataField="productName" HeaderText="productId" SortExpression="productId" />
                <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                <asp:BoundField DataField="dateOfRate" HeaderText="dateOfRate" SortExpression="dateOfRate" />
                <asp:ButtonField ButtonType="Button" CommandName="Edi" ControlStyle-CssClass="editBtn" HeaderText="Action" ShowHeader="True" Text="Edit" />
                <asp:ButtonField ButtonType="Button" CommandName="Del" ControlStyle-CssClass="delBtn" Text="Delete" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

       

    </div>
    </div>
</asp:Content>

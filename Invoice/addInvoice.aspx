<%@ Page Title="" Language="C#" Theme="InvoicePage" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addInvoice.aspx.cs" Inherits="Exercise2.Invoice.addInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clsAddInvoice">
        <asp:Label class="invoiceAddLbl" ID="InvoiceAdd" runat="server" Text="Invoice Add"></asp:Label>
    </div>
    <div class="addInvoceMsglbl">
        <asp:Label  ID="Label2" runat="server" Text=""></asp:Label>
    </div>
    <div class="addMainCls">
        <div class="partyLableCls">
        <asp:Label CssClass="PartyNam" ID="PartyName" runat="server" Text="Party Name: "></asp:Label>
        </div>
        <div class="partyInvoiceDrpCls">
            <asp:DropDownList CssClass="AssignParty" ID="AssignPartyDrp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AssignPartyDrp_SelectedIndexChanged">
               <asp:ListItem Value="SelectProduct" >Select Party</asp:ListItem>
            </asp:DropDownList>
        </div>
        </div>
         <div class="addMainCls2">
           <div class="productLableCls">
        <asp:Label CssClass="productNam" ID="Label1" runat="server" Text="Product Name: "></asp:Label>
        </div>
        <div class="productInvoiceDrpCls">
            <asp:DropDownList CssClass="AssignProduct" ID="AssignProductDrp" AutoPostBack="true" runat="server" OnSelectedIndexChanged="AssignProductDrp_SelectedIndexChanged">
               <asp:ListItem Value="SelectProduct" >Select Product</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="addMainCls3">
        <div class="currentRateLableCls">
        <asp:Label CssClass="currentRateLbl" ID="CurrentRateLblId" runat="server" Text="Current Rate: "></asp:Label>
        </div>
        <div class="currentRateTxtCls">
            <asp:TextBox CssClass="currentRate" ID="CurrentRateID" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator class="validateClass" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="CurrentRateID">*cannot be empty</asp:RequiredFieldValidator>
        </div>
    </div>
        <div class="addMainCls4">
        <div class="quantityLableCls">
        <asp:Label CssClass="quantitybl" ID="QuantityIdLbl" runat="server" Text="Quantity: "></asp:Label>
        </div>
        <div class="quantityTxtCls">
            <asp:TextBox CssClass="quantity" ID="quantityTxtid" runat="server"></asp:TextBox><br />
          <asp:RequiredFieldValidator class="validateClass" ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="quantityTxtid">*cannot be empty</asp:RequiredFieldValidator>

        </div>
    </div>
      <div class="assignInvoiceAddBtns">
            <asp:Button CssClass="addToInvoiceBtn" ID="AddToInvoiceBtnId" runat="server" Text="Add To Invoice" OnClick="AddToInvoiceBtnId_Click"/>
        </div>
    <div class="invoiceGridView">
        <asp:GridView CssClass="gridCls" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="invoiceId"  ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="invoiceId" HeaderText="invoiceId" InsertVisible="False" ReadOnly="True" SortExpression="invoiceId" />
                <asp:BoundField DataField="partyName" HeaderText="partyName" SortExpression="partyId" />
                <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productId" />
                <asp:BoundField DataField="rateOfProduct" HeaderText="rateOfProduct" SortExpression="rateOfProduct" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
              
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
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:partyProductConnectionString5 %>" SelectCommand="SELECT * FROM [invoice]"></asp:SqlDataSource>--%>
    </div>
    <div class="grandTtlLbl">
        <asp:Label CssClass="grandTotolLblCls" ID="GarndTotallblId" runat="server" Text="Grand Total: "></asp:Label>
        <asp:Label CssClass="grandValueCls" ID="GarndTotalValueId" runat="server" Text=""></asp:Label>
    </div>
          <div class="assignInvoiceCloseBtns">
            <asp:Button CssClass="cLoseToInvoiceBtn"  CausesValidation="false" ID="ClosetoInvoiceBtnId" runat="server" Text="Close Invoice" OnClick="ClosetoInvoiceBtnId_Click"/>
        </div>
</asp:Content>

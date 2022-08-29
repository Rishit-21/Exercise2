<%@ Page Title="" Language="C#" Theme="AddProducts" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="Exercise2.AddProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="clsAddProducts">
        <asp:Label class="productAddLbl" ID="ProductAdd" runat="server" Text="Product Add"></asp:Label>
    </div>
    <div class="productMsgCls">
         <asp:Label  ID="ProductAddMsg" runat="server" Text=""></asp:Label>
    </div>
    <div class="addMainCls">
        <div class="productLableCls">
        <asp:Label CssClass="productNam" ID="ProductName" runat="server" Text="Product Name: "></asp:Label>
        </div>
        <div class="productTxtCls">
        <asp:TextBox CssClass="AddProduct" ID="addProductTxt" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator class="validateClass"  ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="addProductTxt">*cannot be empty</asp:RequiredFieldValidator>
      
    </div>
        <div class="addProductBtns">
            <asp:Button CssClass="saveBtn" ID="saveBtnId" runat="server" Text="Save" OnClick="saveBtnId_Click" />
            <asp:Button CssClass="updateBtn" ID="UpdateBtnId" runat="server" Text="Update" Visible="false" OnClick="UpdateBtnId_Click" />
            <asp:Button CssClass="CancelBtn"  CausesValidation="false" ID="cancelBtnId" runat="server" Text="Cancel" OnClick="cancelBtnId_Click" />
        </div>
</asp:Content>

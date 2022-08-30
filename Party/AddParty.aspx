<%@ Page Title="" Language="C#" Theme="AddParty" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddParty.aspx.cs" Inherits="Exercise2.AddParty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clsAddParty">
        <asp:Label class="partyAddLbl" ID="PartyAdd" runat="server" Text="Party Add"></asp:Label>
    </div><br />
    <div class="addPartyLblMsg">
        <asp:Label  ID="PartyAddMsg" runat="server" Text=""></asp:Label>
    </div>
    <div class="addMainCls">
        <div class="partyLableCls">
        <asp:Label CssClass="partyNam" ID="PartyName" runat="server" Text="Party Name: "></asp:Label>
        </div>
        <div class="partyTxtCls">
        <asp:TextBox CssClass="AddParty" ID="addPartyTxt" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator class="validateClass" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="addPartyTxt">*cannot be empty</asp:RequiredFieldValidator>
        </div>
      
    </div>
        <div class="addPartyBtns">
            <asp:Button CssClass="saveBtn" ID="saveBtnId" runat="server" Text="Save" OnClick="saveBtnId_Click" />
            <asp:Button CssClass="updateBtn" ID="UpdateBtnId" runat="server" Text="Update" Visible="false" OnClick="UpdateBtnId_Click" />
            <asp:Button CssClass="CancelBtn" ID="cancelBtnId" CausesValidation="false" runat="server" Text="Cancel" OnClick="cancelBtnId_Click" />
        </div>
</asp:Content>

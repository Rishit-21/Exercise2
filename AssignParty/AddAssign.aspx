<%@ Page Title="" Language="C#" Theme="AddAssign" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddAssign.aspx.cs" Inherits="Exercise2.Assign_Party.AddAssign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="clsAssignParty">
        <asp:Label class="partyAssignLbl" ID="PartyAssign" runat="server" Text="Assign Party Add"></asp:Label>
    </div>
    <div class="addAssignMsgLblcls">
        <asp:Label  ID="Label2" runat="server" Text=""></asp:Label>
    </div>
    <div class="addMainCls">
        <div class="partyLableCls">
        <asp:Label CssClass="partyNam" ID="PartyName" runat="server" Text="Party Name: "></asp:Label>
        </div>
        <div class="partyDrpCls">
            <asp:DropDownList CssClass="AssignParty" ID="AssignPartyDrp" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="AssignPartyDrp_SelectedIndexChanged" >
               <asp:ListItem Value="SelectParty" >Select Party</asp:ListItem>
            </asp:DropDownList>
           
        </div>
        </div>
         <div class="addMainCls2">
        <div class="ProductLableCls">
        <asp:Label CssClass="ProductNam" ID="Label1" runat="server" Text="Product Name: "></asp:Label>
        </div>
        <div class="partyDrpCls">
            <asp:DropDownList CssClass="AssignProduct" ID="AssignProductDrp" runat="server">
                 <asp:ListItem Value="SelectProduct" >Select Product</asp:ListItem>
            </asp:DropDownList>
                                   
        </div>
    </div>
        <div class="assignPartyBtns">
            <asp:Button CssClass="saveBtn" ID="saveBtnId" runat="server" Text="Save" OnClick="saveBtnId_Click" />
            <asp:Button CssClass="updateBtn" ID="UpdateBtnId" runat="server" Text="Update" Visible="false" OnClick="UpdateBtnId_Click" />
            <asp:Button CssClass="CancelBtn" ID="cancelBtnId" CausesValidation="false" runat="server" Text="Cancel" OnClick="cancelBtnId_Click" />
        </div>
</asp:Content>


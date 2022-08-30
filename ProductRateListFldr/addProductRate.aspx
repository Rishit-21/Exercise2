<%@ Page Title="" Language="C#" Theme="AddProductRatePage" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addProductRate.aspx.cs" Inherits="Exercise2.ProductRateListFldr.addProductRate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="clsProductRateAdd">
        <asp:Label class="productRateLbl" ID="ProductRate" runat="server" Text="Product Rate Add"></asp:Label>
    </div>
    <div class="productRateLblMsg">

         <asp:Label  ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    <div class="addMainCls">
        <div class="productLableCls">
        <asp:Label CssClass="productNam" ID="ProductName" runat="server" Text="Product Name: "></asp:Label>
        </div>
        <div class="productDrpCls">
            <asp:DropDownList CssClass="AssignProduct" ID="AssignProductDrp" runat="server" AutoPostBack="true">
               <asp:ListItem Value="SelectProduct" >Select Product</asp:ListItem>
            </asp:DropDownList>
        </div>
        </div>
         <div class="addMainCls2">
        <div class="ProductRateLableCls">
        <asp:Label CssClass="ProductRate" ID="prodRateId" runat="server" Text="Product Rate: "></asp:Label>
        </div>
        <div class="productRateTxtCls">
            <asp:TextBox CssClass="addProductRate" ID="addProductRateTxtId" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator class="validateClass" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="addProductRateTxtId">*cannot be empty</asp:RequiredFieldValidator>
        </div>
    </div>
          <div class="addMainCls3">
        <div class="rateDateLableCls">
        <asp:Label CssClass="RateDate" ID="rateDateId" runat="server" Text="Date Of Rate: "></asp:Label>
        </div>
        <div class="rateDateTxtCls">
            <asp:TextBox CssClass="addRateDate" ID="addRateDateID" Enabled="false" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="select date" OnClick="Button1_Click" />
            <asp:Calendar  ID="Calendar1" Visible="False" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
        </div>
    </div>
        <div class="assignProductRateBtns">
            <asp:Button CssClass="saveBtn" ID="saveBtnId" runat="server" Text="Save" OnClick="saveBtnId_Click" />
              <asp:Button CssClass="updateBtn" ID="UpdateBtnId" runat="server" Text="Update" Visible="false" OnClick="UpdateBtnId_Click" />
            <asp:Button CssClass="CancelBtn" ID="cancelBtnId"  CausesValidation="false" runat="server" Text="Cancel" OnClick="cancelBtnId_Click" />
        </div>
</asp:Content>

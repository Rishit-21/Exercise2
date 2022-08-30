<%@ Page Title="" Language="C#" Theme="PartyPage" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Party.aspx.cs" Inherits="Exercise2.Party" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/PartyPage/StyleSheet1.css" rel="stylesheet" />
    <script src="../JavaScript1.js"></script>
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <div class="PartyPageHeading">
         <asp:Label ID="PartyHeading" runat="server" Text="Party List"></asp:Label><br /><br />                      
     </div>
        <div class="partyMsgLbl">
          <asp:Label ID="PartyMsgLbl" runat="server" Text=""></asp:Label>
        </div>
    <div class="btnDiv">
    <asp:Button CssClass="addBtn" ID="addPrtyBtn" runat="server" Text="Add Party" PostBackUrl="~/Party/AddParty.aspx"  />
        <br />
        
    </div>
        <div class="gridView">
             <asp:GridView CssClass="gridCls" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id"  >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="PartyName" HeaderText="PartyName" SortExpression="PartyName" />
                           <asp:templatefield headertext="action">
                            <itemtemplate>
                             <asp:button id="edit"  CssClass="editBtn" runat="server" text="edit" OnClick="edit_Click" />
                                <asp:button Cssclass="delBtn"  id="delete" runat="server" text="delete" OnClientClick="Confirm()" OnClick="delete_Click"/>
                            </itemtemplate>
                        </asp:templatefield>

<%--                <asp:ButtonField ButtonType="Button" HeaderText="Action" ControlStyle-CssClass="editBtn" CommandName="Edit" Text="Edit" />
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="delBtn" CommandName="Del" ShowHeader="True" Text="Delete" />--%>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
             <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:partyProductConnectionString %>" SelectCommand="SELECT * FROM [party]"></asp:SqlDataSource>--%>
        </div>
    </div>
</asp:Content>

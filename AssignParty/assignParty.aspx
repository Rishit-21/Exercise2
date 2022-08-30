<%@ Page Title="" Language="C#" Theme="AssignParty" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="assignParty.aspx.cs" Inherits="Exercise2.Assign_Party.assignParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript1.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="AssignPartyPageHeading">
            <asp:Label ID="AssignPartyHeading" runat="server" Text=" Assign Party List"></asp:Label>
        </div>
        <div class="assignPartyMsgLblcls">
            <asp:Label ID="AssignPartyMsg" runat="server" Text=""></asp:Label>
        </div>
        <div class="btnDiv">
            <asp:Button CssClass="addBtn" ID="addAssignBtn" runat="server" Text="Assign New Party" PostBackUrl="~/AssignParty/AddAssign.aspx" />
        </div>
        <div class="assignGridView">
            
            <asp:GridView CssClass="gridCls" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="assignId" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="assignId" HeaderText="Assign Id" InsertVisible="False" ReadOnly="True" SortExpression="assignId" />
                    <asp:BoundField DataField="partyName" HeaderText="Party Name" SortExpression="partyName" />
                    <asp:BoundField DataField="productName" HeaderText="Product Name" SortExpression="productName" />
                            <asp:templatefield headertext="action">
                            <itemtemplate>
                                <asp:button id="button1"  CssClass="editBtn" runat="server" text="edit" OnClick="button1_Click"   />
                                <asp:button Cssclass="delBtn"  id="button2" runat="server" text="delete" OnClientClick="Confirm()" OnClick="button2_Click"  />
                            </itemtemplate>
                        </asp:templatefield>

                    <%--<asp:ButtonField ButtonType="Button" CommandName="Edi" ControlStyle-CssClass="editBtn" HeaderText="Action" ShowHeader="True" Text="Edit">
                        <ControlStyle CssClass="editBtn"></ControlStyle>
                    </asp:ButtonField>
                    <asp:ButtonField CommandName="Del" ControlStyle-CssClass="delBtn" Text="Delete" ButtonType="Button">
                        <ControlStyle CssClass="delBtn"></ControlStyle>
                    </asp:ButtonField>--%>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:partyProductConnectionString3 %>" SelectCommand="SELECT * FROM [assignProduct]"></asp:SqlDataSource>--%>
        </div>
    </div>
</asp:Content>

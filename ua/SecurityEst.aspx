<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SecurityEst.aspx.vb" Inherits="ua_SecurityEstDiv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Security Est.</h2>
    <hr />
    <div class="pageinfo">
        <div class="gvborder">
            <asp:GridView ID="gvSecurityEst" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="SecurityEst_ID" BorderWidth="0px" CssClass="gv" ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="Security Est. ID">
                        <ItemTemplate>
                            <asp:Label ID="lblSecurityEst_ID" runat="server" Text='<%# Bind("SecurityEst_ID")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Security Est. Title">
                        <ItemTemplate>
                            <asp:Label ID="lblSecurityEst_Title" runat="server" Text='<%# Bind("SecurityEst_Title")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="40%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Security Est. Division">
                        <ItemTemplate>
                            <asp:Label ID="lblSecurityEstDiv_Name" runat="server" Text='<%# Bind("SecurityEstDiv_Name")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="30%" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" CausesValidation="False" CommandName="Edit" ToolTip="Edit" ImageUrl="../image/icon/ico_gv_edit.png" PostBackUrl='<%# Eval("SecurityEst_ID","SecurityEst_Edit.aspx?sid={0}") %>' />
                            <span onclick="return confirm('Are you sure you want to delete it?')">
                                <asp:ImageButton ID="ibtnDelete" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" ImageUrl="../image/icon/ico_gv_delete.png" />
                            </span>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ibtnInsert" runat="server" CausesValidation="False" ToolTip="Add New" ImageUrl="../image/icon/ico_gv_add.png" PostBackUrl="~/ua/SecurityEst_Add.aspx" />
                        </FooterTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
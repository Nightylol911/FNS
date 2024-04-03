<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SecurityEstDiv.aspx.vb" Inherits="ua_SecurityEstDiv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Security Est. Divisions</h2>
    <hr />
    <div class="pageinfo">
        <div class="gvborder">
            <asp:GridView ID="gvSecurityEstDiv" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="SecurityEstDiv_ID" BorderWidth="0px" CssClass="gv" ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="Security Est. ID">
                        <ItemTemplate>
                            <asp:Label ID="lblSecurityEst_ID" runat="server" Text='<%# Bind("SecurityEstDiv_ID")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblSecurityEstDiv_" runat="server" Text="Security Est. Division:"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvlblSecurityEstDiv" runat="server" ControlToValidate="txtSecurityEstDiv_NameI" ErrorMessage="Enter Security Est. Name!" Text="*" ForeColor="Red" ValidationGroup="vgInsert" />
                        </FooterTemplate>
                        <ItemStyle Width="43%" />
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Security Est. Division">
                        <ItemTemplate>
                            <asp:Label ID="lblSecurityEstDiv_Name" runat="server" Text='<%# Bind("SecurityEstDiv_Name")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSecurityEstDiv_NameE" runat="server" Width="90%" Text='<%# Bind("SecurityEstDiv_Name")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSecurityEstDiv_NameI" runat="server" Width="90%" ValidationGroup="vgInsert"></asp:TextBox>
                        </FooterTemplate>
                        <ItemStyle Width="43%" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" CausesValidation="False" CommandName="Edit" ToolTip="Edit" ImageUrl="../image/icon/ico_gv_edit.png" />
                            <span onclick="return confirm('Are you sure you want to delete it?')">
                                <asp:ImageButton ID="ibtnDelete" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" ImageUrl="../image/icon/ico_gv_delete.png" />
                            </span>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ibtnUpdate" runat="server" CausesValidation="True" CommandName="Update" ToolTip="Update" ImageUrl="../image/icon/ico_gv_update.png" />
                            &nbsp;
                            <asp:ImageButton ID="ibtnCancel" runat="server" CausesValidation="False" CommandName="Cancel" ToolTip="Cancel" ImageUrl="../image/icon/ico_gv_cancel.png" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ibtnInsert" runat="server" CausesValidation="True" CommandName="Insert" ToolTip="Add New" ImageUrl="../image/icon/ico_gv_add.png" ValidationGroup="vgInsert" />
                        </FooterTemplate>
                        <ItemStyle Width="14%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
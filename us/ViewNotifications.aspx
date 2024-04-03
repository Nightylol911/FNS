<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewNotifications.aspx.vb" Inherits="us_ViewNotifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>View Notifications</h2>
        <hr />
        <div class="pageinfo">
            <div class="gvborder">
                <asp:GridView ID="dvNotifications" runat="server" AutoGenerateColumns="false" DataKeyNames="Notification_Seq" BorderWidth="0" CssClass="gv">
                    <Columns>
                        <asp:TemplateField HeaderText="Location Title">
                            <ItemTemplate>
                                <%# Eval("Location_Title")%>
                            </ItemTemplate>
                            <ItemStyle Width="43%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notification Type">
                            <ItemTemplate>
                                <span style="color: Red;">Fire</span>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notification Date">
                            <ItemTemplate>
                                <%# Eval("Notification_DateTime")%>
                            </ItemTemplate>
                            <ItemStyle Width="30%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <a href="ViewNotification.aspx?ns=<%# Eval("Notification_Seq") %>">
                                    <img width="23px" border="0" src="../image/icon/ico_View.png" style="" alt="" />
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>


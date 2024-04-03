<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="uc_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="A">
        <table style="margin-left: auto; margin-right: auto;">
            <tr>
                <td>
                    <a href="/uc/AddNewDevice.aspx">
                        <div class="btnbox">
                            <div style="width: auto; margin-top: 10px;">Add New Device</div>
                            <div style="width: auto; margin-top: 35px;"><img src='../image/icon/ico_addDevice.png' style="width: 64px; height: 64px;" alt="" /></div>
                        </div>
                    </a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


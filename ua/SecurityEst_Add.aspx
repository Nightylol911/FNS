<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SecurityEst_Add.aspx.vb" Inherits="ua_SecurityEst_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDIit_gaDuTf2DS4orWT2lHwYmKGbhtc5M&sensor=false" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            var mapOptions = {
                center: new google.maps.LatLng(24.713024, 46.675531),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById("mapContainer"), mapOptions);

            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                    map.setCenter(initialLocation);
                });
            }

            var gmarkers = [];
            var marker;
            google.maps.event.addListener(map, 'click', function (e) {
                //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());

                document.getElementById("<%=hfLat.ClientID %>").value = e.latLng.lat();
                document.getElementById("<%=hfLon.ClientID %>").value = e.latLng.lng();

                for (i = 0; i < gmarkers.length; i++) {
                    gmarkers[i].setMap(null);
                }
                marker = new google.maps.Marker({ position: new google.maps.LatLng(e.latLng.lat(), e.latLng.lng()), map: map });
                gmarkers.push(marker);
                marker.setMap(map);
            });
        }

        function ClientVal(sender, e) {
            var ctrl1 = document.getElementById('<%= hfLat.ClientID %>');
            var ctrl2 = document.getElementById('<%= hfLon.ClientID %>');
            if (ctrl1.value == '' && ctrl2.value == '') {
                e.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page">
        <h2>Add New Security Est.</h2>
        <hr />
        <div class="formbox">
            <div class="title">Security Est. Division:</div>
            <div class="input">
                <asp:DropDownList ID="ddlSecurityEstDiv" runat="server" Width="80%" DataTextField="SecurityEstDiv_Name" DataValueField="SecurityEstDiv_ID">
                </asp:DropDownList>
            </div>
            <div class="clear"></div>
            <hr />

            <div class="title">Security Est. Title:
                <asp:RequiredFieldValidator ID="rfvSecurityEst_Title" runat="server" ControlToValidate="txtSecurityEst_Title" ErrorMessage="Enter Security Est. Title." Text="*" ForeColor="Red" ValidationGroup="vgAdd" /></div>
            <div class="input">
                <asp:TextBox ID="txtSecurityEst_Title" runat="server" Width="80%"></asp:TextBox></div>
            <div class="clear"></div>
            <hr />

            <div class="title">Security Est. Description:
                <asp:RequiredFieldValidator ID="rfvSecurityEst_Desc" runat="server" ControlToValidate="txtSecurityEst_Desc" ErrorMessage="Enter Security Est. Description." Text="*" ForeColor="Red" ValidationGroup="vgAdd" /></div>
            <div class="input">
                <asp:TextBox ID="txtSecurityEst_Desc" runat="server" Width="90%" Height="100px" TextMode="MultiLine"></asp:TextBox></div>
            <div class="clear"></div>
            <hr />

            <div class="title">Security Est. Location:
                <asp:CustomValidator ID="cvSecurityEst_Location" runat="server" ClientValidationFunction="ClientVal" ErrorMessage="Select Location of Security Est." Text="*" ForeColor="Red" ValidationGroup="vgAdd" /></div>
            <div class="input">
                <div id="mapContainer"></div>
                <asp:HiddenField ID="hfLat" runat="server" />
                <asp:HiddenField ID="hfLon" runat="server" />
            </div>
            <div class="clear"></div>
            <hr />
            
            <div id="btns" style="padding-right: 50px; text-align: right;">
                <asp:Button ID="btnAdd" runat="server" Text="  Add  " CssClass="btn" ValidationGroup="vgAdd" />
                <asp:Button ID="btnCancel" runat="server" Text=" Cancel " CssClass="btnc" />
            </div>
            <div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert" ValidationGroup="vgAdd" />
            </div>
        </div>
    </div>
</asp:Content>


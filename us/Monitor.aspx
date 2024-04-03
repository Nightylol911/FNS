<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Monitor.aspx.vb" Inherits="us_ViewNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div style="width: 100%;">Location of Notification:</div>
        <div>
            <div style="margin-top: 15px;">
                <div id="map" style="width: 100%; height: 700px;"></div>
            </div>
        </div>

        <script type="text/javascript">
            let map;
            let directionsService;
            let directionsRenderer;
            let marker;

            function initMap() {
                map = new google.maps.Map(document.getElementById('map'), {
                    center: { lat: 24.713024, lng: 46.675531 },
                    zoom: 13
                });

                directionsService = new google.maps.DirectionsService();
                directionsRenderer = new google.maps.DirectionsRenderer();
                directionsRenderer.setMap(map);
            }

            function loadDirections() {
                const request = {
                    origin: new google.maps.LatLng(document.getElementById('<%= hSLatitude.ClientID%>').value, document.getElementById('<%= hSLongitude.ClientID%>').value),
                    destination: new google.maps.LatLng(document.getElementById('<%= hCLatitude.ClientID%>').value, document.getElementById('<%= hCLongitude.ClientID%>').value),
                    travelMode: 'DRIVING'
                };

                directionsService.route(request, function (result, status) {
                    if (status == 'OK') {
                        if (marker) {
                            marker.setMap(null);
                        }

                        marker = new google.maps.Marker({
                            position: new google.maps.LatLng(document.getElementById('<%= hCLatitude.ClientID%>').value, document.getElementById('<%= hCLongitude.ClientID%>').value),
                            map: map,
                            icon: {
                                url: "/image/icon/Ripple.svg",
                                scaledSize: new google.maps.Size(200, 200), // scaled size
                                origin: new google.maps.Point(0, 0), // origin
                                anchor: new google.maps.Point(100, 100) // anchor
                            }
                        });

                        directionsRenderer.setDirections(result);
                    } else {
                        console.error('Unable to load directions due to ' + status);
                    }
                });
            }

            function clearDirections() {
                directionsRenderer.setDirections({ routes: [] });
                if (marker) {
                    marker.setMap(null);
                }
            }
        </script>
        
        <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDIit_gaDuTf2DS4orWT2lHwYmKGbhtc5M&sensor=false&callback=initMap" type="text/javascript"></script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="_Timer" runat="server" Interval="3000"></asp:Timer>
        <asp:UpdatePanel ID="_UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hNotification_Seq" runat="server" Value="" />
                <asp:HiddenField ID="hSLatitude" runat="server" Value="" />
                <asp:HiddenField ID="hSLongitude" runat="server" Value="" />
                <asp:HiddenField ID="hCLatitude" runat="server" Value="" />
                <asp:HiddenField ID="hCLongitude" runat="server" Value="" />
                <asp:Button ID="btnMute" runat="server" Text="Mute" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="_Timer" />
                <asp:AsyncPostBackTrigger ControlID="btnMute" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>


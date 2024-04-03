<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewNotification.aspx.vb" Inherits="us_ViewNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDIit_gaDuTf2DS4orWT2lHwYmKGbhtc5M&sensor=false" type="text/javascript"></script>
    <script type="text/javascript">
        var myCenter=new google.maps.LatLng(<%= getLocation() %>);

        function initialize()
        {
        var mapProp = {
          center:myCenter,
          zoom:15,
          mapTypeId:google.maps.MapTypeId.ROADMAP
          };

        var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);

        var marker=new google.maps.Marker({
          position:myCenter,
          });

        marker.setMap(map);
        }

        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div class="page">
            <asp:DataList ID="dlNotification" runat="server" Width="100%">
                <ItemTemplate>
                    <div style="float: left;"><h2>View Notification No. <%# Eval("Notification_Seq")%></h2></div>
                    <div style="float: right; font-size: 11px;"><%# Eval("Notification_DateTime")%></div>
                    <div style="clear: both;"></div>
                    <hr />

                    <div style="float: left; width: 150px;">Customer Name:</div>
                    <div style="float: left; width: calc(50% - 150px);"><%# Eval("Customer_Name") %></div>

                    <div style="float: right; width: calc(50% - 150px);"><%# Eval("Customer_Phone")%></div>
                    <div style="float: right; width: 150px;">Customer Phone:</div>

                    <div style="clear: both;"></div>
                    <hr />

                    <div style="float: left; width: 150px;">Location Name:</div>
                    <div style="float: left; width: calc(100% - 150px);"><%# Eval("Location_Title")%></div>
                    <asp:HiddenField ID="hfLocation" runat="server" Value='<%# Eval("Location_Latitude") & "," & Eval("Location_Longitude")%>' />

                    <div style="clear: both;"></div>
                    <hr />
                </ItemTemplate>
            </asp:DataList>

            <div style="width: 100%;">Location of Notification:</div>
            <div style="clear: both;"></div>
            <div style="margin-top: 15px;">
                <div id="googleMap" style="width:100%; height:300px;"></div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </div>
</asp:Content>


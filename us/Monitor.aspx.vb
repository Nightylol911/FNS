Imports System.Data

Partial Class us_ViewNotification
    Inherits System.Web.UI.Page
    Dim c_noti As New C_Notification
    Dim c_secu As New C_SecurityEst

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _Timer_Tick(sender As Object, e As EventArgs) Handles _Timer.Tick

        Dim dt As New DataTable
        dt = c_noti.getNotifications()

        If dt.Rows.Count > 0 Then
            hNotification_Seq.Value = dt.Rows(0)("Notification_Seq").ToString

            hSLatitude.Value = dt.Rows(0)("SecurityEst_Latitude").ToString
            hSLongitude.Value = dt.Rows(0)("SecurityEst_Longitude").ToString

            hCLatitude.Value = dt.Rows(0)("Location_Latitude").ToString
            hCLongitude.Value = dt.Rows(0)("Location_Longitude").ToString
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "load", "loadDirections();", True)
        Else
            hNotification_Seq.Value = ""
            hCLatitude.Value = ""
            hCLongitude.Value = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clear", "clearDirections();", True)
        End If

    End Sub

    Protected Sub btnMute_Click(sender As Object, e As EventArgs) Handles btnMute.Click
        If hNotification_Seq.Value <> 0 Then
            c_noti.updateStatus(hNotification_Seq.Value)

            hNotification_Seq.Value = ""
            hCLatitude.Value = ""
            hCLongitude.Value = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clear", "clearDirections();", True)
        End If
    End Sub
End Class

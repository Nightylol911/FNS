
Partial Class us_ViewNotifications
    Inherits System.Web.UI.Page
    Dim c_noti As New C_Notification

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                dvNotifications.DataSource = c_noti.getNotificationAll()
                dvNotifications.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

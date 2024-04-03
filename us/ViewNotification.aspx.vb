Imports System.Data

Partial Class us_ViewNotification
    Inherits System.Web.UI.Page
    Dim c_noti As New C_Notification

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                If Not Request.QueryString("ns") = Nothing Then
                    'litNotificationNo.Text = Request.QueryString("ns")

                    dlNotification.DataSource = c_noti.getNotificationInfoByID(Request.QueryString("ns"))
                    dlNotification.DataBind()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function getLocation() As String
        Dim strLoc As String = DirectCast(dlNotification.Items(0).FindControl("hfLocation"), HiddenField).Value
        Return strLoc
    End Function
End Class

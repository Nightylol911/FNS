
Partial Class Notify
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim ns As String = Request.QueryString("ns")
        Dim nt As String = Request.QueryString("nt")

        If Not ns = Nothing Then
            Dim c_noty As New C_Notification
            c_noty.notify(nt, ns)
        End If
    End Sub
End Class

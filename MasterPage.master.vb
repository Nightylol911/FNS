
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Not HttpContext.Current.User.Identity.IsAuthenticated Then
                    Response.Redirect("~/Login.aspx")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


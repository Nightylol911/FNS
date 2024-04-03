
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Not HttpContext.Current.User.Identity.IsAuthenticated Then
                    Response.Redirect("~/Login.aspx")
                Else
                    If HttpContext.Current.User.Identity.Name = "a" Then
                        Response.Redirect("~/ua/Default.aspx")
                    End If

                    If HttpContext.Current.User.Identity.Name = "c" Then
                        Response.Redirect("~/uc/Default.aspx")
                    End If

                    If HttpContext.Current.User.Identity.Name = "s" Then
                        Response.Redirect("~/us/Default.aspx")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

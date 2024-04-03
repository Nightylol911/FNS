
Partial Class ua_SecurityEst_Add
    Inherits System.Web.UI.Page
    Dim c_sees As New C_SecurityEst

    Sub fillDDL()
        ddlSecurityEstDiv.DataSource = c_sees.getSecurityEstDiv()
        ddlSecurityEstDiv.DataBind()
    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillDDL()
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            c_sees.insertSecurityEst(txtSecurityEst_Title.Text, txtSecurityEst_Desc.Text, hfLat.Value, hfLon.Value, ddlSecurityEstDiv.SelectedValue.ToString)
            Response.Redirect("~/ua/SecurityEst.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/ua/SecurityEst.aspx")
    End Sub
End Class

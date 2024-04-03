
Partial Class ua_SecurityEst_Edit
    Inherits System.Web.UI.Page
    Dim c_sees As New C_SecurityEst

    Sub fillDDL()
        ddlSecurityEstDiv.DataSource = c_sees.getSecurityEstDiv()
        ddlSecurityEstDiv.DataBind()
    End Sub

    Sub fillData()
        Try
            Dim dt As Data.DataTable = c_sees.getSecurityEstByID(Request.QueryString("sid"))
            ddlSecurityEstDiv.SelectedValue = dt.Rows(0)("SecurityEstDiv_ID").ToString
            txtSecurityEst_Title.Text = dt.Rows(0)("SecurityEst_Title").ToString
            txtSecurityEst_Desc.Text = dt.Rows(0)("SecurityEst_Desc").ToString
            hfLat.Value = dt.Rows(0)("SecurityEst_Latitude").ToString
            hfLon.Value = dt.Rows(0)("SecurityEst_Longitude").ToString
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillDDL()
            fillData()
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As System.EventArgs) Handles btnEdit.Click
        Try
            c_sees.updateSecurityEst(txtSecurityEst_Title.Text, txtSecurityEst_Desc.Text, hfLat.Value, hfLon.Value, ddlSecurityEstDiv.SelectedValue.ToString, Request.QueryString("sid"))
            Response.Redirect("~/ua/SecurityEst.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/ua/SecurityEst.aspx")
    End Sub
End Class

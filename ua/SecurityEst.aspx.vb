
Partial Class ua_SecurityEstDiv
    Inherits System.Web.UI.Page

    Dim c_sees As New C_SecurityEst

    Sub BindGrid()
        gvSecurityEst.DataSource = c_sees.getSecurityEst()
        gvSecurityEst.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
        End If
        Page.MaintainScrollPositionOnPostBack = True
    End Sub

    Protected Sub gvSecurityEst_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvSecurityEst.PageIndexChanging
        gvSecurityEst.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub gvSecurityEst_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvSecurityEst.RowDeleting
        c_sees.deleteSecurityEst(gvSecurityEst.DataKeys(e.RowIndex).Value)
        BindGrid()
    End Sub
End Class

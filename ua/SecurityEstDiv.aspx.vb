
Partial Class ua_SecurityEstDiv
    Inherits System.Web.UI.Page

    Dim c_sees As New C_SecurityEst

    Sub BindGrid()
        gvSecurityEstDiv.DataSource = c_sees.getSecurityEstDiv()
        gvSecurityEstDiv.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
        End If
        Page.MaintainScrollPositionOnPostBack = True
    End Sub

    Protected Sub gvSecurityEstDiv_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvSecurityEstDiv.PageIndexChanging
        gvSecurityEstDiv.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub gvSecurityEstDiv_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvSecurityEstDiv.RowEditing
        gvSecurityEstDiv.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub gvSecurityEstDiv_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvSecurityEstDiv.RowCancelingEdit
        gvSecurityEstDiv.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub gvSecurityEstDiv_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvSecurityEstDiv.RowUpdating
        c_sees.updateSecurityEstDiv(gvSecurityEstDiv.DataKeys(e.RowIndex).Value, CType(gvSecurityEstDiv.Rows(e.RowIndex).FindControl("txtSecurityEstDiv_NameE"), TextBox).Text)

        gvSecurityEstDiv.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub gvSecurityEstDiv_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvSecurityEstDiv.RowDeleting
        c_sees.deleteSecurityEstDiv(gvSecurityEstDiv.DataKeys(e.RowIndex).Value)
        BindGrid()
    End Sub

    Protected Sub gvSecurityEstDiv_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSecurityEstDiv.RowCommand
        If e.CommandName = "Insert" Then
            c_sees.insertSecurityEstDiv(CType(gvSecurityEstDiv.FooterRow.FindControl("txtSecurityEstDiv_NameI"), TextBox).Text)
            BindGrid()
        End If
    End Sub

End Class

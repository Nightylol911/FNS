
Partial Class uc_AddNewDevice
    Inherits System.Web.UI.Page
    Dim c_cust As New C_Customer

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            c_cust.insertNewDevice(txtCustomer_Name.Text, txtCustomer_Phone.Text, txtCustomer_Note.Text, "c", hfLat.Value, hfLon.Value, txtCustomer_Device_SN.Text)
            Response.Redirect("~/Default.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Default.aspx")
    End Sub
End Class

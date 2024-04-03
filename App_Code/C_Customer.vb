Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net

Public Class C_Customer
    Dim Con As New SqlConnection

    Private Sub openDataBase()
        Con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Con.Open()
    End Sub

    Private Sub closeDatabase()
        Con.Close()
    End Sub

    Function getCustomerAll() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Customer_ID")
        dt.Columns.Add("Customer_Name")
        dt.Columns.Add("Customer_Phone")
        dt.Columns.Add("Customer_Note")
        dt.Columns.Add("Customer_Username")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Customer.Customer_ID, fns_Customer.Customer_Name, fns_Customer.Customer_Phone, fns_Customer.Customer_Note, fns_Customer.Customer_Username FROM fns_Customer", Con)

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Customer_ID") = Read("Customer_ID")
                dr("Customer_Name") = Read("Customer_Name")
                dr("Customer_Phone") = Read("Customer_Phone")
                dr("Customer_Note") = Read("Customer_Note")
                dr("Customer_Username") = Read("Customer_Username")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getCustomerInfoByNID(ByVal Notification_Seq As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Customer_ID")
        dt.Columns.Add("Customer_Name")
        dt.Columns.Add("Customer_Phone")
        dt.Columns.Add("Customer_Note")
        dt.Columns.Add("Customer_Username")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Customer.Customer_ID, fns_Customer.Customer_Name, fns_Customer.Customer_Phone, fns_Customer.Customer_Note, fns_Customer.Customer_Username FROM fns_Customer INNER JOIN fns_Device ON fns_Customer.Customer_ID = fns_Device.Customer_ID INNER JOIN fns_Notification ON fns_Device.Device_SN = fns_Notification.Device_SN WHERE (fns_Notification.Notification_Seq = @Notification_Seq)", Con)
            Comm.Parameters.Add(New SqlParameter("@Notification_Seq", Notification_Seq))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Customer_ID") = Read("Customer_ID")
                dr("Customer_Name") = Read("Customer_Name")
                dr("Customer_Phone") = Read("Customer_Phone")
                dr("Customer_Note") = Read("Customer_Note")
                dr("Customer_Username") = Read("Customer_Username")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getCustomerByID(ByVal Customer_ID As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Customer_ID")
        dt.Columns.Add("Customer_Name")
        dt.Columns.Add("Customer_Phone")
        dt.Columns.Add("Customer_Note")
        dt.Columns.Add("Customer_Username")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Customer.Customer_ID, fns_Customer.Customer_Name, fns_Customer.Customer_Phone, fns_Customer.Customer_Note, fns_Customer.Customer_Username FROM fns_Customer WHERE Customer_ID = @Customer_ID", Con)
            Comm.Parameters.Add(New SqlParameter("@Customer_ID", Customer_ID))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Customer_ID") = Read("Customer_ID")
                dr("Customer_Name") = Read("Customer_Name")
                dr("Customer_Phone") = Read("Customer_Phone")
                dr("Customer_Note") = Read("Customer_Note")
                dr("Customer_Username") = Read("Customer_Username")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Sub insertCustomer(ByVal Customer_Name As String, ByVal Customer_Phone As String, ByVal Customer_Note As String, ByVal Customer_Username As String)
        Try
            Dim Comm As New SqlCommand("INSERT INTO fns_Customer (Customer_Name, Customer_Phone, Customer_Note, Customer_Username) VALUES (@Customer_Name, @Customer_Phone, @Customer_Note, @Customer_Username)", Con)

            openDataBase()

            Comm.Parameters.Add(New SqlParameter("@Customer_Name", Customer_Name.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Phone", Customer_Phone.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Note", Customer_Note.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Username", Customer_Username.Trim()))
            Comm.ExecuteScalar()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

    End Sub

    Sub updateCustomer(ByVal Customer_ID As Integer, ByVal Customer_Name As String, ByVal Customer_Phone As String, ByVal Customer_Note As String, ByVal Customer_Username As String)
        Try
            Dim Comm As New SqlCommand("UPDATE fns_Customer SET Customer_Name = @Customer_Name, Customer_Phone = @Customer_Phone, Customer_Note = @Customer_Note, Customer_Username = @Customer_Username WHERE Customer_ID = @Customer_ID", Con)

            openDataBase()

            Comm.Parameters.Add(New SqlParameter("@Customer_ID", Customer_ID))
            Comm.Parameters.Add(New SqlParameter("@Customer_Name", Customer_Name.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Phone", Customer_Phone.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Note", Customer_Note.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Username", Customer_Username.Trim()))
            Comm.ExecuteNonQuery()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub deleteCustomer(ByVal Customer_ID As Integer)
        Try
            Dim Comm As New SqlCommand("DELETE FROM fns_Customer WHERE Customer_ID = @Customer_ID", Con)

            openDataBase()

            Comm.Parameters.Add(New SqlParameter("@Customer_ID", Customer_ID))
            Comm.ExecuteNonQuery()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub insertNewDevice(ByVal Customer_Name As String, ByVal Customer_Phone As String, ByVal Customer_Note As String, ByVal Customer_Username As String, ByVal Location_Latitude As Double, ByVal Location_Longitude As Double, ByVal Device_SN As Integer)
        Try
            Dim Comm As New SqlCommand("INSERT INTO fns_Customer (Customer_Name, Customer_Phone, Customer_Note, Customer_Username) OUTPUT INSERTED.Customer_ID VALUES (@Customer_Name, @Customer_Phone, @Customer_Note, @Customer_Username)", Con)

            openDataBase()
            Comm.Parameters.Add("@Customer_ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Comm.Parameters.Add(New SqlParameter("@Customer_Name", Customer_Name.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Phone", Customer_Phone.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Note", Customer_Note.Trim()))
            Comm.Parameters.Add(New SqlParameter("@Customer_Username", Customer_Username.Trim()))
            Dim Customer_ID As Integer = Comm.ExecuteScalar()

            Dim Comm2 As New SqlCommand("INSERT INTO fns_Location (Location_Title, Location_Longitude, Location_Latitude, Location__Status, Device_SN, Customer_ID) VALUES (@Location_Title, @Location_Longitude, @Location_Latitude, @Location__Status, @Device_SN, @Customer_ID)", Con)
            Comm2.Parameters.Add(New SqlParameter("@Location_Title", Customer_Name.Trim() & "'s Location"))
            Comm2.Parameters.Add(New SqlParameter("@Location_Longitude", Location_Longitude))
            Comm2.Parameters.Add(New SqlParameter("@Location_Latitude", Location_Latitude))
            Comm2.Parameters.Add(New SqlParameter("@Location__Status", "A"))
            Comm2.Parameters.Add(New SqlParameter("@Device_SN", Device_SN))
            Comm2.Parameters.Add(New SqlParameter("@Customer_ID", Customer_ID))
            Comm2.ExecuteNonQuery()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

    End Sub

    Sub sendEmail(ByVal toAddress As String, ByVal subject As String, ByVal body As String)
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress("your-email@gmail.com")
            mail.To.Add(toAddress)
            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = False

            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.Credentials = New NetworkCredential("your-email@gmail.com", "your-email-password")
            smtp.EnableSsl = True

            smtp.Send(mail)
        Catch ex As Exception
        End Try
    End Sub
End Class

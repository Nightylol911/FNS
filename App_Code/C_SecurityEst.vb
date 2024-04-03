Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net

Public Class C_SecurityEst
    Dim Con As New SqlConnection

    Private Sub openDataBase()
        Con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Con.Open()
    End Sub

    Private Sub closeDatabase()
        Con.Close()
    End Sub

    Function getSecurityEst() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("SecurityEst_ID")
        dt.Columns.Add("SecurityEst_Title")
        dt.Columns.Add("SecurityEstDiv_ID")
        dt.Columns.Add("SecurityEstDiv_Name")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_SecurityEst.SecurityEst_ID, fns_SecurityEst.SecurityEst_Title, fns_SecurityEstDiv.SecurityEstDiv_ID, fns_SecurityEstDiv.SecurityEstDiv_Name FROM fns_SecurityEst INNER JOIN fns_SecurityEstDiv ON fns_SecurityEst.SecurityEstDiv_ID = fns_SecurityEstDiv.SecurityEstDiv_ID", Con)

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("SecurityEst_ID") = Read("SecurityEst_ID")
                dr("SecurityEst_Title") = Read("SecurityEst_Title")
                dr("SecurityEstDiv_ID") = Read("SecurityEstDiv_ID")
                dr("SecurityEstDiv_Name") = Read("SecurityEstDiv_Name")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getSecurityEstByID(ByVal SecurityEst_ID As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("SecurityEst_ID")
        dt.Columns.Add("SecurityEst_Title")
        dt.Columns.Add("SecurityEst_Desc")
        dt.Columns.Add("SecurityEst_Latitude")
        dt.Columns.Add("SecurityEst_Longitude")
        dt.Columns.Add("SecurityEstDiv_ID")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT SecurityEst_ID, SecurityEst_Title, SecurityEst_Desc, SecurityEst_Latitude, SecurityEst_Longitude, SecurityEstDiv_ID FROM fns_SecurityEst WHERE (SecurityEst_ID = @SecurityEst_ID)", Con)
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_ID", SecurityEst_ID))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("SecurityEst_ID") = Read("SecurityEst_ID")
                dr("SecurityEst_Title") = Read("SecurityEst_Title")
                dr("SecurityEst_Desc") = Read("SecurityEst_Desc")
                dr("SecurityEst_Latitude") = Read("SecurityEst_Latitude")
                dr("SecurityEst_Longitude") = Read("SecurityEst_Longitude")
                dr("SecurityEstDiv_ID") = Read("SecurityEstDiv_ID")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getSecurityEstDiv() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("SecurityEstDiv_ID")
        dt.Columns.Add("SecurityEstDiv_Name")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT SecurityEstDiv_ID, SecurityEstDiv_Name FROM fns_SecurityEstDiv", Con)

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("SecurityEstDiv_ID") = Read("SecurityEstDiv_ID")
                dr("SecurityEstDiv_Name") = Read("SecurityEstDiv_Name")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Sub insertSecurityEst(ByVal SecurityEst_Title As String, ByVal SecurityEst_Desc As String, ByVal SecurityEst_Latitude As String, ByVal SecurityEst_Longitude As String, ByVal SecurityEstDiv_ID As String)
        Try

            Dim Comm As New SqlCommand("INSERT INTO fns_SecurityEst (SecurityEst_Title, SecurityEst_Desc, SecurityEst_Latitude, SecurityEst_Longitude, SecurityEstDiv_ID, SecurityEst_Username) VALUES (@SecurityEst_Title, @SecurityEst_Desc, @SecurityEst_Latitude, @SecurityEst_Longitude, @SecurityEstDiv_ID, N's')", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Title", SecurityEst_Title))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Desc", SecurityEst_Desc))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Latitude", SecurityEst_Latitude))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Longitude", SecurityEst_Longitude))
            Comm.Parameters.Add(New SqlParameter("@SecurityEstDiv_ID", SecurityEstDiv_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub updateSecurityEst(ByVal SecurityEst_Title As String, ByVal SecurityEst_Desc As String, ByVal SecurityEst_Latitude As String, ByVal SecurityEst_Longitude As String, ByVal SecurityEstDiv_ID As String, ByVal SecurityEst_ID As String)
        Try

            Dim Comm As New SqlCommand("UPDATE fns_SecurityEst SET SecurityEst_Title = @SecurityEst_Title, SecurityEst_Desc = @SecurityEst_Desc, SecurityEst_Latitude = @SecurityEst_Latitude, SecurityEst_Longitude = @SecurityEst_Longitude, SecurityEstDiv_ID = @SecurityEstDiv_ID WHERE (SecurityEst_ID = @SecurityEst_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Title", SecurityEst_Title))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Desc", SecurityEst_Desc))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Latitude", SecurityEst_Latitude))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Longitude", SecurityEst_Longitude))
            Comm.Parameters.Add(New SqlParameter("@SecurityEstDiv_ID", SecurityEstDiv_ID))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_ID", SecurityEst_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub deleteSecurityEst(ByVal SecurityEst_ID As String)
        Try

            Dim Comm As New SqlCommand("DELETE FROM fns_SecurityEst WHERE (SecurityEst_ID = @SecurityEst_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_ID", SecurityEst_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub insertSecurityEstDiv(ByVal SecurityEstDiv_Name As String)
        Try

            Dim Comm As New SqlCommand("INSERT INTO fns_SecurityEstDiv (SecurityEstDiv_Name) VALUES (@SecurityEstDiv_Name)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@SecurityEstDiv_Name", SecurityEstDiv_Name))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub updateSecurityEstDiv(ByVal SecurityEstDiv_ID As String, ByVal SecurityEstDiv_Name As String)
        Try

            Dim Comm As New SqlCommand("UPDATE fns_SecurityEstDiv SET SecurityEstDiv_Name = @SecurityEstDiv_Name WHERE (SecurityEstDiv_ID = @SecurityEstDiv_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@SecurityEstDiv_ID", SecurityEstDiv_ID))
            Comm.Parameters.Add(New SqlParameter("@SecurityEstDiv_Name", SecurityEstDiv_Name))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub deleteSecurityEstDiv(ByVal SecurityEstDiv_ID As String)
        Try

            Dim Comm As New SqlCommand("DELETE FROM fns_SecurityEstDiv WHERE (SecurityEstDiv_ID = @SecurityEstDiv_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@SecurityEstDiv_ID", SecurityEstDiv_ID))
            Comm.ExecuteNonQuery()
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

    Function getLocation(ByVal SecurityEst_Username As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("SecurityEst_Latitude")
        dt.Columns.Add("SecurityEst_Longitude")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT SecurityEst_Latitude, SecurityEst_Longitude FROM fns_SecurityEst WHERE (SecurityEst_Username = @SecurityEst_Username)", Con)
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_Username", SecurityEst_Username))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("SecurityEst_Latitude") = Read("SecurityEst_Latitude")
                dr("SecurityEst_Longitude") = Read("SecurityEst_Longitude")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

End Class

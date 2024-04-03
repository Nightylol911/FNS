Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net

Public Class C_Location
    Dim Con As New SqlConnection

    Private Sub openDataBase()
        Con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Con.Open()
    End Sub

    Private Sub closeDatabase()
        Con.Close()
    End Sub

    Function getDeviceLocation(ByVal Device_SN As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("Location_Latitude")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location_Longitude, fns_Location.Location_Latitude FROM fns_Location WHERE fns_Location.Device_SN = @Device_SN", Con)
            Comm.Parameters.Add(New SqlParameter("@Device_SN", Device_SN))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Location_Longitude") = Read("Location_Longitude")
                dr("Location_Latitude") = Read("Location_Latitude")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getLocationByID(ByVal Location_ID As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("Location_Latitude")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location_Longitude, fns_Location.Location_Latitude FROM fns_Location WHERE fns_Location.Location_ID = @Location_ID", Con)
            Comm.Parameters.Add(New SqlParameter("@Location_ID", Location_ID))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Location_Longitude") = Read("Location_Longitude")
                dr("Location_Latitude") = Read("Location_Latitude")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getLocationAll() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Location_ID")
        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("Location_Latitude")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location_ID, fns_Location.Location_Longitude, fns_Location.Location_Latitude FROM fns_Location", Con)

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Location_ID") = Read("Location_ID")
                dr("Location_Longitude") = Read("Location_Longitude")
                dr("Location_Latitude") = Read("Location_Latitude")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getLocation(ByVal Location_Longitude As Double, ByVal Location_Latitude As Double) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Location_ID")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location_ID FROM fns_Location WHERE fns_Location.Location_Latitude = @Location_Latitude AND fns_Location.Location_Longitude = @Location_Longitude", Con)
            Comm.Parameters.Add(New SqlParameter("@Location_Latitude", Location_Latitude))
            Comm.Parameters.Add(New SqlParameter("@Location_Longitude", Location_Longitude))
            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Location_ID") = Read("Location_ID")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getLocationByType(ByVal Location_Type As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Location_ID")
        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("Location_Latitude")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location_ID, fns_Location.Location_Longitude, fns_Location.Location_Latitude FROM fns_Location WHERE fns_Location.Location_Type = @Location_Type", Con)
            Comm.Parameters.Add(New SqlParameter("@Location_Type", Location_Type))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Location_ID") = Read("Location_ID")
                dr("Location_Longitude") = Read("Location_Longitude")
                dr("Location_Latitude") = Read("Location_Latitude")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function checkStatus(ByVal Location__Status As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Location__Status")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location__Status FROM fns_Location WHERE fns_Location.Location_ID = @Location_ID", Con)
            Comm.Parameters.Add(New SqlParameter("@Location__Status", Location__Status))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Location__Status") = Read("Location__Status")
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Sub updateStatus(ByVal Location_ID As String, ByVal Location_Status As String)
        Try

            Dim Comm As New SqlCommand("UPDATE fns_Location SET Location__Status = @Location_Status WHERE (Location_ID = @Location_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@Location_ID", Location_ID))
            Comm.Parameters.Add(New SqlParameter("@Location_Status", Location_Status))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try

    End Sub

    Sub insertLocation(ByVal Location_Title As String, ByVal Location_Latitude As String, ByVal Location_Longitude As String, ByVal Location__Status As String, ByVal Device_SN As String, ByVal Customer_ID As String)
        Try

            Dim Comm As New SqlCommand("INSERT INTO fns_Location (Location_Title, Location_Latitude, Location_Longitude, Location__Status, Device_SN, Customer_ID) VALUES (@Location_Title, @Location_Latitude, @Location_Longitude, @Location__Status, @Device_SN, @Customer_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@Location_Title", Location_Title))
            Comm.Parameters.Add(New SqlParameter("@Location_Latitude", Location_Latitude))
            Comm.Parameters.Add(New SqlParameter("@Location_Longitude", Location_Longitude))
            Comm.Parameters.Add(New SqlParameter("@Location__Status", Location__Status))
            Comm.Parameters.Add(New SqlParameter("@Device_SN", Device_SN))
            Comm.Parameters.Add(New SqlParameter("@Customer_ID", Customer_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub updateLocation(ByVal Location_ID As Integer, ByVal Location_Title As String, ByVal Location_Latitude As String, ByVal Location_Longitude As String, ByVal Location__Status As String, ByVal Device_SN As String, ByVal Customer_ID As String)
        Try
            Dim Comm As New SqlCommand("UPDATE fns_Location SET Location_Title = @Location_Title, Location_Latitude = @Location_Latitude, Location_Longitude = @Location_Longitude, Location__Status = @Location__Status, Device_SN = @Device_SN, Customer_ID = @Customer_ID WHERE Location_ID = @Location_ID", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@Location_ID", Location_ID))
            Comm.Parameters.Add(New SqlParameter("@Location_Title", Location_Title))
            Comm.Parameters.Add(New SqlParameter("@Location_Latitude", Location_Latitude))
            Comm.Parameters.Add(New SqlParameter("@Location_Longitude", Location_Longitude))
            Comm.Parameters.Add(New SqlParameter("@Location__Status", Location__Status))
            Comm.Parameters.Add(New SqlParameter("@Device_SN", Device_SN))
            Comm.Parameters.Add(New SqlParameter("@Customer_ID", Customer_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Sub deleteLocation(ByVal Location_ID As Integer)
        Try
            Dim Comm As New SqlCommand("DELETE FROM fns_Location WHERE Location_ID = @Location_ID", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@Location_ID", Location_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Function isNewDevice(ByVal Location_ID As String) As Boolean
        Dim isNew As Boolean

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Location.Location__Status FROM fns_Location WHERE fns_Location.Location_ID = @Location_ID", Con)
            Comm.Parameters.Add(New SqlParameter("@Location_ID", Location_ID))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()

                If Read("Location__Status") = "N" Then
                    isNew = True
                Else
                    isNew = False
                End If

            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return isNew
    End Function

End Class

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class C_Notification
    Dim Con As New SqlConnection

    Private Sub openDataBase()
        Con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Con.Open()
    End Sub

    Private Sub closeDatabase()
        Con.Close()
    End Sub

    Function getNotificationAll() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Customer_ID")
        dt.Columns.Add("Customer_Name")
        dt.Columns.Add("Customer_Phone")
        dt.Columns.Add("Customer_Note")
        dt.Columns.Add("Location_Title")
        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("Location_Latitude")
        dt.Columns.Add("Notification_Seq")
        dt.Columns.Add("Notification_DateTime")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Customer.Customer_ID, fns_Customer.Customer_Name, fns_Customer.Customer_Phone, fns_Customer.Customer_Note, fns_Location.Location_Title, fns_Location.Location_Longitude, fns_Location.Location_Latitude, fns_Notification.Notification_Seq, fns_Notification.Notification_DateTime FROM fns_Notification INNER JOIN fns_Location ON fns_Notification.Device_SN = fns_Location.Device_SN INNER JOIN fns_Customer ON fns_Location.Customer_ID = fns_Customer.Customer_ID", Con)

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Customer_ID") = Read("Customer_ID")
                dr("Customer_Name") = Read("Customer_Name")
                dr("Customer_Phone") = Read("Customer_Phone")
                dr("Customer_Note") = Read("Customer_Note")
                dr("Location_Title") = Read("Location_Title")
                dr("Location_Longitude") = Read("Location_Longitude")
                dr("Location_Latitude") = Read("Location_Latitude")
                dr("Notification_Seq") = Read("Notification_Seq")
                dr("Notification_DateTime") = String.Format("{0:yyyy/MM/dd - HH:mm tt}", Read("Notification_DateTime")).ToString
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getNotificationInfoByID(ByVal Notification_Seq As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Customer_ID")
        dt.Columns.Add("Customer_Name")
        dt.Columns.Add("Customer_Phone")
        dt.Columns.Add("Customer_Note")
        dt.Columns.Add("Location_Title")
        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("Location_Latitude")
        dt.Columns.Add("Notification_Seq")
        dt.Columns.Add("Notification_DateTime")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_Customer.Customer_ID, fns_Customer.Customer_Name, fns_Customer.Customer_Phone, fns_Customer.Customer_Note, fns_Location.Location_Title, fns_Location.Location_Longitude, fns_Location.Location_Latitude, fns_Notification.Notification_Seq, fns_Notification.Notification_DateTime FROM fns_Notification INNER JOIN fns_Location ON fns_Notification.Device_SN = fns_Location.Device_SN INNER JOIN fns_Customer ON fns_Location.Customer_ID = fns_Customer.Customer_ID WHERE (fns_Notification.Notification_Seq = @Notification_Seq)", Con)
            Comm.Parameters.Add(New SqlParameter("@Notification_Seq", Notification_Seq))

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Customer_ID") = Read("Customer_ID")
                dr("Customer_Name") = Read("Customer_Name")
                dr("Customer_Phone") = Read("Customer_Phone")
                dr("Customer_Note") = Read("Customer_Note")
                dr("Location_Title") = Read("Location_Title")
                dr("Location_Longitude") = Read("Location_Longitude")
                dr("Location_Latitude") = Read("Location_Latitude")
                dr("Notification_Seq") = Read("Notification_Seq")
                dr("Notification_DateTime") = String.Format("{0:yyyy/MM/dd - HH:mm tt}", Read("Notification_DateTime")).ToString
                dt.Rows.Add(dr)
            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return dt
    End Function

    Function getNotifications() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("Notification_Seq")
        dt.Columns.Add("Customer_Name")
        dt.Columns.Add("Customer_Phone")
        dt.Columns.Add("Location_Latitude")
        dt.Columns.Add("Location_Longitude")
        dt.Columns.Add("SecurityEst_Latitude")
        dt.Columns.Add("SecurityEst_Longitude")

        Try
            openDataBase()

            Dim Comm = New SqlCommand("SELECT N.Notification_Seq, C.Customer_Name, C.Customer_Phone, L.Location_Latitude, L.Location_Longitude, S.SecurityEst_Latitude, S.SecurityEst_Longitude FROM fns_Notification N, fns_Location L, fns_SecurityEst S, fns_Customer C WHERE C.Customer_ID = L.Customer_ID AND L.Device_SN = N.Device_SN AND N.SecurityEst_ID = S.SecurityEst_ID AND N.Notification_DateTime >= DATEADD(MINUTE, -5, GETDATE()) AND N.Notification_Status = 'N'", Con)

            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()
                dr = dt.NewRow()
                dr("Notification_Seq") = Read("Notification_Seq")
                dr("Customer_Name") = Read("Customer_Name")
                dr("Customer_Phone") = Read("Customer_Phone")
                dr("Location_Latitude") = Read("Location_Latitude")
                dr("Location_Longitude") = Read("Location_Longitude")
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

    Sub updateStatus(ByVal Notification_Seq As String)
        Try

            Dim Comm As New SqlCommand("UPDATE fns_Notification SET Notification_Status = 'D' WHERE Notification_Seq = @Notification_Seq", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@Notification_Seq", Notification_Seq))
            Comm.ExecuteNonQuery()
            closeDatabase()

        Catch ex As Exception
            closeDatabase()
        End Try

    End Sub

    Sub notify(ByVal Notification_Type As String, ByVal Device_SN As String)
        Try
            Dim c_loca As New C_Location
            Dim dt As DataTable = c_loca.getDeviceLocation(Device_SN)
            Dim SecurityEst_ID As Integer = findNearestStation(dt.Rows(0)("Location_Latitude").ToString, _
                                                               dt.Rows(0)("Location_Longitude").ToString)
            Dim Comm As New SqlCommand("INSERT INTO fns_Notification (Notification_Type, Notification_DateTime, " _
                                     & "Notification_Status, Device_SN, SecurityEst_ID) VALUES (@Notification_Type, " _
                                     & "GETDATE(), N'N', @Device_SN, @SecurityEst_ID)", Con)

            openDataBase()
            Comm.Parameters.Add(New SqlParameter("@Notification_Type", Notification_Type))
            Comm.Parameters.Add(New SqlParameter("@Device_SN", Device_SN))
            Comm.Parameters.Add(New SqlParameter("@SecurityEst_ID", SecurityEst_ID))
            Comm.ExecuteNonQuery()
            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try
    End Sub

    Function findNearestStation(ByVal cLatitude As Double, ByVal cLongitude As Double) As Integer
        Dim SecurityEst_ID As Integer = 0

        Try
            Dim sLatitude As Double
            Dim sLongitude As Double
            Dim Distance As Double = 0
            Dim Nearest As Double = 0

            openDataBase()

            Dim Comm = New SqlCommand("SELECT fns_SecurityEst.SecurityEst_ID, fns_SecurityEst.SecurityEst_Latitude, fns_SecurityEst.SecurityEst_Longitude FROM fns_SecurityEst", Con)
            Dim Read As SqlDataReader = Comm.ExecuteReader()
            While Read.Read()

                sLatitude = Read("SecurityEst_Latitude")
                sLongitude = Read("SecurityEst_Longitude")

                Distance = calcDistance(cLatitude, cLongitude, sLatitude, sLongitude)

                If Nearest = 0 Then
                    Nearest = Distance
                End If

                If Distance <= Nearest Then
                    SecurityEst_ID = Read("SecurityEst_ID")
                    Nearest = Distance
                End If

            End While
            Read.Close()

            closeDatabase()
        Catch ex As Exception
            closeDatabase()
        End Try

        Return SecurityEst_ID
    End Function

    Function calcDistance(ByVal cLatitude As Double, ByVal cLongitude As Double, ByVal sLatitude As Double, ByVal sLongitude As Double) As Double
        'Typical radius: 3963.0 (miles) 6387.7 (km)
        Dim R As Double = 6371.7
        Dim lat As Double = (sLatitude - cLatitude) * (Math.PI / 180)
        Dim lng As Double = (sLongitude - cLongitude) * (Math.PI / 180)

        Dim d1 As Double = ((Math.Sin((lat / 2)) * Math.Sin((lat / 2))) _
                          + (Math.Cos((cLatitude * Math.PI / 180)) _
                          * (Math.Cos((sLatitude * Math.PI / 180)) _
                          * (Math.Sin((lng / 2)) * Math.Sin((lng / 2))))))

        Dim d2 As Double = (2 * Math.Asin(Math.Min(1, Math.Sqrt(d1))))

        Return (R * d2)
    End Function

End Class

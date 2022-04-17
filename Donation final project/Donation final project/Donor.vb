Imports System.Net.Mime.MediaTypeNames
Imports System.Windows

Public Class Donor
    Dim databaseConnection As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Donation_Database.mdf';Integrated Security=True")
    Dim databaseQuery As String


    'Adds a Donor into the SQL Database, The only required values are first and last name.
    Function AddDonor(ByVal firstName As String,
                      ByVal lastName As String,
                      Optional ByVal businessName As String = "",
                      Optional ByVal phoneNumber As String = "",
                      Optional ByVal address As String = "",
                      Optional ByVal email As String = "",
                      Optional type As String = "")
        If firstName <> "" And lastName <> "" Then
            Try
                'Opens the Connection to the Donors part of the database
                databaseConnection.Open()

                'Query use to insert a new donor.
                databaseQuery = "INSERT INTO Donors (FirstName, LastName, BusinessName, PhoneNumber, Address, email, type) VALUES(@firstName, @lastName, @businessName, @phoneNumber, @address, @email, @type)"

                'Used to create a new SQL command and send it to the database.
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)

                    'Will always send a first and last name.
                    command.Parameters.Add("@firstName", SqlDbType.NChar).Value = firstName
                    command.Parameters.Add("@lastName", SqlDbType.NChar).Value = lastName

                    'You need multiple if statements.
                    If businessName <> "" Then
                        command.Parameters.Add("@businessName", SqlDbType.Text).Value = businessName
                    Else
                        command.Parameters.Add("@businessName", SqlDbType.Text).Value = DBNull.Value
                    End If
                    If phoneNumber <> "" Then
                        command.Parameters.Add("@phoneNumber", SqlDbType.NChar).Value = phoneNumber
                    Else
                        command.Parameters.Add("@phoneNumber", SqlDbType.NChar).Value = DBNull.Value

                    End If
                    If address <> "" Then
                        command.Parameters.Add("@address", SqlDbType.Text).Value = address
                    Else
                        command.Parameters.Add("@address", SqlDbType.Text).Value = DBNull.Value

                    End If
                    If email <> "" Then
                        command.Parameters.Add("@email", SqlDbType.Text).Value = email
                    Else
                        command.Parameters.Add("@email", SqlDbType.Text).Value = DBNull.Value
                    End If
                    If type <> "" Then
                        command.Parameters.Add("@type", SqlDbType.NChar).Value = type
                    Else
                        command.Parameters.Add("@type", SqlDbType.NChar).Value = DBNull.Value
                    End If


                    command.ExecuteNonQuery()
                End Using

                databaseConnection.Close()

            Catch ex As Exception
                MessageBox.Show("Error message: " + ex.Message)
            End Try
            Return True
        Else
            Return False
        End If

    End Function

End Class

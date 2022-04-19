Imports System.Net.Mime.MediaTypeNames
Imports System.Windows

Public Class DonorQueries
    Dim databaseConnection As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Donation_Database.mdf';Integrated Security=True")
    Dim databaseQuery As String
    Dim errorMessage As String = ""
    Private validation As New Validation
    'data is from https://jsonplaceholder.typicode.com/users



    'Adds a Donor into the SQL Database, The only required values are first and last name.
    Function AddDonor(ByVal donor As Dictionary(Of String, String))
        If validation.validateString(donor.Item("name")) Then
            Try
                'Opens the Connection to the Donors part of the database
                databaseConnection.Open()
                'Query use to insert a new donor.
                databaseQuery = "INSERT INTO Donors (name, PhoneNumber, Address, email, type) VALUES(@name, @phoneNumber, @address, @email, @type)"
                'Used to create a new SQL command and send it to the database.
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                    'Will always be a name added to the database
                    command.Parameters.Add("@name", SqlDbType.NChar).Value = donor.Item("name")
                    If donor.Item("phoneNumber") <> "" Then
                        command.Parameters.Add("@phoneNumber", SqlDbType.NChar).Value = donor.Item("phoneNumber")
                    Else
                        command.Parameters.Add("@phoneNumber", SqlDbType.NChar).Value = DBNull.Value

                    End If
                    If donor.Item("address") <> "" Then
                        command.Parameters.Add("@address", SqlDbType.Text).Value = donor.Item("address")
                    Else
                        command.Parameters.Add("@address", SqlDbType.Text).Value = DBNull.Value

                    End If
                    If donor.Item("email") <> "" Then
                        command.Parameters.Add("@email", SqlDbType.Text).Value = donor.Item("email")
                    Else
                        command.Parameters.Add("@email", SqlDbType.Text).Value = DBNull.Value
                    End If
                    If donor.Item("type") <> "" Then
                        command.Parameters.Add("@type", SqlDbType.NChar).Value = donor.Item("type")
                    Else
                        command.Parameters.Add("@type", SqlDbType.NChar).Value = DBNull.Value
                    End If
                    command.ExecuteNonQuery()
                End Using
                databaseConnection.Close()

            Catch ex As Exception
                errorMessage = "Error message: " + ex.Message
                Return False
            End Try
            errorMessage = ""
            Return True
        Else
            errorMessage = "Failed to Add Entry"
            Return False
        End If

    End Function


    Function getDonors(Optional ByVal searchTerm As String = "")
        Try
            'Opens the database connection
            databaseConnection.Open()
            Dim dataTable As New DataTable()
            databaseQuery = "Select * Donors"
            Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                Using sqlDataAdapter As New SqlClient.SqlDataAdapter()
                    sqlDataAdapter.SelectCommand = command
                    sqlDataAdapter.Fill(dataTable)
                End Using
            End Using

            Return dataTable
            'Closes the database connection
            databaseConnection.Close()
        Catch ex As Exception
            errorMessage = "Error Message: " + ex.Message
            Return False
        End Try

    End Function

    Function getErrorMessage()
        Return errorMessage
    End Function


End Class

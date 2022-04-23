Imports System.Net.Mime.MediaTypeNames
Imports System.Windows

Public Class DonorQueries
    Dim databaseConnection As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Donation_Database.mdf';Integrated Security=True")
    Dim databaseQuery As String
    Dim errorMessage As String = ""
    Private validation As New Validation
    Private databaseError As Boolean = True

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
            databaseQuery = "Select * From Donors"

            'Used to create a new command to get the information from the donors table in the database
            Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                'Used to get a sqlDataAdapter
                Using sqlDataAdapter As New SqlClient.SqlDataAdapter()
                    sqlDataAdapter.SelectCommand = command
                    Using dataTable As New DataTable
                        sqlDataAdapter.Fill(dataTable)
                        databaseError = True
                        databaseConnection.Close()
                        Return dataTable
                    End Using
                End Using
            End Using
            'Closes the database connection
        Catch ex As Exception
            errorMessage = "Error Message: " + ex.Message
            databaseError = False
            Return False

        End Try

    End Function

    Sub updateRow(ByVal id As Integer, ByVal donor As Dictionary(Of String, String))
        If validation.validateString(donor.Item("name")) Then
            Try
                databaseConnection.Open()
                'The query for updating information in a row in the database
                databaseQuery = "Update Donors (name, PhoneNumber, Address, email, type) VALUES(@name, @phoneNumber, @address, @email, @type) WHERE Id=@Id"


                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)



                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id
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

                    databaseError = "True"
                End Using

                databaseConnection.Close()


            Catch ex As Exception
                errorMessage = "Error Message: " + ex.Message
                databaseError = False
            End Try
        Else
            errorMessage = "Failed to update record."
            databaseError = False
        End If
    End Sub

    Function getErrorMessage()
        Return errorMessage
    End Function

    Function displayError()
        Return databaseError
    End Function

End Class

Imports System.Net.Mime.MediaTypeNames
Imports System.Windows

Public Class DonorQueries
    Inherits Queries
    Dim databaseConnection As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Donation_Database.mdf';Integrated Security=True")

    'data is from https://jsonplaceholder.typicode.com/users

    'Adds a Donor into the SQL Database, The only required values are first and last name.
    Public Overrides Sub Add(dictionary As Dictionary(Of String, String))
        If validation.ValidateString(dictionary.Item("name")) Then
            Try
                'Opens the Connection to the Donors part of the database
                databaseConnection.Open()
                'Query use to insert a new donor.
                databaseQuery = "INSERT INTO Donors (name, PhoneNumber, Address, email, type) VALUES(@name, @phoneNumber, @address, @email, @type)"
                'Used to create a new SQL command and send it to the database.
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                    'Will always be a name added to the database
                    command.Parameters.Add("@name", SqlDbType.NChar).Value = dictionary.Item("name")
                    If dictionary.Item("phoneNumber") <> "" Then
                        command.Parameters.Add("@phoneNumber", SqlDbType.NChar).Value = dictionary.Item("phoneNumber")
                    Else
                        command.Parameters.Add("@phoneNumber", SqlDbType.NChar).Value = DBNull.Value

                    End If
                    If dictionary.Item("address") <> "" Then
                        command.Parameters.Add("@address", SqlDbType.Text).Value = dictionary.Item("address")
                    Else
                        command.Parameters.Add("@address", SqlDbType.Text).Value = DBNull.Value

                    End If
                    If dictionary.Item("email") <> "" Then
                        command.Parameters.Add("@email", SqlDbType.Text).Value = dictionary.Item("email")
                    Else
                        command.Parameters.Add("@email", SqlDbType.Text).Value = DBNull.Value
                    End If
                    If dictionary.Item("type") <> "" Then
                        command.Parameters.Add("@type", SqlDbType.NChar).Value = dictionary.Item("type")
                    Else
                        command.Parameters.Add("@type", SqlDbType.NChar).Value = DBNull.Value
                    End If
                    command.ExecuteNonQuery()
                End Using
                databaseConnection.Close()

            Catch ex As Exception
                errorMessage = "Error message: " + ex.Message
                databaseError = False
            End Try
            errorMessage = ""
            databaseError = True
        Else
            errorMessage = "Failed to Add Entry"
            databaseError = False
        End If

    End Sub


    Public Overrides Function GetData()
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
        If validation.ValidateString(donor.Item("name")) Then
            Try
                databaseConnection.Open()
                'The query for updating information in a row in the database
                databaseQuery = "Update Donors SET name = @name, PhoneNumber = @phoneNumber, Address = @address, email = @email, type = @type WHERE Id=@Id"

                'Runs the sql command and updates the donors row
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)


                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id
                    command.Parameters.Add("@name", SqlDbType.NChar).Value = donor.Item("name")

                    'A set of if else statements to verifiy that data has been entered into roles that are not required by the database
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

                    'Runs the Query Command
                    command.ExecuteNonQuery()

                    'Because thier is no error sets the value to true
                    databaseError = True
                End Using

                databaseConnection.Close()


            Catch ex As Exception

                'Gets a error message 
                errorMessage = "Error Message: " + ex.Message

                'Because their is an error sets the value to false 
                databaseError = False
            End Try
        Else
            'Gets a error message 
            errorMessage = "Failed to update record."

            'Because their is an error sets the value to false 

            databaseError = False
        End If
    End Sub


    Function getNames()
        Try
            databaseConnection.Open()
            'Command to get IDs and Names form the database
            databaseQuery = "Select Id, name From Donors"
            Dim names As New Dictionary(Of Integer, String)

            'Used to create a new command to get the information from the donors table in the database
            Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                Using reader As SqlClient.SqlDataReader = command.ExecuteReader()
                    'Uses a while loop with reader to assisgn data to the Dictionary.
                    While reader.Read()

                        names.Add(reader.GetInt32(0), reader.GetString(1))

                    End While

                End Using
            End Using

            'Closes the database connection
            databaseConnection.Close()
            Return names
        Catch ex As Exception
            databaseError = False
            errorMessage = "Error Message: " + ex.Message
        End Try
        Return False
    End Function




End Class

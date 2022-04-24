Public Class DonationQueries
    Dim databaseConnection As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Donation_Database.mdf';Integrated Security=True")
    Dim databaseQuery As String
    Dim errorMessage As String = ""
    Private validation As New Validation
    Private databaseError As Boolean = True

    'data is from https://jsonplaceholder.typicode.com/users



    'Adds a Donation into the SQL Database
    Sub AddDonation(ByVal donation As Dictionary(Of String, String))

        'Validates that the value is greater then -1
        If validation.validateCashValue(donation.Item("value")) Then
            Try
                'Opens the Connection to the Donation part of the database
                databaseConnection.Open()

                'Query use to insert a new donation.
                databaseQuery = "INSERT INTO Donation(Date, Donor_ID, Description, type, value) VALUES(@currentDate, @id, @value, @type, @description)"

                'Used to create a new SQL command and send it to the database.
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)


                    'Their will always be a value for the date, id, type, and value
                    command.Parameters.Add("@currentDate", SqlDbType.Date).Value = donation.Item("currentDate")
                    command.Parameters.Add("@id", SqlDbType.Int).Value = donation.Item("id")
                    command.Parameters.Add("@type", SqlDbType.Char).Value = donation.Item("type")
                    command.Parameters.Add("@value", SqlDbType.Decimal).Value = donation.Item("value")

                    'Verifiys that their is a value for description and it not it will assign NULL
                    If validation.validateString(donation.Item("description")) Then
                        command.Parameters.Add("@description", SqlDbType.Text).Value = donation.Item("description")
                    Else
                        command.Parameters.Add("@description", SqlDbType.Text).Value = DBNull.Value
                    End If

                    'Executes the query command in sql
                    command.ExecuteNonQuery()
                End Using

                'Closes the database connection
                databaseConnection.Close()

                'returns the database error to false
                databaseError = False
            Catch ex As Exception

                'Updates the error message
                errorMessage = "Error message: " + ex.Message

                'Sets the database error to true
                databaseError = True

            End Try

            'Sets the database error to false 
            errorMessage = ""
        Else
            databaseError = True
            errorMessage = "Failed to Add Entry"
        End If

    End Sub

    'Used to get the donation information from the database
    Function getDontations()
        Try
            'Opens the database connection
            databaseConnection.Open()

            'A query to get the donation infomration from the database and the donor name
            databaseQuery = "Select Date, Donor_ID, name , Description, type, value From Donations, Donors"

            'Used to create a new command to get the information from the donation table in the database
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

    Sub updateRow(id As Integer, type As String, value As Integer, Optional description As String = "")
        If validation.validateString(value) Then
            Try
                databaseConnection.Open()
                'The query for updating information in a row in the database
                databaseQuery = "Update Donors SET value = @value, type = @type, description = @description WHERE Id=@Id"

                'Runs the sql command and updates the donors row
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id
                    command.Parameters.Add("@type", SqlDbType.Char).Value = type
                    command.Parameters.Add("@value", SqlDbType.Decimal).Value = value

                    'A set of if else statements to verifiy that data has been entered into roles that are not required by the database
                    If validation.validateString(description) Then
                        command.Parameters.Add("@description", SqlDbType.Text).Value = description
                    Else
                        command.Parameters.Add("@description", SqlDbType.Text).Value = DBNull.Value
                    End If

                    'Runs the Query Command
                    command.ExecuteNonQuery()

                    'Updates to false if their is no error
                    databaseError = False
                End Using

                'Closes the database connection
                databaseConnection.Close()


            Catch ex As Exception

                'Gets a error message 
                errorMessage = "Error Message: " + ex.Message

                'Because their is an error sets the value to true
                databaseError = True
            End Try
        Else

            'Gets a error message 
            errorMessage = "Failed to update record."

            'Because their is an error sets the value to true 
            databaseError = True
        End If
    End Sub

    Sub deleteDonation(id As Integer)
        Try
            'Opens the database connection
            databaseConnection.Open()

            databaseQuery = "DELETE * FROM Donoations WHERE Id = @id"
            'Used to set the delete query 
            Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id
                command.ExecuteNonQuery()

            End Using

            'If their is no error from running the query the it will return false 
            databaseError = False
        Catch ex As Exception
            databaseError = True
            errorMessage = "Error Message: " + ex.Message
        End Try
    End Sub


    Function getErrorMessage()
        Return errorMessage
    End Function

    Function displayError()
        Return databaseError
    End Function

End Class

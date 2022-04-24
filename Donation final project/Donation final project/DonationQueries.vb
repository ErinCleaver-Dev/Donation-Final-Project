Imports System.Windows

Public Class DonationQueries
    Inherits Queries
    Private databaseConnection As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Donation_Database.mdf';Integrated Security=True")


    'data is from https://jsonplaceholder.typicode.com/users

    'Adds a Donation into the SQL Database
    Public Overrides Sub Add(ByVal donation As Dictionary(Of String, String))

        'Validates that the value is greater then -1
        'Has a override of Intger AND Decemical
        If validation.ValidateNumber(CDec(donation.Item("value"))) Then
            Try
                'Opens the Connection to the Donation part of the database
                databaseConnection.Open()

                'Query use to insert a new donation.
                databaseQuery = "INSERT INTO Donations (Date, Donor_ID, Description, Donation_Type, value) VALUES(@currentDate, @id, @description, @donation_type, @value)"

                'Used to create a new SQL command and send it to the database.
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)

                    'Their will always be a value for the date, id, type, and value
                    command.Parameters.Add("@currentDate", SqlDbType.Date).Value = donation.Item("currentDate")
                    command.Parameters.Add("@id", SqlDbType.Int).Value = donation.Item("id")
                    command.Parameters.Add("@donation_type", SqlDbType.Char).Value = donation.Item("donation_type")
                    command.Parameters.Add("@value", SqlDbType.Decimal).Value = donation.Item("value")

                    'Verifiys that their is a value for description and it not it will assign NULL
                    If validation.ValidateString(donation.Item("description")) Then
                        command.Parameters.Add("@description", SqlDbType.Text).Value = donation.Item("description")
                    Else
                        command.Parameters.Add("@description", SqlDbType.Text).Value = DBNull.Value
                    End If

                    'Executes the query command in sql
                    MessageBox.Show("Testing Query")

                    command.ExecuteNonQuery()
                End Using
                'returns the database error to false
                databaseError = False

                'Sets the error message back to nothing
                errorMessage = ""

                MessageBox.Show("Testing closing data connection")

                'Closes the database connection
                databaseConnection.Close()

            Catch ex As Exception
                'Updates the error message
                errorMessage = "Error message: " + ex.Message

                'Sets the database error to true
                databaseError = True

            End Try


        Else
            databaseError = True
            errorMessage = "Failed to Add Entry"
        End If

    End Sub

    'Used to get the donation information from the database
    Public Overrides Function GetData()
        Try
            'Opens the database connection
            databaseConnection.Open()

            'A query to get the donation infomration from the database and the donor name
            databaseQuery = "Select * From Donations"

            'Used to create a new command to get the information from the donation table in the database
            Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                'Used to get a sqlDataAdapter
                Using sqlDataAdapter As New SqlClient.SqlDataAdapter()

                    'set a command to the Data Adapter
                    sqlDataAdapter.SelectCommand = command

                    'Creates a new data table
                    Using dataTable As New DataTable
                        sqlDataAdapter.Fill(dataTable)
                        databaseError = False
                        databaseConnection.Close()


                        Return dataTable
                    End Using
                End Using
            End Using
            'Closes the database connection
        Catch ex As Exception
            ' Will get the error message
            errorMessage = "Error Message: " + ex.Message

            'Displays a database error
            databaseError = True
            Return False
        End Try
    End Function

    Sub UpdateRow(id As Integer, donation_type As String, value As Decimal, Optional description As String = "")
        If validation.ValidateNumber(value) Then
            Try
                databaseConnection.Open()
                'The query for updating information in a row in the database
                databaseQuery = "Update Donations SET value = @value, Donation_Type = @donation_type, description = @description WHERE Id=@Id"

                'Runs the sql command and updates the donors row
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)

                    'Will always be updated unless their is no change to the fields
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id
                    command.Parameters.Add("@donation_type", SqlDbType.Char).Value = donation_type
                    command.Parameters.Add("@value", SqlDbType.Decimal).Value = value

                    'A set of if else statements to verifiy that data has been entered into roles that are not required by the database
                    If validation.ValidateString(description) Then
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

    Sub DeleteDonation(id As Integer)
        Try
            'Opens the database connection
            databaseConnection.Open()

            MessageBox.Show("Testing delete row")

            databaseQuery = "DELETE FROM Donations WHERE Id = @id"
            'Used to set the delete query 

            If validation.ValidateNumber(id) Then
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id
                    command.ExecuteNonQuery()
                End Using
            End If

            'If their is no error from running the query the it will return false 
            databaseError = False
        Catch ex As Exception
            databaseError = True
            errorMessage = "Error Message: " + ex.Message
        End Try
    End Sub

End Class

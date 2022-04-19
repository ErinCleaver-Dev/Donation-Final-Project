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
        If validation.validateString(donor.Item("firstName")) And validation.validateString(donor.Item("lastName")) Then
            Try
                'Opens the Connection to the Donors part of the database
                databaseConnection.Open()
                'Query use to insert a new donor.
                databaseQuery = "INSERT INTO Donors (FirstName, LastName, BusinessName, PhoneNumber, Address, email, type) VALUES(@firstName, @lastName, @businessName, @phoneNumber, @address, @email, @type)"
                'Used to create a new SQL command and send it to the database.
                Using command As New SqlClient.SqlCommand(databaseQuery, databaseConnection)

                    'Will always send a first and last name.
                    command.Parameters.Add("@firstName", SqlDbType.NChar).Value = donor.Item("firstName")
                    command.Parameters.Add("@lastName", SqlDbType.NChar).Value = donor.Item("lastName")

                    'You need multiple if statements.
                    If donor.Item("businessName") <> "" Then
                        command.Parameters.Add("@businessName", SqlDbType.Text).Value = donor.Item("businessName")
                    Else
                        command.Parameters.Add("@businessName", SqlDbType.Text).Value = DBNull.Value
                    End If
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


    Function getDonors(ByVal numberPerPage As Integer, ByVal pageNumber As Integer, ByVal searchTerm As String)
        Try
            Dim donorList As New Dictionary(Of Integer, Donor)



            Return donorList
        Catch ex As Exception
            errorMessage = "Error Message: " + ex.Message
            Return False
        End Try

    End Function

    Function getErrorMessage()
        Return errorMessage
    End Function


End Class

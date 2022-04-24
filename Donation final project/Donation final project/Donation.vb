Public Class Donation
    'Creates a Dictionary to hold donor infomration
    Private donationInformation As New Dictionary(Of String, String)

    'Gets the new donation information
    Public Sub New(ByVal currentDate As String,
                   ByVal id As Integer,
                   ByVal value As Decimal,
                   ByVal type As String,
                   Optional ByVal description As String = ""
                   )

        'Uses a try catch for adding information to the database
        Try
            donationInformation.Add("currentDate", currentDate)
            donationInformation.Add("id", id)
            donationInformation.Add("value", value)
            donationInformation.Add("type", type)
            donationInformation.Add("description", description)
        Catch ex As Exception
            Windows.MessageBox.Show("Error Message: " + ex.Message)
        End Try


    End Sub

    'Returns the dictionary with the donation information information
    Function GetDonor()
        Return donationInformation
    End Function

End Class

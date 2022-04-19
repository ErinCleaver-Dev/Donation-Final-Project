Imports System.Windows

Public Class Donor
    Private donorInformation As New Dictionary(Of String, String)

    Public Sub New(ByVal name As String,
                      Optional ByVal phoneNumber As String = "",
                      Optional ByVal address As String = "",
                      Optional ByVal email As String = "",
                      Optional ByVal type As String = "")

        Try
            donorInformation.Add("name", name)
            donorInformation.Add("phoneNumber", phoneNumber)
            donorInformation.Add("address", address)
            donorInformation.Add("email", email)
            donorInformation.Add("type", type)
        Catch ex As Exception
            MessageBox.Show("Error Message: " + ex.Message)

        End Try


    End Sub

    Function GetDonor()
        Return donorInformation
    End Function


End Class

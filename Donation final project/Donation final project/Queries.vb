Public MustInherit Class Queries
    Protected databaseQuery As String
    Protected errorMessage As String = ""
    Protected validation As New Validation
    Protected databaseError As Boolean = False

    Public Overridable Sub Add(ByVal dictionary As Dictionary(Of String, String))
    End Sub

    Public Overridable Function GetData()
        Return ""
    End Function

    Function getErrorMessage()
        Return errorMessage
    End Function

    Function displayError()
        Return databaseError
    End Function

End Class

Public Class Validation
    Function validateString(ByVal value As String)
        If value <> "" Then
            Return True
        Else
            Return False
        End If
    End Function



End Class

Imports System.Windows

Public Class Validation
    Function validateString(ByVal value As String)
        If value <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Function validateCashValue(ByVal value As Decimal)
        If value > -1 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

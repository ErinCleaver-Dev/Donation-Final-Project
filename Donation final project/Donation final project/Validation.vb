Imports System.Windows

Public Class Validation
    Function ValidateString(ByVal value As String)
        If value <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    'Used for validating that decimal is over 0
    Overloads Function ValidateNumber(ByVal value As Decimal)
        If value > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'Used for validating that integer is over 0
    Overloads Function ValidateNumber(ByVal value As Integer)
        If value > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


End Class

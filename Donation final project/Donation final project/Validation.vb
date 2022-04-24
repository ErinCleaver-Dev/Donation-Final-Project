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
        If value > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ValidateQuery(value As String)
        value.ToLower()
        Dim valid As Boolean = True

        Dim terms() As String = {"delete", "drop", "update", "insert", "create", "truncate", "merge", "using"}
        For Each term As String In terms
            If value.Contains(term) Then
                valid = False
            End If
        Next

        Return valid

    End Function

End Class

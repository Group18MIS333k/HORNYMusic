'Author : Logan Hamilton (LSH494)
'Class - Validation Class 
'Purpose :  Validates inputs 
Public Class ValidationClass

    'Check Decimal - Checks any Decimal to be valid and positive
    Public Function CheckDecimal(strCheck As String) As Decimal
        Dim decCheck As Decimal
        Try
            decCheck = Convert.ToDecimal(strCheck)
        Catch ex As Exception
            Return -1
        End Try
        decCheck = Convert.ToDecimal(strCheck)
        If (decCheck < 0 Or IsDBNull(decCheck) = True) Then

            Return -1
        End If
        Return decCheck
    End Function
    'Check Integer - Checks any Integer to be valid and positive

    Public Function CheckInteger(strCheck As String) As Integer
        Dim intCheck As Integer
        Try
            intCheck = Convert.ToInt32(strCheck)
        Catch ex As Exception
            Return -1
        End Try
        If (intCheck < 0 Or IsDBNull(intCheck) = True) Then
            Return -1
        End If
        Return intCheck
    End Function
    'CheckNull - Checks if field is null 
    Public Function CheckNull(strCheck As String) As Decimal
        Dim strCheck2 As String
        Try
            strCheck2 = Convert.ToString(strCheck)
        Catch ex As Exception
            Return -1
        End Try
        strCheck2 = Convert.ToString(strCheck)
        If (IsDBNull(strCheck2) = True Or strCheck2 < "1") Then
            Return -1
        End If
        Return 1
    End Function
    Public Function CheckPhone(strIN As String) As Boolean

        If strIN.Length = 10 Then
            Return True
        End If
        Return False
    End Function
    Public Function CheckPass(strIN As String) As Boolean
        Dim check1 As Integer
        Dim check2 As Integer
        Dim check3 As Integer
        Dim check4 As Integer
        If strIN.Length > 5 And strIN.Length < 10 Then
            check1 = 1
        End If
        Dim i As Integer
        Dim strOne As String
        For i = 1 To Len(strIN) - 1
            'get one character from string
            strOne = strIN.Substring(i, 1)
            Select Case strOne.ToLower
                Case "0" To "9"
                Case Else
                    check2 = 1
            End Select
        Next
        For i = 1 To Len(strIN) - 1
            'get one character from string
            strOne = strIN.Substring(i, 1)
            Select Case strOne.ToLower
                Case "0" To "9"
                Case Else
                    check3 = 1
            End Select
        Next
        strOne = strIN.Substring(0, 1)
        Select Case strOne.ToLower
            Case "0" To "9"
            Case Else
                check4 = 1
        End Select
        If check1 = 1 And check2 = 1 And check3 = 1 And check4 = 1 Then
            Return True
        End If

        Return False
    End Function
    Public Function CheckZip(strIN As String) As Boolean

        If strIN.Length = 5 Or strIN.Length = 9 Then
            Return True
        End If
        Return False

    End Function
    Public Function CheckState(strIN As String) As Boolean

        If strIN.Length <> 2 Then
            Return False
        End If

        If CheckNotIntegers(strIN) = False Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CheckInitial(strIN As String) As Boolean

        If strIN.Length <> 1 Then
            Return False
        End If

        If CheckInteger(strIN) = True Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CheckAllIntegers(strIN As String) As Boolean
        If CheckNull(strIN.Substring(0, 1)) = False Then
            Return False
        End If
        '’check to see that remained has one digit
        Dim i As Integer
        Dim strOne As String
        For i = 1 To Len(strIN) - 1
            'get one character from string
            strOne = strIN.Substring(i, 1)
            Select Case strOne.ToLower
                Case "0" To "9"
                Case Else
                    Return True
            End Select
        Next
        Return False
    End Function
    Public Function CheckNotIntegers(strIN As String) As Boolean
        If CheckNull(strIN.Substring(0, 1)) = False Then
            Return False
        End If
        '’check to see that remained has one digit
        Dim i As Integer
        Dim strOne As String
        For i = 1 To Len(strIN) - 1
            'get one character from string
            strOne = strIN.Substring(i, 1)
            Select Case strOne.ToLower
                Case "A" To "Z", "a" To "z"
                Case Else
                    Return True
            End Select
        Next
        Return False
    End Function
    'Public Function ValidateEmailAddress(ByVal strEmailAddress As String) As Boolean
    'On Error GoTo Catch

    'Dim objRegExp As New Regex
    ' Dim blnIsValidEmail As Boolean

    '    objRegExp.IgnoreCase = True
    '   objRegExp.Global = True
    '  objRegExp.Pattern = "^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"

    '    blnIsValidEmail = objRegExp.Test(strEmailAddress)
    '   ValidateEmailAddress = blnIsValidEmail
    '  Exit Function

    '    Catch:
    '       ValidateEmailAddress = False
    'End Function
    Public Function isValidEmail(inEmailAddress As String) As Boolean
        ' Author: Unknown
        isValidEmail = True

        If (Len(inEmailAddress) = 0) Then
            isValidEmail = False
            Exit Function
        End If
        If (InStr(1, inEmailAddress, "@") = 0) Then
            isValidEmail = False
            Exit Function
        End If
        If (InStr(1, inEmailAddress, ".") = 0) Then
            isValidEmail = False
            Exit Function
        End If

        If (InStr(inEmailAddress, "@.") > 0) Then
            isValidEmail = False
            Exit Function
        End If

        If ((InStr(inEmailAddress, ".")) = ((Len(inEmailAddress)))) Then
            isValidEmail = False
            Exit Function
        End If

        If ((Len(inEmailAddress)) < (InStr(inEmailAddress, ".") + 2)) Then
            isValidEmail = False
            Exit Function
        End If

        If (InStr(1, inEmailAddress, "@") = 1) Then
            isValidEmail = False
            Exit Function
        End If
        Return isValidEmail

    End Function
End Class


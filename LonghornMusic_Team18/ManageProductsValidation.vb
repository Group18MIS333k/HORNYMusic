Public Class ManageProductsValidation
    Public Function Checkfordigits(strPhone As String) As Boolean
        'purpose: check if given string is all digis
        'input: string
        'output: return true or false based on whether string is all digits

        If strPhone = "" Then
            Return False
        End If
        'declare "i" as counter to check each character
        Dim i As Integer
        'store each temporary character in variable 
        Dim strone As String

        'check each character to see if it is a number, return false if not
        For i = 0 To Len(strPhone) - 1
            strone = strPhone.Substring(i, 1)
            Select Case strone
                Case "0" To "9"

                Case Else
                    Return False
            End Select
        Next

        'if function makes it here, all characters are numbers, return true
        Return True



    End Function

    Public Function Checkforletters(strTest As String) As Boolean
        'purpose: check that string only has letters
        'input: string to check
        'output: false if string has non letters,  true if string is all letters

        If strTest = "" Then
            Return False
        End If

        'declare "i" as counter to check each character
        Dim i As Integer
        'declare variable to hold first character of string
        Dim strone As String

        'check each character to see if it is a letter, return false if not
        For i = 0 To Len(strTest) - 1
            strone = strTest.Substring(i, 1)
            Select Case strone
                Case "a" To "z"

                Case "A" To "Z"

                Case Else
                    Return False
            End Select
        Next

        'if function makes it here, all characters are letters, return true
        Return True

    End Function
End Class

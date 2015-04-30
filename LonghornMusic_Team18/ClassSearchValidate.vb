Public Class ClassSearchValidate
    Public Function CheckDecimal(strInput As String) As Decimal

    

        'declare vairables 
        Dim decResult As Decimal

        'Try/Catch 
        Try
            decResult = Convert.ToDecimal(strInput)
        Catch ex As Exception
            Return -1
        End Try

        'Positive 
        If decResult < 0 Then
            Return -1
        End If

        Return decResult
    End Function

    Function CheckRatings(strinput As String)
        'Purpose: To check and see if ratings are numeric and decimals
        'Arguments: 
        'Returns: Error message or mdecRatingHigher and Lower
        'Author: Morgan May
        Dim decRating As Decimal
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal

        decRating = CheckDecimal(strinput)
        If decRating = -1 Then
            Return -1
        Else
            Return decRating
        End If


    End Function
End Class

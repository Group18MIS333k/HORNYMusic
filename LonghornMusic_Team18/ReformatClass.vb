Public Class Reformatclass
    'Author : Logan Hamilton (LSH494)
    'Class - Reformat Class 
    'Purpose :  Reformats Phone

    'Format Phone - Reformats Phone
    Public Function FormatPhone(strPhone As String) As String
        strPhone = "(" + strPhone.Substring(0, 3) + ") " + strPhone.Substring(3, 3) + "-" + strPhone.Substring(6)
        Return strPhone

    End Function

    Public Function ProperCase(pstrText As String) As String
        ProperCase = StrConv(pstrText, vbProperCase)
        Return ProperCase

    End Function
End Class

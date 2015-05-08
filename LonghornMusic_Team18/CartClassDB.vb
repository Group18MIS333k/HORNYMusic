Imports System.Data
Imports System.Data.SqlClient

Public Class CartClassDB

    ' these module variables are internal to object
    Dim mDatasetCart As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_Team18;user id=msbcj918;password=M1organ61994"
    '(note: the above is ONE long line, not three separate lines as shown, and you must change the catalog to your McCombs login number)


    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property CartDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetCart
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView
        Get
            'run dataset again to user
            Return mMyView
        End Get
    End Property
    Public Sub AddToCart(ByVal strUSPname As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'Purpose: insert inputs into cart table 
        'argument: stored procedure name, array list of paramerter names, and araylist of parameter values
        'return: nothing 
        'author:Parth 

        'creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'tell sql server the name ofthe stored procedure
        Dim objCommand As New SqlDataAdapter(strUSPname, objConnection)

        Try
            'sets the command type to stored procedure
            objCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters to stored procedure
            Dim index As Integer = 0
            For Each ParamName As String In aryParamNames
                objCommand.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'open connection and run insert/update query
            objCommand.SelectCommand.Connection = objConnection
            objConnection.Open()
            objCommand.SelectCommand.ExecuteNonQuery()
            objConnection.Close()

            'print out each element of our array list if error occured
        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName: " & CStr(aryParamNames(index))
                strError = strError & " ParamValue: " & CStr(aryParamValues(index))
                index = index + 1
            Next
            Throw New Exception(strError & " error message is " & ex.Message)
        End Try
    End Sub
    Public Sub DeleteFromCart(ByVal strUSPname As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'Purpose: insert inputs into cart table 
        'argument: stored procedure name, array list of paramerter names, and araylist of parameter values
        'return: nothing 
        'author:Parth 

        'creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'tell sql server the name ofthe stored procedure
        Dim objCommand As New SqlDataAdapter(strUSPname, objConnection)

        Try
            'sets the command type to stored procedure
            objCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters to stored procedure
            Dim index As Integer = 0
            For Each ParamName As String In aryParamNames
                objCommand.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'open connection and run insert/update query
            objCommand.SelectCommand.Connection = objConnection
            objConnection.Open()
            objCommand.SelectCommand.ExecuteNonQuery()
            objConnection.Close()

            'print out each element of our array list if error occured
        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName: " & CStr(aryParamNames(index))
                strError = strError & " ParamValue: " & CStr(aryParamValues(index))
                index = index + 1
            Next
            Throw New Exception(strError & " error message is " & ex.Message)
        End Try
    End Sub




End Class

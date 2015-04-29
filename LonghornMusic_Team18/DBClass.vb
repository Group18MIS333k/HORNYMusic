Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DBClass
    'Add objects to allow project to connect to database
    Dim strQuery As String
    Dim mDatasetZip As New DataSet
    Dim mDatasetCustomer As New DataSet
    Dim intLogin As New Integer
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim returnValue As String

    Dim mstrConnection As String = "workstation id =COMPUTER;packet size=4096;data source=MISSQL.mccombs.utexas.edu;integrated security = False;initial catalog=mis333k_20152_Team18;user id=msbcn366;password=Getrektm9"



    Public Sub GetAllCustomers()
        strQuery = "SELECT * , (lastname + ', ' + firstname) as fullname FROM Customers ORDER BY LastName, FirstName"
        UpdateDB(strQuery)
    End Sub
    Public Sub UpdateDB(ByVal strQuery As String)
        'Purpose: run giver query to update the database
        'argument: one string (any sql statement)
        'return: nothing


        Try
            Dim mdbConn As New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)
            mdbConn.Open()
            mDatasetCustomer.Clear()
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            mdbConn.Close()
        Catch ex As Exception

            Throw New Exception("query is " & strQuery.ToString & " error message is " & ex.Message)

        End Try
    End Sub
    Public Sub GetCityZip(ByVal Zip As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'sets command type to stored procedure
            cmd.CommandText = "usp_project_getcityzip"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objConnection

            'add parameters
            cmd.Parameters.Add(New SqlParameter("@Zip", Zip))

            'clear dataset
            objConnection.Open()
            returnValue = Convert.ToString(cmd.ExecuteScalar())
            objConnection.Close()
            'open connection and fill

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try

    End Sub
    Public Sub GetStateZip(ByVal Zip As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'sets command type to stored procedure
            cmd.CommandText = "usp_project_getstatezip"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objConnection

            'add parameters
            cmd.Parameters.Add(New SqlParameter("@Zip", Zip))

            'clear dataset
            objConnection.Open()
            returnValue = Convert.ToString(cmd.ExecuteScalar())
            objConnection.Close()
            'open connection and fill

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try

    End Sub
    Public ReadOnly Property Zip() As String
        Get
            Return returnValue
        End Get
    End Property
    Public ReadOnly Property CustDataset() As DataSet
        Get
            Return mDatasetCustomer
        End Get
    End Property
    Public Sub AddCustomer(ByVal strpassword As String, ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strCity As String, ByVal strState As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strEmailAddr As String)
        strQuery = "INSERT INTO Customers ( Password, LastName, FirstName, MI, Address, City, State, ZipCode, Phone, EmailAddr) VALUES (" & _
              "'" & strpassword & "', " & _
              "'" & strlast & "', " & _
              "'" & strfirst & "', " & _
              "'" & strMI & "', " & _
              "'" & strAddress & "', " & _
              "'" & strCity & "', " & _
              "'" & strState & "', " & _
              "'" & strZipCode & "', " & _
              "'" & strPhone & "', " & _
              "'" & strEmailAddr & "')"

        UpdateDB(strQuery)
    End Sub
    Public Function CheckEmail(ByVal strCheck As String) As Boolean
        For i = 0 To mDatasetCustomer.Tables.Count - 1

            If strCheck = mDatasetCustomer.Tables("Customers").Rows(0).Item("Email").ToString Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub ModifyCustomer(ByVal strpassword As String, ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strCity As String, ByVal strState As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strEmailAddr As String, ByVal strRecordID As String)
        strQuery = "UPDATE Customers SET Password = '" & strpassword & _
              "', LastName = '" & strlast & _
              "', FirstName = '" & strfirst & _
              "', MI = '" & strMI & _
              "', Address = '" & strAddress & _
              "', City = '" & strCity & _
              "', State = '" & strState & _
              "', ZipCode  = '" & strZipCode & _
              "', EmailAddr = '" & strEmailAddr & _
              "', Phone = '" & strPhone & _
              "' WHERE CustID = " & strRecordID

        UpdateDB(strQuery)
    End Sub
    Public Sub DeleteRecord(ByVal IntID As Integer)
        strQuery = "delete from customers where CustID =" & IntID
        UpdateDB(strQuery)
    End Sub
End Class

Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DBClassCustomer
    'Add objects to allow project to connect to database
    Dim strQuery As String
    Dim mDatasetCustomer As New DataSet
    Dim intLogin As New Integer
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim returnValue As String

    Dim mstrConnection As String = "workstation id =COMPUTER;packet size=4096;data source=MISSQL.mccombs.utexas.edu;integrated security = False;initial catalog=mis333k_20152_Team18;user id=msbcn366;password=Getrektm9"



    Public Sub GetAllCustomers()
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_get_all_customers", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            Me.mDatasetCustomer.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
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


    Public ReadOnly Property CustDataset() As DataSet
        Get
            Return mDatasetCustomer
        End Get
    End Property
    Public Sub AddCustomer(ByVal strpassword As String, ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strEmailAddr As String, ByVal CCN1 As String, ByVal CCN2 As String)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_add_customer", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Password", strpassword))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@LastName", strlast))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FirstName", strfirst))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@MI", strMI))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Address", strAddress))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ZipCode", strZipCode))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Phone", strPhone))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Email", strEmailAddr))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CCN1", CCN1))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CCN2", CCN2))


            'clear dataset
            Me.mDatasetCustomer.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Function CheckEmail(ByVal strCheck As String) As Boolean
        GetAllCustomers()
        For i = 0 To mDatasetCustomer.Tables("Customers").Rows.Count - 1

            If strCheck = mDatasetCustomer.Tables("Customers").Rows(i).Item("Email").ToString Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub EmpModifyCustomer(ByVal strpassword As String, ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strEmailAddr As String, ByVal CCN1 As String, ByVal CCN2 As String, ByVal Enabled As String, ByVal intCustID As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_Emp_modify_customer", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Password", strpassword))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@LastName", strlast))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FirstName", strfirst))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@MI", strMI))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Address", strAddress))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ZipCode", strZipCode))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Phone", strPhone))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Email", strEmailAddr))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Status", Enabled))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CCN1", CCN1))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CCN2", CCN2))


            'clear dataset
            Me.mDatasetCustomer.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub ModifyCustomer(ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strEmailAddr As String, ByVal CCN1 As String, ByVal CCN2 As String, ByVal Enabled As String, ByVal intCustID As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_modify_customer", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@LastName", strlast))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FirstName", strfirst))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@MI", strMI))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Address", strAddress))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ZipCode", strZipCode))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Phone", strPhone))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Email", strEmailAddr))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Status", Enabled))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CCN1", CCN1))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CCN2", CCN2))


            'clear dataset
            Me.mDatasetCustomer.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub ChangePassword(ByVal strpassword As String, ByVal intCustID As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_customer_changepass", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Password", strpassword))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))


            'clear dataset
            Me.mDatasetCustomer.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub DeleteRecord(ByVal IntID As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_customer_delete", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", IntID))


            'clear dataset
            Me.mDatasetCustomer.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetCustomer, "Customers")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
End Class

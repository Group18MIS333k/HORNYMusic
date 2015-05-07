Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class DBClassEmployee

    'Add objects to allow project to connect to database
    Dim strQuery As String
    Dim mDatasetZip As New DataSet
    Dim mDatasetEmployee As New DataSet
    Dim intLogin As New Integer
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim returnValue As String

    Dim mstrConnection As String = "workstation id =COMPUTER;packet size=4096;data source=MISSQL.mccombs.utexas.edu;integrated security = False;initial catalog=mis333k_20152_Team18;user id=msbcn366;password=Getrektm9"



    Public Sub GetAllEmployees()
 Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_get_all_employees", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
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
            mDatasetEmployee.Clear()
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
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
            Return mDatasetEmployee
        End Get
    End Property
    Public Sub AddEmployee(ByVal strpassword As String, ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strSSN As String, ByVal intEmpType As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_add_employee", objConnection)

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
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SSN", strSSN))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpType", intEmpType))
            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub ModifyEmployee(ByVal strPassword As String, ByVal strlast As String, ByVal strfirst As String, ByVal strMI As String, ByVal strAddress As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strSSN As String, ByVal strEmpID As String)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_modify_employee", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Password", strPassword))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@LastName", strlast))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FirstName", strfirst))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@MI", strMI))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Address", strAddress))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ZipCode", strZipCode))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Phone", strPhone))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SSN", strSSN))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpID", strEmpID))

            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub FireEmployee(ByVal IntID As Integer)
        Dim Fired As String
        Fired = "Inactive"
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_employee_firerehire", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Status", Fired))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpID", IntID))


            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub PromoteDemoteEmployee(ByVal IntID As Integer, ByVal intType As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_employee_promotedemote", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpType", intType))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpID", IntID))


            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub ChangePassword(ByVal strpassword As String, ByVal intEmpID As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_employee_changepass", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Password", strpassword))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpID", intEmpID))


            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub RehireEmployee(ByVal IntID As Integer)
        Dim Rehired As String
        Rehired = "Active"
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_employee_firerehire", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Status", Rehired))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@EmpID", IntID))


            'clear dataset
            Me.mDatasetEmployee.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetEmployee, "Employees")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Function CheckSSN(ByVal strCheck As String) As Boolean
        GetAllEmployees()
        For i = 0 To mDatasetEmployee.Tables("Employees").Rows.Count - 1

            If strCheck = mDatasetEmployee.Tables("Employees").Rows(i).Item("SSN").ToString Then
                Return True
            End If
        Next
        Return False
    End Function
End Class

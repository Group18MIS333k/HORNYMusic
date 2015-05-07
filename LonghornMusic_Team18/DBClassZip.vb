Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DBClassZip
    Dim mDatasetZip As New DataSet
    Dim strQuery As String
    Dim intLogin As New Integer
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim returnValue As String
    Dim mstrConnection As String = "workstation id =COMPUTER;packet size=4096;data source=MISSQL.mccombs.utexas.edu;integrated security = False;initial catalog=mis333k_20152_Team18;user id=msbcn366;password=Getrektm9"

    Public Sub GetCityZip(ByVal Zip As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'sets command type to stored procedure
            cmd.CommandText = "usp_customer_getcityzip"
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
            cmd.CommandText = "usp_customer_getstatezip"
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
End Class

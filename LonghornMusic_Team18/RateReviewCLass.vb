Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class RateReviewCLass
    Dim mDatasetRR As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_msbcs740;user id=msbcs740;password=C2d3e4!!!"
    Dim myView As New DataView




    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property RRDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetRR
        End Get
    End Property


    Public Sub SelectQuery(ByVal strQuery As String)

        ' purpose: run any select query and fill dataset

        Try
            ' define data connection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

            ' open the connection and dataset 
            mdbConn.Open()

            ' clear the dataset before filling
            mDatasetRR.Clear()

            ' fill the dataset
            mdbDataAdapter.Fill(mDatasetRR, "tblRateReview")

            ' close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub


    Public Sub GetCustomer(IntCustID As Integer)
        ' purpose: to return all customer records
        ' inputs: none
        ' outputs: none directly, but it opens and fills the dataset
        '          with all the records in tblCustomers

        ' to Get all Customers use Select and use username to filter
        mstrQuery = "select * from tblRateReview where CustID = '" & strUsername & "'"
        ' run the query
        SelectQuery(mstrQuery)
    End Sub


    Public Sub GetAllSongs()
        ' purpose: to return all customer records
        ' inputs: none
        ' outputs: none directly, but it opens and fills the dataset
        '          with all the records in tblCustomers

        ' to Get all Customers use Select and use username to filter
        mstrQuery = "select * from testSongs "
        ' run the query
        SelectQuery(mstrQuery)
    End Sub

End Class

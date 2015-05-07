Imports System.Data
Imports System.Data.SqlClient
Public Class OrderDetailClassDB
    Dim mDatasetOrderDetail As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_Team18;user id=msbcj918;password=M1organ61994"
    '(note: the above is ONE long line, not three separate lines as shown, and you must change the catalog to your McCombs login number)


    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property OrderDetailDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetOrderDetail
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        Get
            Return mMyView
        End Get
    End Property
    Public Sub OrderDetailGetAll()
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_CustOrderDetail_by_orderid", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear the dataset before filling
            mDatasetOrderDetail.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetOrderDetail, "CustOrderDetail")
            'fill dataview
            MyView.Table = mDatasetOrderDetail.Tables("CustOrderDetail")
            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try

    End Sub
End Class


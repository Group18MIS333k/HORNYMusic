Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class SongClass
    Dim mDatasetSong As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mysongView As New DataView




    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property SongDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetSong
        End Get
    End Property

    Public ReadOnly Property mySongView1() As DataView
        Get
            'return dataview
            Return mySongView
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
            mDatasetSong.Clear()

            ' fill the dataset
            mdbDataAdapter.Fill(mDatasetSong, "Songs")

            ' close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub

    Public Sub GetAllSongs()
        ' purpose: to return all customer records
        ' inputs: none
        ' outputs: none directly, but it opens and fills the dataset
        '          with all the records in tblCustomers

        ' to Get all Customers use Select and use username to filter
        mstrQuery = "select * from Songs "
        ' run the query
        SelectQuery(mstrQuery)
    End Sub

End Class


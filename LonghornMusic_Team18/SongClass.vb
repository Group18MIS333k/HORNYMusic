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

    Public Sub SelectAllSongs()

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_songs_Get_all", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetSong.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSong, "Songs")

            'copy dataset to view
            mysongView.Table = mDatasetSong.Tables("Songs")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub GetAllSongsinAlbum(intAlbumID As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "AlbumID =" & intAlbumID

        'sort filtered view


    End Sub
End Class


Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class SongGenreClass
    Dim mDatasetSongGenre As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mMysongGenreView As New DataView




    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property SongGenreDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetSongGenre
        End Get
    End Property

    Public ReadOnly Property mySongGenreView1() As DataView
        Get
            'return dataview
            Return mMysongGenreView
        End Get
    End Property

    Public Sub SelectAllSongswithGenre()

        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_genre_get_all", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetSongGenre.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSongGenre, "Songgenre")

            'copy dataset to view
            mMysongGenreView.Table = mDatasetSongGenre.Tables("Songgenre")
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub GetAllGenres()

        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Genre_getall", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetSongGenre.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSongGenre, "Genres")

            'copy dataset to view
            mMysongGenreView.Table = mDatasetSongGenre.Tables("Genres")
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub SelectAGenre(strGenreTItle As String)
        GetAllGenres()
        mMysongGenreView.RowFilter = "Genre = '" & strGenreTItle & "'"
    End Sub

    Public Sub SelectSongGenrefromSongID(intSongid As Integer)


        SelectAllSongswithGenre()
        mMysongGenreView.RowFilter = "SongID =" & intSongid

        'sort filtered view


    End Sub

    Public Sub GetGenrefromGenreID(intgenreid As Integer)


        SelectAllSongswithGenre()
        mMysongGenreView.RowFilter = "GenreID =" & intgenreid

        'sort filtered view


    End Sub

    Public Sub GetGenreIDandNamefromSongid(intsongID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_sgbridge_w_GenreNames", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intsongID))

            'clear dataset
            mDatasetSongGenre.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSongGenre, "Songgenre")

            'copy dataset to view
            mMysongGenreView.Table = mDatasetSongGenre.Tables("Songgenre")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub AddGenre(strGenre As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_genre_add", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Genre", strGenre))

            'clear dataset
            mDatasetSongGenre.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSongGenre, "Genres")

            'copy dataset to view
            mMysongGenreView.Table = mDatasetSongGenre.Tables("Genres")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub DeleteGenresfromSongid(intsongID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_genre_delete_by_song_id", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intsongID))


            'clear dataset
            mDatasetSongGenre.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSongGenre, "Songgenre")

            'copy dataset to view
            mMysongGenreView.Table = mDatasetSongGenre.Tables("Songgenre")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub AddGenresfromSongid(intsongID As Integer, intGenreID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_genre_add_by_song_id", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intsongID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@GenreID", intGenreID))

            'clear dataset
            mDatasetSongGenre.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSongGenre, "Songgenre")

            'copy dataset to view
            mMysongGenreView.Table = mDatasetSongGenre.Tables("Songgenre")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

End Class

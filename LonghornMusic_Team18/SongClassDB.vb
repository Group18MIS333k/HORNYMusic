Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class SongClassDB
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
            Return mysongView
        End Get
    End Property

    Public Sub SelectAllSongs()

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

    Public Sub SelectSongfromSongID(intSongid As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "SongID =" & intSongid

        'sort filtered view


    End Sub

    Public Sub GetAllSongsinAlbum(intAlbumID As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "AlbumID =" & intAlbumID

        'sort filtered view


    End Sub

    Public Sub GetFeaturedSong()

        SelectFeaturedSongs()



    End Sub



    Public Sub SelectASongwithTitleandArtist(strSongTitle As String, intArtistID As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "SongTitle = '" & strSongTitle & "' and ArtistID = ' " & intArtistID & "'"




    End Sub


    Public Sub SelectASongwithAlbumandTitle(strSOngtitle As String, intAlbumID As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "SongTitle = '" & strSOngtitle & "' and AlbumID = ' " & intAlbumID & "'"

        'sort filtered view


    End Sub



    Public Sub SelectSongsbyArtist(intArtistID As Integer)
        SelectAllSongs()
        mysongView.RowFilter = "ArtistID =" & intArtistID

    End Sub

    Public Sub AddSong(strSongTitle As String, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, decdiscountprice As Decimal, intAlbumID As Integer, strFlag As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_add_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songtitle", strSongTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@DiscountPrice", decdiscountprice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intAlbumID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFlag))




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

    Public Sub AddSongwithNoAlbum(strSongTitle As String, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, strFlag As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_add_with_no_album", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songtitle", strSongTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFlag))




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

    Public Sub RemoveSong(ByVal intSongID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_delete_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songid", intSongID))

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

    Public Sub ModifySong(strSongTitle As String, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, intAlbumID As Integer, strFlag As String, decDiscountPrice As Decimal, intSongID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_modify_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songtitle", strSongTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intAlbumID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFlag))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intSongID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@DiscountPrice", decDiscountPrice))





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

    Public Sub ModifySongnoalbum(strSongTitle As String, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, strFlag As String, decDiscountPrice As Decimal, intSongID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_modify_no_album", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songtitle", strSongTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFlag))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intSongID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@DiscountPrice", decDiscountPrice))





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

    Public Sub SelectFeaturedSongs()

        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_getfeatured_song", mdbConn)

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

    Public Sub SelectDiscountedSongs()

        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_DiscountedSongs_GetALL", mdbConn)

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

    Public Sub GetSongListByArtist(ByVal intArtistID As Integer)
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_AllSongs_byArtist", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
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

    Public Sub GetTrackListByAlbum(ByVal intAlbumID As Integer)
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_AllSongs_onAlbum", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@albumID", intAlbumID))
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
    Public Sub GetGenresBySong(ByVal intsongID As Integer)
        'needs work
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_AllSongs_byArtist", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songID", intsongID))
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
    Public Sub GetSongDescription(ByVal intSongID As Integer)
        'morgan
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_get_description", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songID", intSongID))
            'clear the dataset before filling
            mDatasetSong.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetSong, "Songs")
            'fill dataview
            mysongView.Table = mDatasetSong.Tables("Songs")
            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub GetCart(ByVal intSongID As Integer)
        'morgan
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_get_Cart_Values", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songID", intSongID))
            'clear the dataset before filling
            mDatasetSong.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetSong, "Songs")
            'fill dataview
            mysongView.Table = mDatasetSong.Tables("Songs")
            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

End Class


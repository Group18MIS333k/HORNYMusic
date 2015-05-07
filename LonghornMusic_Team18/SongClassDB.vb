Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class SongClassDB
    Dim mDatasetSong As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mMysongView As New DataView
    Dim mMyView As New DataView

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property SongDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetSong
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        Get
            Return mMyView
        End Get
    End Property

    Public ReadOnly Property mySongView1() As DataView
        Get
            'return dataview
            Return mMysongView
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
            mMysongView.Table = mDatasetSong.Tables("Songs")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetAllSongsinAlbum(intAlbumID As Integer)

        'get all songs with sub above
        SelectAllSongs()
        'sort filtered view
        mMysongView.RowFilter = "AlbumID =" & intAlbumID
    End Sub

    Public Sub SelectASongwithTitleandArtist(strSongTitle As String, intArtistID As Integer)

        'get all songs with sub above
        SelectAllSongs()
        'sort filtered view
        mMysongView.RowFilter = "SongTitle = '" & strSongTitle & "'"
        mMysongView.RowFilter = "ArtistID =" & intArtistID



    End Sub


    Public Sub SelectASongwithAlbumandTitle(strSOngtitle As String, intAlbumID As Integer)

        'get all songs with sub above
        SelectAllSongs()
        'sort filtered view
        mMysongView.RowFilter = "SongTitle = '" & strSOngtitle & "' and AlbumID = ' " & intAlbumID & "'"

    End Sub

    Public Sub SelectSongsbyArtist(intArtistID As Integer)
        SelectAllSongs()
        mMysongView.RowFilter = "ArtistID =" & intArtistID

    End Sub

    Public Sub AddSong(strSongTitle As String, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, intAlbumID As Integer, strFlag As String)

        'Runs SP to add song to song table (album id can be null or a value)
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_add_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add Paranmeter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songtitle", strSongTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intAlbumID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFlag))

            'clear dataset
            mDatasetSong.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetSong, "Songs")

            'copy dataset to view
            mMysongView.Table = mDatasetSong.Tables("Songs")
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub RemoveSong(ByVal intSongID As Integer)

        'use SP to remove song from song table
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
            mMysongView.Table = mDatasetSong.Tables("Songs")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub ModifySong(strSongTitle As String, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, intAlbumID As Integer, strFlag As String, decDiscountPrice As Decimal, intSongID As Integer)

        'use SP to modify songs in song table
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_modify_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameter

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
            mMysongView.Table = mDatasetSong.Tables("Songs")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub SearchRatings(ByVal decRatingLower As Decimal, ByVal decRatingUpper As Decimal)
        'morgan
        mMyView.RowFilter = "AvgRatingNBR > '" & decRatingLower & "' AND avgRatingNBR < '" & decRatingUpper & "'"
    End Sub
    Public Sub SongSearchSort(ByVal strSortValue As String)
        'morgan 
        If strSortValue = "Rating Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AvgRatingNbr ASC"
        End If

        If strSortValue = "Rating Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AvgRatingNbr DESC"
        End If

        If strSortValue = "Artist Name Ascending" Then
            MyView.Sort = "ArtistName ASC"
        End If

        If strSortValue = "Artist Name Descending" Then
            MyView.Sort = "ArtistName DESC"
        End If

        If strSortValue = "Album Name Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AlbumTitle ASC"
        End If

        If strSortValue = "Album Name Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AlbumTitle DESC"
        End If

        If strSortValue = "Song Title Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "SongTitle ASC"
        End If

        If strSortValue = "Song Title Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "SongTitle DESC"
        End If

    End Sub
    Public Sub SongSearchWithAnyParameters(ByVal strSPName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'purpose to run a stored procedure with one parameter
        'inputs: stored procedure name, table name, dataset name, dataview name, array list of pparameter name, array list of parameter Value
        'returns: dataset filled with the correct answers
        'authr: morgan may

        'creates instances of the connection and the command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'tell sql server the name of the stored procedure you wil be executing 
        Dim mdbDataAdapter As New SqlDataAdapter(strSPName, objConnection)
        Try
            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameter(s) to SPROC
            Dim index As Integer = 0
            For Each strParamName As String In aryParamNames
                mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'clear dataset
            Me.mDatasetSong.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetSong, "tblAlbums")
            'copy dataset to dataview
            mMyView.Table = mDatasetSong.Tables("tblAlbums")

        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName : " & CStr(aryParamNames(index))
                strError = strError & "ParamValue: " & CStr(aryParamValues(index))
                index = index + 1
            Next
            Throw New Exception(strError & " error is " & ex.Message)
        End Try
    End Sub

End Class


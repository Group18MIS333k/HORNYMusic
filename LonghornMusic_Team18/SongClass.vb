﻿Imports Microsoft.VisualBasic
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
    Public Sub GetAllSongsinAlbum(intAlbumID As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "AlbumID =" & intAlbumID

            'sort filtered view


    End Sub


    Public Sub SelectASongwithTitle(strSongTitle As String, intArtistID As Integer)


        SelectAllSongs()
        mysongView.RowFilter = "SongTitle = '" & strSongTitle & "'"
        mysongView.RowFilter = "ArtistID =" & intArtistID

        'sort filtered view


    End Sub

    Public Sub AddSong(strSongTitle As String, intSongID As Integer, strDescription As String, intArtistID As Integer, decOriginalPrice As Decimal, decDiscountPrice As Decimal, intAlbumID As Integer, strFlag As String, decRating As Decimal, intNoCustRate As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_add_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songid", intSongID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@songtitle", strSongTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@DiscountPrice", decDiscountPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intAlbumID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFlag))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AverageRatingNBR", decRating))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@NoCustRate", intNoCustRate))



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


End Class

﻿Public Class ArtistDetail
    Inherits System.Web.UI.Page

    Dim ArtistDB As New ArtistClassDB
    Dim AlbumDB As New AlbumClassDB
    Dim SongDB As New SongClassDB
    Dim RRDB As New RateReviewCLass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intArtistID As Integer = Session("ArtistID")
        If IsPostBack = False Then

            'intArtistID = 4
            'load the grid
            'get searched song info
            'SongDB.SelectAllSongs()
            'AlbumDB.SelectAllAlbums()
            SongDB.GetSongListByArtist(intArtistID)
            AlbumDB.GetAlbumListByArtist(intArtistID)
            ArtistDB.GetArtistDescription(intArtistID)
            RRDB.GetArtistRatingReviews(intArtistID)
            ''make gv's visble 
            gvSongList.Visible = True
            gvAlbumList.Visible = True
            gvArtistDescription.Visible = True
            gvArtistRR.Visible = True
            ''narrow down gv's based on that artist the page is supposed to be loaded for 
            'AlbumDB.MyView.RowFilter = "ArtistID = '" & intArtistID & "'"
            'SongDB.MyView.RowFilter = "ArtistID = '" & intArtistID & "'"
            'declare session variables 
            ' Session("CountGoodSearches") = 0
            DataBindSongGV()
            DataBindAlbumGV()
            DataBindDescriptionGV()
            DataBindRatingReviewGV()


            'Else
            '    ' SongDB.SongGetAll()
            '    DataBindSongGV()
            '    DataBindAlbumGV()
        End If


    End Sub
    Public Sub DataBindSongGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvSongList.DataSource = SongDB.SongDataset.Tables("Songs")

        'bind gridview to myview based on sort 
        gvSongList.DataSource = SongDB.mySongView1
        gvSongList.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Public Sub DataBindAlbumGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvAlbumList.DataSource = AlbumDB.AlbumDataset.Tables("Albums")

        'bind gridview to myview based on sort 
        gvAlbumList.DataSource = AlbumDB.myAlbumView1
        gvAlbumList.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Public Sub DataBindDescriptionGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvArtistDescription.DataSource = ArtistDB.ArtistDataset.Tables("Artist")

        'bind gridview to myview based on sort 
        gvArtistDescription.DataSource = ArtistDB.myArtistview1
        gvArtistDescription.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Public Sub DataBindRatingReviewGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvArtistRR.DataSource = RRDB.RRDataset.Tables("Ratings")

        'bind gridview to myview based on sort 
        gvArtistRR.DataSource = RRDB.myView1
        gvArtistRR.DataBind()

        'count of how many elements are in the view after sort

    End Sub

    Protected Sub gvAlbumList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAlbumList.SelectedIndexChanged
        Dim intAlbumID As Integer
        intAlbumID = CInt(gvAlbumList.SelectedRow.Cells(0).Text)
        Session("AlbumID") = intAlbumID
        Response.Redirect("~/AlbumDetail.aspx")
    End Sub

    Protected Sub gvSongList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongList.SelectedIndexChanged
        Dim intSongID As Integer
        intSongID = CInt(gvSongList.SelectedRow.Cells(0).Text)
        Session("AlbumID") = intSongID
        Response.Redirect("~/SongDetail.aspx")
    End Sub
End Class
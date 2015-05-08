Public Class AlbumDetail
    Inherits System.Web.UI.Page
    Dim ArtistDB As New ArtistClassDB
    Dim AlbumDB As New AlbumClassDB
    Dim SongDB As New SongClassDB
    Dim RRDB As New RateReviewCLass
    Dim dbratereview As New RateReviewCLass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intAlbumID As Integer = Session("AlbumID")
        If IsPostBack = False Then


            'load the grid
            'get searched song info
            'SongDB.SelectAllSongs()
            'AlbumDB.SelectAllAlbums()
            SongDB.GetTrackListByAlbum(intAlbumID)
            'AlbumDB.GetAlbumListByArtist(intAlbumID)
            AlbumDB.GetAlbumDescription(intAlbumID)
            RRDB.GetAlbumRatingReviews(intAlbumID)
            ''make gv's visble 
            gvTrackList.Visible = True
            'gvAlbumList.Visible = True
            gvAlbumDescription.Visible = True
            gvAlbumRR.Visible = True
            ''narrow down gv's based on that artist the page is supposed to be loaded for 
            'AlbumDB.MyView.RowFilter = "ArtistID = '" & intAlbumID & "'"
            'SongDB.MyView.RowFilter = "ArtistID = '" & intAlbumID & "'"
            'declare session variables 
            ' Session("CountGoodSearches") = 0
            DataBindTrackGV()
            DataBindDescriptionGV()
            DataBindRatingReviewGV()

            dbratereview.SearchReviewByAlbum(intAlbumID)
            gvComments.DataSource = dbratereview.myView1
            gvComments.DataBind()

            'Else
            '' SongDB.SongGetAll()
            'DataBindSongGV()
            'DataBindAlbumGV()
        End If

        LblArtistName.Text = Session("ArtistID")
    End Sub
    Public Sub DataBindTrackGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvTrackList.DataSource = SongDB.SongDataset.Tables("Songs")

        'bind gridview to myview based on sort 
        gvTrackList.DataSource = SongDB.mySongView1
        gvTrackList.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    'Public Sub DataBindAlbumGV()
    '    'purpose: elimate duplicate code for everytime a view needs a databind 

    '    'sort by the selected item 
    '    'SongDB.DoSort(radSort.SelectedValue.ToString)

    '    'sets gv to dataset &bind
    '    gvAlbumList.DataSource = AlbumDB.AlbumDataset.Tables("Albums")

    '    'bind gridview to myview based on sort 
    '    gvAlbumList.DataSource = AlbumDB.myAlbumView1
    '    gvAlbumList.DataBind()

    '    'count of how many elements are in the view after sort

    'End Sub
    Public Sub DataBindDescriptionGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvAlbumDescription.DataSource = AlbumDB.AlbumDataset.Tables("Albums")

        'bind gridview to myview based on sort 
        gvAlbumDescription.DataSource = AlbumDB.myAlbumView1
        gvAlbumDescription.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Public Sub DataBindRatingReviewGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvAlbumRR.DataSource = RRDB.RRDataset.Tables("Ratings")

        'bind gridview to myview based on sort 
        gvAlbumRR.DataSource = RRDB.myView1
        gvAlbumRR.DataBind()

        'count of how many elements are in the view after sort

    End Sub

    Protected Sub BtnAdd2Cart_Click(sender As Object, e As EventArgs) Handles BtnAdd2Cart.Click

    End Sub
    Protected Sub ResultGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvComments.RowDataBound
        e.Row.Cells(1).Visible = False
        e.Row.Cells(2).Visible = False
        e.Row.Cells(3).Visible = False
        e.Row.Cells(4).Visible = False
        e.Row.Cells(6).Visible = False
        e.Row.Cells(8).Visible = False

    End Sub

    Protected Sub gvComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvComments.SelectedIndexChanged
        Session("AlbumName") = LblArtistName.Text


        Session("CommentID") = CInt(gvComments.SelectedRow.Cells(8).Text)
        Response.Redirect("Vote.Aspx")
    End Sub
End Class
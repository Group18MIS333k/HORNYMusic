Public Class ArtistDetail
    Inherits System.Web.UI.Page
    Dim ArtistDB As New ArtistClassDB
    Dim AlbumDB As New AlbumClassDB
    Dim SongDB As New SongClassDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intArtistID As Integer = Session("ArtistID")
        If IsPostBack = False Then

            'load the grid
            'get searched song info
            SongDB.SelectAllSongs()
            AlbumDB.SelectAllAlbums()

            'make gv's visble 
            gvSongList.Visible = True
            gvAlbumList.Visible = True

            'narrow down gv's based on that artist the page is supposed to be loaded for 
            AlbumDB.MyView.RowFilter = "ArtistID =" & intArtistID
            SongDB.MyView.RowFilter = "ArtistID =" & intArtistID
            'declare session variables 
            ' Session("CountGoodSearches") = 0
            DataBindSongGV()
            DataBindAlbumGV()
        Else
            ' SongDB.SongGetAll()
            DataBindSongGV()
            DataBindAlbumGV()
        End If

        LblArtistName.Text = Session("ArtistID")
    End Sub

    Public Sub DataBindSongGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvSongList.DataSource = SongDB.SongDataset.Tables("Songs")

        'bind gridview to myview based on sort 
        gvSongList.DataSource = SongDB.MyView
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
        gvAlbumList.DataSource = AlbumDB.MyView
        gvAlbumList.DataBind()

        'count of how many elements are in the view after sort

    End Sub

    Protected Sub gvAlbumList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAlbumList.SelectedIndexChanged

    End Sub
End Class
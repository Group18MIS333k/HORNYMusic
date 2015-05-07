Public Class EditProduct
    Inherits System.Web.UI.Page

    Dim DBvalidations As New ManageProductsValidation
    Dim DBSongs As New SongClass
    Dim DBArtist As New ArtistClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'get information of song from db and selected value from the gridview

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
     


        'check that artist exists in the database
        Dim strArtistName As String = "test artist"
        Dim strSongname As String = "testing code"
        Dim artistId As String
        Dim strFlag As String
        artistId = 0

        DBArtist.SelectArtist(strArtistName)

        gvArtist.DataSource = DBArtist.myArtistview1
        gvArtist.DataBind()

        If DBArtist.myArtistview1.Count = 0 Then
            lblError.Text = "Artist doest not exist, please add artist first"
            Exit Sub
        End If

        'DBArtist.myArtistview1.Table.Rows(0).Item("artistID")


        strFlag = radFeatured.SelectedValue.ToString


        'check that song is not duplicate

        DBSongs.SelectASongwithTitleandArtist(strSongname, artistId)
        If DBSongs.mySongView1.Count > 0 Then
            lblError.Text = "Song with same artist already exists"
            Exit Sub
        End If


        'add code to modify song

        DBSongs.ModifySong(txtSong.Text, txtDescription.Text, "artistid", Convert.ToDecimal(txtPrice.Text), "albumID", strFlag, Convert.ToDecimal(txtDiscountPrice.Text), "songID")














    End Sub

   
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("SongDetail.aspx")
    End Sub

    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemovefrmAlbum.Click
        Dim intSongID As Integer = 0
        DBSongs.RemoveSong(intSongID)

        lblError.Text = "song removed"


    End Sub

    Protected Sub btnAddSong_Click(sender As Object, e As EventArgs) Handles btnAddSong.Click
        Response.Redirect("addsong.aspx")
    End Sub
End Class
Public Class AddSong
    Inherits System.Web.UI.Page


    Dim dbSongs As New SongClass
    Dim dbArtist As New ArtistClass
    Dim dbAlbum As New AlbumClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
         Dim intartistId As Integer
        Dim intAlbumID As Integer


        dbArtist.SelectArtist(txtArtist.Text)

        If dbArtist.myArtistview1.Count = 0 Then
            lblError.Text = "Artist doest not exist, please add artist first"
            Exit Sub
        End If

        gvArtist.DataSource = dbArtist.myArtistview1
        gvArtist.DataBind()

        intartistId = gvArtist.Rows(0).Cells(5).Text


        DBSongs.SelectASongwithTitleandArtist(txtSong.Text, intartistId)
        If DBSongs.mySongView1.Count > 0 Then
            lblError.Text = "Song with same artist already exists"
            Exit Sub
        End If

        DBAlbum.GetAlbumFromTitle(txtAlbum.Text)

        gvAlbum.DataSource = DBAlbum.myAlbumView1
        gvAlbum.DataBind()


        If DbAlbum.myAlbumView1.Count = 0 Then
            dbSongs.AddSongwithNoAlbum(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), radFeatured.SelectedValue.ToString)
        Else
            intAlbumID = gvAlbum.Rows(0).Cells(8).Text
            dbSongs.AddSong(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), intAlbumID, radFeatured.SelectedValue.ToString)
        End If

        lblError.Text = "Song has been added"
        btnAdd.Visible = False
    End Sub

    
End Class
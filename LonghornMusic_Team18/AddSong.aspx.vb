Public Class AddSong
    Inherits System.Web.UI.Page


    Dim dbSongs As New SongClass
    Dim dbArtist As New ArtistClass
    Dim dbAlbum As New AlbumClass
    Dim dbsonggenre As New SongGenreClass
    Dim dbvalidations As New ValidationClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
         Dim intartistId As Integer
        Dim intAlbumID As Integer
        Dim decDiscountPrice As Decimal
        Dim intSongID As Integer


        If txtDescription.Text = "" Then
            lblError.Text = "artist description required"
            Exit Sub
        End If

        If txtSong.Text = "" Then
            lblError.Text = "song name required"
            Exit Sub
        End If


        If dbvalidations.CheckDecimal(txtPrice.Text) = -1 Then
            lblError.Text = "Decimal price required"
            Exit Sub

        End If

        If txtArtist.Text = "" Then
            lblError.Text = "artist required"
            Exit Sub
        End If

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

        If txtDiscountPrice.Text = "" Then
            decDiscountPrice = 0
        Else
            If dbvalidations.CheckDecimal(txtDiscountPrice.Text) = -1 Then
                lblError.Text = "discount price must be decimal"
                Exit Sub
            End If
            decDiscountPrice = txtDiscountPrice.Text
        End If

        'check featured
        If radFeatured.SelectedValue = "Y" Then
            'check no other featured values
            dbSongs.GetFeaturedSong()
            If dbSongs.mySongView1.Count > 0 Then
                lblError.Text = "Featured Song already exists"
                Exit Sub
            End If
            dbArtist.GetFeaturedArtist()
            If dbArtist.myArtistview1.Count > 0 Then
                lblError.Text = "Featured Artist already exists"
                Exit Sub
            End If
            dbAlbum.GetFeaturedAlbum()
            If dbAlbum.myAlbumView1.Count > 0 Then
                lblError.Text = "Featured album already exists"
                Exit Sub
            End If
        End If

        'check genres
        DbSongGenre.SelectAGenre(txtGenre1.Text)
        If DbSongGenre.mySongGenreView1.Count = 0 And txtGenre1.Text <> "" Then
            lblError.Text = "Genre 1 does not exist, please add"
            Exit Sub
        End If

        DbSongGenre.SelectAGenre(txtGenre2.Text)
        If DbSongGenre.mySongGenreView1.Count = 0 And txtGenre2.Text <> "" Then
            lblError.Text = "Genre 2 does not exist, please add"
            Exit Sub
        End If

        DbSongGenre.SelectAGenre(txtGenre3.Text)
        If DbSongGenre.mySongGenreView1.Count = 0 And txtGenre3.Text <> "" Then
            lblError.Text = "Genre 3 does not exist, please add"
            Exit Sub
        End If

        DbSongGenre.SelectAGenre(txtGenre4.Text)
        If DbSongGenre.mySongGenreView1.Count = 0 And txtGenre4.Text <> "" Then
            lblError.Text = "Genre 4 does not exist, please add"
            Exit Sub
        End If

        DbSongGenre.SelectAGenre(txtGenre5.Text)
        If DbSongGenre.mySongGenreView1.Count = 0 And txtGenre5.Text <> "" Then
            lblError.Text = "Genre 5 does not exist, please add"
            Exit Sub
        End If

        'add genres


        If DbAlbum.myAlbumView1.Count = 0 Then
            dbSongs.AddSongwithNoAlbum(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), radFeatured.SelectedValue.ToString)
        Else
            intAlbumID = gvAlbum.Rows(0).Cells(8).Text
            dbSongs.AddSong(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), decDiscountPrice, intAlbumID, radFeatured.SelectedValue.ToString)
        End If

        lblError.Text = "Song has been added"

        dbSongs.SelectASongwithTitleandArtist(txtSong.Text, intartistId)
        gvArtist.DataSource = dbSongs.mySongView1
        gvArtist.DataBind()

        intSongID = gvArtist.Rows(0).Cells(9).Text


        'add genres
        If txtGenre1.Text <> "" Then
            dbsonggenre.SelectAGenre(txtGenre1.Text)
            gvsonggenre.DataSource = dbsonggenre.mySongGenreView1
            gvsonggenre.DataBind()
            dbsonggenre.AddGenresfromSongid(intSongID, gvsonggenre.Rows(0).Cells(1).Text)
        End If

        If txtGenre2.Text <> "" Then
            dbsonggenre.SelectAGenre(txtGenre2.Text)
            gvsonggenre.DataSource = dbsonggenre.mySongGenreView1
            gvsonggenre.DataBind()
            dbsonggenre.AddGenresfromSongid(intSongID, gvsonggenre.Rows(0).Cells(1).Text)
        End If

        If txtGenre3.Text <> "" Then
            dbsonggenre.SelectAGenre(txtGenre3.Text)
            gvsonggenre.DataSource = dbsonggenre.mySongGenreView1
            gvsonggenre.DataBind()
            dbsonggenre.AddGenresfromSongid(intSongID, gvsonggenre.Rows(0).Cells(1).Text)
        End If
        If txtGenre4.Text <> "" Then
            dbsonggenre.SelectAGenre(txtGenre4.Text)
            gvsonggenre.DataSource = dbsonggenre.mySongGenreView1
            gvsonggenre.DataBind()
            dbsonggenre.AddGenresfromSongid(intSongID, gvsonggenre.Rows(0).Cells(1).Text)
        End If
        If txtGenre5.Text <> "" Then
            dbsonggenre.SelectAGenre(txtGenre5.Text)
            gvsonggenre.DataSource = dbsonggenre.mySongGenreView1
            gvsonggenre.DataBind()
            dbsonggenre.AddGenresfromSongid(intSongID, gvsonggenre.Rows(0).Cells(1).Text)
        End If

        btnAdd.Visible = False
    End Sub

    
End Class
Public Class EditProduct
    Inherits System.Web.UI.Page

    Dim DBvalidations As New ManageProductsValidation
    Dim DBSongs As New SongClass
    Dim DBArtist As New ArtistClass
    Dim DbAlbum As New AlbumClass
    Dim DbSongGenre As New SongGenreClass
    Dim Dbvalidation As New ValidationClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'session variable song id
            Dim intsongid As Integer = 1
            Dim intartistid As Integer
            Dim intalbumID As Integer
            Dim intNumberofGenres As Integer


            DBSongs.SelectSongfromSongID(intsongid)
            gvSongs.DataSource = DBSongs.mySongView1
            gvSongs.DataBind()
            intartistid = gvSongs.Rows(0).Cells(2).Text
            txtSong.Text = gvSongs.Rows(0).Cells(0).Text
            txtDescription.Text = gvSongs.Rows(0).Cells(1).Text

            DBArtist.SelectArtistwithArtistID(intartistid)
            gvArtist.DataSource = DBArtist.myArtistview1
            gvArtist.DataBind()

            txtArtist.Text = gvArtist.Rows(0).Cells(0).Text
            txtPrice.Text = gvSongs.Rows(0).Cells(3).Text
            If gvSongs.Rows(0).Cells(4).Text = "&nbsp;" Then
                txtDiscountPrice.Text = 0
            Else
                txtDiscountPrice.Text = gvSongs.Rows(0).Cells(4).Text
            End If
            If gvSongs.Rows(0).Cells(5).Text = "&nbsp;" Then
                txtAlbum.Text = ""
            Else
                intalbumID = gvSongs.Rows(0).Cells(5).Text
                DbAlbum.GetAlbumFromAlbumID(intalbumID)
                gvAlbum.DataSource = DbAlbum.myAlbumView1
                gvAlbum.DataBind()
                txtAlbum.Text = gvAlbum.Rows(0).Cells(0).Text

            End If
            radFeatured.SelectedValue = gvSongs.Rows(0).Cells(6).Text

            DbSongGenre.GetGenreIDandNamefromSongid(intsongid)
            intNumberofGenres = DbSongGenre.mySongGenreView1.Count
            lblError.Text = intNumberofGenres
            gvSongGenre.DataSource = DbSongGenre.mySongGenreView1
            gvSongGenre.DataBind()

            If intNumberofGenres = 1 Then
                txtGenre1.Text = gvSongGenre.Rows(0).Cells(1).Text
            End If

            If intNumberofGenres = 2 Then
                txtGenre1.Text = gvSongGenre.Rows(0).Cells(1).Text
                txtGenre2.Text = gvSongGenre.Rows(1).Cells(1).Text
            End If
            If intNumberofGenres = 3 Then
                txtGenre1.Text = gvSongGenre.Rows(0).Cells(1).Text
                txtGenre2.Text = gvSongGenre.Rows(1).Cells(1).Text
                txtGenre3.Text = gvSongGenre.Rows(2).Cells(1).Text
            End If

            If intNumberofGenres = 4 Then
                txtGenre1.Text = gvSongGenre.Rows(0).Cells(1).Text
                txtGenre2.Text = gvSongGenre.Rows(1).Cells(1).Text
                txtGenre3.Text = gvSongGenre.Rows(2).Cells(1).Text
                txtGenre4.Text = gvSongGenre.Rows(3).Cells(1).Text
            End If

            If intNumberofGenres = 5 Then
                txtGenre1.Text = gvSongGenre.Rows(0).Cells(1).Text
                txtGenre2.Text = gvSongGenre.Rows(1).Cells(1).Text
                txtGenre3.Text = gvSongGenre.Rows(2).Cells(1).Text
                txtGenre4.Text = gvSongGenre.Rows(3).Cells(1).Text
                txtGenre5.Text = gvSongGenre.Rows(4).Cells(1).Text
            End If


        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
     


        'check that artist exists in the database
        
        Dim intartistId As Integer
        Dim intAlbumID As Integer
        Dim decDiscountPrice As Decimal
        Dim intSongID As Integer = 1
        'Session("intSongID")


        DBArtist.SelectArtist(txtArtist.Text)

        If DBArtist.myArtistview1.Count = 0 Then
            lblError.Text = "Artist doest not exist, please add artist first"
            Exit Sub
        End If

        gvArtist.DataSource = DBArtist.myArtistview1
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
            If Dbvalidation.CheckDecimal(txtDiscountPrice.Text) = -1 Then
                lblError.Text = "please enter a decimal discount price"
                Exit Sub
            End If
            decDiscountPrice = Convert.ToDecimal(txtDiscountPrice.Text)
        End If

        If Dbvalidation.CheckDecimal(txtPrice.Text) = -1 Then
            lblError.Text = "please enter a decimal price"
            Exit Sub
        End If



        'modify genres
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

        'delete all genres with song id
        DbSongGenre.DeleteGenresfromSongid(intSongID)

        'add genres from edit form
        If txtGenre1.Text <> "" Then
            DbSongGenre.SelectAGenre(txtGenre1.Text)
            gvSongGenre.DataSource = DbSongGenre.mySongGenreView1
            gvSongGenre.DataBind()
            DbSongGenre.AddGenresfromSongid(intSongID, gvSongGenre.Rows(0).Cells(1).Text)
        End If

        If txtGenre2.Text <> "" Then
            DbSongGenre.SelectAGenre(txtGenre2.Text)
            gvSongGenre.DataSource = DbSongGenre.mySongGenreView1
            gvSongGenre.DataBind()
            DbSongGenre.AddGenresfromSongid(intSongID, gvSongGenre.Rows(0).Cells(1).Text)
        End If

        If txtGenre3.Text <> "" Then
            DbSongGenre.SelectAGenre(txtGenre3.Text)
            gvSongGenre.DataSource = DbSongGenre.mySongGenreView1
            gvSongGenre.DataBind()
            DbSongGenre.AddGenresfromSongid(intSongID, gvSongGenre.Rows(0).Cells(1).Text)
        End If
        If txtGenre4.Text <> "" Then
            DbSongGenre.SelectAGenre(txtGenre4.Text)
            gvSongGenre.DataSource = DbSongGenre.mySongGenreView1
            gvSongGenre.DataBind()
            DbSongGenre.AddGenresfromSongid(intSongID, gvSongGenre.Rows(0).Cells(1).Text)
        End If
        If txtGenre5.Text <> "" Then
            DbSongGenre.SelectAGenre(txtGenre5.Text)
            gvSongGenre.DataSource = DbSongGenre.mySongGenreView1
            gvSongGenre.DataBind()
            DbSongGenre.AddGenresfromSongid(intSongID, gvSongGenre.Rows(0).Cells(1).Text)
        End If

        If DbAlbum.myAlbumView1.Count = 0 Then
            DBSongs.ModifySongnoalbum(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), radFeatured.SelectedValue.ToString, decDiscountPrice, intSongID)
        Else
            intAlbumID = gvAlbum.Rows(0).Cells(8).Text
            DBSongs.ModifySong(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), intAlbumID, radFeatured.SelectedValue.ToString, decDiscountPrice, intSongID)
        End If

        lblError.Text = "song has been modified"

    End Sub

    Protected Sub btnAddSong_Click(sender As Object, e As EventArgs) Handles btnAddSong.Click
        Response.Redirect("addsong.aspx")
    End Sub

    Protected Sub txtGenre1_TextChanged(sender As Object, e As EventArgs) Handles txtGenre1.TextChanged

    End Sub
End Class
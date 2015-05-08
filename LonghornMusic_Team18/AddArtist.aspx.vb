Public Class AddArtist
    Inherits System.Web.UI.Page

    Dim DBArtist As New ArtistClassDB
    Dim DBAlbum As New AlbumClassDB
    Dim DBSongs As New SongClassDB
    Dim DBValidations As New ValidationClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim intArtistID As Integer
        Dim intAlbumID As Integer
        Dim decdiscountprice As Decimal


        If txtArtist.Text = "" Then
            lblError.Text = "artist required"
            Exit Sub
        End If

        If txtSongDescription.Text = "" Then
            lblError.Text = "song description required"
        End If

        If txtDescription.Text = "" Then
            lblError.Text = "artist description required"
            Exit Sub
        End If

        If txtSong.Text = "" Then
            lblError.Text = "song name required"
            Exit Sub
        End If

        If DBValidations.CheckDecimal(txtPrice.Text) = -1 Then
            lblError.Text = "decimal price required"
            Exit Sub

        End If

        If radFeatured.SelectedValue = "Y" Then
            'check no other featured values
            DBSongs.GetFeaturedSong()
            If DBSongs.mySongView1.Count > 0 Then
                lblError.Text = "Featured Song already exists"
                Exit Sub
            End If
            DBArtist.GetFeaturedArtist()
            If DBArtist.myArtistview1.Count > 0 Then
                lblError.Text = "Featured Artist already exists"
                Exit Sub
            End If
            DBAlbum.GetFeaturedAlbum()
            If DBAlbum.myAlbumView1.Count > 0 Then
                lblError.Text = "Featured album already exists"
                Exit Sub
            End If
        End If

        'create new artist ID
        DBArtist.AddArtist(txtArtist.Text)

        DBArtist.SelectNewArtist()


        gvNewArtist.DataSource = DBArtist.myArtistview1
        gvNewArtist.DataBind()

        intArtistID = gvNewArtist.Rows(0).Cells(5).Text

        DBAlbum.GetAlbumFromTitle(txtAlbum.Text)

        gvAlbum.DataSource = DBAlbum.myAlbumView1
        gvAlbum.DataBind()

        If txtDiscountPrice.Text = "" Then
            decdiscountprice = 0.0
        Else
            If DBValidations.CheckDecimal(txtDiscountPrice.Text) = -1 Then
                lblError.Text = "Please enter a decimal discount price"
                Exit Sub
            End If
            decdiscountprice = txtDiscountPrice.Text
        End If

        If DBAlbum.myAlbumView1.Count = 0 Then

            DBSongs.AddSongwithNoAlbum(txtSong.Text, txtSongDescription.Text, intArtistID, Convert.ToDecimal(txtPrice.Text), radFeatured.SelectedValue.ToString)
        Else
            intAlbumID = gvAlbum.Rows(0).Cells(8).Text
            DBSongs.AddSong(txtSong.Text, txtSongDescription.Text, intArtistID, Convert.ToDecimal(txtPrice.Text), decdiscountprice, intAlbumID, radFeatured.SelectedValue.ToString)
        End If

        DBArtist.ModifyArtist(txtArtist.Text, intArtistID, txtDescription.Text, radFeatured.SelectedValue.ToString)

        lblError.Text = "New Artist and Song have been added"
        btnAdd.Visible = False





    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvNewArtist.SelectedIndexChanged

    End Sub
End Class
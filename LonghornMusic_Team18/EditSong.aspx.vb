Public Class EditProduct
    Inherits System.Web.UI.Page

    Dim DBvalidations As New ManageProductsValidation
    Dim DBSongs As New SongClass
    Dim DBArtist As New ArtistClass
    Dim DbAlbum As New AlbumClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'session variable song id
            Dim intsongid As Integer = 395
            Dim intartistid As Integer
            'Dim intalbumID As Integer


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
            txtDiscountPrice.Text = gvSongs.Rows(0).Cells(4).Text
            radFeatured.SelectedValue = gvSongs.Rows(0).Cells(6).Text
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
     


        'check that artist exists in the database
        
        Dim intartistId As Integer
        Dim intAlbumID As Integer
        Dim decDiscountPrice As Decimal

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
            decDiscountPrice = Convert.ToDecimal(txtDiscountPrice.Text)
        End If
        If DbAlbum.myAlbumView1.Count = 0 Then
            DBSongs.ModifySongnoalbum(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), radFeatured.SelectedValue.ToString, decDiscountPrice, 395)
        Else
            intAlbumID = gvAlbum.Rows(0).Cells(8).Text
            DBSongs.ModifySong(txtSong.Text, txtDescription.Text, intartistId, Convert.ToDecimal(txtPrice.Text), intAlbumID, radFeatured.SelectedValue.ToString, decDiscountPrice, 395)
        End If

        lblError.Text = "song has been modified"
        














    End Sub

    Protected Sub btnAddSong_Click(sender As Object, e As EventArgs) Handles btnAddSong.Click
        Response.Redirect("addsong.aspx")
    End Sub
End Class
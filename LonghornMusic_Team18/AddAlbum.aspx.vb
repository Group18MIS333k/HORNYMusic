Public Class AddAlbum
    Inherits System.Web.UI.Page

    Dim dbArtist As New ArtistClassDB
    Dim dbsong As New SongClassDB
    Dim martistID As Integer
    Dim dbAlbum As New AlbumClassDB
    Dim malbumID As Integer
    Dim dbvalidations As New ValidationClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            lblPickSongs.Visible = False
            gvSongs.Visible = False
        End If

    End Sub

    Protected Sub btnSearchArtist_Click(sender As Object, e As EventArgs) Handles btnSearchArtist.Click
        'see if artist exists

        dbArtist.SelectArtist(txtArtistSearch.Text)

        If dbArtist.myArtistview1.Count = 0 Then
            lblError.Text = "Artist doest not exist, please add artist first"
            Exit Sub
        End If


        gvArtistSearch.DataSource = dbArtist.myArtistview1

        gvArtistSearch.DataBind()




    End Sub

    Public Sub gvArtistSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvArtistSearch.SelectedIndexChanged



        Dim decOriginalPrice As Decimal = 0

        txtArtist.Text = gvArtistSearch.SelectedRow.Cells(1).Text

        martistID = gvArtistSearch.SelectedRow.Cells(6).Text
        lblArtistSearch.Visible = False
        txtArtistSearch.Visible = False
        btnSearchArtist.Visible = False

        lblartist.Text = martistID
        gvArtistSearch.Visible = False

        lblPickSongs.Visible = True
        gvSongs.Visible = True

        dbsong.SelectSongsbyArtist(martistID)

        gvSongs.DataSource = dbsong.mySongView1
        gvSongs.DataBind()




        'create a new albumID fill with artist ID


        'get albumID by searching blank 
        dbAlbum.AddAlbum(martistID, decOriginalPrice)
        lblError.Text = "new album added, please add at least one song"

        dbAlbum.GetNewAlbumID()

        gvNewAlbum.DataSource = dbAlbum.myAlbumView1
        gvNewAlbum.DataBind()

        malbumID = gvNewAlbum.Rows(0).Cells(8).Text

        lblalbum.Text = malbumID



    End Sub

    Public Sub gvSongs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongs.SelectedIndexChanged
        'check that song does not exist in album already
        Dim intsongID As Integer
        Dim strSongtitle As String
        Dim strDescription As String
        Dim decOriginalPrice As Decimal
        Dim decDiscountPrice As Decimal = 0
        Dim strfeaturedFlg As String
        Dim intalbum As Integer
        Dim intartistID As Integer


        intalbum = lblalbum.Text
        intartistID = lblartist.Text

        strSongtitle = gvSongs.SelectedRow.Cells(1).Text
        strDescription = gvSongs.SelectedRow.Cells(2).Text
        decOriginalPrice = gvSongs.SelectedRow.Cells(4).Text

        If gvSongs.SelectedRow.Cells(5).Text = "&nbsp;" Then
            decDiscountPrice = 0.0
        Else
            decDiscountPrice = gvSongs.SelectedRow.Cells(5).Text
        End If



        If gvSongs.SelectedRow.Cells(7).Text = "&nbsp;" Then
            strfeaturedFlg = "N"
        Else
            strfeaturedFlg = gvSongs.SelectedRow.Cells(7).Text
        End If


        intsongID = gvSongs.SelectedRow.Cells(10).Text
        dbsong.SelectASongwithAlbumandTitle(strSongtitle, intalbum)

        If dbsong.mySongView1.Count > 0 Then
            lblError.Text = "song exists in album"
            Exit Sub
        End If



        'if sone has albumd id, add song, if not, modify
        If gvSongs.SelectedRow.Cells(6).Text = "&nbsp;" Then
            'modify song

            dbsong.ModifySong(strSongtitle, strDescription, intartistID, decOriginalPrice, intalbum, strfeaturedFlg, decDiscountPrice, intsongID)
        Else

            dbsong.AddSong(strSongtitle, strDescription, intartistID, decOriginalPrice, decDiscountPrice, intalbum, strfeaturedFlg)
            lblError.Text = "song has been added"
        End If


        dbsong.SelectSongsbyArtist(intartistID)

        gvSongs.DataSource = dbsong.mySongView1
        gvSongs.DataBind()




        btnAdd.Enabled = True

        'add rest of information to album


    End Sub


    Public Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim intalbum2 As Integer
        Dim intartistID As Integer
        intalbum2 = lblalbum.Text
        intartistID = lblartist.Text



        If txtAlbum.Text = "" Then
            lblError.Text = "Enter Album Name"
            Exit Sub
        End If

        If txtDescription.Text = "" Then
            lblError.Text = "Enter Description"
            Exit Sub
        End If

        If dbvalidations.CheckDecimal(txtPrice.Text) = -1 Then
            lblError.Text = "Enter decimal Price"
            Exit Sub
        End If

        If dbvalidations.CheckDecimal(txtDiscountPrice.Text) = -1 Then
            lblError.Text = "Enter Discount Price"
            Exit Sub
        End If
        If radFeatured.SelectedValue = "Y" Then
            'check no other featured values
            dbsong.GetFeaturedSong()
            If dbsong.mySongView1.Count > 0 Then
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

        btnAdd.Visible = False
        gvSongs.Visible = False


        dbAlbum.ModifyAlbum(txtAlbum.Text, txtDescription.Text, radFeatured.SelectedValue.ToString, Convert.ToDecimal(txtPrice.Text), Convert.ToDecimal(txtDiscountPrice.Text), intalbum2)
        lblError.Text = "album has been added"
    End Sub

    
End Class
Public Class AddSong
    Inherits System.Web.UI.Page

    Dim dbvalidations As New ManageProductsValidation
    Dim dbSong As New SongClass
    Dim dbArtist As New ArtistClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'add validations
        'get variable name based on clicked song 
        Dim intsongID As Integer = 356
        Dim artistID As Integer = 48
        Dim albumID As Integer = 23
        Dim strFeature As String = "n"
        Dim intAverage As Integer = 0
        Dim intnotcust As Integer = 0

        If txtSong.Text = "" Then
            lblError.Text = "Please enter proper Song Title"
            Exit Sub
        End If
        If txtAlbum.Text = "" Then
            lblError.Text = "Album Title Required"
            Exit Sub
        End If
        If txtArtist.Text = "" Then
            lblError.Text = "Artist Title Required"
            Exit Sub
        End If
        If txtGenre1.Text = "" Then
            lblError.Text = "Genre Required"
            Exit Sub
        End If
        If dbvalidations.Checkfordigits(txtPrice.Text) = False Then
            lblError.Text = "Please enter proper Price"
            Exit Sub
        End If
        'enter code for check if string is all numbers from class

        If radFeatured.SelectedItem.Text = "Yes" Then
            'check to see if featured already exists, if it does, give error, if not, allow
            'search for featured, if row = 0 then it doesnt exist
        End If

        'check that artist exists
        dbArtist.SelectArtist(txtArtist.Text)

        If dbArtist.myArtistview1.Count = 0 Then
            lblError.Text = "Artist doest not exist, please add artist first"
            Exit Sub
        End If

        'check that song is not duplicate

        dbSong.SelectASongwithTitle(txtSong.Text, artistID)
        If dbSong.mySongView1.Count > 0 Then
            lblError.Text = "Song with same artist already exists"
            Exit Sub
        End If



        dbSong.AddSong(txtSong.Text, intsongID, txtDescription.Text, artistID, txtPrice.Text, txtDiscountPrice.Text, albumID, strFeature, intAverage, intnotcust)
        lblError.Text = "song added"



    End Sub
End Class
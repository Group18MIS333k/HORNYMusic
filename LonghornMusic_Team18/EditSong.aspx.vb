Public Class EditProduct
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'get variable name based on clicked song 
        If txtSong.Text = "" Then
            lblError.Text = "Title Required"
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
        If txtGenre.Text = "" Then
            lblError.Text = "Genre Required"
            Exit Sub
        End If
        If txtDiscountPrice.Text = "" Then
            lblError.Text = "Price Required"
            Exit Sub
        End If
        'enter code for check if string is all numbers from class

        If radFeatured.SelectedItem.Text = "Yes" Then
            'check to see if featured already exists, if it does, give error, if not, allow
            'search for featured, if row = 0 then it doesnt exist
        End If


    End Sub
End Class
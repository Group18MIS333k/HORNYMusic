Public Class AddArtist
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtArtist.Text = "" Then
            lblError.Text = "artist required"
            Exit Sub
        End If

        If txtDescription.Text = "" Then
            lblError.Text = "artist required"
            Exit Sub
        End If

        If txtSong.Text = "" Then
            lblError.Text = "song name required"
            Exit Sub
        End If

        If txtPrice.Text = "" Then
            lblError.Text = "price required"
            Exit Sub

        End If

        'add artist
        'add customer based on artist 
    End Sub
End Class
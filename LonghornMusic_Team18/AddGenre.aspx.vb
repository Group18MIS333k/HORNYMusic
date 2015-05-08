Public Class AddGenre
    Inherits System.Web.UI.Page

    Dim DbSongGenre As New SongGenreClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DbSongGenre.SelectAGenre(txtGenre.Text)
        If DbSongGenre.mySongGenreView1.Count > 0 Then
            lblerror.Text = "Genre already exists"
            Exit Sub
        End If
        DbSongGenre.AddGenre(txtGenre.Text)
        lblerror.Text = "Genre has been added"
        btnSave.Visible = False

    End Sub
End Class
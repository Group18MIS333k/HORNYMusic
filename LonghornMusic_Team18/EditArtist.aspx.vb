Public Class EditArtist
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtArtist.Text = "" Then
            lblError.Text = "artist required"
            Exit Sub
        End If

        If txtDescription.Text = "" Then
            lblError.Text = "artist required"
            Exit Sub
        End If


    End Sub
End Class
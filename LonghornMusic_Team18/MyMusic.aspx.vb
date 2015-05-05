Public Class MyMusic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DB As New RateReviewCLass
        Dim SongDB As New SongClass
        SongDB.SelectAllSongs()

        gvMusicLibrary.DataSource = SongDB.SongDataset
        gvMusicLibrary.DataBind()



    End Sub

    Protected Sub gvMusicLibrary_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicLibrary.SelectedIndexChanged
        Response.Redirect("SongDetail.aspx")
    End Sub
End Class
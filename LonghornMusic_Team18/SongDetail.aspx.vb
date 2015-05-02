Public Class SongDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub gvSongList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongList.SelectedIndexChanged
        Response.Redirect("EditSong.aspx")
    End Sub
End Class
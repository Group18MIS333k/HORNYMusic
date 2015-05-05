Public Class EditAlbum
    Inherits System.Web.UI.Page

    Dim DBSong As New SongClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim albumid As Integer = 2

        DBSong.GetAllSongsinAlbum(albumid)

        gvSongList.DataSource = DBSong.mySongView1
        gvSongList.DataBind()

    End Sub

   
End Class
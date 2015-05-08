Public Class ArtistDetail
    Inherits System.Web.UI.Page
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList
    Dim CartDB As New CartClassDB
    Dim SongDB As New SongClassDB
    Dim dbratereview As New RateReviewCLass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then



            Dim intartistid = 37
            dbratereview.SearchReviewByArtist(intartistid)
            gvComments.DataSource = dbratereview.myView1
            gvComments.DataBind()


        Else



        End If
    End Sub
    Protected Sub ResultGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvComments.RowDataBound
        e.Row.Cells(1).Visible = False
        e.Row.Cells(2).Visible = False
        e.Row.Cells(3).Visible = False
        e.Row.Cells(4).Visible = False
        e.Row.Cells(6).Visible = False
        e.Row.Cells(8).Visible = False

    End Sub

    Protected Sub gvAlbumList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAlbumList.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvComments.SelectedIndexChanged
        Session("ArtistName") = LblArtistName.Text

        Session("CommentID") = CInt(gvComments.SelectedRow.Cells(8).Text)
        Response.Redirect("Vote.Aspx")
    End Sub
End Class
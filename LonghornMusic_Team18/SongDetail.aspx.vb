Public Class SongDetail
    Inherits System.Web.UI.Page

    Dim dbratereview As New RateReviewCLass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim songid As Integer = 1
        Dim artistid As Integer = 54
        dbratereview.SearchReviewBySong(artistid, songid)

        gvComments.DataSource = dbratereview.myView1
        gvComments.DataBind()

    End Sub


    Protected Sub gvComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvComments.SelectedIndexChanged
        LblRatingsNReviews.Text = "Upvote"

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Response.Redirect("editsong.aspx")

    End Sub
End Class
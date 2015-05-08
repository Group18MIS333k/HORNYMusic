Public Class AlbumDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Response.Redirect("editalbum.aspx")
    End Sub

    Protected Sub gvComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvComments.SelectedIndexChanged

    End Sub
End Class
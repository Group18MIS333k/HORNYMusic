Public Class EditArtist
    Inherits System.Web.UI.Page

    Dim DBartists As New ArtistClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'get session variable from artist detail
        'SESSION
        If IsPostBack = False Then
            Dim artistID As Integer = 68

            DBartists.SelectArtistwithArtistID(artistID)
            gvArtist.DataSource = DBartists.myArtistview1
            gvArtist.DataBind()

            txtArtist.Text = gvArtist.Rows(0).Cells(0).Text
            txtDescription.Text = gvArtist.Rows(0).Cells(1).Text
            radFeatured.Text = gvArtist.Rows(0).Cells(2).Text
        End If



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



        'get artist ID from artist details page
        'SESSIONs
        DBartists.ModifyArtist(txtArtist.Text, 68, txtDescription.Text, radFeatured.SelectedValue.ToString)

        lblError.Text = "artist has been modified"
    End Sub

    Protected Sub btnAddArtist_Click(sender As Object, e As EventArgs) Handles btnAddArtist.Click
        Response.Redirect("addartist.aspx")
    End Sub

   
End Class
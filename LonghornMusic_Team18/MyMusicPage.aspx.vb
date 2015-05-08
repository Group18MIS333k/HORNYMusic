Public Class MyMusicPage
    Inherits System.Web.UI.Page
    Dim SongDB As New SongClassDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SongDB.SelectAllSongs()
            DataBindStuff()
        End If
    End Sub
    Public Sub DataBindStuff()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvMyMusic.DataSource = SongDB.SongDataset.Tables("Songs")

        'bind gridview to myview based on sort 
        gvMyMusic.DataSource = SongDB.mySongView1
        gvMyMusic.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMyMusic.SelectedIndexChanged
        If ddlRateReview.SelectedValue = "Artist" Then
            Session("ArtistID") = gvMyMusic.SelectedRow.Cells(3).Text
            Session("AlbumID") = ""
            Session("SongID") = ""
            Label7.Text = "Artist picked"

        ElseIf ddlRateReview.SelectedValue = "Album" Then
            Session("AlbumID") = gvMyMusic.SelectedRow.Cells(6).Text
            Session("ArtistID") = ""
            Session("SongID") = ""
            Label7.Text = "Album picked"


        ElseIf ddlRateReview.SelectedValue = "Song" Then
            Session("SongID") = gvMyMusic.SelectedRow.Cells(10).Text
            Session("ArtistID") = ""
            Session("AlbumID") = ""
            Label7.Text = "Song picked"


        End If
        'Response.Redirect("RateReview.Aspx")
    End Sub

    Protected Sub ddlRateReview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRateReview.SelectedIndexChanged
        Session("RateType") = ddlRateReview.SelectedItem.ToString()
        Label6.Text = Session("RateType").ToString()
    End Sub
End Class
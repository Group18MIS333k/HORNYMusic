Public Class EditAlbum
    Inherits System.Web.UI.Page

    Dim DBSong As New SongClassDB
    Dim DBAlbum As New AlbumClassDB
    Dim dbvalidations As New ValidationClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SESSION
        Dim albumid As Integer = 2

        DBSong.GetAllSongsinAlbum(albumid)

        gvSongList.DataSource = DBSong.mySongView1
        gvSongList.DataBind()

    End Sub


    Protected Sub gvSongList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongList.SelectedIndexChanged
        'get intsongid from the selected song list
        Dim intSongID As Integer
        'SESSSION
        Dim albumid As Integer = 2
        intSongID = gvSongList.SelectedRow.Cells(2).Text



        DBSong.RemoveSong(intSongID)

        DBSong.GetAllSongsinAlbum(albumid)

        gvSongList.DataSource = DBSong.mySongView1
        gvSongList.DataBind()



        lblError.Text = "song removed"


    End Sub

    Protected Sub btnAddAlbum_Click(sender As Object, e As EventArgs) Handles btnAddAlbum.Click
        Response.Redirect("addalbum.aspx")
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim decDiscountprice As Decimal


        If txtAlbum.Text = "" Then
            lblError.Text = "Enter Album Name"
            Exit Sub
        End If

        If txtDescription.Text = "" Then
            lblError.Text = "Enter Description"
            Exit Sub
        End If

        If dbvalidations.CheckDecimal(txtPrice.Text) = -1 Then
            lblError.Text = "Enter decimal Price"
            Exit Sub
        End If

        If txtDiscountPrice.Text = "" Then
            decDiscountprice = 0
        Else
            If dbvalidations.CheckDecimal(txtDiscountPrice.Text) = -1 Then
                lblError.Text = "Enter Decimal Discount Price"
                Exit Sub
            End If
        End If


        DBAlbum.ModifyAlbum(txtAlbum.Text, txtDescription.Text, radFeatured.SelectedValue.ToString, Convert.ToDecimal(txtPrice.Text), decDiscountprice, "intalbumID")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnAddSong.Click
        Response.Redirect("AddSong.aspx")
    End Sub
End Class
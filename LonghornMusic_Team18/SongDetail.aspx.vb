Public Class SongDetail
    Inherits System.Web.UI.Page
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList
    Dim CartDB As New CartClassDB
    Dim SongDB As New SongClassDB
    Dim RRDB As New RateReviewCLass
    Dim dbratereview As New RateReviewCLass


    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intSongID As Integer = Session("AlbumID")
        'if the customer is logged in, add cart button is visible



        If Session("CustID") <> "" Then
            BtnAdd2Cart.Visible = True
            btnLogin.Visible = False

        Else
            BtnAdd2Cart.Visible = False
            btnLogin.Visible = True

        End If
        'if not, there is a btn login that redirects to log in page
        'customer id grab the customer id from session variable and put it into a variable custID
        'If IsPostBack = False Then

        intSongID = 4
        'load the grid
        'get searched song info
        'SongDB.SelectAllSongs()
        'AlbumDB.SelectAllAlbums()


        'SongDB.GetGenresBySong(intSongID)


        SongDB.GetSongDescription(intSongID)
        RRDB.GetSongRatingReviews(intSongID)
        SongDB.GetCart(intSongID)
        ''make gv's visble 
        gvGenres.Visible = True
        'gvAlbumList.Visible = True
        gvSongDescription.Visible = True
        gvSongRR.Visible = True
        ''narrow down gv's based on that artist the page is supposed to be loaded for 
        'AlbumDB.MyView.RowFilter = "ArtistID = '" & intSongID & "'"
        'SongDB.MyView.RowFilter = "ArtistID = '" & intSongID & "'"
        'declare session variables 
        ' Session("CountGoodSearches") = 0

        'DataBindGenresGV()
        DataBindDescriptionGV()
        DataBindRatingReviewGV()



        'Else
        '' SongDB.SongGetAll()
        'DataBindSongGV()
        'DataBindAlbumGV()
        'End If

        LblArtistName.Text = Session("ArtistID")
        dbratereview.SearchReviewBySong(intSongID)
        gvComments.DataSource = dbratereview.myView1
        gvComments.DataBind()

    End Sub

    'Public Sub DataBindAlbumGV()
    '    'purpose: elimate duplicate code for everytime a view needs a databind 

    '    'sort by the selected item 
    '    'SongDB.DoSort(radSort.SelectedValue.ToString)

    '    'sets gv to dataset &bind
    '    gvAlbumList.DataSource = AlbumDB.AlbumDataset.Tables("Albums")

    '    'bind gridview to myview based on sort 
    '    gvAlbumList.DataSource = AlbumDB.myAlbumView1
    '    gvAlbumList.DataBind()

    '    'count of how many elements are in the view after sort

    'End Sub
    Public Sub DataBindDescriptionGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvSongDescription.DataSource = SongDB.SongDataset.Tables("Songs")

        'bind gridview to myview based on sort 
        gvSongDescription.DataSource = SongDB.mySongView1
        gvSongDescription.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Public Sub DataBindRatingReviewGV()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvSongRR.DataSource = RRDB.RRDataset.Tables("Ratings")

        'bind gridview to myview based on sort 
        gvSongRR.DataSource = RRDB.myView1
        gvSongRR.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    '    If IsPostBack = False Then

    '        'load the grid
    '        'get searched song info
    '        SongDB.SelectAllSongs()


    '        gvSongList.Visible = True
    '        SongDB.MyView.RowFilter = "SongID = '1'"
    '        'declare session variables 
    '        Session("CountGoodSearches") = 0
    '        DataBindStuff()
    '    Else
    '        ' SongDB.SongGetAll()
    '        DataBindStuff()
    '    End If
    'End Sub

    'Public Sub DataBindStuff()
    '    'purpose: elimate duplicate code for everytime a view needs a databind 

    '    'sort by the selected item 
    '    'SongDB.DoSort(radSort.SelectedValue.ToString)

    '    'sets gv to dataset &bind
    '    gvSongList.DataSource = SongDB.SongDataset.Tables("Songs")

    '    'bind gridview to myview based on sort 
    '    gvSongList.DataSource = SongDB.MyView
    '    gvSongList.DataBind()

    '    'count of how many elements are in the view after sort

    'End Sub
    'Protected Sub BtnAdd2Cart_Click(sender As Object, e As EventArgs) Handles BtnAdd2Cart.Click


    '    maryParamNames.Add("@CustID")
    '    maryParamNames.Add("@SongID")
    '    maryParamNames.Add("@AlbumID")
    '    maryParamNames.Add("@OriginalPrice")
    '    maryParamNames.Add("@DiscountPrice")

    '    ''get each unique row from the gridview 
    '    ''       For i = 0 To gvSongList.Rows.Count
    '    'For Each cell as ListItem In gvSongList.Rows(0).Cells.
    '    '    'get each individual cell value from row and put in maryParamValues arrayList
    '    '    maryParamValues.Add(gvSongList.Rows(0).Cells)

    '    'Next
    '    ''   Next
    '    'For i = 0 To gvSongList.Rows(0).Cells.Count
    '    '    'get each individual cell value from row and put in maryParamValues arrayList
    '    '    maryParamValues.Add(gvSongList.Rows(0).Cells(i))
    '    'Next





    '    CartDB.UseSPforInsertQuery("usp_cart_Add_Item", maryParamNames, maryParamValues)
    'End Sub


    Protected Sub gvSongDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongDescription.SelectedIndexChanged

    End Sub
    Protected Sub ResultGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvComments.RowDataBound
        e.Row.Cells(1).Visible = False
        e.Row.Cells(2).Visible = False
        e.Row.Cells(3).Visible = False
        e.Row.Cells(4).Visible = False
        e.Row.Cells(6).Visible = False
        e.Row.Cells(8).Visible = False

    End Sub
    Protected Sub BtnAdd2Cart_Click(sender As Object, e As EventArgs) Handles BtnAdd2Cart.Click
        Dim aryNames As New ArrayList
        Dim aryValues As New ArrayList
        Dim intcustID As Integer
        intcustID = Session("CustID")

        aryNames.Add("@custID")
        aryNames.Add("@songID")
        aryNames.Add("@albumID")
        aryNames.Add("@originalPriceID")
        aryNames.Add("@discountPriceID")


        For row = 0 To gvAdd2Cart.Rows.Count - 1
            For cell = 0 To gvAdd2Cart.Rows(row).Cells.Count - 1
                aryValues.Add(intcustID)
                aryValues.Add(gvAdd2Cart.Rows(row).Cells(cell).Text)
            Next
        Next

        CartDB.AddToCart("usp_cart_Add_Item", aryNames, aryValues)


    End Sub

    Protected Sub gvComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvComments.SelectedIndexChanged
        'Session("SongName") = lblSongName.Text
        Session("AlbumName") = LblArtistName.Text
        Session("ArtistName") = LblAlbumName.Text

        Session("CommentID") = CInt(gvComments.SelectedRow.Cells(8).Text)
        Response.Redirect("Vote.Aspx")
    End Sub
End Class
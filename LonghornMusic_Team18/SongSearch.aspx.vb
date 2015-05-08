Public Class Search
    Inherits System.Web.UI.Page
    Dim valid As New ValidationClass
    Dim mdecRatingLower As Decimal
    Dim mdecRatingHigher As Decimal
    Dim genre As New GenreClassDB
    Dim search As New SongClassDB
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            genre.GenreGetAll()
            LoadCheckBoxList()

        End If
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnPartialSearch_Click(sender As Object, e As EventArgs) Handles btnPartialSearch.Click
        'searches artist, album, and title
        If txtTitle.Text <> "" And txtArtist.Text <> "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@artistame")
            maryParamNames.Add("@albumname")
            maryParamNames.Add("@SongTitle")
            maryParamValues.Add(txtArtist.Text)
            maryParamValues.Add(txtAlbum.Text)
            maryParamValues.Add(txtTitle.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_All", maryParamNames, maryParamValues)
        End If

        'searches just album
        If txtTitle.Text = "" And txtArtist.Text = "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@albumname")
            maryParamValues.Add(txtAlbum.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_AlbumOnly", maryParamNames, maryParamValues)
        End If

        'searches artist and album
        If txtTitle.Text = "" And txtArtist.Text <> "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@artistame")
            maryParamNames.Add("@albumname")
            maryParamValues.Add(txtArtist.Text)
            maryParamValues.Add(txtAlbum.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_ArtistANDAlbum", maryParamNames, maryParamValues)
        End If

        'searches artist only
        If txtTitle.Text = "" And txtArtist.Text = "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@artistame")
            maryParamValues.Add(txtArtist.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_ArtistOnly", maryParamNames, maryParamValues)
        End If

        'searches title and album
        If txtTitle.Text <> "" And txtArtist.Text = "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@Songtitle")
            maryParamNames.Add("@albumname")
            maryParamValues.Add(txtArtist.Text)
            maryParamValues.Add(txtAlbum.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_TitleANDAlbum", maryParamNames, maryParamValues)
        End If

        'searches title and artist
        If txtTitle.Text <> "" And txtArtist.Text <> "" And txtAlbum.Text = "" Then
            maryParamNames.Add("@songtitle")
            maryParamNames.Add("@artistname")
            maryParamValues.Add(txtTitle.Text)
            maryParamValues.Add(txtArtist.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_TitleANDArtist", maryParamNames, maryParamValues)
        End If

        'searches title only
        If txtTitle.Text <> "" And txtArtist.Text = "" And txtAlbum.Text = "" Then
            maryParamNames.Add("@songtitle")
            maryParamValues.Add(txtTitle.Text)
            search.SongSearchWithAnyParameters("usp_song_search_partial_TitleANDArtist", maryParamNames, maryParamValues)
        End If

        'I feel like all of this could be put into a sub. 
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text = "" Then
            mdecRatingLower = 0
        Else
            mdecRatingLower = valid.CheckDecimalwNull(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
                Exit Sub
            End If
        End If


        If txtRatingHigher.Text = "" Then
            mdecRatingHigher = 5
        Else
            mdecRatingHigher = valid.CheckDecimalwNull(txtRatingHigher.Text)
            If mdecRatingHigher = -1 Then
                lblMessage.Text = "Higher rating must be numeric value"
                Exit Sub
            End If
        End If

        Try
            If mdecRatingLower < mdecRatingHigher Then
            End If

        Catch ex As Exception
            lblMessage.Text = "Please put lower rating first"
            Exit Sub
        End Try


        search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        SearchGenres()
        DataBindStuff()
        'end sub

        'search the name in the database and order by whatever is selected in the ddl
        'Title, Genre, Artist, Album, Rating

        'If ddlSort.SelectedValue.ToString = "Name Ascending" Then
        '    'search.AlbumSearchNamePartialAsc(txtAlbumNamae.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If
        'If ddlSort.SelectedValue.ToString = "Name Descending" Then
        '    'search.AlbumSearchNamePartialDsc(txtAlbumNamae.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If

        'If ddlSort.SelectedValue.ToString = "Artist Ascending" Then
        '    'search.AlbumSearchArtistPartialAsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If
        'If ddlSort.SelectedValue.ToString = "Artist Descending" Then
        '    'search.AlbumSearchArtistPartialDsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If


        'If ddlSort.SelectedValue.ToString = "Album Ascending" Then
        '    'search.AlbumSearchArtistPartialAsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If

        'If ddlSort.SelectedValue.ToString = "Album Descending" Then
        '    'search.AlbumSearchArtistPartialDsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If

        ''ask about these two
        'If ddlSort.SelectedValue.ToString = "Rating Ascending" Then
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    'need a do sort
        '    DataBindStuff()
        'End If
        'If ddlSort.SelectedValue.ToString = "Rating Descending" Then
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    'need a do sort
        '    DataBindStuff()
        'End If


    End Sub
    Public Sub SearchGenres()

        Dim genresSearch As String = ""
        Dim genreFilter As String = ""




        Dim genreItem As ListItem
        For Each genreItem In cblGenres.Items
            If genreItem.Selected Then
                'genres.Add(cblGenres.SelectedValue.ToString)
                genreFilter = "Genre = '" & genreItem.Text & "' OR "
                genresSearch += genreFilter
            End If
        Next


        If genresSearch.Length > 0 Then
            genresSearch = genresSearch.Substring(0, genresSearch.Length - 4)
        End If


        search.MyView.RowFilter = genresSearch


    End Sub

    'Sub LoadListBox()
    '    'Purpose: to load the list box with data from database
    '    'Arguments: 
    '    'Returns: a list box full of genres
    '    'Author: Morgan May

    '    'this loads the list box with the data from the table
    '    'get's the data from the table
    '    Me.lbxGenre.DataSource = genre.GenreDataset.Tables("tblGenres")
    '    'what we want it to say in the list 
    '    Me.lbxGenre.DataTextField = "Genre"
    '    'where it finds what to put in the list
    '    Me.lbxGenre.DataValueField = "GenreID"
    '    'binds it to the list box
    '    Me.lbxGenre.DataBind()


    'End Sub

    Protected Sub btnKeywordSearch_Click(sender As Object, e As EventArgs) Handles btnKeywordSearch.Click
        'searches artist, album, and title
        If txtTitle.Text <> "" And txtArtist.Text <> "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@artistname")
            maryParamNames.Add("@albumname")
            maryParamNames.Add("@SongTitle")
            maryParamValues.Add(txtArtist.Text)
            maryParamValues.Add(txtAlbum.Text)
            maryParamValues.Add(txtTitle.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_All", maryParamNames, maryParamValues)
        End If

        'searches just album
        If txtTitle.Text = "" And txtArtist.Text = "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@albumname")
            maryParamValues.Add(txtAlbum.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_AlbumOnly", maryParamNames, maryParamValues)
        End If

        'searches artist and album
        If txtTitle.Text = "" And txtArtist.Text <> "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@artistame")
            maryParamNames.Add("@albumname")
            maryParamValues.Add(txtArtist.Text)
            maryParamValues.Add(txtAlbum.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_ArtistANDAlbum", maryParamNames, maryParamValues)
        End If

        'searches artist only
        If txtTitle.Text = "" And txtArtist.Text = "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@artistame")
            maryParamValues.Add(txtArtist.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_ArtistOnly", maryParamNames, maryParamValues)
        End If

        'searches title and album
        If txtTitle.Text <> "" And txtArtist.Text = "" And txtAlbum.Text <> "" Then
            maryParamNames.Add("@Songtitle")
            maryParamNames.Add("@albumname")
            maryParamValues.Add(txtArtist.Text)
            maryParamValues.Add(txtAlbum.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_TitleANDAlbum", maryParamNames, maryParamValues)
        End If

        'searches title and artist
        If txtTitle.Text <> "" And txtArtist.Text <> "" And txtAlbum.Text = "" Then
            maryParamNames.Add("@songtitle")
            maryParamNames.Add("@artistname")
            maryParamValues.Add(txtTitle.Text)
            maryParamValues.Add(txtArtist.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_TitleANDArtist", maryParamNames, maryParamValues)
        End If

        'searches title only
        If txtTitle.Text <> "" And txtArtist.Text = "" And txtAlbum.Text = "" Then
            maryParamNames.Add("@songtitle")
            maryParamValues.Add(txtTitle.Text)
            search.SongSearchWithAnyParameters("usp_song_search_keyword_TitleANDArtist", maryParamNames, maryParamValues)
        End If

        'I feel like all of this could be put into a sub. 
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text = "" Then
            mdecRatingLower = 0
        Else
            mdecRatingLower = valid.CheckDecimalwNull(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
                Exit Sub
            End If
        End If


        If txtRatingHigher.Text = "" Then
            mdecRatingHigher = 5
        Else
            mdecRatingHigher = valid.CheckDecimalwNull(txtRatingHigher.Text)
            If mdecRatingHigher = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
                Exit Sub
            End If
        End If

        Try
            If mdecRatingLower < mdecRatingHigher Then
            End If

        Catch ex As Exception
            lblMessage.Text = "Please put lower rating first"
            Exit Sub
        End Try

        search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        SearchGenres()
        DataBindStuff()

        ''I feel like all of this could be put into a sub. 
        ''checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        'If txtRatingLower.Text IsNot Nothing Then
        '    mdecRatingLower = valid.CheckRatings(txtRatingLower.Text)
        '    If mdecRatingLower = -1 Then
        '        lblMessage.Text = "Lower rating must be numeric value"
        '        Exit Sub
        '    End If
        'Else
        '    mdecRatingLower = 0
        'End If

        'If txtRatingHigher.Text IsNot Nothing Then
        '    valid.CheckRatings(txtRatingHigher.Text)
        '    If mdecRatingHigher = -1 Then
        '        lblMessage.Text = "Higher rating must be numeric value"
        '        Exit Sub
        '    End If
        'Else
        '    mdecRatingHigher = 5
        'End If

        'Try
        '    If mdecRatingLower < mdecRatingHigher Then
        '    End If

        'Catch ex As Exception
        '    lblMessage.Text = "Please put lower rating first"
        '    Exit Sub
        'End Try
        ''end sub

        ''search the name in the database and order by whatever is selected in the ddl
        ''Title, Genre, Artist, Album, Rating

        'If ddlSort.SelectedValue.ToString = "Name Ascending" Then
        '    'search.AlbumSearchNameKeywordAsc(txtAlbumNamae.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If
        'If ddlSort.SelectedValue.ToString = "Name Descending" Then
        '    'search.AlbumSearchNameKeywordDsc(txtAlbumNamae.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If

        'If ddlSort.SelectedValue.ToString = "Artist Ascending" Then
        '    'search.AlbumSearchArtistKeywordAsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If
        'If ddlSort.SelectedValue.ToString = "Artist Descending" Then
        '    'search.AlbumSearchArtistKeywordDsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If


        'If ddlSort.SelectedValue.ToString = "Album Ascending" Then
        '    'search.AlbumSearchArtistKeywordAsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If

        'If ddlSort.SelectedValue.ToString = "Album Descending" Then
        '    'search.AlbumSearchArtistKeywordDsc(txtArtistName.Text.ToCharArray)
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    DataBindStuff()
        'End If

        ''ask about these two
        'If ddlSort.SelectedValue.ToString = "Rating Ascending" Then
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    'need a do sort
        '    DataBindStuff()
        'End If
        'If ddlSort.SelectedValue.ToString = "Rating Descending" Then
        '    search.SearchRatings(mdecRatingLower, mdecRatingHigher)
        '    'need a do sort
        '    DataBindStuff()
        'End If

    End Sub
    Public Sub DataBindStuff()

        ' purpose: bind data
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May
        'eliminate duplicate code for everytime a view needs a databind

        gvSearchResults.DataSource = search.SongDataset.Tables("Songs")
        'sort by the selected item
        'sort.DoSort(ddlSort.SelectedValue.ToString)
        'bind gridview to myview based on sort
        gvSearchResults.DataSource = search.MyView
        search.SongSearchSort(ddlSort.SelectedValue.ToString)
        gvSearchResults.DataBind()

        'count of how many elements are in the view after sort
        lblRecords.Text = search.MyView.Count.ToString()
    End Sub
    Public Sub LoadCheckBoxList()

        'this loads the drop down list with the data from the table
        'get's the data from the table
        Me.cblGenres.DataSource = genre.GenreDataset.Tables("tblGenres")
        'what we want it to say in the list 
        Me.cblGenres.DataTextField = "Genre"
        'where it finds what to put in the list
        Me.cblGenres.DataValueField = "Genre"
        'binds it to the ddl
        Me.cblGenres.DataBind()

    End Sub

    Protected Sub gvSearchResults_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSearchResults.SelectedIndexChanged
        'Response.Redirect("SongDetail.aspx?SongID=" & Me.gvSearchResults.SelectedRow.Cells())
    End Sub
End Class
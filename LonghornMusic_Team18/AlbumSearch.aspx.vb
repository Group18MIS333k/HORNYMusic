Public Class AlbumSearch
    Inherits System.Web.UI.Page
    Dim mdecRatingLower As Decimal
    Dim mdecRatingHigher As Decimal
    Dim valid As New ClassSearchValidate
    Dim sort As New SortClassDB
    Dim search As New AlbumClassDB
    Dim genre As New GenreClassDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadListBox()

        If IsPostBack = False Then
            Me.ddlSort.SelectedIndex = 0
            Me.ddlSort_selectedIndexChanged(Me.ddlSort, System.EventArgs.Empty)
        End If
    End Sub

    Protected Sub btnPartialSearch_Click(sender As Object, e As EventArgs) Handles btnPartialSearch.Click
        'checks and sees if the user inputed a name
        If txtAlbumNamae.Text = "" And txtArtistName.Text = "" Then
            lblMessage.Text = "Please input something into the textbox"
            Exit Sub
        End If

        lblMessage.Text = ""
        search.AlbumGetAll()
        'I feel like all of this could be put into a sub. 
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text IsNot Nothing Then
            mdecRatingLower = valid.CheckRatings(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
                Exit Sub
            End If
        Else
            mdecRatingLower = 0
        End If

        If txtRatingHigher.Text IsNot Nothing Then
            valid.CheckRatings(txtRatingHigher.Text)
            If mdecRatingHigher = -1 Then
                lblMessage.Text = "Higher rating must be numeric value"
                Exit Sub
            End If
        Else
            mdecRatingHigher = 5
        End If

        Try
            If mdecRatingLower < mdecRatingHigher Then
            End If

        Catch ex As Exception
            lblMessage.Text = "Please put lower rating first"
            Exit Sub
        End Try
        'end sub

        'search the name in the database and order by whatever is selected in the ddl

        If ddlSort.SelectedValue.ToString = "Name Ascending" Then
            search.AlbumSearchNamePartialAsc(txtAlbumNamae.Text.ToCharArray)
            Search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Name Descending" Then
            search.AlbumSearchNamePartialDsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If

        If ddlSort.SelectedValue.ToString = "Artist Ascending" Then
            search.AlbumSearchArtistPartialAsc(txtArtistName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Artist Descending" Then
            search.AlbumSearchArtistPartialDsc(txtArtistName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If

        'ask about these two
        If ddlSort.SelectedValue.ToString = "Rating Ascending" Then
            search.AlbumSearchRatingPartialAsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Rating Descending" Then
            search.AlbumSearchRatingPartialDsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If

    End Sub
    Sub LoadListBox()
        'Purpose: to load the list box with data from database
        'Arguments: 
        'Returns: a list box full of genres
        'Author: Morgan May

        'this loads the list box with the data from the table
        'get's the data from the table
        Me.lbxGenre.DataSource = genre.GenreDataset.Tables("tblGenres")
        'what we want it to say in the list 
        Me.lbxGenre.DataTextField = "Genres"
        'where it finds what to put in the list
        Me.lbxGenre.DataValueField = "GenreID"
        'binds it to the list box
        Me.lbxGenre.DataBind()


    End Sub

    Protected Sub btnKeywordSearch_Click(sender As Object, e As EventArgs) Handles btnKeywordSearch.Click
        'checks and sees if the user inputed a name
        If txtAlbumNamae.Text = "" And txtArtistName.Text = "" Then
            lblMessage.Text = "Please input something into the textbox"
            Exit Sub
        End If

        lblMessage.Text = ""
        search.AlbumGetAll()
        'I feel like all of this could be put into a sub. 
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text IsNot Nothing Then
            mdecRatingLower = valid.CheckRatings(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
                Exit Sub
            End If
        Else
            mdecRatingLower = 0
        End If

        If txtRatingHigher.Text IsNot Nothing Then
            valid.CheckRatings(txtRatingHigher.Text)
            If mdecRatingHigher = -1 Then
                lblMessage.Text = "Higher rating must be numeric value"
                Exit Sub
            End If
        Else
            mdecRatingHigher = 5
        End If

        Try
            If mdecRatingLower < mdecRatingHigher Then
            End If

        Catch ex As Exception
            lblMessage.Text = "Please put lower rating first"
            Exit Sub
        End Try
        'end sub

        'search the name in the database and order by whatever is selected in the ddl

        If ddlSort.SelectedValue.ToString = "Name Ascending" Then
            search.AlbumSearchNameKeywordAsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Name Descending" Then
            search.AlbumSearchNameKeywordDsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If

        If ddlSort.SelectedValue.ToString = "Artist Ascending" Then
            search.AlbumSearchArtistKeywordAsc(txtArtistName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Artist Descending" Then
            search.AlbumSearchArtistKeywordDsc(txtArtistName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If

        'ask about these two
        If ddlSort.SelectedValue.ToString = "Rating Ascending" Then
            search.AlbumSearchRatingKeywordAsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Rating Descending" Then
            search.AlbumSearchRatingKeywordDsc(txtAlbumNamae.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If

    End Sub
    Public Sub DataBindStuff()

        ' purpose: bind data
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May
        'eliminate duplicate code for everytime a view needs a databind

        'sort by the selected item

        'bind gridview to myview based on sort
        gvSearchResults.DataSource = album.AlbumDataSet.Tables("tblAlbums")
        gvSearchResults.DataBind()

        'count of how many elements are in the view after sort
        lblRecords.Text = gvSearchResults.Rows.Count.ToString
    End Sub

    Private Sub ddlSort_selectedIndexChanged(dropDownList As DropDownList, Empty As EventArgs)
        Dim index As Integer = Me.ddlSort.SelectedIndex
    End Sub

End Class
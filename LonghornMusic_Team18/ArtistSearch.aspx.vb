Public Class ArtistSearch
    Inherits System.Web.UI.Page
    Dim mdecRatingLower As Decimal
    Dim mdecRatingHigher As Decimal
    Dim valid As New ClassSearchValidate
    Dim sort As New SortClassDB
    Dim genre As New GenreClassDB
    Dim search As New ArtistClassDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'is postback being false prevents everything from reloading every time you do something
        If IsPostBack = False Then
            Me.ddlSort.SelectedIndex = 0
            Me.ddlSort_selectedIndexChanged(Me.ddlSort, System.EventArgs.Empty)
        End If
    End Sub

    Protected Sub btnPartialSearch_Click(sender As Object, e As EventArgs) Handles btnPartialSearch.Click


        'checks and sees if the user inputed a name
        If txtName.Text = "" Then
            lblMessage.Text = "Please input something into the textbox"
            Exit Sub
        End If

        lblMessage.Text = ""
        search.ArtistGetAll()
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
            search.ArtistSearchArtistPartialAsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Name Descending" Then
            search.ArtistSearchArtistPartialDsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Rating Ascending" Then
            search.ArtistSearchRatingPartialAsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Rating Descending" Then
            search.ArtistSearchRatingPartialDsc(txtName.Text.ToCharArray)
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
        If txtName.Text = "" Then
            lblMessage.Text = "Please put something in the text box"
            Exit Sub
        End If

        lblMessage.Text = ""
        search.ArtistGetAll()
        'I feel like all of this could be put into a sub. 
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text Is Nothing Then
            mdecRatingLower = valid.CheckRatings(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
                Exit Sub
            End If
        Else
            mdecRatingLower = 0
        End If

        If txtRatingHigher.Text Is Nothing Then
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
            search.ArtistSearchArtistKeywordAsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Name Descending" Then
            search.ArtistSearchArtistKeywordDsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Rating Ascending" Then
            search.ArtistSearchRatingKeywordAsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If
        If ddlSort.SelectedValue.ToString = "Rating Descending" Then
            search.ArtistSearchRatingKeywordDsc(txtName.Text.ToCharArray)
            search.SearchRatings(mdecRatingLower, mdecRatingHigher)
            DataBindStuff()
        End If


    End Sub
    Public Sub DataBindStuff()

        ' purpose: bind data
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May

        'get all

        'eliminate duplicate code for everytime a view needs a databind

        'sort by the selected item
        'sort.DoSort(ddlSort.SelectedValue.ToString)
        'bind gridview to myview based on sort
        gvSearchResults.DataSource = search.ArtistDataset.Tables("tblArtists")
        gvSearchResults.DataBind()

        'count of how many elements are in the view after sort
        lblRecords.Text = gvSearchResults.Rows.Count.ToString
    End Sub

    Protected Sub ddlSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSort.SelectedIndexChanged
        Dim index As Integer = Me.ddlSort.SelectedIndex

    End Sub
End Class
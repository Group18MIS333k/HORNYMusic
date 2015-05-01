Public Class Search
    Inherits System.Web.UI.Page
    Dim valid As New ClassSearchValidate
    Dim song As New SongClassDB
    Dim mdecRatingLower As Decimal
    Dim mdecRatingHigher As Decimal
    Dim genre As New GenreClassDB
    Dim sort As New SortClassDB
    Dim search As New ArtistClassDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnPartialSearch_Click(sender As Object, e As EventArgs) Handles btnPartialSearch.Click
        'checks and sees if user inputed a title
        If txtTitle.Text <> "" Then

        End If

        'checks and sees if user inputed an album
        If txtAlbum.Text <> "" Then

        End If

        'checks and sees if user inputed an artist
        If txtArtist.Text <> "" Then

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
        Me.lbxGenre.DataTextField = "Genre"
        'where it finds what to put in the list
        Me.lbxGenre.DataValueField = "GenreID"
        'binds it to the list box
        Me.lbxGenre.DataBind()


    End Sub

    Protected Sub btnKeywordSearch_Click(sender As Object, e As EventArgs) Handles btnKeywordSearch.Click
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
        'Search Ratings
        Search.SearchRatings(mdecRatingLower, mdecRatingHigher)

    End Sub
    Public Sub DataBindStuff()

        ' purpose: bind data
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May
        'eliminate duplicate code for everytime a view needs a databind

        'sort by the selected item
        'sort.DoSort(ddlSort.SelectedValue.ToString)
        'bind gridview to myview based on sort
        gvSearchResults.DataSource = sort.MyView
        gvSearchResults.DataBind()

        'count of how many elements are in the view after sort
        lblRecords.Text = sort.MyView.Count.ToString()
    End Sub
End Class
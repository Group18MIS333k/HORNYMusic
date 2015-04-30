Public Class ArtistSearch
    Inherits System.Web.UI.Page
    Dim mdecRatingLower As Decimal
    Dim mdecRatingHigher As Decimal
    Dim valid As New ClassSearchValidate
    Dim sort As New SortClassDB
    Dim genre As New GenreClassDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnPartialSearch_Click(sender As Object, e As EventArgs) Handles btnPartialSearch.Click
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text <> "" Then
            mdecRatingLower = valid.CheckRatings(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
            End If
        End If

        If txtRatingHigher.Text <> "" Then
            valid.CheckRatings(txtRatingHigher.Text)
            If mdecRatingHigher = -1 Then
                lblMessage.Text = "Higher rating must be numeric value"
            End If
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
        'checks and sees if the user inputed a rating, and if they did it checks if it's a valid numeric decimal
        If txtRatingLower.Text <> "" Then
            mdecRatingLower = valid.CheckRatings(txtRatingLower.Text)
            If mdecRatingLower = -1 Then
                lblMessage.Text = "Lower rating must be numeric value"
            End If
        End If

        If txtRatingHigher.Text <> "" Then
            valid.CheckRatings(txtRatingHigher.Text)
            If mdecRatingHigher = -1 Then
                lblMessage.Text = "Higher rating must be numeric value"
            End If
        End If

    End Sub
    Public Sub DataBindStuff()

        ' purpose: bind data
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May
        'eliminate duplicate code for everytime a view needs a databind

        'sort by the selected item
        sort.DoSort(ddlSort.SelectedValue.ToString)
        'bind gridview to myview based on sort
        gvSearchResults.DataSource = sort.MyView
        gvSearchResults.DataBind()

        'count of how many elements are in the view after sort
        lblRecords.Text = sort.MyView.Count.ToString()
    End Sub
End Class
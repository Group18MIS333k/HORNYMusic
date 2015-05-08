
Public Class ArtistSearch

    Inherits System.Web.UI.Page

    Dim mdecRatingLower As Decimal
    Dim mdecRatingHigher As Decimal
    Dim valid As New ValidationClass
    Dim genre As New GenreClassDB
    Dim search As New ArtistClassDB

    Dim mAryParamNames As New ArrayList
    Dim mAryParamValues As New ArrayList


    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'is postback being false prevents everything from reloading every time you do something
        If IsPostBack = False Then
            genre.GenreGetAll()
            LoadCheckBoxList()
        End If




    End Sub

    Public Sub btnPartialSearch_Click(sender As Object, e As EventArgs) Handles btnPartialSearch.Click
        mAryParamNames.Add("@artist")
        mAryParamValues.Add(txtName.Text)




        If txtName.Text IsNot Nothing Then
            search.ArtistSearchWithAnyParameters("usp_artist_search_partial_artistOnly", mAryParamNames, mAryParamValues)
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


        SearchGenresAndRatings(mdecRatingLower, mdecRatingHigher)
        DataBindStuff()



        'figure out the fucking filter on that dumbcunt listbox
        'lbxGenre.SelectedItem

        'For Each i In lbxGenre.SelectedItem

        'Next

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
    '    Me.lbxGenre.DataTextField = "Genres"
    '    'where it finds what to put in the list
    '    Me.lbxGenre.DataValueField = "GenreID"
    '    'binds it to the list box
    '    Me.lbxGenre.DataBind()


    'End Sub

    Protected Sub btnKeywordSearch_Click(sender As Object, e As EventArgs) Handles btnKeywordSearch.Click

        mAryParamNames.Add("@artist")
        mAryParamValues.Add(txtName.Text)


        ''checks and sees if the user inputed a name
        'search.ArtistGetAll()

        If txtName.Text IsNot Nothing Then
            search.ArtistSearchWithAnyParameters("usp_artist_search_keyword_artistOnly", mAryParamNames, mAryParamValues)
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

        SearchGenresAndRatings(mdecRatingLower, mdecRatingHigher)

        DataBindStuff()







    End Sub
    Public Sub DataBindStuff()

        ' purpose: bind data
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May

        'get all

        'eliminate duplicate code for everytime a view needs a databind

        'sort by the selected item

        'bind gridview to myview based on sort
        gvSearchResults.DataSource = search.ArtistDataset.Tables("Artists")
        gvSearchResults.DataSource = search.MyView 'sets grid to view
        search.ArtistSearchSort(ddlSort.SelectedValue.ToString)
        gvSearchResults.DataBind()

        'count of how many elements are in the view after sort
        lblRecords.Text = gvSearchResults.Rows.Count.ToString
    End Sub

    Protected Sub ddlSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSort.SelectedIndexChanged


    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cblGenres.SelectedIndexChanged

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
    Public Sub SearchGenresAndRatings(ByVal decRatingLower As Decimal, ByVal decRatingUpper As Decimal)

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
            search.MyView.RowFilter = "AvgRatingNBR > '" & decRatingLower & "' AND avgRatingNBR < '" & decRatingUpper & "' AND " & genresSearch
        Else
            search.MyView.RowFilter = "AvgRatingNBR > '" & decRatingLower & "' AND avgRatingNBR < '" & decRatingUpper & "'"
        End If
    End Sub
    'Public Sub SearchGenres()



    '    Dim genresSearch As String = ""
    '    Dim genreFilter As String = ""




    '    Dim genreItem As ListItem
    '    For Each genreItem In cblGenres.Items
    '        If genreItem.Selected Then
    '            genreFilter = "Genre = '" & genreItem.Text & "' OR "
    '            genresSearch += genreFilter
    '        End If
    '    Next


    '    If genresSearch.Length > 0 Then
    '        genresSearch = genresSearch.Substring(0, genresSearch.Length - 4)
    '    End If


    '    search.MyView.RowFilter = genresSearch


    'End Sub
End Class
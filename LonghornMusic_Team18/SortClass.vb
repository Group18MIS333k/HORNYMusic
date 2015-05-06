

Public Class SortClassDB

    Dim mMyView As New DataView


    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        Get
            Return mMyView
        End Get
    End Property
    'will this actually work?? 
    Public Sub DoSortDDL(ByVal strSortValue As String)
        ' purpose: sort results
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May
        'eliminate duplicate code for everytime a view needs a databind
        'checks the sort value in the the radio button list


        If strSortValue = "Rating Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Rating ASC"
        End If

        If strSortValue = "Rating Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Rating DESC"
        End If

        If strSortValue = "Artist Name Ascending" Then
            MyView.Sort = "ArtistName ASC"
        End If

        If strSortValue = "Artist Name Descending" Then
            MyView.Sort = "ArtistName DESC"
        End If

        If strSortValue = "Album Name Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AlbumName ASC"
        End If

        If strSortValue = "Album Name Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AlbumName DESC"
        End If

        If strSortValue = "Song Title Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "SongTitle ASC"
        End If

        If strSortValue = "Song Title Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "SongTitle DESC"
        End If

    End Sub

    'Protected Sub SortRecords(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
    '    Dim sortExpression As String = e.SortExpression
    '    Dim direction As String = String.Empty
    '    If SortDirection = SortDirection.Ascending Then
    '        SortDirection = SortDirection.Descending
    '        direction = " DESC"
    '    Else
    '        SortDirection = SortDirection.Ascending
    '        direction = " ASC"
    '    End If
    '    Dim table As DataTable = Me.GetData()
    '    table.DefaultView.Sort = sortExpression & direction
    '    GridView1.DataSource = table
    '    GridView1.DataBind()
    'End Sub


    'Public Property SortDirection() As SortDirection
    '    Get
    '        If ViewState("SortDirection") Is Nothing Then
    '            ViewState("SortDirection") = SortDirection.Ascending
    '        End If
    '        Return DirectCast(ViewState("SortDirection"), SortDirection)
    '    End Get
    '    Set(ByVal value As SortDirection)
    '        ViewState("SortDirection") = value
    '    End Set
    'End Property


End Class





Public Class SortClassDB

    Dim mMyView As New DataView


    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        Get
            Return mMyView
        End Get
    End Property
    Public Sub DoSort(ByVal strSortValue As String)
        ' purpose: sort results
        ' arguments: 
        ' returns: N/A
        ' author: Morgan May
        'eliminate duplicate code for everytime a view needs a databind
        'checks the sort value in the the radio button list
        If strSortValue = "Title Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Title ASC"
        End If

        If strSortValue = "Title Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Title DESC"
        End If

        If strSortValue = "Artist Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Album ASC"
        End If

        If strSortValue = "Artist Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Album DESC"
        End If

        If strSortValue = "Rating Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Rating ASC"
        End If

        If strSortValue = "Rating Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Rating DESC"
        End If

        If strSortValue = "Name Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Rating ASC"
        End If

        If strSortValue = "Name Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "Rating DESC"
        End If
    End Sub
End Class



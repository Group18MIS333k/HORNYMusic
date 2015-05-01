Imports System.Data
Imports System.Data.SqlClient
Public Class SongClassDB
    ' these module variables are internal to object
    Dim mDatasetSong As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_Team18;user id=msbcj918;password=M1organ61994"
    '(note: the above is ONE long line, not three separate lines as shown, and you must change the catalog to your McCombs login number)


    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property SongDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetSong
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        Get
            Return mMyView
        End Get
    End Property

    'Public Sub SearchSongTitlePartialAsc(ByVal strInput As String)
    '    mMyView.RowFilter = "SongTitle Like '" & strInput & "%'"
    'End Sub
    'Public Sub SearchSongGenrePartialAsc(ByVal strInput As String)
    '    mMyView.RowFilter = "Genre Like '" & strInput & "'"
    'End Sub
    'Public Sub SearchSongTitleKeywordAsc(ByVal strInput As String)
    '    mMyView.RowFilter = "SongTitle Like '" & strInput & "'"
    'End Sub
    'Public Sub SearchArtistGenreKeywordAsc(ByVal strInput As String)
    '    mMyView.RowFilter = "Genre Like '" & strInput & "'"
    'End Sub
    'Public Sub SearchArtistNamePartialDesc(ByVal strInput As String)
    '    mMyView.RowFilter = "ArtistName Like '" & strInput & "'"
    'End Sub
    'Public Sub SearchArtistGenrePartialDesc(ByVal strInput As String)
    '    mMyView.RowFilter = "Genre Like '" & strInput & "'"
    'End Sub
    'Public Sub SearchArtistNameKeywordDesc(ByVal strInput As String)
    '    mMyView.RowFilter = "ArtistName Like '" & strInput & "'"
    'End Sub
    'Public Sub SearchArtistGenreKeywordDesc(ByVal strInput As String)
    '    mMyView.RowFilter = "Genre Like '" & strInput & "'"
    'End Sub
End Class


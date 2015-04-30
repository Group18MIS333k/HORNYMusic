Imports System.Data
Imports System.Data.SqlClient
Public Class ArtistClassDB
    ' these module variables are internal to object
    Dim mDatasetArtist As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_Team18;user id=msbcj918;password=M1organ61994"
    '(note: the above is ONE long line, not three separate lines as shown, and you must change the catalog to your McCombs login number)


    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property ArtistDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetArtist
        End Get
    End Property
    Public Sub SearchArtistPartialAsc(ByVal strInput As String)
        mMyView.RowFilter = "Name Like '" & strInput & "%'"
    End Sub
    Public Sub SearchArtistPartialDesc(ByVal strInput As String)
        mMyView.RowFilter = "Name Like '" & strInput & "%'"
    End Sub
    Public Sub SearchArtistKeywordAsc(ByVal strInput As String)
        mMyView.RowFilter = "Name Like '%" & strInput & "%'"
    End Sub
    Public Sub SearchArtistKeywordDesc(ByVal strInput As String)
        mMyView.RowFilter = "Name Like '%" & strInput & "%'"
    End Sub

End Class

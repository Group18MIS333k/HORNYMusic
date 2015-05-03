Imports System.Data
Imports System.Data.SqlClient
Public Class ArtistClassDB
    'WILL NEED TO ADD PARAMETERS 
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

    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        Get
            Return mMyView
        End Get
    End Property

    Public Sub SearchRatings(ByVal decRatingLower As Decimal, ByVal decRatingUpper As Decimal)
        mMyView.RowFilter = "AvgRatingNBR > '" & decRatingLower & "' AND avgRatingNBR < '" & decRatingUpper & "'"
    End Sub

    Public Sub ArtistSearchArtistKeywordAsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artist_asc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchArtistKeywordDsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artist_dsc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchRatingKeywordAsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_rating_asc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchRatingKeywordDsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_rating_dsc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub ArtistSearchArtistPartialAsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_partial_artist_asc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchArtistPartialDsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_partial_artist_dsc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchRatingPartialAsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_partial_rating_asc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchRatingPartialDsc(strInput As String)
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_search_partial_rating_dsc", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to stored procedure
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistGetAll()
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artists_get_all", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear the dataset before filling
            mDatasetArtist.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")
            'fill dataview
            mMyView.Table = mDatasetArtist.Tables("tblArtists")
            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
End Class

﻿Imports System.Data
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
    'Public Sub DoFilterSortListBox(strGenre1 As String, strGenre2 As String, strGenre3 As String, strGenre4 As String, strGenre5 As String)
    '    mMyView.RowFilter = "Genre = '" & strGenre1 & "'"
    'End Sub
    'Public Sub ArtistSearchArtistKeywordAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artistOnly_SortArtistAsc", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
    '        'clear the dataset before filling
    '        mDatasetArtist.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    'Public Sub ArtistSearchArtistKeywordDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artistOnly_SortArtistDsc", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
    '        'clear the dataset before filling
    '        mDatasetArtist.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    'Public Sub ArtistSearchArtistKeywordRatingAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artistOnly_SortRatingAsc", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
    '        'clear the dataset before filling
    '        mDatasetArtist.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    'Public Sub ArtistSearchArtistKeywordRatingDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artistOnly_SortRatingDsc", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
    '        'clear the dataset before filling
    '        mDatasetArtist.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub

    'Public Sub ArtistSearchArtistPartialAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("usp_artist_search_keyword_artistOnly_SortRatingDsc", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
    '        'clear the dataset before filling
    '        mDatasetArtist.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    'Public Sub ArtistSearchArtistPartialDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artist", strInput))
    '        'clear the dataset before filling
    '        mDatasetArtist.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub


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

    'THIS WILL RUN ALL THE PROCEDURES NECESSARY FROM THE ARTIST TABLE
    Public Sub ArtistSearchWithAnyParameters(ByVal strSPName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'purpose to run a stored procedure with one parameter
        'inputs: stored procedure name, table name, dataset name, dataview name, array list of pparameter name, array list of parameter Value
        'returns: dataset filled with the correct answers

        'creates instances of the connection and the command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'tell sql server the name of the stored procedure you wil be executing 
        Dim mdbDataAdapter As New SqlDataAdapter(strSPName, objConnection)
        Try
            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameter(s) to SPROC
            Dim index As Integer = 0
            For Each strParamName As String In aryParamNames
                mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'clear dataset
            Me.mDatasetArtist.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetArtist, "tblArtists")
            'copy dataset to dataview
            mMyView.Table = mDatasetArtist.Tables("tblArtists")

        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName : " & CStr(aryParamNames(index))
                strError = strError & "ParamValue: " & CStr(aryParamValues(index))
                index = index + 1
            Next
            Throw New Exception(strError & " error is " & ex.Message)
        End Try
    End Sub
    Public Sub ArtistSearchSort(ByVal strSortValue As String)
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

    End Sub
End Class

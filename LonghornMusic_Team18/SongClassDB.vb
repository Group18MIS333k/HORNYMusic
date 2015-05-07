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
            ' return dataset to userC:\Users\Morgan\Desktop\MIS333k\LonghornMusic_Team18\LonghornMusic_Team18\SongClassDB.vb
            Return mDatasetSong
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
    Public Sub SongSearchSort(ByVal strSortValue As String)
        If strSortValue = "Rating Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AvgRatingNbr ASC"
        End If

        If strSortValue = "Rating Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AvgRatingNbr DESC"
        End If

        If strSortValue = "Artist Name Ascending" Then
            MyView.Sort = "ArtistName ASC"
        End If

        If strSortValue = "Artist Name Descending" Then
            MyView.Sort = "ArtistName DESC"
        End If

        If strSortValue = "Album Name Ascending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AlbumTitle ASC"
        End If

        If strSortValue = "Album Name Descending" Then
            'sort by the column name in the dataview
            MyView.Sort = "AlbumTitle DESC"
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
    Public Sub SongSearchWithAnyParameters(ByVal strSPName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
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
            Me.mDatasetSong.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetSong, "tblAlbums")
            'copy dataset to dataview
            mMyView.Table = mDatasetSong.Tables("tblAlbums")

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
    ''needs to have procedure name put in
    'Public Sub SongSearchNameKeywordAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub

    ''needs to have procedure name put in & parameters
    'Public Sub SongSearchNameKeywordDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    ''Name, Artist
    ''needs to have procedure name put in & paramentser
    'Public Sub SongSearchArtistKeywordAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    ''needs to have procedure name put in and parameters
    'Public Sub SongSearchArtistKeywordDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    ''needs to have procedure name put in
    'Public Sub AlbumSearchNamePartialAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub

    ''needs to have procedure name put in
    'Public Sub SongSearchNamePartialDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    ''Name, Artist
    ''needs to have procedure name put in
    'Public Sub SongSearchArtistPartialAsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    ''needs to have procedure name put in
    'Public Sub SongSearchArtistPartialDsc(strInput As String)
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

    '        'add parameter to stored procedure
    '        mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@", strInput))
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")


    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub
    ''needs procedure name put in
    'Public Sub SongGetAll()
    '    'purpse: run any select query and fill data set
    '    Try
    '        'define dataconnection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter("", mdbConn)
    '        'sets command type to stored procedure
    '        mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'clear the dataset before filling
    '        mDatasetSong.Clear()
    '        'fill the dataset
    '        mdbDataAdapter.Fill(mDatasetSong, "tblSongs")
    '        'fill dataview
    '        mMyView.Table = mDatasetSong.Tables("tblAlbums")
    '        'if any problems, give them an error"
    '    Catch ex As Exception
    '        Throw New Exception("error is " & ex.Message)
    '    End Try
    'End Sub


End Class


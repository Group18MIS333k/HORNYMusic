Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ArtistClassDB
    Dim mDatasetArtist As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mMyArtistView As New DataView
    Dim mMyView As New DataView

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property ArtistDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetArtist
        End Get
    End Property

    Public ReadOnly Property myArtistview1() As DataView
        'peter
        Get
            'return dataview
            Return mMyArtistView
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView 'make sure and due this so your views work
        'morgan 
        Get
            Return mMyView
        End Get
    End Property

    'Public Sub SearchRatings(ByVal decRatingLower As Decimal, ByVal decRatingUpper As Decimal)
    '    'morgan 
    '    mMyView.RowFilter = "AvgRatingNBR > '" & decRatingLower & "' AND avgRatingNBR < '" & decRatingUpper & "'"
    'End Sub



    Public Sub SelectAllArtists()
        'peter
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artists_Get_all", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetArtist.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetArtist, "Artists")

            'copy dataset to view
            mMyArtistView.Table = mDatasetArtist.Tables("Artists")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub


    Public Sub ArtistGetAll()
        'morgan
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


    Public Sub SelectArtist(StrArtistName As String)
        ' this sub selects a specific artist

        'get all sub (above)
        SelectAllArtists()
        'sort filtered view
        mMyArtistView.RowFilter = "ArtistName = '" & StrArtistName & "'"

    End Sub
    Public Sub SelectArtistwithArtistID(intArtistID As Integer)


        SelectAllArtists()
        mMyArtistView.RowFilter = "ArtistID =" & intArtistID


        'sort filtered view


    End Sub
    Public Sub SelectNewArtist()


        SelectAllArtists()
        mMyArtistView.RowFilter = "Description is null"


        'sort filtered view


    End Sub

    Public Sub ModifyArtist(strArtistName As String, intArtistID As Integer, strDescription As String, strFlag As String)

        'runs SP that modifies artist records
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_modify_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ArtistName", strArtistName))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))

            'clear dataset
            mDatasetArtist.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetArtist, "Songs")

            'copy dataset to view
            mMyArtistView.Table = mDatasetArtist.Tables("Songs")
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    'THIS WILL RUN ALL THE PROCEDURES NECESSARY FROM THE ARTIST TABLE
    Public Sub ArtistSearchWithAnyParameters(ByVal strSPName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'purpose to run a stored procedure with one parameter
        'inputs: stored procedure name, table name, dataset name, dataview name, array list of pparameter name, array list of parameter Value
        'returns: dataset filled with the correct answers
        'author: morgan may 

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
            mdbDataAdapter.Fill(mDatasetArtist, "Artists")
            'copy dataset to dataview
            mMyView.Table = mDatasetArtist.Tables("Artists")

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
        'morgan
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

    End Sub


    Public Sub AddArtist(strArtistName As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artist_add", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ArtistName", strArtistName))







            'clear dataset
            mDatasetArtist.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetArtist, "Artists")

            'copy dataset to view
            mMyArtistView.Table = mDatasetArtist.Tables("Artists")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub GetFeaturedArtist()


        SelectAllArtists()
        mMyArtistView.RowFilter = "FeaturedFlg = 'Y'"

        'sort filtered view


    End Sub


End Class

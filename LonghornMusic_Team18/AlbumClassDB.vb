Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class AlbumClassDB
    Dim mDatasetAlbum As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mMyAlbumView As New DataView
    Dim mMyView As New DataView

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property AlbumDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetAlbum
        End Get
    End Property


    Public ReadOnly Property MyView() As DataView
        Get
            Return mMyView
        End Get

    End Property

    'Public Sub SearchRatings(ByVal decRatingLower As Decimal, ByVal decRatingUpper As Decimal)
    '    'morgan
    '    mMyView.RowFilter = "AvgRatingNBR > '" & decRatingLower & "' AND avgRatingNBR < '" & decRatingUpper & "'"
    'End Sub
    'THIS WILL RUN ALL THE PROCEDURES NECESSARY FROM THE ARTIST TABLE
    Public Sub AlbumSearchWithAnyParameters(ByVal strSPName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
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
            Me.mDatasetAlbum.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetAlbum, "Albums")
            'copy dataset to dataview
            mMyView.Table = mDatasetAlbum.Tables("Albums")

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

    Public Sub AlbumSearchSort(ByVal strSortValue As String)
        'morgan may 
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

    End Sub


    Public ReadOnly Property myAlbumView1() As DataView
        'Peter
        Get
            'return dataview
            Return mMyAlbumView
        End Get
    End Property

    Public Sub SelectAllAlbums()
        'peter
        'use SP to get all albums
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_albums_get_all", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetAlbum.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetAlbum, "Albums")

            'copy dataset to view
            mMyAlbumView.Table = mDatasetAlbum.Tables("Albums")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub AlbumGetAll()
        'morgan 
        'purpse: run any select query and fill data set
        Try
            'define dataconnection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_albums_get_all", mdbConn)
            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear the dataset before filling
            mDatasetAlbum.Clear()
            'fill the dataset
            mdbDataAdapter.Fill(mDatasetAlbum, "tblAlbums")
            'fill dataview
            mMyView.Table = mDatasetAlbum.Tables("tblAlbums")
            'if any problems, give them an error"
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetNewAlbumID()
        'peter
        'use above sp
        SelectAllAlbums()
        mMyAlbumView.RowFilter = "AlbumTitle is null"
        'sort filtered view
    End Sub
    Public Sub GetAlbumFromTitle(strAlbumTitle As String)


        SelectAllAlbums()
        mMyAlbumView.RowFilter = "AlbumTitle = '" & strAlbumTitle & "'"


        'sort filtered view


    End Sub
    Public Sub GetAlbumFromAlbumID(intAlbumID As Integer)


        SelectAllAlbums()
        mMyAlbumView.RowFilter = "AlbumID =" & intAlbumID


        'sort filtered view


    End Sub
    Public Sub AddAlbum(intArtistID As Integer, DecOriginalPrice As Decimal)
        'peter
        'use SP to create an album based on Artist id and autogenerated AlbumID
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_album_create_album_with_artist_ID", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ArtistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", DecOriginalPrice))

            'clear dataset
            mDatasetAlbum.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetAlbum, "Albums")

            'copy dataset to view
            mMyAlbumView.Table = mDatasetAlbum.Tables("Albums")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub ModifyAlbum(strAlbumTitle As String, strAlbumDescription As String, strFeaturedFlg As String, decOriginalPrice As Decimal, decDiscountPrice As Decimal, intalbumID As Integer)
        'peter
        'Use SP to modify an already existing album
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_album_modify", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumTitle", strAlbumTitle))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Description", strAlbumDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@FeaturedFlg", strFeaturedFlg))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@OriginalPrice", decOriginalPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@DiscountPrice", decDiscountPrice))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intalbumID))

            'clear dataset
            mDatasetAlbum.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetAlbum, "Albums")

            'copy dataset to view
            mMyAlbumView.Table = mDatasetAlbum.Tables("Albums")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub GetFeaturedAlbum()

        SelectFeaturedAlbum()



    End Sub


    Public Sub SelectFeaturedAlbum()
        'peter
        'use SP to get all albums
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_getfeatured_album", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetAlbum.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetAlbum, "Albums")

            'copy dataset to view
            mMyAlbumView.Table = mDatasetAlbum.Tables("Albums")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub SelectDiscountedAlbum()
        'peter
        'use SP to get all albums
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_DiscountedAlbums_getall", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetAlbum.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetAlbum, "Albums")

            'copy dataset to view
            mMyAlbumView.Table = mDatasetAlbum.Tables("Albums")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

End Class

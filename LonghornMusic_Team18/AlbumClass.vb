Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class AlbumClass
    Dim mDatasetAlbum As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim myAlbumView As New DataView




    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property AlbumDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetAlbum
        End Get
    End Property

    Public ReadOnly Property myAlbumView1() As DataView
        Get
            'return dataview
            Return myAlbumView
        End Get
    End Property



    Public Sub SelectAllAlbums()

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
            myAlbumView.Table = mDatasetAlbum.Tables("Albums")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetNewAlbumID()


        SelectAllAlbums()
        myAlbumView.RowFilter = "AlbumTitle is null"


        'sort filtered view


    End Sub

    Public Sub GetAlbumFromTitle(strAlbumTitle As String)


        SelectAllAlbums()
        myAlbumView.RowFilter = "AlbumTitle = '" & strAlbumTitle & "'"


        'sort filtered view


    End Sub
    Public Sub GetAlbumFromAlbumID(intAlbumID As Integer)


        SelectAllAlbums()
        myAlbumView.RowFilter = "AlbumTitle =" & intAlbumID


        'sort filtered view


    End Sub

    Public Sub AddAlbum(intArtistID As Integer, DecOriginalPrice As Decimal)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
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
            myAlbumView.Table = mDatasetAlbum.Tables("Albums")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub



    Public Sub ModifyAlbum(strAlbumTitle As String, strAlbumDescription As String, strFeaturedFlg As String, decOriginalPrice As Decimal, decDiscountPrice As Decimal, intalbumID As Integer)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
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
            myAlbumView.Table = mDatasetAlbum.Tables("Albums")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try



    End Sub
End Class

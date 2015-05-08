Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class RateReviewCLass
    Dim mDatasetRR As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim myView As New DataView




    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property RRDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetRR
        End Get
    End Property

    Public ReadOnly Property myView1() As DataView
        Get
            'return dataview
            Return myview
        End Get
    End Property



    Public Sub SelectAllReviews()

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Ratings_Get_all", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub SearchReviewByCustIDandArtistID(ByVal intCustID As Integer, ByVal intArtistID As Integer)

        SelectAllReviews()
        myView.RowFilter = "CustID = '" & intCustID & "' and SongID = ' " & intArtistID & "'"
        'sort filtered view


    End Sub
    Public Sub SearchReviewByCustIDandALbumID(ByVal intCustID As Integer, ByVal intAlbumID As Integer)

        SelectAllReviews()
        myView.RowFilter = "CustID = '" & intCustID & "' and SongID = ' " & intAlbumID & "'"
        'sort filtered view


    End Sub
    Public Sub SearchReviewByCustIDandSongID(ByVal intCustID As Integer, ByVal intSongID As Integer)

        SelectAllReviews()
        myView.RowFilter = "CustID = '" & intCustID & "' and SongID = ' " & intSongID & "'"
        'sort filtered view


    End Sub

    Public Sub SearchReviewBySong(ByVal intSongID As Integer)
        'establish connection

        SelectAllReviews()
        myView.RowFilter = "songid =" & intSongID
        'sort filtered view


    End Sub
    Public Sub SearchReviewByArtist(ByVal intArtistID As Integer)
        'establish connection

        SelectAllReviews()
        myView.RowFilter = "Artistid =" & intArtistID
        'sort filtered view


    End Sub
    Public Sub SearchReviewByAlbum(ByVal intAlbumID As Integer)
        'establish connection

        SelectAllReviews()
        myView.RowFilter = "Albumid =" & intAlbumID
        'sort filtered view


    End Sub

    Public Sub ModifySongReview(intCustID As Integer, intSongID As Integer, strReview As String, strRating As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_ratings_modify_song", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intSongID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Review", strReview))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Rating", strRating))




            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub AddSongReview(intCustID As Integer, intSongID As Integer, strReview As String, strRating As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Ratings_add_song", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SongID", intSongID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Review", strReview))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Rating", strRating))




            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub AddArtistReview(intCustID As Integer, intArtistID As Integer, strReview As String, strRating As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Ratings_add_artist", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ArtistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Review", strReview))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Rating", strRating))




            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub ModifyArtistReview(intCustID As Integer, intArtistID As Integer, strReview As String, strRating As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Ratings_modify_artist", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ArtistID", intArtistID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Review", strReview))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Rating", strRating))




            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub AddAlbumReview(intCustID As Integer, intAlbumID As Integer, strReview As String, strRating As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Ratings_add_album", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intAlbumID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Review", strReview))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Rating", strRating))




            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub ModifyAlbumReview(intCustID As Integer, intAlbumID As Integer, strReview As String, strRating As String)

        'purpose create dataset with a SP that returns all customers and copy that dataset into a dataview
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_Ratings_modify_album", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add oaraneter

            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@AlbumID", intAlbumID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Review", strReview))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Rating", strRating))




            'clear dataset
            mDatasetRR.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            'copy dataset to view
            myView.Table = mDatasetRR.Tables("Ratings")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub
    Public Sub SearchReviewByComment(ByVal intCommentID As Integer)
        'establish connection

        SelectAllReviews()
        myView.RowFilter = "CommentID =" & intCommentID
        'sort filtered view


    End Sub

    'select count ratings from ratings where song id = x
    'select avg ratings from ratings where song id = x

    Public Sub UpvoteDownvote(ByVal VoteCount As Integer, ByVal intCommentID As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_customer_upvotedownvote", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@VoteCount", VoteCount))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CommentID", intCommentID))

            'clear dataset
            Me.mDatasetRR.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")
            'copy to dataview
            'clear dataset
            myView.Table = mDatasetRR.Tables("Ratings")
            SelectAllReviews()

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub

End Class

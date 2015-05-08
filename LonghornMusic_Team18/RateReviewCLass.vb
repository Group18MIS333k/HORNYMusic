Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class RateReviewCLass
    Dim mDatasetRR As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mMyView As New DataView


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
            Return mMyview
        End Get
    End Property


    Public Sub SelectQuery(ByVal strQuery As String)

        ' purpose: run any select query and fill dataset

        Try
            ' define data connection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

            ' open the connection and dataset 
            mdbConn.Open()

            ' clear the dataset before filling
            mDatasetRR.Clear()

            ' fill the dataset
            mdbDataAdapter.Fill(mDatasetRR, "Ratings")

            ' close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub
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
            mMyView.Table = mDatasetRR.Tables("Ratings")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub


    Public Sub SearchReviewByCustIDandSongID(ByVal intCustID As Integer, ByVal intArtistID As Integer)

        SelectAllReviews()
        mMyView.RowFilter = "CustID =" & intCustID
        mMyView.RowFilter = "SongID =" & intArtistID
        'sort filtered view


    End Sub

    Public Sub SearchReviewBySong(ByVal intSongID As Integer)
        'establish connection

        SelectAllReviews()
        mMyView.RowFilter = "SongID =" & intSongID
        'sort filtered view


    End Sub
    Public Sub SearchReviewByComment(ByVal intCommentID As Integer)
        'establish connection

        SelectAllReviews()
        mMyView.RowFilter = "CommentID =" & intCommentID
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
            mMyView.Table = mDatasetRR.Tables("Ratings")
            SelectAllReviews()

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub

   

End Class

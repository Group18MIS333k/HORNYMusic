Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class DBClassVotes

    'Add objects to allow project to connect to database
    Dim strQuery As String
    Dim mdatasetVotes As New DataSet
    Dim intLogin As New Integer
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim returnValue As String

    Dim mstrConnection As String = "workstation id =COMPUTER;packet size=4096;data source=MISSQL.mccombs.utexas.edu;integrated security = False;initial catalog=mis333k_20152_Team18;user id=msbcn366;password=Getrektm9"



    Public Sub GetAllVotes()
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_get_all_votes", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'clear dataset
            Me.mdatasetVotes.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mdatasetVotes, "Votes")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public ReadOnly Property VoteDataset() As DataSet
        Get
            Return mdatasetVotes
        End Get
    End Property

    Public Sub AddVote(ByVal intCommentID As Integer, ByVal intCustID As Integer, ByVal intVote As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_vote", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CommentID", intCommentID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Vote", intVote))

            'clear dataset
            Me.mdatasetVotes.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mdatasetVotes, "Votes")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
    Public Sub ChangeVote(ByVal intCommentID As Integer, ByVal intCustID As Integer, ByVal intVote As Integer)
        Try
            'create command and connection
            Dim objConnection As New SqlConnection(mstrConnection)
            'tell SQL the procedure
            Dim cmd As New SqlCommand

            'tell SQL the procedure
            Dim mdbDataAdapter As New SqlDataAdapter("usp_vote_change", objConnection)

            'sets command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameters

            'add parameters
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CommentID", intCommentID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CustID", intCustID))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Vote", intVote))

            'clear dataset
            Me.mdatasetVotes.Clear()
            'open connection and fill
            mdbDataAdapter.Fill(mdatasetVotes, "Votes")
            'copy to dataview

        Catch ex As Exception
            Throw New Exception(" error message is " & ex.Message)

        End Try
    End Sub
End Class

Public Class Vote
    Inherits System.Web.UI.Page
    Dim dbratereview As New RateReviewCLass
    Dim intCommentID As New Integer
    Dim DBVote As New DBClassVotes
    Dim intPrevote As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If Session("CustID") Is Nothing Then
        'Response.Redirect("Login.aspx")
        '  End If
        Session("CustID") = 10005
        intCommentID = Session("CommentID")
        dbratereview.SearchReviewByComment(intCommentID)
        gvComments.DataSource = dbratereview.myView1
        gvComments.DataBind()
        txtSongName.Text = Session("SongName")
        txtArtistName.Text = Session("ArtistName")
        txtAlbumName.Text = Session("AlbumName")

        DBVote.GetAllVotes()
        For i = 0 To DBVote.VoteDataset.Tables("Votes").Rows.Count - 1
            If Session("CustID") = DBVote.VoteDataset.Tables("Votes").Rows(i).Item("CustID").ToString Then
                If intCommentID = DBVote.VoteDataset.Tables("Votes").Rows(i).Item("CommentID").ToString Then
                    If DBVote.VoteDataset.Tables("Votes").Rows(i).Item("Vote").ToString = 1 Then
                        btnUpvote.Enabled = False
                        intPrevote = 1
                    Else
                        btnDownvote.Enabled = False
                        intPrevote = -1
                    End If
                End If

            End If
        Next


    End Sub

    Public Sub SetFormRegular()
        intCommentID = Session("CommentID")
        dbratereview.SearchReviewByComment(intCommentID)
        gvComments.DataSource = dbratereview.myView1
        gvComments.DataBind()
        txtSongName.Text = Session("SongName")
    End Sub
    Protected Sub ResultGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvComments.RowDataBound
        e.Row.Cells(0).Visible = False
        e.Row.Cells(1).Visible = False
        e.Row.Cells(2).Visible = False
        e.Row.Cells(3).Visible = False
        e.Row.Cells(5).Visible = False
        e.Row.Cells(7).Visible = False
    End Sub
    Protected Sub btnUpvote_Click(sender As Object, e As EventArgs) Handles btnUpvote.Click

        Dim NumVotes As Integer
        intCommentID = Session("CommentID")
        NumVotes = CInt(gvComments.Rows(0).Cells(6).Text)
        NumVotes = (NumVotes + 1)
        If (intPrevote = -1) Then
            NumVotes = (NumVotes + 1)
            DBVote.ChangeVote(intCommentID, Session("CustID"), 1)
            dbratereview.UpvoteDownvote(NumVotes, intCommentID)
            SetFormRegular()
        Else
            DBVote.AddVote(intCommentID, Session("CustID"), 1)
            dbratereview.UpvoteDownvote(NumVotes, intCommentID)
            SetFormRegular()
        End If
        btnDownvote.Enabled = True
        btnUpvote.Enabled = False
        intPrevote = 1

    End Sub

    Protected Sub btnDownvote_Click(sender As Object, e As EventArgs) Handles btnDownvote.Click
        Dim NumVotes As Integer
        intCommentID = Session("CommentID")
        NumVotes = CInt(gvComments.Rows(0).Cells(6).Text)
        NumVotes = (NumVotes - 1)
        If (intPrevote = 1) Then
            NumVotes = (NumVotes - 1)
            DBVote.ChangeVote(intCommentID, Session("CustID"), 0)
            dbratereview.UpvoteDownvote(NumVotes, intCommentID)
            SetFormRegular()
        Else
            DBVote.AddVote(intCommentID, Session("CustID"), 0)
            dbratereview.UpvoteDownvote(NumVotes, intCommentID)
            SetFormRegular()
        End If
        btnDownvote.Enabled = False
        btnUpvote.Enabled = True
        intPrevote = -1

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)

    End Sub
End Class
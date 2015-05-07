﻿Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page
End Class
Public Class RateReview
    Inherits System.Web.UI.Page

    Dim db As New RateReviewCLass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'get cust id from login and song/artist id from the select, use this to search for review on rate and review table
        'if rating exists, display it on the textboxes, hide add button
        'if rating doesn't exist, hide save button

        If IsPostBack = False Then
            Dim custid As Integer
            Dim songid As Integer
            custid = 10001
            songid = 2
            db.SearchReviewByCustIDandSongID(custid, songid)
            If db.myView1.Count = 0 Then
                btnSave.Visible = False
            End If

            If db.myView1.Count <> 0 Then
                btnAdd.Visible = False
                gvReview.DataSource = db.myView1
                gvReview.DataBind()
                radRating.SelectedValue = gvReview.Rows(0).Cells(5).Text
                txtReview.Text = gvReview.Rows(0).Cells(4).Text
                'fill revew textbox with review from database
            End If
        End If




    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblError.Text = ""
        If txtReview.Text.Length > 100 Then
            lblError.Text = "Too many characters"
            Exit Sub
        End If

        'add code to modify information to database here'

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        lblError.Text = ""
        txtReview.Text = ""

        db.ModifySongReview(10001, 2, txtReview.Text, radRating.SelectedValue.ToString)
        'add code to modify to database here
    End Sub

 
 

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lblError.Text = ""
        If txtReview.Text.Length > 100 Then
            lblError.Text = "Too many characters"
            Exit Sub
        End If

        db.AddSongReview(10001, 2, txtReview.Text, radRating.SelectedValue.ToString)
        'add coded to add to database
    End Sub

   
    
End Class
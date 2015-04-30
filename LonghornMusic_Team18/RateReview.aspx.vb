Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page
End Class
Public Class RateReview
    Inherits System.Web.UI.Page

    Dim db As New RateReviewCLass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intCustID As Integer
        intCustID = 10001
        db.GetCustomer(intCustID)


    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblError.Text = ""
        If txtReview.Text.Length < 100 Then
            lblError.Text = "Too many characters"
            Exit Sub
        End If

        If radRating.SelectedIndex = -1 Then
            lblError.Text = "Must submit user rating"
            Exit Sub
        End If

        'add code to save information to database here'

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        lblError.Text = ""
        txtReview.Text = ""

        'add code to modify to database here
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim msg As MailMessage = New MailMessage()
        Dim mailobj As New SmtpClient("smtp.mccombs.utexas.edu")
        msg.From = New MailAddress("peterkang0603@yahoo.com", "Peter Kang")
        msg.To.Add(New MailAddress("peterkang0603@yahoo.com", "Peter Kangg"))
        msg.IsBodyHtml = "False"
        msg.Body = "testing email code"
        msg.Subject = "testing subject"
        mailobj.Send(msg)
        msg.To.Clear()
        lblError.Text = "email has been sent"
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If radgift.SelectedItem.Text = "yes" Then
            'replace email to with recepient, from with gift giver
            Dim msg As MailMessage = New MailMessage()
            Dim mailobj As New SmtpClient("smtp.mccombs.utexas.edu")
            msg.From = New MailAddress("peterkang0603@yahoo.com", "Peter Kang")
            msg.To.Add(New MailAddress("peterkang0603@yahoo.com", "Peter Kangg"))
            msg.IsBodyHtml = "False"
            msg.Body = "Here's your gift"
            msg.Subject = "gift for you"
            mailobj.Send(msg)
            msg.To.Clear()

            msg.From = New MailAddress("peterkang0603@yahoo.com", "Peter Kang")
            msg.To.Add(New MailAddress("peterkang0603@yahoo.com", "Peter Kangg"))
            msg.IsBodyHtml = "False"
            msg.Body = "your gift has been sent"
            msg.Subject = "gift receipt"
            mailobj.Send(msg)
            msg.To.Clear()
            lblError.Text = "email has been sent"
            Exit Sub
        End If

        If radgift.SelectedItem.Text = "no" Then
            'replace emails with buyer
            Dim msg As MailMessage = New MailMessage()
            Dim mailobj As New SmtpClient("smtp.mccombs.utexas.edu")
            msg.From = New MailAddress("peterkang0603@yahoo.com", "Peter Kang")
            msg.To.Add(New MailAddress("peterkang0603@yahoo.com", "Peter Kangg"))
            msg.IsBodyHtml = "False"
            msg.Body = "this is your receipt"
            msg.Subject = "receipt"
            mailobj.Send(msg)
            msg.To.Clear()
            lblError.Text = "email has been sent"
        End If
    End Sub
End Class
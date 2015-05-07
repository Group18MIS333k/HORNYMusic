Imports System.Net.Mail
Public Class NewUserRegistration
    Inherits System.Web.UI.Page
    Dim DB As New DBClassCustomer
    Dim DBZip As New DBClassZip
    Dim Zip As Integer
    Dim Check As Decimal
    Dim Validater As New ValidationClass
    Dim Format As New Reformatclass
    Dim CustID As Integer
    Dim NewUser As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        'Registers new customer - Validates inputs
        Check = Validater.CheckNull(txtPassword.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a password"
            Exit Sub
        End If
        Check = Validater.CheckNull(txtState.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid Zip"
            Exit Sub
        End If
        Check = Validater.CheckNull(txtAddress.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter an Address"
            Exit Sub
        End If
        Check = Validater.CheckInitial(txtInitial.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid middle initial"
            Exit Sub
        End If
        Check = Validater.CheckNull(txtFirstName.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a first name"
            Exit Sub
        End If
        Check = Validater.CheckNull(txtLastName.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a last name"
            Exit Sub
        End If
        Check = Validater.CheckAllIntegers(txtPhone.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a phone number"
            Exit Sub
        End If
        Check = Validater.CheckPhone(txtPhone.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid phone number"
            Exit Sub
        End If


        Check = Validater.CheckNull(txtEmail.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid email"
            Exit Sub
        End If
        Check = Validater.CheckInteger(txtZip.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid zip"
            Exit Sub
        End If
        Check = Validater.CheckZip(txtZip.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid zip"
            Exit Sub
        End If
        Check = Validater.isValidEmail(txtEmail.Text)
        If (Check <> -1) Then
            lblError.Text = "Please enter a valid email"
            Exit Sub
        End If
        If DB.CheckEmail(txtEmail.Text) = True Then
            lblError.Text = "Duplicate Email"
            Exit Sub
        End If
        DB.GetAllCustomers()

        'Add record
        DB.AddCustomer(txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtAddress.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtCCN1.Text, txtCCN2.Text)
        lblError.Text = "record added"

        'Sends Confirmation Email
        Dim Msg As MailMessage = New MailMessage
        Dim Mailobj As New SmtpClient("smtp.mccombs.utexas.edu")
        Msg.From = New MailAddress("DoNotReply@Longhornmusic.net", "Longhorn Music")
        Msg.To.Add(New MailAddress(txtEmail.Text, txtLastName.Text + ", " + txtFirstName.Text))
        Msg.IsBodyHtml = "False"
        Msg.Body = "Welcome to Longhorn Music, the premier online music store of Longhorns everywhere!" & vbCrLf & "Your Email is: " & txtEmail.Text & vbCrLf & "Your Password is: " & txtPassword.Text & vbCrLf & "Thank you for joining, and visit soon!" & vbCrLf & "Longhorn Music Team 18 Staff"
        Msg.Subject = "Account Created"
        'Mailobj.Send(Msg)
        Msg.To.Clear()
        Response.Redirect("Welcomepage.aspx")
    End Sub


    Protected Sub txtZip_TextChanged(sender As Object, e As EventArgs) Handles txtZip.TextChanged
        'Zip Code Lookup
        Check = Validater.CheckZip(txtZip.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid 5 digit zip"
            Exit Sub
        End If

        'Assigns Values Based on Zip
        Zip = Convert.ToInt32(txtZip.Text)
        DBZip.GetCityZip(Zip)
        txtCity.Text = DBZip.Zip()
        DBZip.GetStateZip(Zip)
        txtState.Text = DBZip.Zip()

    End Sub

    Protected Sub txtCCN1_TextChanged(sender As Object, e As EventArgs) Handles txtCCN1.TextChanged
        'Check if CCN has been entered
        Check = Validater.CheckNull(txtCCN1.Text)
        If (Check = -1) Then
            lblError.Text = ""
            Exit Sub
        End If
        Check = Validater.CheckAllIntegers(txtCCN1.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid Credit Card Number"
            Exit Sub
        End If

        Dim CCCheck As String
        CCCheck = txtCCN1.Text

        If CCCheck.Length < 15 Then
            lblError.Text = "Invalid Number"
            Exit Sub
        End If

        'Pick CCN Carrier
        If CCCheck.Length = 15 Then
            txtCCType1.Text = "AMEX"
        Else
            If CCCheck.Substring(0, 1) = 4 Then
                txtCCType1.Text = "VISA"
            ElseIf CCCheck.Substring(0, 1) = 6 Then
                txtCCType1.Text = "Discover"
            ElseIf CCCheck.Substring(0, 2) = 54 Then
                txtCCType1.Text = "MasterCard"
            Else
                lblError.Text = "Invalid Number"
                Exit Sub
            End If

        End If
        lblError.Text = ""

    End Sub

    Protected Sub txtCCN2_TextChanged(sender As Object, e As EventArgs) Handles txtCCN2.TextChanged
        Check = Validater.CheckNull(txtCCN2.Text)
        If (Check = -1) Then
            lblError.Text = ""
            Exit Sub
        End If
        Check = Validater.CheckAllIntegers(txtCCN2.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid Credit Card Number"
            Exit Sub
        End If

        Dim CCCheck2 As String
        CCCheck2 = txtCCN2.Text
        If CCCheck2.Length < 15 Then
            lblError.Text = "Invalid Number"
            Exit Sub
        End If
        If CCCheck2.Length = 15 Then
            txtCCType2.Text = "AMEX"
        Else
            CCCheck2 = txtCCN2.Text
            If CCCheck2.Substring(0, 1) = 4 Then
                txtCCType2.Text = "VISA"
            ElseIf CCCheck2.Substring(0, 1) = 6 Then
                txtCCType2.Text = "Discover"
            ElseIf CCCheck2.Substring(0, 2) = 54 Then
                txtCCType2.Text = "MasterCard"
            Else
                lblError.Text = "Invalid Number"
                Exit Sub
            End If

        End If
        lblError.Text = ""

    End Sub
End Class
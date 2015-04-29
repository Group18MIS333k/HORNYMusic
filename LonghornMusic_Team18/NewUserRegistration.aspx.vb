Public Class NewUserRegistration
    Inherits System.Web.UI.Page
    Dim DB As New DBClass
    Dim Zip As Integer
    Dim Check As Decimal
    Dim Validater As New ValidationClass
    Dim Format As New Reformatclass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Check = Validater.CheckNull(txtPassword.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a password"
            Exit Sub
        End If
        Check = Validater.CheckState(txtState.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid State"
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
        Check = Validater.CheckPass(txtPassword.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid password"
            Exit Sub
        End If
        ' Call customer.GetLoginInfo()

        '  Dim Login() As DBClass.sLogin
        '  Login = customer.LoginData()
        '  For i = 0 To Login.Length - 1

        '  If txtUsername.Text = Login(i).ID Then
        'lblError.Text = "Username Already In Use"
        ' Exit Sub
        ' End If
        'Next



        DB.AddCustomer(txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtEmail.Text)
        lblError.Text = "record added"
    End Sub

    Protected Sub txtZip_TextChanged(sender As Object, e As EventArgs) Handles txtZip.TextChanged
        Zip = Convert.ToInt32(TextBox1)
        ' txtCity.Text = DB.CustDataset.Tables("ZipCodes").ToString
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Zip = Convert.ToInt32(TextBox1.Text)
        DB.GetCityZip(Zip)
        TextBox2.Text = DB.Zip()
        DB.GetStateZip(Zip)
        TextBox3.Text = DB.Zip()

    End Sub

End Class
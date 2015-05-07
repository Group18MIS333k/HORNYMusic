Public Class NewEmployee
    Inherits System.Web.UI.Page
    Dim Validater As New ValidationClass
    Dim Check As Decimal
    Dim DB As New DBClassEmployee
    Dim DBZIp As New DBClassZip
    Dim Zip As Integer
    Dim Manager As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmpType") Is Nothing Then
            Response.Redirect("EmployeeLogin.aspx")
        End If
    End Sub

    Protected Sub btnSaveEmp_Click(sender As Object, e As EventArgs) Handles btnSaveEmp.Click
        'Checks modifications
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


        Check = Validater.CheckNull(txtSSN.Text)
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
        Check = Validater.CheckSSN(txtSSN.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid SSN"
            Exit Sub
        End If

        If ckbxManager.Checked = True Then
            Manager = "102"
        Else
            Manager = "101"
        End If

        'Saves Modifications
        If DB.CheckSSN(txtSSN.Text) = True Then
            lblError.Text = "Duplicate SSN"
            Exit Sub
        End If
        DB.AddEmployee(txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtAddress.Text, txtZip.Text, txtPhone.Text, txtSSN.Text, Manager)
        lblError.Text = "record modified"
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAddress.Text = ""
        txtCity.Text = ""
        txtFirstName.Text = ""
        txtInitial.Text = ""
        txtLastName.Text = ""
        txtPassword.Text = ""
        txtPhone.Text = ""
        txtSSN.Text = ""
        txtState.Text = ""
        txtZip.Text = ""
        lblError.Text = ""
        ckbxManager.Checked = False
    End Sub

    Protected Sub txtZip_TextChanged(sender As Object, e As EventArgs) Handles txtZip.TextChanged
        Check = Validater.CheckZip(txtZip.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid 5 digit zip"
            Exit Sub
        End If
        Zip = Convert.ToInt32(txtZip.Text)
        DBZip.GetCityZip(Zip)
        txtCity.Text = DBZip.Zip()
        DBZip.GetStateZip(Zip)
        txtState.Text = DBZip.Zip()
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("ManageEmployees.aspx")
    End Sub
End Class
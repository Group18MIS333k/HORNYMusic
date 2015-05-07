Public Class ManageCustomer
    Inherits System.Web.UI.Page
    Dim DB As New DBClassCustomer
    Dim DBZip As New DBClassZip
    Dim Format As New Reformatclass
    Dim Validater As New ValidationClass
    Dim dacustomers As New SqlDataSource
    Dim mDatasetCustomer As New DataSet
    Dim Check As Decimal
    Dim CustID As Integer
    Dim Zip As Integer
    Dim Enabled As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmpType") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
        DB.GetAllCustomers()

        'get all customers
        If IsPostBack = False Then

            Me.ddlCustomer.DataSource = DB.CustDataset.Tables("Customers")
            Me.ddlCustomer.DataTextField = "fullname"
            Me.ddlCustomer.DataValueField = "CustID"
            Me.ddlCustomer.DataBind()
            FillTextboxes()
            FillZip()
            FillCCType()
        End If

    End Sub
    Public Sub FillZip()
        'Fills City and State based on Zip
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
    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        SetFormRegular()
        FillTextboxes()
        FillZip()
        FillCCType()
        lblError.Text = ""

    End Sub
    Public Sub FillTextboxes()
        Dim intIndex As Integer

        intIndex = Me.ddlCustomer.SelectedIndex

        txtLastName.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("LastName").ToString
        txtFirstName.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("FirstName").ToString
        txtInitial.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("MI").ToString
        txtPassword.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Password").ToString
        txtAddress.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Address").ToString
        txtZip.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Zipcode").ToString
        txtEmail.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Email").ToString
        txtPhone.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Phone").ToString
        txtCCN1.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Credit Card #1 Number").ToString
        txtCCN2.Text = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Credit Card #2 Number").ToString

        txtPhone.Text = Format.FormatPhone(txtPhone.Text)

        'Declare Cust ID
        CustID = DB.CustDataset.Tables("Customers").Rows(intIndex).Item("CustID").ToString

        'Account Enabled/Disabled radio button
        If (DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Status").ToString = "No") Then
            rbAccountEnabled.SelectedValue = "No"

        Else
            rbAccountEnabled.SelectedValue = "Yes"

        End If

    End Sub
    Public Sub SetFormRegular()
        DB.GetAllCustomers()
        If IsPostBack = False Then

            Me.ddlCustomer.DataSource = DB.CustDataset.Tables("Customers")
            Me.ddlCustomer.DataTextField = "fullname"
            Me.ddlCustomer.DataValueField = "CustID"
            Me.ddlCustomer.DataBind()
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Validations, mostly checknull

        If Validater.CheckNull(txtCCN1.Text) <> -1 And Validater.CheckNull(txtCCType1.Text) = -1 Then
            lblError.Text = "Please enter a vaid CC#"
            Exit Sub
        End If

        If Validater.CheckNull(txtCCN2.Text) <> -1 And Validater.CheckNull(txtCCType2.Text) = -1 Then
            lblError.Text = "Please enter a vaid CC#"
            Exit Sub
        End If

        Check = Validater.CheckNull(txtPassword.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a password"
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

        Check = Validater.CheckPhone(txtPhone.Text)
        If (Check = False) Then
            lblError.Text = "Please enter a valid phone number"
            Exit Sub
        End If
        Check = Validater.CheckAllIntegers(txtPhone.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a phone number"
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

        'Check for duplicate email

        If txtEmail.Text <> DB.CustDataset.Tables("Customers").Rows(ddlCustomer.SelectedIndex).Item("Email").ToString Then
            If DB.CheckEmail(txtEmail.Text) = True Then
                lblError.Text = "Duplicate Email"
                Exit Sub
            End If
        End If

        'Get enabled/disabled variable
        If rbAccountEnabled.SelectedValue = "Yes" Then
            Enabled = "Yes"
        Else
            Enabled = "No"
        End If
        'Declare Cust ID
        CustID = DB.CustDataset.Tables("Customers").Rows(ddlCustomer.SelectedIndex).Item("CustID").ToString

        DB.EmpModifyCustomer(txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtAddress.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtCCN1.Text, txtCCN2.Text, Enabled, CustID)
        lblError.Text = "record modified"
        SetFormRegular()
        DB.GetAllCustomers()
        ddlCustomer.DataValueField = "CustID"
        FillTextboxes()
        btnModify.Visible = True
        btnModify.Enabled = True
        btnDelete.Visible = True
        btnDelete.Enabled = True
        btnSave.Visible = False
        btnSave.Enabled = False
        btnAbortModify.Visible = False
        btnAbortModify.Enabled = False
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtInitial.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPhone.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True
        txtCCN1.ReadOnly = True
        txtCCN2.ReadOnly = True
        ddlCustomer.Enabled = True
        rbAccountEnabled.Enabled = False
        lblError.Text = ""

    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        txtPhone.Text = DB.CustDataset.Tables("Customers").Rows(Me.ddlCustomer.SelectedIndex).Item("Phone").ToString
        btnModify.Visible = False
        btnModify.Enabled = False
        btnDelete.Visible = False
        btnDelete.Enabled = False
        btnSave.Visible = True
        btnSave.Enabled = True
        btnAbortModify.Visible = True
        btnAbortModify.Enabled = True
        txtAddress.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFirstName.ReadOnly = False
        txtInitial.ReadOnly = False
        txtLastName.ReadOnly = False
        txtPassword.ReadOnly = False
        txtPhone.ReadOnly = False
        txtZip.ReadOnly = False
        txtCCN1.ReadOnly = False
        txtCCN2.ReadOnly = False
        rbAccountEnabled.Enabled = True
        ddlCustomer.Enabled = False
    End Sub

    Protected Sub btnAbortModify_Click(sender As Object, e As EventArgs) Handles btnAbortModify.Click
        btnModify.Visible = True
        btnModify.Enabled = True
        btnDelete.Visible = True
        btnDelete.Enabled = True
        btnSave.Visible = False
        btnSave.Enabled = False
        btnAbortModify.Visible = False
        btnAbortModify.Enabled = False
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtInitial.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPhone.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True
        txtCCN1.ReadOnly = True
        txtCCN2.ReadOnly = True
        ddlCustomer.Enabled = True
        rbAccountEnabled.Enabled = False
        SetFormRegular()
        FillTextboxes()
        lblError.Text = ""
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        btnModify.Visible = False
        btnModify.Enabled = False
        btnDelete.Visible = False
        btnDelete.Enabled = False
        btnAbortDelete.Visible = True
        btnAbortDelete.Enabled = True
        btnConfirmDelete.Visible = True
        btnConfirmDelete.Enabled = True
        ddlCustomer.Enabled = False
        lblError.Text = "Are you sure you want to delete this record?"
    End Sub

    Protected Sub btnConfirmDelete_Click(sender As Object, e As EventArgs) Handles btnConfirmDelete.Click
        Dim intDelete As New Integer
        intDelete = DB.CustDataset.Tables("Customers").Rows(ddlCustomer.SelectedIndex).Item("CustID").ToString
        DB.DeleteRecord(intDelete)
        Session("Deleted") = Session("Deleted") + 1
        lblError.Text = "Record Deleted"
        btnModify.Visible = True
        btnModify.Enabled = True
        btnDelete.Visible = True
        btnDelete.Enabled = True
        btnAbortDelete.Visible = False
        btnAbortDelete.Enabled = False
        btnConfirmDelete.Visible = False
        btnConfirmDelete.Enabled = False
        ddlCustomer.Enabled = True
        SetFormRegular()
        FillTextboxes()
        Me.ddlCustomer.DataSource = DB.CustDataset.Tables("Customers")
        Me.ddlCustomer.DataTextField = "fullname"
        Me.ddlCustomer.DataValueField = "CustID"
        Me.ddlCustomer.DataBind()
        Me.ddlCustomer.SelectedIndex = 0
    End Sub

    Protected Sub btnAbortDelete_Click(sender As Object, e As EventArgs) Handles btnAbortDelete.Click
        btnModify.Visible = True
        btnModify.Enabled = True
        btnDelete.Visible = True
        btnDelete.Enabled = True
        btnAbortDelete.Visible = False
        btnAbortDelete.Enabled = False
        btnConfirmDelete.Visible = False
        btnConfirmDelete.Enabled = False
        ddlCustomer.Enabled = True
        lblError.Text = ""
        SetFormRegular()
        FillTextboxes()
    End Sub

    Protected Sub txtZip_TextChanged(sender As Object, e As EventArgs) Handles txtZip.TextChanged
        FillZip()

    End Sub


    Protected Sub txtCCN1_TextChanged(sender As Object, e As EventArgs) Handles txtCCN1.TextChanged
        Check = Validater.CheckNull(txtCCN1.Text)
        If (Check = -1) Then
            lblError.Text = ""
            txtCCType1.Text = ""
            Exit Sub
        End If
        Check = Validater.CheckAllIntegers(txtCCN1.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid Credit Card Number"
            txtCCType1.Text = ""
            Exit Sub
        End If

        Dim CCCheck As String
        CCCheck = txtCCN1.Text

        If CCCheck.Length < 15 Then
            lblError.Text = "Invalid Number"
            txtCCType1.Text = ""

            Exit Sub
        End If
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
                txtCCType1.Text = ""

                Exit Sub
            End If

        End If
        lblError.Text = ""

    End Sub

    Protected Sub txtCCN2_TextChanged(sender As Object, e As EventArgs) Handles txtCCN2.TextChanged
        Check = Validater.CheckNull(txtCCN2.Text)
        If (Check = -1) Then
            lblError.Text = ""
            txtCCType2.Text = ""

            Exit Sub
        End If
        Check = Validater.CheckAllIntegers(txtCCN2.Text)
        If (Check = -1) Then
            lblError.Text = "Please enter a valid Credit Card Number"
            txtCCType2.Text = ""
            Exit Sub
        End If

        Dim CCCheck2 As String
        CCCheck2 = txtCCN2.Text
        If CCCheck2.Length < 15 Then
            lblError.Text = "Invalid Number"
            txtCCType2.Text = ""
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
                txtCCType2.Text = ""

                Exit Sub
            End If

        End If
        lblError.Text = ""


    End Sub
    Public Sub FillCCType()
        Dim CCCheck As String
        Dim CCCheck2 As String
        CCCheck = txtCCN1.Text
        CCCheck2 = txtCCN2.Text
        If CCCheck.Length < 15 And CCCheck2.Length < 15 Then
            txtCCType1.Text = ""
            txtCCType2.Text = ""

            Exit Sub
        End If
        If CCCheck2.Length > 14 Then
            If CCCheck2.Length = 15 Then
                txtCCType2.Text = "AMEX"
            Else
                If CCCheck2.Substring(0, 1) = 4 Then
                    txtCCType2.Text = "VISA"
                ElseIf CCCheck2.Substring(0, 1) = 6 Then
                    txtCCType2.Text = "Discover"
                ElseIf CCCheck2.Substring(0, 2) = 54 Then
                    txtCCType2.Text = "MasterCard"
                End If
            End If
        End If
        If CCCheck.Length > 14 Then
            If CCCheck.Length = 15 Then
                txtCCType1.Text = "AMEX"
            Else
                If CCCheck.Substring(0, 1) = 4 Then
                    txtCCType1.Text = "VISA"
                ElseIf CCCheck.Substring(0, 1) = 6 Then
                    txtCCType1.Text = "Discover"
                ElseIf CCCheck.Substring(0, 2) = 54 Then
                    txtCCType1.Text = "MasterCard"
                End If
            End If
        End If
    End Sub


    Protected Sub lnkEmpSpash_Click(sender As Object, e As EventArgs) Handles lnkEmpSpash.Click
        Response.Redirect("EmployeeSplash.aspx")
    End Sub
End Class
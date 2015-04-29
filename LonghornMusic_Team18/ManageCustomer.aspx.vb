Public Class ManageCustomer
    Inherits System.Web.UI.Page
    Dim DB As New DBClass
    Dim Format As New Reformatclass
    Dim Validater As New ValidationClass
    Dim dacustomers As New SqlDataSource
    Dim mDatasetCustomer As New DataSet
    Dim Check As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DB.GetAllCustomers()

        'get all customers
        If IsPostBack = False Then

            Me.ddlCustomer.DataSource = DB.CustDataset.Tables("Customers")
            Me.ddlCustomer.DataTextField = "fullname"
            Me.ddlCustomer.DataValueField = "CustID"
            Me.ddlCustomer.DataBind()
            FillTextboxes()
        End If

    End Sub

    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        SetFormRegular()
        FillTextboxes()

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
        txtPhone.Text = Format.FormatPhone(txtPhone.Text)
        'If (DB.CustDataset.Tables("Customers").Rows(intIndex).Item("Status") = 1) Then
        'rbAccountEnabled.SelectedValue = 1

        ' Else
        'rbAccountEnabled.SelectedValue = 0

        'End If

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



        If txtEmail.Text <> DB.CustDataset.Tables("Customers").Rows(ddlCustomer.SelectedIndex).Item("Email").ToString Then
            If DB.CheckEmail(txtEmail.Text) = True Then
                lblError.Text = "Duplicate Email"
                Exit Sub
            End If
        End If

        DB.ModifyCustomer(txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, ddlCustomer.SelectedValue.ToString)
        lblError.Text = "record modified"
        SetFormRegular()
        DB.GetAllCustomers()
        ddlCustomer.DataValueField = "CustID"
        FillTextboxes()
    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        btnModify.Visible = False
        btnModify.Enabled = False
        btnDelete.Visible = False
        btnDelete.Enabled = False
        btnSave.Visible = True
        btnSave.Enabled = True
        btnAbortModify.Visible = True
        btnAbortModify.Enabled = True
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFirstName.ReadOnly = False
        txtInitial.ReadOnly = False
        txtLastName.ReadOnly = False
        txtPassword.ReadOnly = False
        txtPhone.ReadOnly = False
        txtState.ReadOnly = False
        txtZip.ReadOnly = False
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
        SetFormRegular()
        FillTextboxes()
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
        lblError.Text = "Are you sure yoou want to delete this record?"
    End Sub

    Protected Sub btnConfirmDelete_Click(sender As Object, e As EventArgs) Handles btnConfirmDelete.Click
        Dim intDelete As New Integer
        intDelete = ddlCustomer.SelectedIndex + 1
        DB.DeleteRecord(intDelete)
        lblError.Text = "Record Deleted"
        ddlCustomer.SelectedIndex = 0
        SetFormRegular()
        FillTextboxes()
        Me.ddlCustomer.DataSource = DB.CustDataset.Tables("Customers")
        Me.ddlCustomer.DataTextField = "fullname"
        Me.ddlCustomer.DataValueField = "CustID"
        Me.ddlCustomer.DataBind()
        btnModify.Visible = True
        btnModify.Enabled = True
        btnDelete.Visible = True
        btnDelete.Enabled = True
        btnAbortDelete.Visible = False
        btnAbortDelete.Enabled = False
        btnConfirmDelete.Visible = False
        btnConfirmDelete.Enabled = False
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
        lblError.Text = ""
        SetFormRegular()
        FillTextboxes()
    End Sub
End Class
Public Class ManageEmployees
    Inherits System.Web.UI.Page
    Dim DB As New DBClassEmployee
    Dim DBZip As New DBClassZip
    Dim Format As New Reformatclass
    Dim Validater As New ValidationClass
    Dim dacustomers As New SqlDataSource
    Dim mDatasetCustomer As New DataSet
    Dim Zip As Integer
    Dim Check As Decimal
    Dim intIndex As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Checks for Session Variable

        If Session("EmpType") Is Nothing Then
            Response.Redirect("EmployeeLogin.aspx")
        ElseIf Session("EmpType") = 101 Then
            btnFire.Enabled = False
            btnFire.Visible = False
            ddlEmployee.Enabled = False
            btnNewEmployee.Visible = False
            btnNewEmployee.Enabled = False
            btnPromote.Visible = False
            btnPromote.Enabled = False
            btnDemote.Enabled = False
            btnDemote.Visible = False
            btnChangePassword.Visible = True
            btnChangePassword.Enabled = True
        End If



        DB.GetAllEmployees()

        'get all Employees in DDL
        If IsPostBack = False Then

            Me.ddlEmployee.DataSource = DB.CustDataset.Tables("Employees")
            Me.ddlEmployee.DataTextField = "fullname"
            Me.ddlEmployee.DataValueField = "EmpID"
            Me.ddlEmployee.DataBind()
            'Selects currently logged in Employee
            ddlEmployee.SelectedValue = CInt(Session("EmpID"))
            FillTextboxes()
            FillZip()

        End If
        If Session("EmpID") = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString Then
            btnFire.Visible = False
            btnFire.Enabled = False
        Else
            btnFire.Enabled = True
            btnFire.Visible = True

        End If

    End Sub
    Public Sub FillZip()
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


    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEmployee.SelectedIndexChanged
        SetFormRegular()
        FillTextboxes()
        FillZip()

    End Sub
    Public Sub FillTextboxes()
        'Fills Textboxes from DDL/Database
        lblError.Text = ""
        intIndex = Me.ddlEmployee.SelectedIndex
        txtLastName.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("LastName").ToString
        txtFirstName.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("FirstName").ToString
        txtInitial.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("MI").ToString
        txtPassword.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Password").ToString
        txtAddress.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Address").ToString
        txtZip.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Zipcode").ToString
        txtEmpID.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString
        txtSSN.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("SSN").ToString
        txtPhone.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Phone").ToString
        txtPhone.Text = Format.FormatPhone(txtPhone.Text)


        'Employee or Manager Get/Fill
        If (DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpType") = 101) Then
            txtEmpType.Text = "Employee"

        Else
            txtEmpType.Text = "Manager"

        End If
        If (txtEmpType.Text = "Manager") And (Session("EmpType") = 102) Then
            btnPromote.Enabled = False
            btnPromote.Visible = False
            btnDemote.Visible = True
            btnDemote.Enabled = True

        End If
        If (txtEmpType.Text = "Employee") And (Session("EmpType") = 102) Then
            btnPromote.Enabled = True
            btnPromote.Visible = True
            btnDemote.Visible = False
            btnDemote.Enabled = False

        End If

        'Active/ Inactive Fill

        If (DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Status").ToString = "Inactive") Then
            txtActive.Text = "No"

        Else
            txtActive.Text = "Yes"

        End If
        If (txtActive.Text = "No") And (Session("EmpType") = 102) Then
            btnFire.Enabled = False
            btnFire.Visible = False
            btnRehire.Visible = True
            btnRehire.Enabled = True

        End If
        If (txtActive.Text = "Yes") And (Session("EmpType") = 102) Then
            btnFire.Enabled = True
            btnFire.Visible = True
            btnRehire.Visible = False
            btnRehire.Enabled = False

        End If
    End Sub
    Public Sub SetFormRegular()
        'Resets form and reloads DDL
        If Session("EmpType") Is Nothing Then
            Response.Redirect("EmployeeLogin.aspx")
        ElseIf Session("EmpType") = 101 Then
            btnFire.Enabled = False
            btnFire.Visible = False
            ddlEmployee.Enabled = False
            btnNewEmployee.Visible = False
            btnNewEmployee.Enabled = False
            btnPromote.Visible = False
            btnPromote.Enabled = False
            btnDemote.Enabled = False
            btnDemote.Visible = False
            btnChangePassword.Visible = True
            btnChangePassword.Enabled = True
        End If

        DB.GetAllEmployees()

        If IsPostBack = False Then

            Me.ddlEmployee.DataSource = DB.CustDataset.Tables("Employees")
            Me.ddlEmployee.DataTextField = "fullname"
            Me.ddlEmployee.DataValueField = "EmpID"
            Me.ddlEmployee.DataBind()
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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



        'Saves Modifications

        DB.ModifyEmployee(txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtAddress.Text, txtZip.Text, txtPhone.Text, txtSSN.Text, txtEmpID.Text)
        lblError.Text = "record modified"
        SetFormRegular()
        DB.GetAllEmployees()
        ddlEmployee.DataValueField = "EmpID"
        FillTextboxes()
        btnModify.Visible = True
        btnModify.Enabled = True
        If Session("EmpType") = 102 Then
            btnFire.Visible = True
            btnFire.Enabled = True
            ddlEmployee.Enabled = True
            btnChangePassword.Visible = False
            btnChangePassword.Enabled = False

        End If
        btnSave.Visible = False
        btnSave.Enabled = False
        btnAbortModify.Visible = False
        btnAbortModify.Enabled = False
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPhone.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True
        btnNewEmployee.Visible = True
        btnNewEmployee.Enabled = True
    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'Modify button changes
        intIndex = ddlEmployee.SelectedIndex
        txtPhone.Text = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Phone").ToString
        btnModify.Visible = False
        btnModify.Enabled = False
        btnFire.Visible = False
        btnFire.Enabled = False
        btnSave.Visible = True
        btnSave.Enabled = True
        btnAbortModify.Visible = True
        btnAbortModify.Enabled = True
        txtAddress.ReadOnly = False
        txtPhone.ReadOnly = False
        txtZip.ReadOnly = False
        btnNewEmployee.Visible = False
        btnNewEmployee.Enabled = False
        ddlEmployee.Enabled = False
        If Session("EmpType") = 102 Then
            txtPassword.ReadOnly = False
        End If
    End Sub

    Protected Sub btnAbortModify_Click(sender As Object, e As EventArgs) Handles btnAbortModify.Click
        'Abort Modify Button changes
        btnModify.Visible = True
        btnModify.Enabled = True
        If Session("EmpType") = 102 Then
            btnFire.Visible = True
            btnFire.Enabled = True
            ddlEmployee.Enabled = True
        End If
        btnSave.Visible = False
        btnSave.Enabled = False
        btnAbortModify.Visible = False
        btnAbortModify.Enabled = False
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPhone.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True
        btnNewEmployee.Visible = True
        btnNewEmployee.Enabled = True
        SetFormRegular()
        FillTextboxes()
    End Sub

    Protected Sub btnFire_Click(sender As Object, e As EventArgs) Handles btnFire.Click
        'Delete button changes
        btnModify.Visible = False
        btnModify.Enabled = False
        btnFire.Visible = False
        btnFire.Enabled = False
        btnAbortFire.Visible = True
        btnAbortFire.Enabled = True
        btnConfirmFire.Visible = True
        btnConfirmFire.Enabled = True
        ddlEmployee.Enabled = False
        btnNewEmployee.Visible = False
        btnNewEmployee.Enabled = False
        lblError.Text = "Are you sure you want to fire this employee?"
    End Sub

    Protected Sub btnConfirmFire_Click(sender As Object, e As EventArgs) Handles btnConfirmFire.Click
        'Confirm Fire - Fires currently selected Employee
        Dim intDelete As New Integer
        Dim intIndex As Integer
        intIndex = Me.ddlEmployee.SelectedIndex
        intDelete = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString
        DB.FireEmployee(intDelete)
        lblError.Text = "Employee Fired"
        SetFormRegular()
        FillTextboxes()
        btnModify.Visible = True
        btnModify.Enabled = True
        btnAbortFire.Visible = False
        btnAbortFire.Enabled = False
        btnConfirmFire.Visible = False
        btnConfirmFire.Enabled = False
        btnNewEmployee.Visible = True
        btnNewEmployee.Enabled = True
        ddlEmployee.Enabled = True

    End Sub

    Protected Sub btnAbortFire_Click(sender As Object, e As EventArgs) Handles btnAbortFire.Click
        'Abort Delete Actions
        btnModify.Visible = True
        btnModify.Enabled = True
        btnFire.Visible = True
        btnFire.Enabled = True
        btnAbortFire.Visible = False
        btnAbortFire.Enabled = False
        btnConfirmFire.Visible = False
        btnConfirmFire.Enabled = False
        btnNewEmployee.Visible = True
        btnNewEmployee.Enabled = True
        ddlEmployee.Enabled = True
        lblError.Text = ""
        SetFormRegular()
        FillTextboxes()
    End Sub

    Protected Sub txtZip_TextChanged(sender As Object, e As EventArgs) Handles txtZip.TextChanged
  FillZip()
    End Sub

    Protected Sub btnPromote_Click(sender As Object, e As EventArgs) Handles btnPromote.Click
        Dim IntID As New Integer
        Dim intIndex As Integer
        Dim NewType As Integer = 102
        intIndex = Me.ddlEmployee.SelectedIndex
        IntID = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString
        DB.PromoteDemoteEmployee(IntID, NewType)
        SetFormRegular()
        FillTextboxes()
    End Sub

    Protected Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim intIndex As Integer
        intIndex = Me.ddlEmployee.SelectedIndex
        Session("Password") = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("Password").ToString
        Session("EmployeePassChangeID") = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString
        Response.Redirect("ChangePassword.aspx")
        SetFormRegular()
        FillTextboxes()
    End Sub

    Protected Sub btnNewEmployee_Click(sender As Object, e As EventArgs) Handles btnNewEmployee.Click
        Response.Redirect("NewEmployee.aspx")

    End Sub

    Protected Sub btnDemote_Click(sender As Object, e As EventArgs) Handles btnDemote.Click
        Dim IntID As New Integer
        Dim intIndex As Integer
        Dim NewType As Integer = 101
        intIndex = Me.ddlEmployee.SelectedIndex
        IntID = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString
        If Session("EmpType") = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpType").ToString Then
            If Session("EmpID") = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpType").ToString Then
                Session("EmpType") = "101"
            End If
        End If
        DB.PromoteDemoteEmployee(IntID, NewType)
        SetFormRegular()
        FillTextboxes()
    End Sub

    Protected Sub btnRehire_Click(sender As Object, e As EventArgs) Handles btnRehire.Click
        Dim IntID As New Integer
        Dim intIndex As Integer
        Dim Rehired As String = "Inactive"
        intIndex = Me.ddlEmployee.SelectedIndex
        IntID = DB.CustDataset.Tables("Employees").Rows(intIndex).Item("EmpID").ToString
        DB.RehireEmployee(IntID)
        SetFormRegular()
        FillTextboxes()
    End Sub

   
    Protected Sub lnkEmpSplash_Click(sender As Object, e As EventArgs) Handles lnkEmpSplash.Click
        Response.Redirect("EmployeeSplash.aspx")

    End Sub
End Class
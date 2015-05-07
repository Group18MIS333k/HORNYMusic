Public Class EmployeeLogin
    Inherits System.Web.UI.Page
    Dim DB As New DBClassEmployee
    Dim dacustomers As New SqlDataSource
    Dim EmpDataSet As New DataSet
    Dim mintcount As Decimal
    Dim Checknull As Decimal
    Dim Validater As New ValidationClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'create session
            Session("Count") = 0
        End If
        DB.GetAllEmployees()
        mintcount = CInt(Session("Count"))
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        For i = 0 To DB.CustDataset.Tables("Employees").Rows.Count - 1
            If txtEmpID.Text = DB.CustDataset.Tables("Employees").Rows(i).Item("EmpID").ToString Then
                If txtPassword.Text = DB.CustDataset.Tables("Employees").Rows(i).Item("Password").ToString Then
                    Session("EmpType") = DB.CustDataset.Tables("Employees").Rows(i).Item("EmpType").ToString
                    If DB.CustDataset.Tables("Employees").Rows(i).Item("Status").ToString = "Fired" Then
                        lblError.Text = "Employee has been fired. Login Disabled."
                        Exit Sub
                    End If
                    Session("EmpID") = txtEmpID.Text
                    Response.Redirect("EmployeeSplash.aspx")
                    Exit Sub
                End If

            End If
        Next

        mintcount += 1
        txtCount.Text = mintcount.ToString
        'replace session variable
        Session("Count") = mintcount
        lblError.Text = "Bad Login. After 3 login will be disabled"
        If mintcount = 3 Then
            btnLogin.Enabled = False
        End If


    End Sub
End Class
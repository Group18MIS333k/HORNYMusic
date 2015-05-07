Public Class Login
    Inherits System.Web.UI.Page
    Dim DB As New DBClassCustomer
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
        DB.GetAllCustomers()
        Session("Deleted") = 0
        mintcount = CInt(Session("Count"))

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        For i = 0 To DB.CustDataset.Tables("Customers").Rows.Count - 1
            If txtEmail.Text = DB.CustDataset.Tables("Customers").Rows(i).Item("Email").ToString Then
                If txtPassword.Text = DB.CustDataset.Tables("Customers").Rows(i).Item("Password").ToString Then
                    Session("CustID") = DB.CustDataset.Tables("Customers").Rows(i).Item("CustID").ToString
                    Response.Redirect("AccountInfo.aspx")
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
Public Class EmployeeSplash
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmpType") Is Nothing Then
            Response.Redirect("EmployeeLogin.aspx")
        End If
    End Sub

    Protected Sub lnkManageEmployees_Click(sender As Object, e As EventArgs) Handles lnkManageEmployees.Click
        Response.Redirect("manageemployees.aspx")

    End Sub

    Protected Sub lnkManageCustomers_Click(sender As Object, e As EventArgs) Handles lnkManageCustomers.Click
        Response.Redirect("managecustomer.aspx")

    End Sub
End Class
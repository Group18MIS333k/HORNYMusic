Public Class ChangePassword
    Inherits System.Web.UI.Page
    Dim DB As New DBClassCustomer
    Dim DBEmp As New DBClassEmployee
    Dim EitherID As New Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        'Gets Custumer/Employee ID from session
        If Session("EmpID") Is Nothing Then
            EitherID = Session("CustID")
        Else
            EitherID = Session("EmployeePassChangeID")
        End If
        'Checks if password is same as password loaded in Account Info

        If txtOld.Text = Session("Password").ToString Then

            'Reset Session password
            Session("Password") = txtNew.Text

            'Change pass
            If Session("EmpID") Is Nothing Then
                DB.ChangePassword(txtNew.Text, EitherID)
            Else
                DBEmp.ChangePassword(txtNew.Text, EitherID)
            End If
            lblError.Text = "Password Successfully Updated"
        Else
            lblError.Text = "Incorrect Password!"

        End If



    End Sub
End Class
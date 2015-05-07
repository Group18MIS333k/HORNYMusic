Public Class WelcomePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmpType") <> "" Or Session("CustID") <> "" Then
            'set form as logged in user
            If Session("CustID") = "" Then
                lnkAccount.Visible = False
                lnkAccount.Enabled = False
                lnkMyMusic.Enabled = False
                lnkMyMusic.Visible = False

            End If
            lnkLogout.Enabled = True
            lnkLogout.Visible = True
            lnkEmployeeLogin.Enabled = False
            lnkEmployeeLogin.Visible = False
            lnkLogin.Enabled = False
            lnkLogin.Visible = False
            lnkRegister.Enabled = False
            lnkRegister.Visible = False
        Else
            'set Form as guest
            lnkLogout.Enabled = False
            lnkLogout.Visible = False
            lnkEmployeeLogin.Enabled = True
            lnkEmployeeLogin.Visible = True
            lnkLogin.Enabled = True
            lnkLogin.Visible = True
            lnkMyMusic.Visible = False
            lnkMyMusic.Enabled = False
            lnkAccount.Visible = False
            lnkAccount.Enabled = False
        End If
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.Click
        'Reset Session Variables
        Session("CustID") = ""
        Session("EmpID") = ""
        Session("EmpType") = ""

        'Set form to guest
        lnkLogout.Enabled = False
        lnkLogout.Visible = False
        lnkEmployeeLogin.Enabled = True
        lnkEmployeeLogin.Visible = True
        lnkLogin.Enabled = True
        lnkLogin.Visible = True
        lnkMyMusic.Visible = False
        lnkMyMusic.Enabled = False
        lnkAccount.Visible = False
        lnkAccount.Enabled = False
        lnkRegister.Enabled = True
        lnkRegister.Visible = True
    End Sub

End Class
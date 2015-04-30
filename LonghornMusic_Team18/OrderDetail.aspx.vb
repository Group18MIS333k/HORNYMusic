Public Class OrderDetail
    Inherits System.Web.UI.Page
    Dim db As New OrderDetailClassDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intOrderID As Integer

        If IsPostBack = True Then
            intOrderID = Request.QueryString("OrderID")
            DataBindStuff()

        End If

    End Sub

    Public Sub DataBindStuff()
        db.OrderDetailGetAll()
        gvOrderDetail.DataSource = db.MyView
        gvOrderDetail.DataBind()
    End Sub

    Protected Sub gvOrderDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvOrderDetail.SelectedIndexChanged

    End Sub
End Class
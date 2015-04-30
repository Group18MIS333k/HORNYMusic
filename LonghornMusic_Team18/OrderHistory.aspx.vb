
Public Class OrderHistory
    Inherits System.Web.UI.Page
    Dim db As New OrderHistoryClassDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        db.OrdersGetAll()
        gvOrderHistory.DataSource = db.MyView
        gvOrderHistory.DataBind()
    End Sub

    Protected Sub gvOrderHistory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvOrderHistory.SelectedIndexChanged
        Dim OrderID As New Integer
        'gets selected orderID from the table
        OrderID = CInt(Me.gvOrderHistory.SelectedRow.Cells(0).Text)
        'puts that order as an integer into a session level variable
        OrderID = Session("OrderID")
        'sends you to the Order Detail Page
        Response.Redirect("OrderDetail.aspx?OrderID=" & CInt(Me.gvOrderHistory.SelectedRow.Cells(0).Text))

    End Sub
End Class
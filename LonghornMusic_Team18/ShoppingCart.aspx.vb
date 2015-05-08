Public Class ShoppingCart
    Inherits System.Web.UI.Page
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList
    Dim CartDB As New CartClassDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load






    End Sub
    Public Sub DataBindShoppingCart()
        gvShoppingCart.DataSource = CartDB.CartDataset.Tables("Cart")
        gvShoppingCart.DataSource = CartDB.MyView
        gvShoppingCart.DataBind()

    End Sub

    Protected Sub gvShoppingCart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvShoppingCart.SelectedIndexChanged

    End Sub
End Class


Public Class ShoppingCart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Session("Cart") = 1


        End If

    End Sub

    Public Sub GetSubtotal(
        Dim decOriginalPrice As Decimal
        Dim decTax As Decimal
        For i = 0 To gvShoppingCart.Rows.Count - 1
            decOriginalPrice += CDec(gvShoppingCart.Rows(i).Cells(3).Text)
        Next

        Dim decDiscount As Decimal
        For i = 0 To gvShoppingCart.Rows.Count - 1
            decDiscount += gvShoppingCart.Rows(i).Cells(4).Text
        Next

        Dim decSavings As Decimal
        decSavings = decOriginalPrice - decDiscount


        lblSubtotal.Text = decOriginalPrice.ToString
        lblSavings.Text = decSavings.ToString

        decTax = decSavings * 0.0825
        lblTotal.Text = (decSavings + decTax)



    End Sub

    Protected Sub gvShoppingCart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvShoppingCart.SelectedIndexChanged
        Dim intSongID As Integer
        intSongID = CInt(gvShoppingCart.SelectedRow.Cells(0).Text)
        Session("SongID") = intSongID
        Response.Redirect("~/SongDetail.aspx")
    End Sub
End Class
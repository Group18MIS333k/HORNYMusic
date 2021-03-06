﻿Public Class ShoppingCart
    Inherits System.Web.UI.Page
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList
    Dim CartDB As New CartClassDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Session("Cart") = 0

            maryParamNames.Add("@CustID")
            maryParamNames.Add("@SongID")
            maryParamNames.Add("@AlbumID")
            maryParamNames.Add("@OriginalPrice")
            maryParamNames.Add("@DiscountPrice")

            'get each unique row from the gridview 
            For Each cell In gvShoppingCart.Rows(0).Cells
                'get each individual cell value from row and put in maryParamValues arrayList
                maryParamValues.Add(gvShoppingCart.Rows(0).Cells.ToString)

            Next

            CartDB.UseSPforInsertQuery("usp_cart_Add_Item", maryParamNames, maryParamValues)

        End If



    End Sub
    Public Sub DataBindShoppingCart()
        gvShoppingCart.DataSource = CartDB.CartDataset.Tables("Cart")
        gvShoppingCart.DataSource = CartDB.MyView
        gvShoppingCart.DataBind()

    End Sub


    Protected Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click

    End Sub

    Protected Sub gvShoppingCart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvShoppingCart.SelectedIndexChanged

    End Sub
End Class
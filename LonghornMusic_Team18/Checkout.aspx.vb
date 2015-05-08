Public Class Checkout
    Inherits System.Web.UI.Page
    Dim CartDB As New CartClassDB
    Dim CustDB As New DBClassCustomer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Cart") <> 1 Then

        End If
        DataBindShoppingCart()
        DataBindCustomer()

    End Sub

    Public Sub FillDDL()
        'this tells the drop down box where to get the data
        Me.ddlPaymentMethod0.DataSource = CustDB.CustDataset.Tables("Customers").Columns(8)
        'sets which column from the dataset wil be displayed in the ddl
        Me.ddlPaymentMethod0.DataTextField = "Credit Card #1 Number"
        'sets which column from the dataset will be the value stored when items are selected 
        Me.ddlPaymentMethod0.DataValueField = "Credit Card #1 Number"
        'binds data
        Me.ddlPaymentMethod0.DataBind()

    End Sub

    Public Sub DataBindShoppingCart()
        gvCart.DataSource = CartDB.CartDataset.Tables("Cart")
        gvCart.DataSource = CartDB.MyView
        gvCart.DataBind()

    End Sub
    Public Sub DataBindCustomer()
        gvCustomer.DataSource = CustDB.CustDataset.Tables("Customers")
        gvCustomer.DataSource = CustDB.MyView
        gvCustomer.DataBind()

    End Sub
    Public Sub GetSubtotal()
        Dim decOriginalPrice As Decimal
        Dim decTax As Decimal
        For i = 0 To gvCart.Rows.Count - 1
            decOriginalPrice += CDec(gvCart.Rows(i).Cells(3).Text)
        Next

        Dim decDiscount As Decimal
        For i = 0 To gvCart.Rows.Count - 1
            decDiscount += gvCart.Rows(i).Cells(4).Text
        Next

        Dim decSavings As Decimal
        decSavings = decOriginalPrice - decDiscount


        lblCheckoutSubtotal0.Text = decSavings.ToString


        decTax = decSavings * 0.0825
        lblCheckoutTax0.Text = decTax.ToString
        lblCheckoutTotal0.Text = (decSavings + decTax).ToString



    End Sub

    

  
    Protected Sub btnProceed0_Click(sender As Object, e As EventArgs) Handles btnProceed0.Click

    End Sub

   
   
    Protected Sub gvCart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCart.SelectedIndexChanged

    End Sub

    Protected Sub gvCheckoutCart0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCheckoutCart0.SelectedIndexChanged

    End Sub
End Class
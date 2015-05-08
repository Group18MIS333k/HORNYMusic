Public Class SongDetail
    Inherits System.Web.UI.Page
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList
    Dim CartDB As New CartClassDB
    Dim SongDB As New SongClassDB


    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            'load the grid
            'get searched song info
            SongDB.SelectAllSongs()


            gvSongList.Visible = True
            SongDB.mySongView1.RowFilter = "SongID = '1'"
            'declare session variables 
            Session("CountGoodSearches") = 0
            DataBindStuff()
        Else
            ' SongDB.SongGetAll()
            DataBindStuff()
        End If
    End Sub

    Public Sub DataBindStuff()
        'purpose: elimate duplicate code for everytime a view needs a databind 

        'sort by the selected item 
        'SongDB.DoSort(radSort.SelectedValue.ToString)

        'sets gv to dataset &bind
        gvSongList.DataSource = SongDB.SongDataset.Tables("Songs")

        'bind gridview to myview based on sort 
        gvSongList.DataSource = SongDB.mySongView1
        gvSongList.DataBind()

        'count of how many elements are in the view after sort

    End Sub
    Protected Sub BtnAdd2Cart_Click(sender As Object, e As EventArgs) Handles BtnAdd2Cart.Click


        maryParamNames.Add("@CustID")
        maryParamNames.Add("@SongID")
        maryParamNames.Add("@AlbumID")
        maryParamNames.Add("@OriginalPrice")
        maryParamNames.Add("@DiscountPrice")

        ''get each unique row from the gridview 
        ''       For i = 0 To gvSongList.Rows.Count
        'For Each cell as ListItem In gvSongList.Rows(0).Cells.
        '    'get each individual cell value from row and put in maryParamValues arrayList
        '    maryParamValues.Add(gvSongList.Rows(0).Cells)

        'Next
        ''   Next
        'For i = 0 To gvSongList.Rows(0).Cells.Count
        '    'get each individual cell value from row and put in maryParamValues arrayList
        '    maryParamValues.Add(gvSongList.Rows(0).Cells(i))
        'Next





        CartDB.UseSPforInsertQuery("usp_cart_Add_Item", maryParamNames, maryParamValues)
    End Sub


End Class
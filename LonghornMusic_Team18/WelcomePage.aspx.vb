Public Class WelcomePage
    Inherits System.Web.UI.Page
    Dim SongDB As New SongClassDB
    Dim ArtistDB As New ArtistClassDB
    Dim AlbumDB As New AlbumClassDB

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
        If IsPostBack = False Then
            GetFeatures()
        End If
    End Sub
    Public Sub GetFeatures()
        'Featured Song
        SongDB.GetFeaturedSong()
        gvFeaturedSongs.DataSource = SongDB.SongDataset.Tables("Songs")
        gvFeaturedSongs.DataSource = SongDB.mySongView1
        gvFeaturedSongs.DataBind()

        'Featured Artist
        ArtistDB.GetFeaturedArtist()
        gvFeaturedArtists.DataSource = ArtistDB.ArtistDataset.Tables("Artists")
        gvFeaturedArtists.DataSource = ArtistDB.myArtistview1
        gvFeaturedArtists.DataBind()

        'Featured Album
        AlbumDB.GetFeaturedAlbum()
        gvFeaturedAlbums.DataSource = AlbumDB.AlbumDataset.Tables("Albums")
        gvFeaturedAlbums.DataSource = AlbumDB.myAlbumView1
        gvFeaturedAlbums.DataBind()

        'Discounted Song
        SongDB.GetDiscountSong()
        gvDiscountedSongs.DataSource = SongDB.SongDataset.Tables("Songs")
        gvDiscountedSongs.DataSource = SongDB.mySongView1
        gvDiscountedSongs.DataBind()

        'Discounted Album
        AlbumDB.GetDiscountAlbum()
        gvDiscountedAlbums.DataSource = AlbumDB.AlbumDataset.Tables("Albums")
        gvDiscountedAlbums.DataSource = AlbumDB.myAlbumView1
        gvDiscountedAlbums.DataBind()
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
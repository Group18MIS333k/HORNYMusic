Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ArtistClass
    Dim mDatasetArtist As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim mMyArtistView As New DataView

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property ArtistDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetArtist
        End Get
    End Property

    Public ReadOnly Property myArtistview1() As DataView
        Get
            'return dataview
            Return mMyArtistView
        End Get
    End Property

    Public Sub SelectAllArtists()

        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_artists_Get_all", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'clear dataset
            mDatasetArtist.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetArtist, "Artists")

            'copy dataset to view
            mMyArtistView.Table = mDatasetArtist.Tables("Artists")

        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub SelectArtist(StrArtistName As String)
        ' this sub selects a specific artist

        'get all sub (above)
        SelectAllArtists()
        'sort filtered view
        mMyArtistView.RowFilter = "ArtistName = '" & StrArtistName & "'"

    End Sub

    Public Sub ModifyArtist(strArtistName As String, intArtistID As Integer, strDescription As String, strFlag As String)

        'runs SP that modifies artist records
        Try
            'establich connection
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter("usp_song_modify_by_manager", mdbConn)

            'sets the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'add parameter
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ArtistName", strArtistName))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@description", strDescription))
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@artistID", intArtistID))

            'clear dataset
            mDatasetArtist.Clear()

            'fill dataset with allcustomers
            mdbDataAdapter.Fill(mDatasetArtist, "Songs")

            'copy dataset to view
            mMyArtistView.Table = mDatasetArtist.Tables("Songs")
        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub


End Class

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ArtistClass
    Dim mDatasetArtist As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team18;user id=msbcs740;password=C2d3e4!!!"
    Dim myArtistView As New DataView




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
            Return myArtistView
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
            myArtistView.Table = mDatasetArtist.Tables("Artists")






        Catch ex As Exception
            Throw New Exception("error is " & ex.Message)
        End Try
    End Sub

    Public Sub SelectArtist(StrArtistName As String)


        SelectAllArtists()
        myArtistView.RowFilter = "ArtistName = '" & StrArtistName & "'"


        'sort filtered view


    End Sub


End Class

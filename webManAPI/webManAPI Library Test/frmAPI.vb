Imports System.Reflection
Imports Sc.webManAPI

Public Class frmAPI

    Dim psAPI As webMan
    Dim timerTemp As New Timer()

    Private ImageListItem As ImageList
    Private CancelImageLoad As Boolean = False
    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        psAPI = New webMan(txtAddress.Text)

        timerTemp.Start()
        Dim PSitm As List(Of PS3GameItem)
        tsslStatus.Text = "Loading game list..."
        ImageListItem = New ImageList()
        ImageListItem.ColorDepth = ColorDepth.Depth32Bit
        ImageListItem.ImageSize = New Size(128, 128)
        PSitm = Await psAPI.GetGamesAsync()
        lvGames.Items.Clear()

        Dim tb = DirectCast(My.Resources.icon_wm_psx.GetThumbnailImage(128, 128, Nothing, IntPtr.Zero), Bitmap)
        ImageListItem.Images.Add(Icon.FromHandle(tb.GetHicon))

        lvGames.LargeImageList = ImageListItem
        For Each itm As PS3GameItem In PSitm
            Dim lvi As New ListViewItem
            lvi.ImageIndex = 0
            lvi.Text = itm.desc
            lvi.SubItems.Add(itm.url)
            lvi.Tag = itm
            lvGames.Items.Add(lvi)
        Next
        tsslStatus.Text = "Loading cover art..."
        btnStopLoadCovers.Visible = True
        lvGames.Update()
        CancelImageLoad = False

        For Each itm As ListViewItem In lvGames.Items
            If CancelImageLoad Then
                CancelImageLoad = False
                Exit For
            End If

            Dim D As PS3GameItem = DirectCast(itm.Tag, PS3GameItem)

            Try
                Dim ic As Icon = Await DownloadImageToIcon.GetIcon("http://" & txtAddress.Text & D.img, New Size(128, 128))
                If ic IsNot Nothing Then ImageListItem.Images.Add(ic)
                itm.ImageIndex = ImageListItem.Images.Count - 1
            Catch ex As Exception
                itm.ImageIndex = 0
            End Try
            My.Application.DoEvents()
        Next
        btnStopLoadCovers.Visible = False

        lvGames.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        lvGames.Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

        tsslStatus.Text = "Finished"

    End Sub

    Private Sub frmAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timerTemp.Interval = 3000
        AddHandler timerTemp.Tick, AddressOf UpdateTemp
        cmbType.SelectedIndex = 1
    End Sub

    Async Sub UpdateTemp()
        timerTemp.Stop()
        Dim temp = Await psAPI.GetTemperatureExAsync()
        tsslTemp.Text = String.Format("CPU: {0}, RSX: {1}, Fan: {2}%", temp.DegC.CPU, temp.DegC.RSX, temp.FanSpeed)
        timerTemp.Start()
    End Sub

    Async Sub btnMountGame_Click(sender As Object, e As EventArgs) Handles btnMountGame.Click
        Await psAPI.MountGameAsync(DirectCast(lvGames.SelectedItems(0).Tag, PS3GameItem), chkLaunch.Checked)
    End Sub

    Private Sub btnStopLoadCovers_Click(sender As Object, e As EventArgs) Handles btnStopLoadCovers.Click
        CancelImageLoad = True
    End Sub

    Private Async Sub btnTurnOff_Click(sender As Object, e As EventArgs) Handles btnTurnOff.Click
        Await psAPI.ShutdownAsync
    End Sub

    Private Async Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        Await psAPI.RestartAsync
    End Sub

    Private Sub cmbType_TextChanged(sender As Object, e As EventArgs) Handles cmbType.TextChanged
        Select Case cmbType.SelectedIndex
            Case 0
                lvGames.View = View.Details

            Case 1
                lvGames.View = View.LargeIcon

        End Select
    End Sub

    Private Async Sub btnUnmount_Click(sender As Object, e As EventArgs) Handles btnUnmount.Click
        Await psAPI.UnmountGameAsync
    End Sub
End Class

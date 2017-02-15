<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAPI))
        Me.lvGames = New System.Windows.Forms.ListView()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnMountGame = New System.Windows.Forms.Button()
        Me.chkLaunch = New System.Windows.Forms.CheckBox()
        Me.ssSystem = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslTemp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnStopLoadCovers = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTurnOff = New System.Windows.Forms.Button()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.btnUnmount = New System.Windows.Forms.Button()
        Me.ssSystem.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvGames
        '
        Me.lvGames.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chURL})
        Me.lvGames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvGames.FullRowSelect = True
        Me.lvGames.LargeImageList = Me.ImageList1
        Me.lvGames.Location = New System.Drawing.Point(3, 61)
        Me.lvGames.Name = "lvGames"
        Me.lvGames.Size = New System.Drawing.Size(566, 301)
        Me.lvGames.TabIndex = 0
        Me.lvGames.UseCompatibleStateImageBehavior = False
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 93
        '
        'chURL
        '
        Me.chURL.Text = "Location"
        Me.chURL.Width = 90
        '
        'lblAddress
        '
        Me.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(3, 8)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblAddress.TabIndex = 1
        Me.lblAddress.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAddress.Location = New System.Drawing.Point(54, 4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(127, 20)
        Me.txtAddress.TabIndex = 2
        Me.txtAddress.Text = "192.168.1.111"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(187, 3)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnMountGame
        '
        Me.btnMountGame.Location = New System.Drawing.Point(3, 3)
        Me.btnMountGame.Name = "btnMountGame"
        Me.btnMountGame.Size = New System.Drawing.Size(75, 23)
        Me.btnMountGame.TabIndex = 4
        Me.btnMountGame.Text = "Mount"
        Me.btnMountGame.UseVisualStyleBackColor = True
        '
        'chkLaunch
        '
        Me.chkLaunch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkLaunch.AutoSize = True
        Me.chkLaunch.Location = New System.Drawing.Point(84, 6)
        Me.chkLaunch.Name = "chkLaunch"
        Me.chkLaunch.Size = New System.Drawing.Size(134, 17)
        Me.chkLaunch.TabIndex = 5
        Me.chkLaunch.Text = "Also Launch the Game"
        Me.chkLaunch.UseVisualStyleBackColor = True
        '
        'ssSystem
        '
        Me.ssSystem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.tsslTemp})
        Me.ssSystem.Location = New System.Drawing.Point(0, 394)
        Me.ssSystem.Name = "ssSystem"
        Me.ssSystem.Size = New System.Drawing.Size(572, 22)
        Me.ssSystem.TabIndex = 6
        '
        'tsslStatus
        '
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(557, 17)
        Me.tsslStatus.Spring = True
        Me.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsslTemp
        '
        Me.tsslTemp.Name = "tsslTemp"
        Me.tsslTemp.Size = New System.Drawing.Size(0, 17)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lvGames, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(572, 394)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.btnMountGame, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.chkLaunch, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnUnmount, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 365)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(302, 29)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.btnConnect, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtAddress, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblAddress, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnStopLoadCovers, 3, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(391, 29)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icon-iphone-retina.png")
        '
        'btnStopLoadCovers
        '
        Me.btnStopLoadCovers.Location = New System.Drawing.Point(268, 3)
        Me.btnStopLoadCovers.Name = "btnStopLoadCovers"
        Me.btnStopLoadCovers.Size = New System.Drawing.Size(120, 23)
        Me.btnStopLoadCovers.TabIndex = 4
        Me.btnStopLoadCovers.Text = "Stop Loading Covers"
        Me.btnStopLoadCovers.UseVisualStyleBackColor = True
        Me.btnStopLoadCovers.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.btnTurnOff, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnRestart, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbType, 2, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 29)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(289, 29)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'btnTurnOff
        '
        Me.btnTurnOff.Location = New System.Drawing.Point(3, 3)
        Me.btnTurnOff.Name = "btnTurnOff"
        Me.btnTurnOff.Size = New System.Drawing.Size(75, 23)
        Me.btnTurnOff.TabIndex = 0
        Me.btnTurnOff.Text = "Turn Off"
        Me.btnTurnOff.UseVisualStyleBackColor = True
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(84, 3)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(75, 23)
        Me.btnRestart.TabIndex = 1
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'cmbType
        '
        Me.cmbType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Detail View", "Cover View"})
        Me.cmbType.Location = New System.Drawing.Point(165, 4)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(121, 21)
        Me.cmbType.TabIndex = 2
        '
        'btnUnmount
        '
        Me.btnUnmount.Location = New System.Drawing.Point(224, 3)
        Me.btnUnmount.Name = "btnUnmount"
        Me.btnUnmount.Size = New System.Drawing.Size(75, 23)
        Me.btnUnmount.TabIndex = 6
        Me.btnUnmount.Text = "Unmount"
        Me.btnUnmount.UseVisualStyleBackColor = True
        '
        'frmAPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 416)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ssSystem)
        Me.Name = "frmAPI"
        Me.Text = "webMan API Test"
        Me.ssSystem.ResumeLayout(False)
        Me.ssSystem.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvGames As ListView
    Friend WithEvents chName As ColumnHeader
    Friend WithEvents chURL As ColumnHeader
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnMountGame As Button
    Friend WithEvents chkLaunch As CheckBox
    Friend WithEvents ssSystem As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents tsslTemp As ToolStripStatusLabel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnStopLoadCovers As Button
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents btnTurnOff As Button
    Friend WithEvents btnRestart As Button
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents btnUnmount As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_fixit
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_fixit))
        Me.btn_fixit = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txbox_filename = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btn_dlg_open_file = New System.Windows.Forms.Button()
        Me.btn_dlg_open_crc = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btn_about = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Finder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Srrdb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Fixer = New System.Windows.Forms.ToolStripButton()
        Me.btn_cleanmorgdir = New System.Windows.Forms.Button()
        Me.btn_patchposition = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_trknum = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Lists = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_fixit
        '
        Me.btn_fixit.Location = New System.Drawing.Point(456, 60)
        Me.btn_fixit.Name = "btn_fixit"
        Me.btn_fixit.Size = New System.Drawing.Size(75, 23)
        Me.btn_fixit.TabIndex = 0
        Me.btn_fixit.Text = "Try to fix it !"
        Me.btn_fixit.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File"
        '
        'txbox_filename
        '
        Me.txbox_filename.Location = New System.Drawing.Point(77, 28)
        Me.txbox_filename.Name = "txbox_filename"
        Me.txbox_filename.Size = New System.Drawing.Size(454, 20)
        Me.txbox_filename.TabIndex = 2
        Me.txbox_filename.Text = "C:\Users\Home\MP3s\Artist-Album-Year-GRP\01-Intro.mp3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CRC"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(77, 62)
        Me.TextBox2.MaxLength = 8
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "12345678"
        '
        'btn_dlg_open_file
        '
        Me.btn_dlg_open_file.Location = New System.Drawing.Point(9, 28)
        Me.btn_dlg_open_file.Name = "btn_dlg_open_file"
        Me.btn_dlg_open_file.Size = New System.Drawing.Size(24, 19)
        Me.btn_dlg_open_file.TabIndex = 5
        Me.btn_dlg_open_file.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btn_dlg_open_file, "Open *.mp3 File" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Format: 01-.......mp3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.btn_dlg_open_file.UseVisualStyleBackColor = True
        '
        'btn_dlg_open_crc
        '
        Me.btn_dlg_open_crc.Enabled = False
        Me.btn_dlg_open_crc.Location = New System.Drawing.Point(9, 62)
        Me.btn_dlg_open_crc.Name = "btn_dlg_open_crc"
        Me.btn_dlg_open_crc.Size = New System.Drawing.Size(24, 19)
        Me.btn_dlg_open_crc.TabIndex = 7
        Me.btn_dlg_open_crc.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btn_dlg_open_crc, "Read from *.sfv")
        Me.btn_dlg_open_crc.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(152, 64)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(102, 17)
        Me.CheckBox1.TabIndex = 10
        Me.CheckBox1.Text = "00->20 in ID3v1"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, "If checked, iterates through all 0x00 in the ID3v1 Tag and tries again with 0x20" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attention, takes some time...")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btn_about
        '
        Me.btn_about.Location = New System.Drawing.Point(374, 60)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(67, 23)
        Me.btn_about.TabIndex = 8
        Me.btn_about.Text = "About"
        Me.btn_about.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 9
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Finder, Me.ToolStripSeparator1, Me.Lists, Me.ToolStripSeparator3, Me.Srrdb, Me.ToolStripSeparator2, Me.Fixer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(562, 25)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Finder
        '
        Me.Finder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Finder.Image = CType(resources.GetObject("Finder.Image"), System.Drawing.Image)
        Me.Finder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Finder.Name = "Finder"
        Me.Finder.Size = New System.Drawing.Size(82, 22)
        Me.Finder.Text = "Release Finder"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Srrdb
        '
        Me.Srrdb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Srrdb.Image = CType(resources.GetObject("Srrdb.Image"), System.Drawing.Image)
        Me.Srrdb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Srrdb.Name = "Srrdb"
        Me.Srrdb.Size = New System.Drawing.Size(44, 22)
        Me.Srrdb.Text = "SRRDB"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Fixer
        '
        Me.Fixer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Fixer.Image = CType(resources.GetObject("Fixer.Image"), System.Drawing.Image)
        Me.Fixer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Fixer.Name = "Fixer"
        Me.Fixer.Size = New System.Drawing.Size(58, 22)
        Me.Fixer.Text = "MP3 Fixer"
        '
        'btn_cleanmorgdir
        '
        Me.btn_cleanmorgdir.Location = New System.Drawing.Point(46, 76)
        Me.btn_cleanmorgdir.Name = "btn_cleanmorgdir"
        Me.btn_cleanmorgdir.Size = New System.Drawing.Size(139, 23)
        Me.btn_cleanmorgdir.TabIndex = 26
        Me.btn_cleanmorgdir.Text = "Patch!"
        Me.btn_cleanmorgdir.UseVisualStyleBackColor = True
        '
        'btn_patchposition
        '
        Me.btn_patchposition.Location = New System.Drawing.Point(36, 77)
        Me.btn_patchposition.Name = "btn_patchposition"
        Me.btn_patchposition.Size = New System.Drawing.Size(125, 23)
        Me.btn_patchposition.TabIndex = 27
        Me.btn_patchposition.Text = "Patch !"
        Me.btn_patchposition.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(31, 20)
        Me.TextBox1.TabIndex = 28
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(173, 28)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(31, 20)
        Me.TextBox3.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Position"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Value of new Byte"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_patchposition)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 106)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Edit 1 Byte at the same position in all files"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb_trknum)
        Me.GroupBox2.Controls.Add(Me.btn_cleanmorgdir)
        Me.GroupBox2.Location = New System.Drawing.Point(324, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(225, 105)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Remove *.mp3s from Morgoths Vaccinator "
        '
        'cb_trknum
        '
        Me.cb_trknum.AutoSize = True
        Me.cb_trknum.Location = New System.Drawing.Point(46, 49)
        Me.cb_trknum.Name = "cb_trknum"
        Me.cb_trknum.Size = New System.Drawing.Size(139, 17)
        Me.cb_trknum.TabIndex = 27
        Me.cb_trknum.Text = "Tracknumber (ID3 v1.1)"
        Me.cb_trknum.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txbox_filename)
        Me.GroupBox3.Controls.Add(Me.btn_fixit)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btn_about)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.btn_dlg_open_crc)
        Me.GroupBox3.Controls.Add(Me.btn_dlg_open_file)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 35)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(537, 92)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Single *.mp3 Heuristic Fixxer"
        '
        'Lists
        '
        Me.Lists.Name = "Lists"
        Me.Lists.Size = New System.Drawing.Size(69, 22)
        Me.Lists.Text = "Release Lists"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'frm_fixit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 262)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_fixit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MP3 Toolkit v0.04 - Fixer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_fixit As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents txbox_filename As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents btn_dlg_open_file As Button
    Friend WithEvents btn_dlg_open_crc As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btn_about As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Finder As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Srrdb As ToolStripButton
    Friend WithEvents Fixer As ToolStripButton
    Friend WithEvents btn_cleanmorgdir As Button
    Friend WithEvents btn_patchposition As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cb_trknum As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Lists As ToolStripLabel
End Class

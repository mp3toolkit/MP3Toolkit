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
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_fixit
        '
        Me.btn_fixit.Location = New System.Drawing.Point(472, 75)
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
        Me.Label1.Location = New System.Drawing.Point(39, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File"
        '
        'txbox_filename
        '
        Me.txbox_filename.Location = New System.Drawing.Point(74, 43)
        Me.txbox_filename.Name = "txbox_filename"
        Me.txbox_filename.Size = New System.Drawing.Size(473, 20)
        Me.txbox_filename.TabIndex = 2
        Me.txbox_filename.Text = "C:\Users\Home\MP3s\Artist-Album-Year-GRP\01-Intro.mp3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CRC"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(74, 77)
        Me.TextBox2.MaxLength = 8
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "12345678"
        '
        'btn_dlg_open_file
        '
        Me.btn_dlg_open_file.Location = New System.Drawing.Point(6, 43)
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
        Me.btn_dlg_open_crc.Location = New System.Drawing.Point(6, 77)
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
        Me.CheckBox1.Location = New System.Drawing.Point(149, 79)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(102, 17)
        Me.CheckBox1.TabIndex = 10
        Me.CheckBox1.Text = "00->20 in ID3v1"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, "If checked, iterates through all 0x00 in the ID3v1 Tag and tries again with 0x20" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attention, takes some time...")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btn_about
        '
        Me.btn_about.Location = New System.Drawing.Point(399, 75)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(67, 23)
        Me.btn_about.TabIndex = 8
        Me.btn_about.Text = "About"
        Me.btn_about.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(396, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 9
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Finder, Me.ToolStripSeparator1, Me.Srrdb, Me.ToolStripSeparator2, Me.Fixer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(559, 25)
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
        'frm_fixit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 142)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_about)
        Me.Controls.Add(Me.btn_dlg_open_crc)
        Me.Controls.Add(Me.btn_dlg_open_file)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbox_filename)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_fixit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_fixit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MP3 Toolkit v0.03 - Fixer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
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
End Class

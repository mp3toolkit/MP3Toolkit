<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Finder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Finder))
        Me.btn_find_renames = New System.Windows.Forms.Button()
        Me.btn_mis_nfo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btn_mis_sfv = New System.Windows.Forms.Button()
        Me.btn_mis_m3u = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_result_dir = New System.Windows.Forms.Button()
        Me.mp3_root_dir = New System.Windows.Forms.TextBox()
        Me.btn_mp3_root_dir = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Finder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Srrdb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Fixer = New System.Windows.Forms.ToolStripButton()
        Me.btn_2x_nfo = New System.Windows.Forms.Button()
        Me.btn_2x_sfv = New System.Windows.Forms.Button()
        Me.btn_2x_m3u = New System.Windows.Forms.Button()
        Me.info_listbox = New System.Windows.Forms.Label()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_find_renames
        '
        Me.btn_find_renames.Location = New System.Drawing.Point(15, 342)
        Me.btn_find_renames.Name = "btn_find_renames"
        Me.btn_find_renames.Size = New System.Drawing.Size(206, 37)
        Me.btn_find_renames.TabIndex = 23
        Me.btn_find_renames.Text = "Find ""renamed"" releases"
        Me.btn_find_renames.UseVisualStyleBackColor = True
        '
        'btn_mis_nfo
        '
        Me.btn_mis_nfo.Location = New System.Drawing.Point(15, 284)
        Me.btn_mis_nfo.Name = "btn_mis_nfo"
        Me.btn_mis_nfo.Size = New System.Drawing.Size(206, 37)
        Me.btn_mis_nfo.TabIndex = 22
        Me.btn_mis_nfo.Text = "Find missing *.nfo"
        Me.btn_mis_nfo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Results:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(245, 121)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(986, 20)
        Me.TextBox2.TabIndex = 20
        '
        'btn_mis_sfv
        '
        Me.btn_mis_sfv.Location = New System.Drawing.Point(15, 226)
        Me.btn_mis_sfv.Name = "btn_mis_sfv"
        Me.btn_mis_sfv.Size = New System.Drawing.Size(206, 37)
        Me.btn_mis_sfv.TabIndex = 19
        Me.btn_mis_sfv.Text = "Find missing *.sfv"
        Me.btn_mis_sfv.UseVisualStyleBackColor = True
        '
        'btn_mis_m3u
        '
        Me.btn_mis_m3u.Location = New System.Drawing.Point(15, 167)
        Me.btn_mis_m3u.Name = "btn_mis_m3u"
        Me.btn_mis_m3u.Size = New System.Drawing.Size(206, 37)
        Me.btn_mis_m3u.TabIndex = 18
        Me.btn_mis_m3u.Text = "Find missing *.m3u"
        Me.btn_mis_m3u.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(247, 193)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(984, 355)
        Me.ListBox1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(244, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "MP3 Root Dir:"
        '
        'btn_result_dir
        '
        Me.btn_result_dir.Location = New System.Drawing.Point(15, 105)
        Me.btn_result_dir.Name = "btn_result_dir"
        Me.btn_result_dir.Size = New System.Drawing.Size(206, 37)
        Me.btn_result_dir.TabIndex = 15
        Me.btn_result_dir.Text = "Select Results Folder"
        Me.btn_result_dir.UseVisualStyleBackColor = True
        '
        'mp3_root_dir
        '
        Me.mp3_root_dir.Location = New System.Drawing.Point(245, 58)
        Me.mp3_root_dir.Name = "mp3_root_dir"
        Me.mp3_root_dir.ReadOnly = True
        Me.mp3_root_dir.Size = New System.Drawing.Size(986, 20)
        Me.mp3_root_dir.TabIndex = 14
        '
        'btn_mp3_root_dir
        '
        Me.btn_mp3_root_dir.Location = New System.Drawing.Point(15, 42)
        Me.btn_mp3_root_dir.Name = "btn_mp3_root_dir"
        Me.btn_mp3_root_dir.Size = New System.Drawing.Size(206, 37)
        Me.btn_mp3_root_dir.TabIndex = 13
        Me.btn_mp3_root_dir.Text = "Select MP3 Root Folder"
        Me.btn_mp3_root_dir.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(217, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem1.Text = "Get Details on srrdb.com"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem2.Text = "Open Dir in Windows Explorer"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Finder, Me.ToolStripSeparator1, Me.Srrdb, Me.ToolStripSeparator2, Me.Fixer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1254, 25)
        Me.ToolStrip1.TabIndex = 26
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
        'btn_2x_nfo
        '
        Me.btn_2x_nfo.Location = New System.Drawing.Point(15, 400)
        Me.btn_2x_nfo.Name = "btn_2x_nfo"
        Me.btn_2x_nfo.Size = New System.Drawing.Size(206, 37)
        Me.btn_2x_nfo.TabIndex = 27
        Me.btn_2x_nfo.Text = "Find multiple *.nfo"
        Me.btn_2x_nfo.UseVisualStyleBackColor = True
        '
        'btn_2x_sfv
        '
        Me.btn_2x_sfv.Location = New System.Drawing.Point(15, 458)
        Me.btn_2x_sfv.Name = "btn_2x_sfv"
        Me.btn_2x_sfv.Size = New System.Drawing.Size(206, 37)
        Me.btn_2x_sfv.TabIndex = 28
        Me.btn_2x_sfv.Text = "Find multiple *.sfv"
        Me.btn_2x_sfv.UseVisualStyleBackColor = True
        '
        'btn_2x_m3u
        '
        Me.btn_2x_m3u.Location = New System.Drawing.Point(12, 518)
        Me.btn_2x_m3u.Name = "btn_2x_m3u"
        Me.btn_2x_m3u.Size = New System.Drawing.Size(206, 37)
        Me.btn_2x_m3u.TabIndex = 29
        Me.btn_2x_m3u.Text = "Find multiple *.m3u"
        Me.btn_2x_m3u.UseVisualStyleBackColor = True
        '
        'info_listbox
        '
        Me.info_listbox.AutoSize = True
        Me.info_listbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_listbox.Location = New System.Drawing.Point(244, 167)
        Me.info_listbox.Name = "info_listbox"
        Me.info_listbox.Size = New System.Drawing.Size(47, 13)
        Me.info_listbox.TabIndex = 30
        Me.info_listbox.Text = "Status:"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem3.Text = "Send to RekSFV"
        '
        'frm_Finder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 567)
        Me.Controls.Add(Me.info_listbox)
        Me.Controls.Add(Me.btn_2x_m3u)
        Me.Controls.Add(Me.btn_2x_sfv)
        Me.Controls.Add(Me.btn_2x_nfo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btn_find_renames)
        Me.Controls.Add(Me.btn_mis_nfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.btn_mis_sfv)
        Me.Controls.Add(Me.btn_mis_m3u)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_result_dir)
        Me.Controls.Add(Me.mp3_root_dir)
        Me.Controls.Add(Me.btn_mp3_root_dir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Finder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MP3 Toolkit v0.03 - Finder"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_find_renames As Button
    Friend WithEvents btn_mis_nfo As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents btn_mis_sfv As Button
    Friend WithEvents btn_mis_m3u As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_result_dir As Button
    Friend WithEvents mp3_root_dir As TextBox
    Friend WithEvents btn_mp3_root_dir As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Finder As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Srrdb As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Fixer As ToolStripButton
    Friend WithEvents btn_2x_nfo As Button
    Friend WithEvents btn_2x_sfv As Button
    Friend WithEvents btn_2x_m3u As Button
    Friend WithEvents info_listbox As Label
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class

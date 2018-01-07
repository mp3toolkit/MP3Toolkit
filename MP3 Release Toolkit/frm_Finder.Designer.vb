<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Finder
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Finder))
        Me.btn_find_renames = New System.Windows.Forms.Button()
        Me.btn_mis_nfo = New System.Windows.Forms.Button()
        Me.btn_mis_sfv = New System.Windows.Forms.Button()
        Me.btn_mis_m3u = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btn_result_dir = New System.Windows.Forms.Button()
        Me.btn_mp3_root_dir = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Finder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Lists = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Srrdb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Fixer = New System.Windows.Forms.ToolStripButton()
        Me.btn_2x_nfo = New System.Windows.Forms.Button()
        Me.btn_2x_sfv = New System.Windows.Forms.Button()
        Me.btn_2x_m3u = New System.Windows.Forms.Button()
        Me.info_listbox = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_ftpdfiles = New System.Windows.Forms.Button()
        Me.btn_sysjpg = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.workdir = New System.Windows.Forms.TextBox()
        Me.mp3_root_dir = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_find_renames
        '
        Me.btn_find_renames.Location = New System.Drawing.Point(25, 80)
        Me.btn_find_renames.Name = "btn_find_renames"
        Me.btn_find_renames.Size = New System.Drawing.Size(158, 22)
        Me.btn_find_renames.TabIndex = 23
        Me.btn_find_renames.Text = "Find ""renamed"" releases"
        Me.btn_find_renames.UseVisualStyleBackColor = True
        '
        'btn_mis_nfo
        '
        Me.btn_mis_nfo.Location = New System.Drawing.Point(25, 81)
        Me.btn_mis_nfo.Name = "btn_mis_nfo"
        Me.btn_mis_nfo.Size = New System.Drawing.Size(158, 22)
        Me.btn_mis_nfo.TabIndex = 22
        Me.btn_mis_nfo.Text = "Find missing *.nfo"
        Me.btn_mis_nfo.UseVisualStyleBackColor = True
        '
        'btn_mis_sfv
        '
        Me.btn_mis_sfv.Location = New System.Drawing.Point(25, 52)
        Me.btn_mis_sfv.Name = "btn_mis_sfv"
        Me.btn_mis_sfv.Size = New System.Drawing.Size(158, 23)
        Me.btn_mis_sfv.TabIndex = 19
        Me.btn_mis_sfv.Text = "Find missing *.sfv"
        Me.btn_mis_sfv.UseVisualStyleBackColor = True
        '
        'btn_mis_m3u
        '
        Me.btn_mis_m3u.Location = New System.Drawing.Point(25, 24)
        Me.btn_mis_m3u.Name = "btn_mis_m3u"
        Me.btn_mis_m3u.Size = New System.Drawing.Size(158, 22)
        Me.btn_mis_m3u.TabIndex = 18
        Me.btn_mis_m3u.Text = "Find missing *.m3u"
        Me.btn_mis_m3u.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(245, 163)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(984, 355)
        Me.ListBox1.TabIndex = 17
        '
        'btn_result_dir
        '
        Me.btn_result_dir.Location = New System.Drawing.Point(18, 50)
        Me.btn_result_dir.Name = "btn_result_dir"
        Me.btn_result_dir.Size = New System.Drawing.Size(158, 22)
        Me.btn_result_dir.TabIndex = 15
        Me.btn_result_dir.Text = "Select Results Folder"
        Me.btn_result_dir.UseVisualStyleBackColor = True
        '
        'btn_mp3_root_dir
        '
        Me.btn_mp3_root_dir.Location = New System.Drawing.Point(18, 19)
        Me.btn_mp3_root_dir.Name = "btn_mp3_root_dir"
        Me.btn_mp3_root_dir.Size = New System.Drawing.Size(158, 22)
        Me.btn_mp3_root_dir.TabIndex = 13
        Me.btn_mp3_root_dir.Text = "Select MP3 Root Folder"
        Me.btn_mp3_root_dir.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(217, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Enabled = False
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem1.Text = "Get Details on srrdb.com"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem2.Text = "Open Dir in Windows Explorer"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Enabled = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem3.Text = "Send to RekSFV"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Enabled = False
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem4.Text = "Delete File directly"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Finder, Me.ToolStripSeparator1, Me.Lists, Me.ToolStripSeparator3, Me.Srrdb, Me.ToolStripSeparator2, Me.Fixer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1238, 25)
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
        'Lists
        '
        Me.Lists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Lists.Image = CType(resources.GetObject("Lists.Image"), System.Drawing.Image)
        Me.Lists.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Lists.Name = "Lists"
        Me.Lists.Size = New System.Drawing.Size(73, 22)
        Me.Lists.Text = "Release Lists"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        Me.btn_2x_nfo.Location = New System.Drawing.Point(25, 24)
        Me.btn_2x_nfo.Name = "btn_2x_nfo"
        Me.btn_2x_nfo.Size = New System.Drawing.Size(158, 22)
        Me.btn_2x_nfo.TabIndex = 27
        Me.btn_2x_nfo.Text = "Find multiple *.nfo"
        Me.btn_2x_nfo.UseVisualStyleBackColor = True
        '
        'btn_2x_sfv
        '
        Me.btn_2x_sfv.Location = New System.Drawing.Point(25, 52)
        Me.btn_2x_sfv.Name = "btn_2x_sfv"
        Me.btn_2x_sfv.Size = New System.Drawing.Size(158, 22)
        Me.btn_2x_sfv.TabIndex = 28
        Me.btn_2x_sfv.Text = "Find multiple *.sfv"
        Me.btn_2x_sfv.UseVisualStyleBackColor = True
        '
        'btn_2x_m3u
        '
        Me.btn_2x_m3u.Location = New System.Drawing.Point(25, 80)
        Me.btn_2x_m3u.Name = "btn_2x_m3u"
        Me.btn_2x_m3u.Size = New System.Drawing.Size(158, 22)
        Me.btn_2x_m3u.TabIndex = 29
        Me.btn_2x_m3u.Text = "Find multiple *.m3u"
        Me.btn_2x_m3u.UseVisualStyleBackColor = True
        '
        'info_listbox
        '
        Me.info_listbox.AutoSize = True
        Me.info_listbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_listbox.Location = New System.Drawing.Point(244, 143)
        Me.info_listbox.Name = "info_listbox"
        Me.info_listbox.Size = New System.Drawing.Size(47, 13)
        Me.info_listbox.TabIndex = 30
        Me.info_listbox.Text = "Status:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_2x_nfo)
        Me.GroupBox1.Controls.Add(Me.btn_2x_sfv)
        Me.GroupBox1.Controls.Add(Me.btn_2x_m3u)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 114)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Find Duplicates"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_mis_m3u)
        Me.GroupBox2.Controls.Add(Me.btn_mis_sfv)
        Me.GroupBox2.Controls.Add(Me.btn_mis_nfo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 281)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 114)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Find missing files"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_ftpdfiles)
        Me.GroupBox3.Controls.Add(Me.btn_sysjpg)
        Me.GroupBox3.Controls.Add(Me.btn_find_renames)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 404)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(206, 114)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Miscellaneous"
        '
        'btn_ftpdfiles
        '
        Me.btn_ftpdfiles.Enabled = False
        Me.btn_ftpdfiles.Location = New System.Drawing.Point(25, 52)
        Me.btn_ftpdfiles.Name = "btn_ftpdfiles"
        Me.btn_ftpdfiles.Size = New System.Drawing.Size(158, 22)
        Me.btn_ftpdfiles.TabIndex = 24
        Me.btn_ftpdfiles.Text = "Find FTPd files"
        Me.btn_ftpdfiles.UseVisualStyleBackColor = True
        '
        'btn_sysjpg
        '
        Me.btn_sysjpg.Location = New System.Drawing.Point(25, 24)
        Me.btn_sysjpg.Name = "btn_sysjpg"
        Me.btn_sysjpg.Size = New System.Drawing.Size(158, 22)
        Me.btn_sysjpg.TabIndex = 18
        Me.btn_sysjpg.Text = "Find system *.jpgs"
        Me.btn_sysjpg.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_mp3_root_dir)
        Me.GroupBox4.Controls.Add(Me.btn_result_dir)
        Me.GroupBox4.Location = New System.Drawing.Point(19, 32)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(198, 87)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Directories (Global Setting)"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.workdir)
        Me.GroupBox5.Controls.Add(Me.mp3_root_dir)
        Me.GroupBox5.Location = New System.Drawing.Point(240, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(988, 87)
        Me.GroupBox5.TabIndex = 35
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Select Path on the left"
        '
        'workdir
        '
        Me.workdir.Location = New System.Drawing.Point(7, 52)
        Me.workdir.Name = "workdir"
        Me.workdir.ReadOnly = True
        Me.workdir.Size = New System.Drawing.Size(975, 20)
        Me.workdir.TabIndex = 24
        '
        'mp3_root_dir
        '
        Me.mp3_root_dir.Location = New System.Drawing.Point(7, 19)
        Me.mp3_root_dir.Name = "mp3_root_dir"
        Me.mp3_root_dir.ReadOnly = True
        Me.mp3_root_dir.Size = New System.Drawing.Size(975, 20)
        Me.mp3_root_dir.TabIndex = 22
        '
        'frm_Finder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 527)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.info_listbox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Finder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MP3 Toolkit v0.06 - Finder"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_find_renames As Button
    Friend WithEvents btn_mis_nfo As Button
    Friend WithEvents btn_mis_sfv As Button
    Friend WithEvents btn_mis_m3u As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btn_result_dir As Button
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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn_sysjpg As Button
    Friend WithEvents btn_ftpdfiles As Button
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Lists As ToolStripButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents workdir As TextBox
    Friend WithEvents mp3_root_dir As TextBox
End Class

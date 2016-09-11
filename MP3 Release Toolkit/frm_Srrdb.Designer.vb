<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Srrdb
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
        Dim btn_fixit As System.Windows.Forms.Button
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Srrdb))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btn_loadfolderlist = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Finder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Srrdb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Fixer = New System.Windows.Forms.ToolStripButton()
        Me.cb_Logwget = New System.Windows.Forms.CheckBox()
        Me.cb_logretag = New System.Windows.Forms.CheckBox()
        btn_fixit = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_fixit
        '
        btn_fixit.Location = New System.Drawing.Point(444, 66)
        btn_fixit.Name = "btn_fixit"
        btn_fixit.Size = New System.Drawing.Size(121, 32)
        btn_fixit.TabIndex = 27
        btn_fixit.Text = "Get srrs and fix them !"
        btn_fixit.UseVisualStyleBackColor = True
        AddHandler btn_fixit.Click, AddressOf Me.btn_fixit_Click
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 28)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(417, 719)
        Me.ListBox1.TabIndex = 1
        '
        'btn_loadfolderlist
        '
        Me.btn_loadfolderlist.Location = New System.Drawing.Point(444, 28)
        Me.btn_loadfolderlist.Name = "btn_loadfolderlist"
        Me.btn_loadfolderlist.Size = New System.Drawing.Size(121, 32)
        Me.btn_loadfolderlist.TabIndex = 2
        Me.btn_loadfolderlist.Text = "Load Folderlist"
        Me.btn_loadfolderlist.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Finder, Me.ToolStripSeparator1, Me.Srrdb, Me.ToolStripSeparator2, Me.Fixer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(577, 25)
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
        'cb_Logwget
        '
        Me.cb_Logwget.AutoSize = True
        Me.cb_Logwget.Location = New System.Drawing.Point(444, 123)
        Me.cb_Logwget.Name = "cb_Logwget"
        Me.cb_Logwget.Size = New System.Drawing.Size(80, 17)
        Me.cb_Logwget.TabIndex = 28
        Me.cb_Logwget.Text = "Log WGET"
        Me.cb_Logwget.UseVisualStyleBackColor = True
        '
        'cb_logretag
        '
        Me.cb_logretag.AutoSize = True
        Me.cb_logretag.Location = New System.Drawing.Point(444, 146)
        Me.cb_logretag.Name = "cb_logretag"
        Me.cb_logretag.Size = New System.Drawing.Size(80, 17)
        Me.cb_logretag.TabIndex = 29
        Me.cb_logretag.Text = "Log ReTag"
        Me.cb_logretag.UseVisualStyleBackColor = True
        '
        'frm_Srrdb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 769)
        Me.Controls.Add(Me.cb_logretag)
        Me.Controls.Add(Me.cb_Logwget)
        Me.Controls.Add(btn_fixit)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btn_loadfolderlist)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Srrdb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MP3 Toolkit v0.03 - SRRDB"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btn_loadfolderlist As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Finder As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Srrdb As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Fixer As ToolStripButton
    Friend WithEvents cb_Logwget As CheckBox
    Friend WithEvents cb_logretag As CheckBox
End Class

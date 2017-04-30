<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_lists
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_lists))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Finder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Lists = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Srrdb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Fixer = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_compare = New System.Windows.Forms.Button()
        Me.btn_loadlist1 = New System.Windows.Forms.Button()
        Me.btn_load_list2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_2to1 = New System.Windows.Forms.CheckBox()
        Me.cb_1to2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_createlist = New System.Windows.Forms.Button()
        Me.txt_resultpath = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Finder, Me.ToolStripSeparator1, Me.Lists, Me.ToolStripSeparator3, Me.Srrdb, Me.ToolStripSeparator2, Me.Fixer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1244, 25)
        Me.ToolStrip1.TabIndex = 27
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_compare)
        Me.GroupBox4.Controls.Add(Me.btn_loadlist1)
        Me.GroupBox4.Controls.Add(Me.btn_load_list2)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(198, 121)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Compare"
        '
        'btn_compare
        '
        Me.btn_compare.Location = New System.Drawing.Point(18, 82)
        Me.btn_compare.Name = "btn_compare"
        Me.btn_compare.Size = New System.Drawing.Size(158, 22)
        Me.btn_compare.TabIndex = 16
        Me.btn_compare.Text = "Compare them !"
        Me.btn_compare.UseVisualStyleBackColor = True
        '
        'btn_loadlist1
        '
        Me.btn_loadlist1.Location = New System.Drawing.Point(18, 26)
        Me.btn_loadlist1.Name = "btn_loadlist1"
        Me.btn_loadlist1.Size = New System.Drawing.Size(158, 22)
        Me.btn_loadlist1.TabIndex = 13
        Me.btn_loadlist1.Text = "Load List 1"
        Me.btn_loadlist1.UseVisualStyleBackColor = True
        '
        'btn_load_list2
        '
        Me.btn_load_list2.Location = New System.Drawing.Point(18, 54)
        Me.btn_load_list2.Name = "btn_load_list2"
        Me.btn_load_list2.Size = New System.Drawing.Size(158, 22)
        Me.btn_load_list2.TabIndex = 15
        Me.btn_load_list2.Text = "Load List 2"
        Me.btn_load_list2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(228, 67)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(500, 355)
        Me.ListBox1.TabIndex = 36
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(734, 66)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(500, 355)
        Me.ListBox2.TabIndex = 37
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(228, 488)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(1006, 264)
        Me.ListBox3.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "List 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(731, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "List 2:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 446)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Results:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(289, 435)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 42
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_2to1)
        Me.GroupBox1.Controls.Add(Me.cb_1to2)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 79)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'cb_2to1
        '
        Me.cb_2to1.AutoSize = True
        Me.cb_2to1.Location = New System.Drawing.Point(17, 49)
        Me.cb_2to1.Name = "cb_2to1"
        Me.cb_2to1.Size = New System.Drawing.Size(146, 17)
        Me.cb_2to1.TabIndex = 1
        Me.cb_2to1.Text = "Compare List 2 with List 1"
        Me.cb_2to1.UseVisualStyleBackColor = True
        '
        'cb_1to2
        '
        Me.cb_1to2.AutoSize = True
        Me.cb_1to2.Location = New System.Drawing.Point(17, 23)
        Me.cb_1to2.Name = "cb_1to2"
        Me.cb_1to2.Size = New System.Drawing.Size(146, 17)
        Me.cb_1to2.TabIndex = 0
        Me.cb_1to2.Text = "Compare List 1 with List 2"
        Me.cb_1to2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.btn_createlist)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 266)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 155)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Create Lists"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 22)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Results Directory"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_createlist
        '
        Me.btn_createlist.Location = New System.Drawing.Point(13, 50)
        Me.btn_createlist.Name = "btn_createlist"
        Me.btn_createlist.Size = New System.Drawing.Size(158, 22)
        Me.btn_createlist.TabIndex = 17
        Me.btn_createlist.Text = "Create List"
        Me.btn_createlist.UseVisualStyleBackColor = True
        '
        'txt_resultpath
        '
        Me.txt_resultpath.BackColor = System.Drawing.SystemColors.Control
        Me.txt_resultpath.Location = New System.Drawing.Point(228, 462)
        Me.txt_resultpath.Name = "txt_resultpath"
        Me.txt_resultpath.Size = New System.Drawing.Size(500, 20)
        Me.txt_resultpath.TabIndex = 45
        Me.txt_resultpath.Text = "Path to Results"
        '
        'frm_lists
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 762)
        Me.Controls.Add(Me.txt_resultpath)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_lists"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MP3 Toolkit v0.05 - Release Lists"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Finder As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Srrdb As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Fixer As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_compare As Button
    Friend WithEvents btn_loadlist1 As Button
    Friend WithEvents btn_load_list2 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cb_2to1 As CheckBox
    Friend WithEvents cb_1to2 As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_createlist As Button
    Friend WithEvents Lists As ToolStripButton
    Friend WithEvents Button1 As Button
    Friend WithEvents txt_resultpath As TextBox
End Class

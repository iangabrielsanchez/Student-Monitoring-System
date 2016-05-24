<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageSections
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.startMon = New System.Windows.Forms.DateTimePicker()
        Me.endMon = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.endTue = New System.Windows.Forms.DateTimePicker()
        Me.startTue = New System.Windows.Forms.DateTimePicker()
        Me.endWed = New System.Windows.Forms.DateTimePicker()
        Me.startWed = New System.Windows.Forms.DateTimePicker()
        Me.endThurs = New System.Windows.Forms.DateTimePicker()
        Me.startThurs = New System.Windows.Forms.DateTimePicker()
        Me.endFri = New System.Windows.Forms.DateTimePicker()
        Me.startFri = New System.Windows.Forms.DateTimePicker()
        Me.endSat = New System.Windows.Forms.DateTimePicker()
        Me.startSat = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbxMon = New System.Windows.Forms.CheckBox()
        Me.cbxTue = New System.Windows.Forms.CheckBox()
        Me.cbxWed = New System.Windows.Forms.CheckBox()
        Me.cbxThurs = New System.Windows.Forms.CheckBox()
        Me.cbxFri = New System.Windows.Forms.CheckBox()
        Me.cbxSat = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 43)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(268, 380)
        Me.DataGridView1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(18, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sections:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(13, 433)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(112, 35)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(169, 433)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(112, 35)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'startMon
        '
        Me.startMon.Enabled = False
        Me.startMon.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.startMon.Location = New System.Drawing.Point(431, 105)
        Me.startMon.Name = "startMon"
        Me.startMon.ShowUpDown = True
        Me.startMon.Size = New System.Drawing.Size(123, 26)
        Me.startMon.TabIndex = 12
        '
        'endMon
        '
        Me.endMon.Enabled = False
        Me.endMon.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.endMon.Location = New System.Drawing.Point(560, 105)
        Me.endMon.Name = "endMon"
        Me.endMon.ShowUpDown = True
        Me.endMon.Size = New System.Drawing.Size(123, 26)
        Me.endMon.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(427, 82)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Start Time:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(556, 82)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "End Time:"
        '
        'endTue
        '
        Me.endTue.Enabled = False
        Me.endTue.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.endTue.Location = New System.Drawing.Point(560, 160)
        Me.endTue.Name = "endTue"
        Me.endTue.ShowUpDown = True
        Me.endTue.Size = New System.Drawing.Size(123, 26)
        Me.endTue.TabIndex = 17
        '
        'startTue
        '
        Me.startTue.Enabled = False
        Me.startTue.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.startTue.Location = New System.Drawing.Point(431, 160)
        Me.startTue.Name = "startTue"
        Me.startTue.ShowUpDown = True
        Me.startTue.Size = New System.Drawing.Size(123, 26)
        Me.startTue.TabIndex = 16
        '
        'endWed
        '
        Me.endWed.Enabled = False
        Me.endWed.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.endWed.Location = New System.Drawing.Point(560, 215)
        Me.endWed.Name = "endWed"
        Me.endWed.ShowUpDown = True
        Me.endWed.Size = New System.Drawing.Size(123, 26)
        Me.endWed.TabIndex = 19
        '
        'startWed
        '
        Me.startWed.Enabled = False
        Me.startWed.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.startWed.Location = New System.Drawing.Point(431, 215)
        Me.startWed.Name = "startWed"
        Me.startWed.ShowUpDown = True
        Me.startWed.Size = New System.Drawing.Size(123, 26)
        Me.startWed.TabIndex = 18
        '
        'endThurs
        '
        Me.endThurs.Enabled = False
        Me.endThurs.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.endThurs.Location = New System.Drawing.Point(560, 270)
        Me.endThurs.Name = "endThurs"
        Me.endThurs.ShowUpDown = True
        Me.endThurs.Size = New System.Drawing.Size(123, 26)
        Me.endThurs.TabIndex = 21
        '
        'startThurs
        '
        Me.startThurs.Enabled = False
        Me.startThurs.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.startThurs.Location = New System.Drawing.Point(431, 270)
        Me.startThurs.Name = "startThurs"
        Me.startThurs.ShowUpDown = True
        Me.startThurs.Size = New System.Drawing.Size(123, 26)
        Me.startThurs.TabIndex = 20
        '
        'endFri
        '
        Me.endFri.Enabled = False
        Me.endFri.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.endFri.Location = New System.Drawing.Point(560, 325)
        Me.endFri.Name = "endFri"
        Me.endFri.ShowUpDown = True
        Me.endFri.Size = New System.Drawing.Size(123, 26)
        Me.endFri.TabIndex = 23
        '
        'startFri
        '
        Me.startFri.Enabled = False
        Me.startFri.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.startFri.Location = New System.Drawing.Point(431, 325)
        Me.startFri.Name = "startFri"
        Me.startFri.ShowUpDown = True
        Me.startFri.Size = New System.Drawing.Size(123, 26)
        Me.startFri.TabIndex = 22
        '
        'endSat
        '
        Me.endSat.Enabled = False
        Me.endSat.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.endSat.Location = New System.Drawing.Point(560, 381)
        Me.endSat.Name = "endSat"
        Me.endSat.ShowUpDown = True
        Me.endSat.Size = New System.Drawing.Size(123, 26)
        Me.endSat.TabIndex = 25
        '
        'startSat
        '
        Me.startSat.Enabled = False
        Me.startSat.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.startSat.Location = New System.Drawing.Point(431, 381)
        Me.startSat.Name = "startSat"
        Me.startSat.ShowUpDown = True
        Me.startSat.Size = New System.Drawing.Size(123, 26)
        Me.startSat.TabIndex = 24
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(607, 433)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 26
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbxMon
        '
        Me.cbxMon.AutoSize = True
        Me.cbxMon.Location = New System.Drawing.Point(309, 109)
        Me.cbxMon.Name = "cbxMon"
        Me.cbxMon.Size = New System.Drawing.Size(88, 24)
        Me.cbxMon.TabIndex = 27
        Me.cbxMon.Text = "Monday:"
        Me.cbxMon.UseVisualStyleBackColor = True
        '
        'cbxTue
        '
        Me.cbxTue.AutoSize = True
        Me.cbxTue.Location = New System.Drawing.Point(309, 164)
        Me.cbxTue.Name = "cbxTue"
        Me.cbxTue.Size = New System.Drawing.Size(92, 24)
        Me.cbxTue.TabIndex = 28
        Me.cbxTue.Text = "Tuesday:"
        Me.cbxTue.UseVisualStyleBackColor = True
        '
        'cbxWed
        '
        Me.cbxWed.AutoSize = True
        Me.cbxWed.Location = New System.Drawing.Point(309, 219)
        Me.cbxWed.Name = "cbxWed"
        Me.cbxWed.Size = New System.Drawing.Size(116, 24)
        Me.cbxWed.TabIndex = 29
        Me.cbxWed.Text = "Wednesday:"
        Me.cbxWed.UseVisualStyleBackColor = True
        '
        'cbxThurs
        '
        Me.cbxThurs.AutoSize = True
        Me.cbxThurs.Location = New System.Drawing.Point(309, 274)
        Me.cbxThurs.Name = "cbxThurs"
        Me.cbxThurs.Size = New System.Drawing.Size(97, 24)
        Me.cbxThurs.TabIndex = 30
        Me.cbxThurs.Text = "Thursday:"
        Me.cbxThurs.UseVisualStyleBackColor = True
        '
        'cbxFri
        '
        Me.cbxFri.AutoSize = True
        Me.cbxFri.Location = New System.Drawing.Point(309, 329)
        Me.cbxFri.Name = "cbxFri"
        Me.cbxFri.Size = New System.Drawing.Size(75, 24)
        Me.cbxFri.TabIndex = 31
        Me.cbxFri.Text = "Friday:"
        Me.cbxFri.UseVisualStyleBackColor = True
        '
        'cbxSat
        '
        Me.cbxSat.AutoSize = True
        Me.cbxSat.Location = New System.Drawing.Point(309, 385)
        Me.cbxSat.Name = "cbxSat"
        Me.cbxSat.Size = New System.Drawing.Size(96, 24)
        Me.cbxSat.TabIndex = 32
        Me.cbxSat.Text = "Saturday:"
        Me.cbxSat.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(358, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Section:"
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(431, 40)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(172, 26)
        Me.txtSection.TabIndex = 34
        '
        'ManageSections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 482)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxSat)
        Me.Controls.Add(Me.cbxFri)
        Me.Controls.Add(Me.cbxThurs)
        Me.Controls.Add(Me.cbxWed)
        Me.Controls.Add(Me.cbxTue)
        Me.Controls.Add(Me.cbxMon)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.endSat)
        Me.Controls.Add(Me.startSat)
        Me.Controls.Add(Me.endFri)
        Me.Controls.Add(Me.startFri)
        Me.Controls.Add(Me.endThurs)
        Me.Controls.Add(Me.startThurs)
        Me.Controls.Add(Me.endWed)
        Me.Controls.Add(Me.startWed)
        Me.Controls.Add(Me.endTue)
        Me.Controls.Add(Me.startTue)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.endMon)
        Me.Controls.Add(Me.startMon)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ManageSections"
        Me.Text = "Manage Sections"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents startMon As System.Windows.Forms.DateTimePicker
    Friend WithEvents endMon As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents endTue As System.Windows.Forms.DateTimePicker
    Friend WithEvents startTue As System.Windows.Forms.DateTimePicker
    Friend WithEvents endWed As System.Windows.Forms.DateTimePicker
    Friend WithEvents startWed As System.Windows.Forms.DateTimePicker
    Friend WithEvents endThurs As System.Windows.Forms.DateTimePicker
    Friend WithEvents startThurs As System.Windows.Forms.DateTimePicker
    Friend WithEvents endFri As System.Windows.Forms.DateTimePicker
    Friend WithEvents startFri As System.Windows.Forms.DateTimePicker
    Friend WithEvents endSat As System.Windows.Forms.DateTimePicker
    Friend WithEvents startSat As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbxMon As System.Windows.Forms.CheckBox
    Friend WithEvents cbxTue As System.Windows.Forms.CheckBox
    Friend WithEvents cbxWed As System.Windows.Forms.CheckBox
    Friend WithEvents cbxThurs As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFri As System.Windows.Forms.CheckBox
    Friend WithEvents cbxSat As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSection As System.Windows.Forms.TextBox
End Class

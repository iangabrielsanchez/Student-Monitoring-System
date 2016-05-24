Imports System.Data.OleDb
Imports System.IO

Public Class ManageSections

    Private Sub ManageSections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim com As String = "SELECT [Section] FROM tblSections"
        runCommand(com)
    End Sub

    Private Sub runCommand(ByVal com As String)
        Try
            DataGridView1.Rows.Clear()
        Catch ex As Exception
        Finally
            Try
                Dim dbProvider As String
                Dim dbSource As String
                Dim database As String
                Dim fullDatabasePath As String
                Dim currentDirectory As String
                Dim dbcon As New OleDbConnection
                dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;"

                database = "\SYSDB.mdb"
                currentDirectory = Directory.GetCurrentDirectory()
                fullDatabasePath = Chr(34) & currentDirectory & database & Chr(34)
                dbSource = "Data Source = " & fullDatabasePath
                dbcon.ConnectionString = dbProvider & dbSource
                Dim Adpt As New OleDbDataAdapter(com, dbcon)
                Dim ds As New DataSet()
                Adpt.Fill(ds, "tblLogs")
                DataGridView1.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Try
    End Sub

    Private Sub cbxMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxMon.CheckedChanged
        If cbxMon.Checked Then
            startMon.Enabled = True
            endMon.Enabled = True
        Else
            startMon.Enabled = False
            endMon.Enabled = False
            startMon.Text = ""
            endMon.Text = ""
        End If
    End Sub

    Private Sub cbxTue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTue.CheckedChanged
        If cbxTue.Checked Then
            startTue.Enabled = True
            endTue.Enabled = True
        Else
            startTue.Enabled = False
            endTue.Enabled = False
            startTue.Text = ""
            endTue.Text = ""
        End If
    End Sub

    Private Sub cbxWed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxWed.CheckedChanged
        If cbxWed.Checked Then
            startWed.Enabled = True
            endWed.Enabled = True
        Else
            startWed.Enabled = False
            endWed.Enabled = False
            startWed.Text = ""
            endWed.Text = ""
        End If
    End Sub

    Private Sub cbxThurs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxThurs.CheckedChanged
        If cbxThurs.Checked Then
            startThurs.Enabled = True
            endThurs.Enabled = True
        Else
            startThurs.Enabled = False
            endThurs.Enabled = False
            startThurs.Text = ""
            endThurs.Text = ""
        End If
    End Sub

    Private Sub cbxFri_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxFri.CheckedChanged
        If cbxFri.Checked Then
            startFri.Enabled = True
            endFri.Enabled = True
        Else
            startFri.Enabled = False
            endFri.Enabled = False
            startFri.Text = ""
            endFri.Text = ""
        End If
    End Sub

    Private Sub cbxSat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSat.CheckedChanged
        If cbxSat.Checked Then
            startSat.Enabled = True
            endSat.Enabled = True
        Else
            startSat.Enabled = False
            endSat.Enabled = False
            startSat.Text = ""
            endSat.Text = ""
        End If
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        resetFields()
    End Sub

    Private Sub resetFields()
        txtSection.Text = Nothing
        cbxMon.Checked = False
        cbxTue.Checked = False
        cbxWed.Checked = False
        cbxThurs.Checked = False
        cbxFri.Checked = False
        txtSection.Focus()
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        deleteEntry()
    End Sub

    Private Sub deleteEntry()
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete entry? Deleting sections is not recommended", "Are you sure?", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            sysdb.query("DELETE FROM tblSections WHERE [Section] = '" & DataGridView1.SelectedCells(0).Value.ToString & "'")
        End If
        Dim com As String = "SELECT [Section] FROM tblSections"
        runCommand(com)
    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            deleteEntry()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtSection.Text = "" Then
            MsgBox("Section must have a value!")
            Exit Sub
        End If

        Dim count As Integer = 0
        Dim qr1 As String = "null,null,"
        Dim qr2 As String = "null,null,"
        Dim qr3 As String = "null,null,"
        Dim qr4 As String = "null,null,"
        Dim qr5 As String = "null,null,"
        Dim qr6 As String = "null,null"
        If cbxMon.Checked Then
            qr1 = "'" & startMon.Value.ToString("hh:mm tt") & "', '" & endMon.Value.ToString("hh:mm tt") & "',"
            count += 1
        End If
        If cbxTue.Checked Then
            qr2 = "'" & startTue.Value.ToString("hh:mm tt") & "', '" & endTue.Value.ToString("hh:mm tt") & "',"
            count += 1
        End If
        If cbxWed.Checked Then
            qr3 = "'" & startWed.Value.ToString("hh:mm tt") & "', '" & endWed.Value.ToString("hh:mm tt") & "',"
            count += 1
        End If
        If cbxThurs.Checked Then
            qr4 = "'" & startThurs.Value.ToString("hh:mm tt") & "', '" & endThurs.Value.ToString("hh:mm tt") & "',"
            count += 1
        End If
        If cbxFri.Checked Then
            qr5 = "'" & startFri.Value.ToString("hh:mm tt") & "', '" & endFri.Value.ToString("hh:mm tt") & "',"
            count += 1
        End If
        If cbxSat.Checked Then
            qr6 = "'" & startSat.Value.ToString("hh:mm tt") & "', '" & endSat.Value.ToString("hh:mm tt") & "'"
            count += 1
        End If
        If count = 0 Then
            MsgBox("No schedule to save!")
        Else
            sysdb.query("DELETE FROM tblSections WHERE [Section] = '" & txtSection.Text & "'")
            'MsgBox("INSERT INTO tblSections VALUES('" & txtSection.Text & "', " & qr1 & qr2 & qr3 & qr4 & qr5 & qr6 & ")")
            sysdb.query("INSERT INTO tblSections VALUES('" & txtSection.Text & "', " & qr1 & qr2 & qr3 & qr4 & qr5 & qr6 & ")")
            MsgBox("Section Saved!")
            Dim com As String = "SELECT [Section] FROM tblSections"
            runCommand(com)
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        txtSection.Text = DataGridView1.CurrentCell.Value.ToString
        'monday
        If sysdb.retrieveVariable("SELECT mon FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "mon") <> "" Then
            cbxMon.Checked = True
            startMon.Value = sysdb.retrieveVariable("SELECT mon FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "mon")
            endMon.Value = sysdb.retrieveVariable("SELECT emon FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "emon")
        Else
            cbxMon.Checked = False
        End If
        If sysdb.retrieveVariable("SELECT tue FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "tue") <> "" Then
            cbxTue.Checked = True
            startTue.Value = sysdb.retrieveVariable("SELECT tue FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "tue")
            endTue.Value = sysdb.retrieveVariable("SELECT etue FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "etue")
        Else
            cbxTue.Checked = False
        End If
        If sysdb.retrieveVariable("SELECT wed FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "wed") <> "" Then
            cbxWed.Checked = True
            startWed.Value = sysdb.retrieveVariable("SELECT wed FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "wed")
            endWed.Value = sysdb.retrieveVariable("SELECT ewed FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "ewed")
        Else
            cbxWed.Checked = False
        End If
        If sysdb.retrieveVariable("SELECT thurs FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "thurs") <> "" Then
            cbxThurs.Checked = True
            startThurs.Value = sysdb.retrieveVariable("SELECT thurs FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "thurs")
            endThurs.Value = sysdb.retrieveVariable("SELECT ethurs FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "ethurs")
        Else
            cbxThurs.Checked = False
        End If
        If sysdb.retrieveVariable("SELECT fri FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "fri") <> "" Then
            cbxFri.Checked = True
            startFri.Value = sysdb.retrieveVariable("SELECT fri FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "fri")
            endFri.Value = sysdb.retrieveVariable("SELECT efri FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "efri")
        Else
            cbxFri.Checked = False
        End If
        If sysdb.retrieveVariable("SELECT sat FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "sat") <> "" Then
            cbxSat.Checked = True
            startSat.Value = sysdb.retrieveVariable("SELECT sat FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "sat")
            endSat.Value = sysdb.retrieveVariable("SELECT esat FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "esat")
        Else
            cbxSat.Checked = False
        End If
    End Sub
End Class
Imports System.Data.OleDb
Imports System.IO
Imports System.ComponentModel

Public Class StudentSearch
    Private Shared dbcon As New OleDbConnection
    Private Sub StudentSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        loadtable()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        AddStudent.ShowDialog()
        AddStudent.Close()
        loadtable()
    End Sub

    
    Private Sub loadtable()
        Try
            DataGridView1.Rows.Clear()
        Catch ex As Exception
        Finally
            Dim dbProvider As String
            Dim dbSource As String
            Dim database As String
            Dim fullDatabasePath As String
            Dim currentDirectory As String
            Dim dbcon As New OleDbConnection
            dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;"

            database = "\SYSDB.mdb"
            currentDirectory = Directory.GetCurrentDirectory()

            'fullDatabasePath = Chr(34) & currentDirectory & "\Resources\" & database & Chr(34)
            fullDatabasePath = Chr(34) & currentDirectory & database & Chr(34)
            dbSource = "Data Source = " & fullDatabasePath
            dbcon.ConnectionString = dbProvider & dbSource

            Dim com As String = "SELECT studnum, fname, lname, course, sect, studstat FROM tblStudents"
            Dim Adpt As New OleDbDataAdapter(com, dbcon)
            Dim ds As New DataSet()
            Adpt.Fill(ds, "tblStudents")
            ds.Tables(0).Columns(0).ColumnName = "Student Number"
            ds.Tables(0).Columns(1).ColumnName = "First Name"
            ds.Tables(0).Columns(2).ColumnName = "Last Name"
            ds.Tables(0).Columns(3).ColumnName = "Course"
            ds.Tables(0).Columns(4).ColumnName = "Section"
            ds.Tables(0).Columns(5).ColumnName = "Student Status"
            DataGridView1.DataSource = ds.Tables(0)
            'DataGridView1.columns[0].
        End Try


    End Sub

    
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete entry?", "Are you sure?", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            deleteEntry()
        End If
        loadtable()
    End Sub

    Private Sub deleteEntry()
        sysdb.query("DELETE FROM tblStudents WHERE studnum = '" & DataGridView1.SelectedRows(0).Cells(0).Value.ToString & "'")
        sysdb.query("DELETE FROM tblSched WHERE studnum = '" & DataGridView1.SelectedRows(0).Cells(0).Value.ToString & "'")
        sysdb.query("DELETE FROM tblStudSched WHERE studnum = '" & DataGridView1.SelectedRows(0).Cells(0).Value.ToString & "'")
        sysdb.query("DELETE FROM tblStudStatus WHERE studnum = '" & DataGridView1.SelectedRows(0).Cells(0).Value.ToString & "'")
    End Sub

    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged
        Try
            DataGridView1.Rows.Clear()
        Catch ex As Exception
        Finally
            Dim dbProvider As String
            Dim dbSource As String
            Dim database As String
            Dim fullDatabasePath As String
            Dim currentDirectory As String
            Dim dbcon As New OleDbConnection
            dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;"

            database = "\SYSDB.mdb"
            currentDirectory = Directory.GetCurrentDirectory()

            'fullDatabasePath = Chr(34) & currentDirectory & "\Resources\" & database & Chr(34)
            fullDatabasePath = Chr(34) & currentDirectory & database & Chr(34)
            dbSource = "Data Source = " & fullDatabasePath
            dbcon.ConnectionString = dbProvider & dbSource

            Dim com As String = "SELECT fname, lname, studnum, course, sect, studstat FROM tblStudents WHERE ((fname LIKE '%" & txtSearch.Text & "%') OR (lname LIKE '%" & txtSearch.Text & "%') OR (studnum LIKE '%" & txtSearch.Text & "%') OR (course LIKE '%" & txtSearch.Text & "%') OR (sect LIKE '%" & txtSearch.Text & "%'))"
            Dim Adpt As New OleDbDataAdapter(com, dbcon)
            Dim ds As New DataSet()
            Adpt.Fill(ds, "tblStudents")
            ds.Tables(0).Columns(0).ColumnName = "Student Number"
            ds.Tables(0).Columns(1).ColumnName = "First Name"
            ds.Tables(0).Columns(2).ColumnName = "Last Name"
            ds.Tables(0).Columns(3).ColumnName = "Course"
            ds.Tables(0).Columns(4).ColumnName = "Section"
            ds.Tables(0).Columns(5).ColumnName = "Student Status"
            DataGridView1.DataSource = ds.Tables(0)
            'DataGridView1.columns[0].
        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            Button4.PerformClick()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        editprofile()
    End Sub

    Private Sub editprofile()
        Dim edit As New AddStudent
        edit.Text = "Edit Student Profile"
        edit.txtStudNum.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
        edit.txtFName.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
        edit.txtLName.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        edit.txtCourse.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
        edit.sect = DataGridView1.SelectedRows(0).Cells(4).Value.ToString
        edit.txtGuardian.Text = sysdb.retrieveVariable("SELECT [guardian] FROM tblStudents WHERE studnum = '" & edit.txtStudNum.Text & "'", "guardian")
        Dim imgName As String = sysdb.retrieveVariable("SELECT picloc FROM tblStudents WHERE studnum = '" & edit.txtStudNum.Text & "'", "picloc")

        'Dim newimg As New Bitmap(imgName)
        edit.picbox.SizeMode = PictureBoxSizeMode.Zoom
        'edit.picbox.Image = DirectCast(newimg, Image)
        edit.picbox.ImageLocation = imgName

        edit.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        editprofile()
    End Sub
End Class

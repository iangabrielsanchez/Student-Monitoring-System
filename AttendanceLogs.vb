Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc

Public Class AttendanceLogs

    Private Sub AttendanceLogs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        loadtable()
    End Sub

    Private Sub exportToExcel()
        Dim prog As New Exporting
        Try

            prog.Show()
            Dim progress = prog.ProgressBar1
            progress.Maximum = 9
            'verfying the datagridview having data or not
            progress.Increment(1)
            If ((DataGridView1.Columns.Count = 0) Or (DataGridView1.Rows.Count = 0)) Then
                progress.Increment(10)
                prog.Close()
                prog.Dispose()
                Exit Sub
            End If

            progress.Increment(1)
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView1.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView1.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    dr1(j) = DataGridView1.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next
            progress.Increment(1)
            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            progress.Increment(1)
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            progress.Increment(1)
            Dim dt As System.Data.DataTable = dset.Tables(0)
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            progress.Increment(1)
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(1, colIndex) = dc.ColumnName
            Next
            progress.Increment(1)
            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

                Next
            Next
            progress.Increment(1)
            wSheet.Columns.AutoFit()
            Dim currentDirectory As String = Directory.GetCurrentDirectory()
            Dim strFileName As String = currentDirectory & "\EXPORTED.xls"
            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try
            progress.Increment(1)
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            progress.Increment(1)
            wBook.SaveAs(strFileName)
            excel.Workbooks.Open(strFileName)
            excel.Visible = True
            prog.Close()
            prog.Dispose()
            MsgBox("EXPORTED TO " & vbCrLf & strFileName)
        Catch ex As Exception
            prog.Close()
            prog.Dispose()
            MsgBox("Export failed. Please close all opened excel files and try again.")
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        exportToExcel()
    End Sub

    Private Sub loadtable()
        Dim com As String = "SELECT studnum AS [STUDENT NUMBER], wholename AS [STUDENT NAME], eventdesc AS [EVENT DESCRIPTION], FORMAT(eventtime, 'SHORT DATE') AS [DATE], FORMAT(eventtime, 'SHORT TIME') AS [TIME] FROM tblLogs ORDER BY eventtime ASC"
        runCommand(com)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim com As String = "SELECT studnum AS [STUDENT NUMBER], wholename AS [STUDENT NAME], eventdesc AS [EVENT DESCRIPTION], FORMAT(eventtime, 'SHORT DATE') AS [DATE], FORMAT(eventtime, 'SHORT TIME') AS [TIME] FROM tblLogs WHERE ((wholename LIKE '%" & txtSearch.Text & "%') OR (studnum LIKE '%" & txtSearch.Text & "%'))"
        runCommand(com)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            DateTimePicker1.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            RadioButton3.Enabled = True
            RadioButton1.Checked = True
            ComboBox1.Enabled = True
            ComboBox1.SelectedIndex = 0
            loadfilters()

        ElseIf Not CheckBox1.Checked Then
            DateTimePicker1.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            ComboBox1.SelectedItem = Nothing
            ComboBox1.Enabled = False
            loadtable()
        End If
    End Sub
    Dim comprev As String = ""
    Private Sub loadfilters()

        'Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
        'Dim cal As Calendar = dfi.Calendar
        'MsgBox(sysdb.retrieveVariable("Select DatePart('ww',eventtime) FROM tblLogs where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "'", "DatePart('ww',eventtime)"))
        'MsgBox(cal.GetWeekOfYear(DateTimePicker1.Value.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday))
        Dim com As String = "SELECT studnum AS [STUDENT NUMBER], wholename AS [STUDENT NAME], eventdesc AS [EVENT DESCRIPTION], FORMAT(eventtime, 'SHORT DATE') AS [DATE], FORMAT(eventtime, 'SHORT TIME') AS [TIME] FROM tblLogs"
        If ComboBox1.Enabled Then
            If ComboBox1.SelectedIndex = 0 Then
                If RadioButton1.Checked Then
                    com = com & " where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "' ORDER BY eventtime ASC"
                ElseIf RadioButton2.Checked Then
                    com = com & " where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "' AND eventdesc = 'STUDENT LOGGED IN LATE' ORDER BY eventtime ASC"
                ElseIf RadioButton3.Checked Then
                    com = com & " where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "' AND eventdesc = 'STUDENT IS ABSENT' ORDER BY eventtime ASC"
                End If

            ElseIf ComboBox1.SelectedIndex = 1 Then
                If RadioButton1.Checked Then
                    com = com & " WHERE DATEPART('ww', eventtime) = DATEPART('ww', '" & DateTimePicker1.Value.Date.ToString & "') ORDER BY eventtime ASC"
                ElseIf RadioButton2.Checked Then
                    com = com & " WHERE DATEPART('ww', eventtime) = DATEPART('ww', '" & DateTimePicker1.Value.Date.ToString & "') AND eventdesc = 'STUDENT LOGGED IN LATE' ORDER BY eventtime ASC"
                ElseIf RadioButton3.Checked Then
                    com = com & " WHERE DATEPART('ww', eventtime) = DATEPART('ww', '" & DateTimePicker1.Value.Date.ToString & "') AND eventdesc = 'STUDENT IS ABSENT' ORDER BY eventtime ASC"
                End If

            ElseIf ComboBox1.SelectedIndex = 2 Then
                If RadioButton1.Checked Then
                    com = com & " WHERE MONTH(eventtime) = MONTH('" & DateTimePicker1.Value.Date.ToString & "') ORDER BY eventtime ASC"
                ElseIf RadioButton2.Checked Then
                    com = com & " WHERE MONTH(eventtime) = MONTH('" & DateTimePicker1.Value.Date.ToString & "') AND eventdesc = 'STUDENT LOGGED IN LATE' ORDER BY eventtime ASC"
                ElseIf RadioButton3.Checked Then
                    com = com & " WHERE MONTH(eventtime) = MONTH('" & DateTimePicker1.Value.Date.ToString & "') AND eventdesc = 'STUDENT IS ABSENT' ORDER BY eventtime ASC"
                End If

            Else
                loadtable()
            End If
        Else
            If RadioButton1.Checked Then
                com = com & " where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "' ORDER BY eventtime ASC"
            ElseIf RadioButton2.Checked Then
                com = com & " where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "' AND eventdesc = 'STUDENT LOGGED IN LATE' ORDER BY eventtime ASC"
            ElseIf RadioButton3.Checked Then
                com = com & " where FORMAT(eventtime,'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "' AND eventdesc = 'STUDENT LOGGED IN LATE' ORDER BY eventtime ASC"
            End If
        End If
        'If com <> comprev Then
        '    comprev = com
        '    runCommand(com)
        '    Exit Sub
        'End If
        runCommand(com)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If CheckBox1.Checked Then
            loadfilters()
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If CheckBox1.Checked Then
            loadfilters()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If CheckBox1.Checked Then
            loadfilters()
        End If
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

                'fullDatabasePath = Chr(34) & currentDirectory & "\Resources\" & database & Chr(34)
                fullDatabasePath = Chr(34) & currentDirectory & database & Chr(34)
                dbSource = "Data Source = " & fullDatabasePath
                dbcon.ConnectionString = dbProvider & dbSource
                'MsgBox(DateTimePicker1.Value.Date.ToString("d"))
                'MsgBox(sysdb.retrieveVariable("SELECT FORMAT(eventtime,'mm/dd/yyyy') FROM tblLogs", "eventtime"))
                Dim Adpt As New OleDbDataAdapter(com, dbcon)
                Dim ds As New DataSet()
                Adpt.Fill(ds, "tblLogs")
                ds.Tables(0).Columns(0).ColumnName = "STUDENT NUMBER"
                ds.Tables(0).Columns(1).ColumnName = "STUDENT NAME"
                ds.Tables(0).Columns(2).ColumnName = "EVENT DESCRIPTION"
                ds.Tables(0).Columns(3).ColumnName = "DATE"
                ds.Tables(0).Columns(4).ColumnName = "TIME"
                DataGridView1.DataSource = ds.Tables(0)
                'DataGridView1.columns[0].
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If CheckBox1.Checked Then
            loadfilters()
        End If
    End Sub
    Dim savepdf As New SaveFileDialog
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        savepdf.Filter = "PDF Files | *.pdf"
        savepdf.DefaultExt = "pdf"
        savepdf.ShowDialog()
        If savepdf.FileName = "" Then
            Exit Sub
        Else
            ExportDataToPDFTable()
            MsgBox("PDF Created Successfully")
        End If
    End Sub

    Private Function GetDataTable() As DataTable
        Dim dataTable As New DataTable("MyDataTable")
        'Create another DataColumn Name
        Dim dataColumn_1 As New DataColumn(DataGridView1.Columns(0).HeaderText.ToString(), GetType(String))
        dataTable.Columns.Add(dataColumn_1)
        Dim dataColumn_2 As New DataColumn(DataGridView1.Columns(1).HeaderText.ToString(), GetType(String))
        dataTable.Columns.Add(dataColumn_2)
        Dim dataColumn_3 As New DataColumn(DataGridView1.Columns(2).HeaderText.ToString(), GetType(String))
        dataTable.Columns.Add(dataColumn_3)
        Dim dataColumn_4 As New DataColumn(DataGridView1.Columns(3).HeaderText.ToString(), GetType(String))
        dataTable.Columns.Add(dataColumn_4)
        Dim dataColumn_5 As New DataColumn(DataGridView1.Columns(4).HeaderText.ToString(), GetType(String))
        dataTable.Columns.Add(dataColumn_5)
        'Now Add some row to newly created dataTable
        Dim dataRow As DataRow
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            dataRow = dataTable.NewRow()
            ' Important you have create New row
            dataRow(DataGridView1.Columns(0).HeaderText.ToString()) = DataGridView1.Rows(i).Cells(0).Value.ToString()
            dataRow(DataGridView1.Columns(1).HeaderText.ToString()) = DataGridView1.Rows(i).Cells(1).Value.ToString()
            dataRow(DataGridView1.Columns(2).HeaderText.ToString()) = DataGridView1.Rows(i).Cells(2).Value.ToString()
            dataRow(DataGridView1.Columns(3).HeaderText.ToString()) = DataGridView1.Rows(i).Cells(3).Value.ToString()
            dataRow(DataGridView1.Columns(4).HeaderText.ToString()) = DataGridView1.Rows(i).Cells(4).Value.ToString()

            dataTable.Rows.Add(dataRow)
        Next
        dataTable.AcceptChanges()
        Return dataTable
    End Function

    Private Sub ExportDataToPDFTable()
        Dim paragraph As New Paragraph
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 40, 40, 40, 10)
        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(savepdf.FileName, FileMode.Create))
        doc.Open()

        Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        Dim p1 As New Phrase
        p1 = New Phrase(New Chunk("Attendance Logs", font12BoldRed))
        doc.Add(p1)

        'Create instance of the pdf table and set the number of column in that table
        Dim PdfTable As New PdfPTable(5)
        PdfTable.TotalWidth = 490.0F
        'fix the absolute width of the table
        PdfTable.LockedWidth = True
        'relative col widths in proportions - 1,4,1,1 and 1
        Dim widths As Single() = New Single() {1.0F, 1.5F, 1.5F, 1.0F, 1.0F}
        PdfTable.SetWidths(widths)
        PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
        PdfTable.SpacingBefore = 1.0F

        'pdfCell Decleration
        Dim PdfPCell As PdfPCell = Nothing

        'Assigning values to each cell as phrases
        PdfPCell = New PdfPCell(New Phrase(New Chunk("STUDENT NO", font12Bold)))
        'Alignment of phrase in the pdfcell
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        'Add pdfcell in pdftable
        PdfTable.AddCell(PdfPCell)
        PdfPCell = New PdfPCell(New Phrase(New Chunk("STUDENT NAME", font12Bold)))
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        PdfTable.AddCell(PdfPCell)
        PdfPCell = New PdfPCell(New Phrase(New Chunk("EVENT DESCRIPTION", font12Bold)))
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        PdfTable.AddCell(PdfPCell)
        PdfPCell = New PdfPCell(New Phrase(New Chunk("DATE", font12Bold)))
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        PdfTable.AddCell(PdfPCell)
        PdfPCell = New PdfPCell(New Phrase(New Chunk("TIME", font12Bold)))
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        PdfTable.AddCell(PdfPCell)

        Dim dt As DataTable = GetDataTable()
        If dt IsNot Nothing Then
            'Now add the data from datatable to pdf table
            For rows As Integer = 0 To dt.Rows.Count - 1
                For column As Integer = 0 To dt.Columns.Count - 1
                    PdfPCell = New PdfPCell(New Phrase(dt.Rows(rows)(column).ToString(), font12Normal))
                    If column = 0 Or column = 1 Then
                        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                    Else
                        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                    End If
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            'Adding pdftable to the pdfdocument
            doc.Add(PdfTable)
        End If
        doc.Close()
    End Sub

End Class

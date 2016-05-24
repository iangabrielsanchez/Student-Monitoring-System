Public Class Form1
    Dim activePanel As String = ""

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        AbsentDetector.Start()
        AbsentChecker.Check()
        lblDT.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "  " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
        btnStdSearch.PerformClick()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblDT.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "  " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
    End Sub

    Private Sub pnlMenu_resetButtons()
        Dim defaultcolor = System.Drawing.ColorTranslator.FromHtml("#61BD58")
        btnStdSearch.BackColor = defaultcolor
        Button1.BackColor = defaultcolor
    End Sub

    Private Sub MainPanel_Reset()
        MainPanel.Controls.Clear()
        activePanel = ""
    End Sub

    Private Sub btnStdSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnStdSearch.Click

        pnlMenu_resetButtons()
        btnStdSearch.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F7B03")
        MainPanel_Reset()
        Dim stdsearch As New StudentSearch
        If Not activePanel.Equals("stdsearch") Then

            MainPanel.Controls.Add(stdsearch)
            activePanel = "stdsearch"
            stdsearch.Show()
        End If


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        pnlMenu_resetButtons()
        Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F7B03")
        MainPanel_Reset()
        Dim attlog As New AttendanceLogs
        If Not activePanel.Equals("attlog") Then
            MainPanel.Controls.Add(attlog)
            activePanel = "attlog"
            attlog.Show()
        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        StudentLogin.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnStdSearch.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            Button1.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            Button3.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub AbsentDetector_Tick(sender As System.Object, e As System.EventArgs) Handles AbsentDetector.Tick
        AbsentChecker.Check()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ManageSections.ShowDialog()
        ManageSections.Dispose()
    End Sub
End Class

Public Class Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sysdb.testConnection()
        Timer1.Start()
        lblDT.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "  " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblDT.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "  " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim username As String = txtUser.Text.ToLower
        Dim password As String = txtPass.Text
        
        If txtUser.Text <> "" Then


            If (sysdb.retrieveVariable("SELECT * FROM tblUsers WHERE username = '" & username & "'", "username") = username) Then
                If (sysdb.retrieveVariable("SELECT * FROM tblUsers WHERE username = '" & username & "'", "pass") = password) Then

                    Form1.Show()
                    Me.Close()
                Else
                    MsgBox("INVALID USERNAME OR PASSWORD")
                End If
            Else
                MsgBox("INVALID USERNAME OR PASSWORD")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        StudentLogin.Show()
        Me.Close()
    End Sub

    Private Sub Login_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Button2.PerformClick()
        End If
    End Sub
End Class
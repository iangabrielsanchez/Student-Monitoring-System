Public Class StudentLogin
    Dim counter As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        counter += 1
        lblDT.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "  " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
        If counter = 10 Then
            counter = 0
            clearArea()
        End If
    End Sub

    Private Sub StudentLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sysdb.testConnection()
        TextBox1.Select()
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        Timer1.Start()
        lblDT.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "  " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub clearArea()
        PictureBox2.Image = Nothing
        Label2.Text = Nothing
        Label3.Text = Nothing
        Label4.Text = Nothing
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        clearArea()
        Dim today As String = DateTime.Today.ToString("dddd").ToUpper
        'MsgBox(today)
        Try
            Dim studno As String = TextBox1.Text


            Dim stime As String = ""
            Dim etime As String = ""
            Dim section As String = sysdb.retrieveVariable("SELECT sect FROM tblStudents WHERE studnum = '" & studno & "'", "sect")
            Dim which As String = ""
            Dim ewhich As String = ""
            Select Case today
                Case "MONDAY"
                    which = "mon"
                    ewhich = "emon"
                Case "TUESDAY"
                    which = "tue"
                    ewhich = "etue"
                Case "WEDNESDAY"
                    which = "wed"
                    ewhich = "ewed"
                Case "THURSDAY"
                    which = "thurs"
                    ewhich = "ethurs"
                Case "FRIDAY"
                    which = "fri"
                    ewhich = "efri"
                Case "SATURDAY"
                    which = "sat"
                    ewhich = "esat"
            End Select

            If which <> "" Then
                stime = sysdb.retrieveVariable("SELECT format([" & which & "],'h:nn AM/PM') FROM tblSections WHERE [Section] = '" & section & "'", "Expr1000")
                etime = sysdb.retrieveVariable("SELECT format([" & ewhich & "],'h:nn AM/PM') FROM tblSections WHERE [Section] = '" & section & "'", "Expr1000")
            End If

            Dim studstat As String = sysdb.retrieveVariable("SELECT studstat FROM tblStudStatus WHERE studnum = '" & studno & "'", "studstat")
            Dim studname As String = sysdb.retrieveVariable("SELECT fname FROM tblStudents WHERE studnum = '" & studno & "'", "fname") & " " & sysdb.retrieveVariable("SELECT lname FROM tblStudents WHERE studnum = '" & studno & "'", "lname")
            Dim sect As String = sysdb.retrieveVariable("SELECT sect FROM tblStudents WHERE studnum = '" & studno & "'", "sect")
            Dim course As String = sysdb.retrieveVariable("SELECT course FROM tblStudents WHERE studnum = '" & studno & "'", "course")
            Dim picloc As String = sysdb.retrieveVariable("SELECT picloc FROM tblStudents WHERE studnum = '" & studno & "'", "picloc")
            Dim curtime As String = DateTime.Now.ToShortTimeString
            If (studstat = "IN") Then
                sysdb.query("UPDATE tblStudStatus SET studstat = 'OUT' WHERE studnum = '" & studno & "'")
                sysdb.query("UPDATE tblStudents SET studstat = 'OUT' WHERE studnum = '" & studno & "'")
                sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('STUDENT LOGGED OUT', '" & studname & "', '" & studno & "', '" & Date.Now & "')")
                Label2.Text = "SIGNED OUT - " & studname
                Label3.Text = sect
                Label4.Text = course
                PictureBox2.ImageLocation = picloc
                counter = 0
            ElseIf (studstat = "OUT") Then

                'if the student has class then true
                If Trim(stime) <> "" Then
                    'MsgBox("STIME IS " & stime & " and ETIME IS " & etime)
                    'if this is true, then class is not ended
                    'MsgBox(curtime & " and" & etime)
                    'MsgBox(DateTime.Compare(curtime, etime).ToString)
                    If (DateTime.Compare(curtime, etime) < 0) Then
                        'if true then late
                        If (DateTime.Compare(curtime, stime) > 0) Then
                            sysdb.query("UPDATE tblStudStatus SET studstat = 'IN' WHERE studnum = '" & studno & "'")
                            sysdb.query("UPDATE tblStudents SET studstat = 'IN CLASS - LATE' WHERE studnum = '" & studno & "'")
                            sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('STUDENT LOGGED IN LATE', '" & studname & "', '" & studno & "', '" & Date.Now & "')")
                            Label2.Text = "SIGNED IN LATE- " & studname
                            Label3.Text = sect
                            Label4.Text = course
                            PictureBox2.ImageLocation = picloc
                            counter = 0
                        Else
                            sysdb.query("UPDATE tblStudStatus SET studstat = 'IN' WHERE studnum = '" & studno & "'")
                            sysdb.query("UPDATE tblStudents SET studstat = 'IN CLASS' WHERE studnum = '" & studno & "'")
                            sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('STUDENT LOGGED IN', '" & studname & "', '" & studno & "', '" & Date.Now & "')")
                            Label2.Text = "SIGNED IN - " & studname
                            Label3.Text = sect
                            Label4.Text = course
                            PictureBox2.ImageLocation = picloc
                            counter = 0
                        End If
                    Else
                        sysdb.query("UPDATE tblStudStatus SET studstat = 'IN' WHERE studnum = '" & studno & "'")
                        sysdb.query("UPDATE tblStudents SET studstat = 'IN' WHERE studnum = '" & studno & "'")
                        sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('STUDENT LOGGED IN', '" & studname & "', '" & studno & "', '" & Date.Now & "')")
                        Label2.Text = "SIGNED IN - " & studname
                        Label3.Text = sect
                        Label4.Text = course
                        PictureBox2.ImageLocation = picloc
                        counter = 0
                    End If

                Else
                    sysdb.query("UPDATE tblStudStatus SET studstat = 'IN' WHERE studnum = '" & studno & "'")
                    sysdb.query("UPDATE tblStudents SET studstat = 'IN' WHERE studnum = '" & studno & "'")
                    sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('STUDENT LOGGED IN', '" & studname & "', '" & studno & "', '" & Date.Now & "')")
                    Label2.Text = "SIGNED IN - " & studname
                    Label3.Text = sect
                    Label4.Text = course
                    PictureBox2.ImageLocation = picloc
                    counter = 0
                End If

            Else
                Throw New ApplicationException("Exception Occured")
            End If

        Catch ex As Exception
            clearArea()
            Label2.Text = "UNKNOWN STUDENT!"
            Label3.Text = "STUDENT DOES NOT EXIST IN THE DATABASE!"
            'sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('UNKNOWN STUDENT LOGGED IN/OUT', 'UNKNOWN', '" & TextBox1.Text & "', '" & Date.Now & "')")
        End Try
        TextBox1.Text = ""
    End Sub

    Private Sub StudentLogin_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            Button3.PerformClick()
        End If
    End Sub
End Class
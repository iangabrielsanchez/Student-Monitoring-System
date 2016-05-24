Public Class AddStudent

    Public sect As String = ""
    Dim imgName As String
    Private Sub AddStudent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSection.Items.Clear()
        txtSection.Items.AddRange(sysdb.retrieveList("SELECT [SECTION] FROM tblSections", "[SECTION]"))
        If Me.Text = "Edit Student Profile" Then
            txtSection.SelectedItem = sect
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to cancel?", "Are you sure?", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim result As Integer = MessageBox.Show("Are you sure you that all data are accurate?", "Are you sure?", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            If Trim(txtFName.Text) = "" Then
                MsgBox("Please fill in all required fields")
            ElseIf Trim(txtLName.Text) = "" Then
                MsgBox("Please fill in all required fields")
            ElseIf Trim(txtStudNum.Text) = "" Then
                MsgBox("Please fill in all required fields")
            ElseIf Trim(txtCourse.Text) = "" Then
                MsgBox("Please fill in all required fields")
            ElseIf Trim(txtSection.Text) = "" Then
                MsgBox("Please fill in all required fields")
            ElseIf Trim(txtGuardian.Text) = "" Then
                MsgBox("Please fill in all required fields")
                'ElseIf Trim(imgName) = "" Then
                'MsgBox("Please fill in all required fields")
            Else
                Try
                    sysdb.query("DELETE FROM tblStudents WHERE studnum = '" & txtStudNum.Text & "'")
                    sysdb.query("DELETE FROM tblStudStatus WHERE studnum = '" & txtStudNum.Text & "'")
                    saveStudentInfo()
                    sysdb.query("INSERT INTO tblStudStatus (studnum, studstat) VALUES ('" & txtStudNum.Text & "' , " & "'OUT')")
                    MsgBox("Student Information Successfully Saved")
                    Me.Close()
                Catch ex As Exception
                End Try
            End If

        Else
        End If
    End Sub

    Private Sub saveStudentInfo()

        sysdb.query("INSERT INTO tblStudents (fname,lname,studnum,course,sect,guardian,picloc) VALUES ('" _
                       & txtFName.Text & "' , '" _
                       & txtLName.Text & "' , '" _
                       & txtStudNum.Text & "' , '" _
                       & txtCourse.Text & "' , '" _
                       & txtSection.Text & "' , '" _
                       & txtGuardian.Text & "' , '" _
                       & imgName & "')")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        browsepic()
    End Sub

    Private Sub browsepic()
        Try
            Dim dlgImage As FileDialog = New OpenFileDialog()

            dlgImage.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png"

            If dlgImage.ShowDialog() = DialogResult.OK Then
                imgName = dlgImage.FileName
                Dim newimg As New Bitmap(imgName)
                picbox.SizeMode = PictureBoxSizeMode.Zoom
                picbox.Image = DirectCast(newimg, Image)
            End If

            dlgImage = Nothing
        Catch ae As System.ArgumentException
            imgName = " "
            MessageBox.Show(ae.Message.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub cbxSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSection.SelectedIndexChanged
        loadSection(txtSection.SelectedItem)
    End Sub

    Private Sub loadSection(ByVal section As String)
        'monday
        If sysdb.retrieveVariable("SELECT mon FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "mon") <> "" Then
            startMon.Enabled = True
            endMon.Enabled = True
            startMon.Value = sysdb.retrieveVariable("SELECT mon FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "mon")
            endMon.Value = sysdb.retrieveVariable("SELECT emon FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "emon")
        Else
            startMon.Enabled = False
            endMon.Enabled = False
        End If
        If sysdb.retrieveVariable("SELECT tue FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "tue") <> "" Then
            startTue.Enabled = True
            endTue.Enabled = True
            startTue.Value = sysdb.retrieveVariable("SELECT tue FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "tue")
            endTue.Value = sysdb.retrieveVariable("SELECT etue FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "etue")
        Else
            startTue.Enabled = False
            endTue.Enabled = False
        End If
        If sysdb.retrieveVariable("SELECT wed FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "wed") <> "" Then
            startWed.Enabled = True
            endWed.Enabled = True
            startWed.Value = sysdb.retrieveVariable("SELECT wed FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "wed")
            endWed.Value = sysdb.retrieveVariable("SELECT ewed FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "ewed")
        Else
            startWed.Enabled = False
            endWed.Enabled = False
        End If
        If sysdb.retrieveVariable("SELECT thurs FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "thurs") <> "" Then
            startThurs.Enabled = True
            endThurs.Enabled = True
            startThurs.Value = sysdb.retrieveVariable("SELECT thurs FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "thurs")
            endThurs.Value = sysdb.retrieveVariable("SELECT ethurs FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "ethurs")
        Else
            startThurs.Enabled = False
            endThurs.Enabled = False
        End If
        If sysdb.retrieveVariable("SELECT fri FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "fri") <> "" Then
            startFri.Enabled = True
            endFri.Enabled = True
            startFri.Value = sysdb.retrieveVariable("SELECT fri FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "fri")
            endFri.Value = sysdb.retrieveVariable("SELECT efri FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "efri")
        Else
            startFri.Enabled = False
            endFri.Enabled = False
        End If
        If sysdb.retrieveVariable("SELECT sat FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "sat") <> "" Then
            startSat.Enabled = True
            endSat.Enabled = True
            startSat.Value = sysdb.retrieveVariable("SELECT sat FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "sat")
            endSat.Value = sysdb.retrieveVariable("SELECT esat FROM tblSections WHERE [Section] = '" & txtSection.Text & "'", "esat")
        Else
            startSat.Enabled = False
            endSat.Enabled = False
        End If
    End Sub

End Class
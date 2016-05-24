Public Class AbsentChecker

    Public Shared Sub Check()
        Dim today As String = DateTime.Today.ToString("dddd").ToUpper
        Dim curtime As String = DateTime.Now.ToString("t")
        ''convert(datetime, '20:10:44', 108)
        'MsgBox("SELECT studnum from tblStudSched WHERE day_ = '" & today & "' AND FORMAT(CAST(etime AS DATETIME),'hh:mm tt') < FORMAT(CAST('" & curtime & "' AS DATETIME),'hh:mm tt'), 'studnum'")
        'Dim absentlist As String() = sysdb.retrieveList("SELECT studnum from tblStudSched WHERE day_ = '" & today & "' AND FORMAT(CAST(etime AS DATETIME),'hh:mm tt') < FORMAT(CAST('" & curtime & "' AS DATETIME),'hh:mm tt')", "studnum")
        ''FORMAT(CAST(etime AS DATETIME),'hh:mm tt')
        'If absentlist(0) <> "null" Then
        '    For Each student In absentlist
        '        MsgBox(student)
        '    Next
        'End If

        'ALGORITHM FOR ABSENT CHECKING:
        '   >list all students
        '   >get student endtimes for today individually
        '   >check if that time is over
        '      >if not, then skip
        '      >if yes, then check if student is already listed as absent
        '           >if yes, then skip
        '           >if not, then list
        '
        '   NOTES: 
        '       >This algorithm might not be very efficient, but it should do the job
        '       >By default, it should check absent students every 5 minutes(300000 interval) and on startup
        '           >it can be changed by changing Form1.AbsentDetector.Interval


        'list all student numbers
        Dim studentslist As String() = sysdb.retrieveList("SELECT studnum from tblStudents", "studnum")

        'declare a new array where studentslist.index is associated with studenttimes(studentslist.index)
        Dim studenttimes(studentslist.Length) As String

        'populate studenttimes
        For student As Integer = 0 To studentslist.Length - 1

            studenttimes(student) = sysdb.retrieveVariable("SELECT etime FROM tblStudSched WHERE studnum = '" & studentslist(student) & "' AND day_ = '" & today & "'", "etime")

        Next

        'now compare times individually
        'DateTime.Compare(timeend, timeslist2(time)) > 0
        For index As Integer = 0 To studentslist.Length - 1

            'if sched today is not empty, then check schedule if ended
            If Not (studenttimes(index) = "") Then

                'check schedule if ended
                If (DateTime.Compare(studenttimes(index), curtime) < 0) Then

                    
                    'check if NOT listed as absent
                    If ((sysdb.retrieveVariable("SELECT eventdesc FROM tblLogs WHERE studnum = '" & studentslist(index) & "' AND WEEKDAY(eventtime) = WEEKDAY('" & DateTime.Today.ToString & "')", "eventdesc") = "")) Then
                        MsgBox("line 60")

                        Dim studname As String = sysdb.retrieveVariable("SELECT fname FROM tblStudents WHERE studnum = '" & studentslist(index) & "'", "fname") & " " & sysdb.retrieveVariable("SELECT lname FROM tblStudents WHERE studnum = '" & studentslist(index) & "'", "lname")

                        sysdb.query("INSERT INTO tblLogs (eventdesc, wholename, studnum, eventtime) VALUES ('STUDENT IS ABSENT', '" & studname & "', '" & studentslist(index) & "', '" & Date.Now & "')")

                    End If
                End If

            End If

        Next

    End Sub
End Class

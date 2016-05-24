Imports System.Data.OleDb
Imports System.IO

Public Class sysdb
    Private Shared dbcon As New OleDbConnection
    Private Shared Sub connect()
        Dim dbProvider As String
        Dim dbSource As String
        Dim database As String
        Dim fullDatabasePath As String
        Dim currentDirectory As String

        dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;"

        database = "\SYSDB.mdb"
        currentDirectory = Directory.GetCurrentDirectory()

        'fullDatabasePath = Chr(34) & currentDirectory & "\Resources\" & database & Chr(34)
        fullDatabasePath = Chr(34) & currentDirectory & database & Chr(34)
        dbSource = "Data Source = " & fullDatabasePath

        dbcon.ConnectionString = dbProvider & dbSource
    End Sub

    Public Shared Function testConnection() As Boolean
        Try
            connect()
            dbcon.Open()
            Console.WriteLine("Connection Successful")
            dbcon.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error, cannot connect to database" & ex.ToString)
            Application.Exit()
            Return False
        End Try
    End Function

    Shared Function query(ByVal sql As String) As Boolean
        Dim com As New OleDbCommand(sql, dbcon)
        Try
            dbcon.Open()
            com.ExecuteNonQuery()
            com.Dispose()
            dbcon.Close()
        Catch ex As Exception
            dbcon.Close()

            MsgBox("Something went wrong in dbfunc, Enter Query" & ex.ToString)
            Return False
        End Try
        Return True
    End Function

    Shared Function retrieveVariable(ByVal sql As String, ByVal row As String) As String
        Dim cmd As New OleDbCommand(sql, dbcon)
        Dim var As String = ""
        Try
            dbcon.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                While reader.Read
                    var = reader(row).ToString
                End While
            End Using
            dbcon.Close()
        Catch ex As Exception
            dbcon.Close()
            MsgBox("Something went wrong in dbfunc, Retrieve Record" & ex.ToString)
            Return "You're not supposed to see this"
        End Try
        Return var
    End Function

    Shared Function retrieveList(ByVal sql As String, ByVal row As String) As String()
        Dim cmd As New OleDbCommand(sql, dbcon)
        Dim var As String = ""
        Dim strList As String() = {"null"}

        Try
            dbcon.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                Dim ctr As Integer = 0
                While reader.Read

                    var = reader.GetString(0)
                    strList(ctr) = var
                    ctr = ctr + 1
                    ReDim Preserve strList(ctr)
                End While
                ReDim Preserve strList(ctr - 1)
            End Using
            dbcon.Close()
        Catch ex As Exception
            dbcon.Close()
            MsgBox("Something went wrong in dbfunc, Retrieve Record" & ex.ToString)
            Return strList
        End Try
        Return strList
    End Function
End Class

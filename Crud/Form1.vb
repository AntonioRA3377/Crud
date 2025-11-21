
Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        conn = New MySqlConnection
        conn.ConnectionString = " server=localhost; userid=root; password=root; database= crud_demo_db"

        Try
            conn.Open()
            MessageBox.Show("Connected")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub ButtonInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim query As String = "INSERT INTO student_tbl (name, age, email) VALUES (@name, @age ,@email)"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database= crud_demo_db")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show(" Record Insert Succesfully ")
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        Dim query As String = "SELECT * FROM crud_demo_db.student_tbl;"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database= crud_demo_db")
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table) 'FROM
                MySqlData.DataSource = table 'Display to DATAGRIDVIEW
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

